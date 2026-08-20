using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Jaeger.SAT.Catalogos.Helpers;
using Jaeger.SAT.Catalogos.Scraping.Entities;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;

namespace Jaeger.SAT.Catalogos.Scraping.Helpers {
    public class Resources2Gateway : IResourcesGateway {
        private readonly HttpClient _httpClient;
        protected internal string sessionCookie;

        public Resources2Gateway(HttpClient httpClient = null) {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            if (httpClient != null) {
                _httpClient = httpClient;
            } else {
                HttpClientHandler handler = new HttpClientHandler {
                    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
                    AllowAutoRedirect = true
                };

                _httpClient = new HttpClient(handler);
                ConfigureDefaultHeaders(_httpClient);
            }
        }

        #region Métodos Sincrónicos Nativo

        public UrlResponse Headers(string url) {
            url = NormalizeUrl(url);

            using (HttpRequestMessage request = CreateRequest(HttpMethod.Head, url))
            using (HttpResponseMessage response = _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).GetAwaiter().GetResult()) {
                using (MemoryStream memoryStream = ReadResponseToMemoryStreamSync(response)) {
                    return MapToUrlResponseFromStream(response, url, memoryStream);
                }
            }
        }

        public UrlResponse Get(string url, string destinationPath) {
            url = NormalizeUrl(url);

            using (HttpRequestMessage request = CreateRequest(HttpMethod.Get, url)) {
                try {
                    using (HttpResponseMessage response = _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).GetAwaiter().GetResult()) {
                        using (MemoryStream memoryStream = ReadResponseToMemoryStreamSync(response)) {
                            if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(destinationPath)) {
                                bool fileSaved = SaveMemoryStreamToDiskSync(memoryStream, destinationPath);
                                if (!fileSaved) {
                                    LogInfoService.Log("No se pudo escribir el archivo en disco.", destinationPath);
                                }
                            }

                            return MapToUrlResponseFromStream(response, url, memoryStream);
                        }
                    }
                } catch (Exception ex) {
                    LogInfoService.Log($"Error en GET '{url}': {ex.Message}", ex.StackTrace);
                    throw;
                }
            }
        }

        /// <summary>
        /// Descarga sincrónica para archivos grandes directamente a disco con soporte de reanudación y progreso.
        /// </summary>
        public bool DownloadLargeFile(string url, string destinationPath, IProgress<LargeFileDownloadProgress> progress = null) {
            return Task.Run(() => DownloadLargeFileAsync(url, destinationPath, progress, CancellationToken.None)).GetAwaiter().GetResult();
        }

        #endregion

        #region Métodos Asincrónicos Nativo

        public async Task<UrlResponse> HeadersAsync(string url) {
            url = NormalizeUrl(url);

            using (HttpRequestMessage request = CreateRequest(HttpMethod.Head, url))
            using (HttpResponseMessage response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false)) {
                using (MemoryStream memoryStream = await ReadResponseToMemoryStreamAsync(response).ConfigureAwait(false)) {
                    return MapToUrlResponseFromStream(response, url, memoryStream);
                }
            }
        }

        public async Task<UrlResponse> GetAsync(string url, string destinationPath) {
            url = NormalizeUrl(url);

            using (HttpRequestMessage request = CreateRequest(HttpMethod.Get, url)) {
                try {
                    using (HttpResponseMessage response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false)) {
                        using (MemoryStream memoryStream = await ReadResponseToMemoryStreamAsync(response).ConfigureAwait(false)) {
                            if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(destinationPath)) {
                                bool fileSaved = await SaveMemoryStreamToDiskAsync(memoryStream, destinationPath).ConfigureAwait(false);
                                if (!fileSaved) {
                                    LogInfoService.Log("No se pudo escribir el archivo en disco.", destinationPath);
                                }
                            }

                            return MapToUrlResponseFromStream(response, url, memoryStream);
                        }
                    }
                } catch (Exception ex) {
                    LogInfoService.Log($"Error en GET Async '{url}': {ex.Message}", ex.StackTrace);
                    throw;
                }
            }
        }

        /// <summary>
        /// Descarga asincrónica optimizada para archivos grandes mediante transmisión continua (streaming) a disco.
        /// Evita desbordamientos de memoria RAM y soporta reanudación vía HTTP Range.
        /// </summary>
        public async Task<bool> DownloadLargeFileAsync(string url, string destinationPath, IProgress<LargeFileDownloadProgress> progress = null, CancellationToken cancellationToken = default) {
            url = NormalizeUrl(url);
            EnsureDirectoryExists(destinationPath);

            long existingFileLength = 0;
            FileInfo fileInfo = new FileInfo(destinationPath);

            if (fileInfo.Exists) {
                existingFileLength = fileInfo.Length;
            }

            using (HttpRequestMessage request = CreateRequest(HttpMethod.Get, url)) {
                if (existingFileLength > 0) {
                    request.Headers.Range = new RangeHeaderValue(existingFileLength, null);
                }

                try {
                    using (HttpResponseMessage response = await _httpClient.SendAsync(
                        request,
                        HttpCompletionOption.ResponseHeadersRead,
                        cancellationToken).ConfigureAwait(false)) {
                        if (!response.IsSuccessStatusCode && response.StatusCode != HttpStatusCode.PartialContent) {
                            LogInfoService.Log($"Error HTTP {response.StatusCode} al descargar {url}", null);
                            return false;
                        }

                        long? totalBytes = response.Content.Headers.ContentLength;
                        if (response.StatusCode == HttpStatusCode.PartialContent && totalBytes.HasValue) {
                            totalBytes += existingFileLength;
                        }

                        FileMode fileMode = (response.StatusCode == HttpStatusCode.PartialContent)
                            ? FileMode.Append
                            : FileMode.Create;

                        using (Stream networkStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                        using (FileStream fileStream = new FileStream(
                            destinationPath,
                            fileMode,
                            FileAccess.Write,
                            FileShare.None,
                            bufferSize: 81920,
                            useAsync: true)) {
                            byte[] buffer = new byte[81920];
                            long totalBytesDownloaded = existingFileLength;
                            int bytesRead;

                            while ((bytesRead = await networkStream.ReadAsync(buffer, 0, buffer.Length, cancellationToken).ConfigureAwait(false)) > 0) {
                                await fileStream.WriteAsync(buffer, 0, bytesRead, cancellationToken).ConfigureAwait(false);

                                totalBytesDownloaded += bytesRead;

                                progress?.Report(new LargeFileDownloadProgress {
                                    BytesDownloaded = totalBytesDownloaded,
                                    TotalBytes = totalBytes
                                });
                            }
                        }

                        return true;
                    }
                } catch (Exception ex) {
                    LogInfoService.Log($"Error en descarga masiva '{url}': {ex.Message}", ex.StackTrace);
                    throw;
                }
            }
        }

        #endregion

        #region Procesamiento de Streams y Mapeo de Respuesta

        private MemoryStream ReadResponseToMemoryStreamSync(HttpResponseMessage response) {
            MemoryStream memoryStream = new MemoryStream();
            if (response.Content != null) {
                using (Stream networkStream = response.Content.ReadAsStreamAsync().GetAwaiter().GetResult()) {
                    networkStream.CopyTo(memoryStream);
                }
            }
            return memoryStream;
        }

        private async Task<MemoryStream> ReadResponseToMemoryStreamAsync(HttpResponseMessage response) {
            MemoryStream memoryStream = new MemoryStream();
            if (response.Content != null) {
                using (Stream networkStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false)) {
                    await networkStream.CopyToAsync(memoryStream).ConfigureAwait(false);
                }
            }
            return memoryStream;
        }

        private bool SaveMemoryStreamToDiskSync(MemoryStream memoryStream, string destinationPath) {
            try {
                EnsureDirectoryExists(destinationPath);
                memoryStream.Position = 0;

                using (FileStream fileStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write, FileShare.None, 8192, false)) {
                    memoryStream.CopyTo(fileStream);
                }
                return true;
            } catch (Exception ex) {
                LogInfoService.Log($"Error de escritura en disco '{destinationPath}': {ex.Message}", ex.StackTrace);
                return false;
            }
        }

        private async Task<bool> SaveMemoryStreamToDiskAsync(MemoryStream memoryStream, string destinationPath) {
            try {
                EnsureDirectoryExists(destinationPath);
                memoryStream.Position = 0;

                using (FileStream fileStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true)) {
                    await memoryStream.CopyToAsync(fileStream).ConfigureAwait(false);
                }
                return true;
            } catch (Exception ex) {
                LogInfoService.Log($"Error de escritura en disco '{destinationPath}': {ex.Message}", ex.StackTrace);
                return false;
            }
        }

        private UrlResponse MapToUrlResponseFromStream(HttpResponseMessage response, string url, MemoryStream dataStream) {
            UrlResponse urlResponse = new UrlResponse();
            urlResponse.Url = url;
            urlResponse.HttpStatus = (int)response.StatusCode;
            urlResponse.LastModified = response.Content?.Headers?.LastModified?.DateTime;

            if (dataStream != null && dataStream.Length > 0) {
                PopulateBodyFromStream(urlResponse, dataStream);
            }

            return urlResponse;
        }

        private void PopulateBodyFromStream(UrlResponse urlResponse, MemoryStream dataStream) {
            dataStream.Position = 0;
            Encoding encoder = DetectEncodingWithBOM(dataStream);

            dataStream.Position = 0;
            using (StreamReader dataReader = new StreamReader(
                stream: dataStream,
                encoding: encoder ?? Encoding.UTF8,
                detectEncodingFromByteOrderMarks: false,
                bufferSize: 1024,
                leaveOpen: true)) {
                urlResponse.Body = dataReader.ReadToEnd();
            }
        }

        private Encoding DetectEncodingWithBOM(MemoryStream dataStream) {
            if (dataStream == null || dataStream.Length < 2)
                return null;

            byte[] buffer = dataStream.ToArray();

            if (buffer.Length >= 3 && buffer[0] == 0xEF && buffer[1] == 0xBB && buffer[2] == 0xBF)
                return Encoding.UTF8;

            if (buffer.Length >= 2 && buffer[0] == 0xFF && buffer[1] == 0xFE)
                return Encoding.Unicode;

            if (buffer.Length >= 2 && buffer[0] == 0xFE && buffer[1] == 0xFF)
                return Encoding.BigEndianUnicode;

            if (buffer.Length >= 4 && buffer[0] == 0x00 && buffer[1] == 0x00 && buffer[2] == 0xFE && buffer[3] == 0xFF)
                return Encoding.UTF32;

            return null;
        }

        #endregion

        #region Métodos Privados Auxiliares

        private string NormalizeUrl(string url) {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException("La URL no puede estar vacía.", nameof(url));

            string trimmedUrl = url.Trim();

            if (!trimmedUrl.StartsWith("http://", StringComparison.OrdinalIgnoreCase) &&
                !trimmedUrl.StartsWith("https://", StringComparison.OrdinalIgnoreCase)) {
                trimmedUrl = "http://" + trimmedUrl;
            }

            return trimmedUrl;
        }

        private HttpRequestMessage CreateRequest(HttpMethod method, string url) {
            HttpRequestMessage request = new HttpRequestMessage(method, url);

            if (!string.IsNullOrWhiteSpace(sessionCookie)) {
                request.Headers.TryAddWithoutValidation("Cookie", sessionCookie);
            }

            return request;
        }

        private void ConfigureDefaultHeaders(HttpClient client) {
            client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36");
            client.DefaultRequestHeaders.Accept.ParseAdd("text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Language", "es-MX,es;q=0.8,en-US;q=0.5,en;q=0.3");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Upgrade-Insecure-Requests", "1");
        }

        private void EnsureDirectoryExists(string filePath) {
            string directory = Path.GetDirectoryName(filePath);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory)) {
                Directory.CreateDirectory(directory);
            }
        }

        #endregion
    }
}