using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Jaeger.SAT.Catalogos.Helpers;
using Jaeger.SAT.Catalogos.Scraping.Entities;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;

namespace Jaeger.SAT.Catalogos.Scraping.Helpers {
    public class Resources2Gateway : IResourcesGateway {
        private readonly HttpClient _httpClient;
        protected internal string sessionCookie;

        public Resources2Gateway(HttpClient httpClient = null) {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

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

        /// <summary>
        /// Obtiene encabezados HTTP mediante petición HEAD sincrónica.
        /// </summary>
        public UrlResponse Headers(string url) {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException("La URL no puede estar vacía.", nameof(url));

            using (HttpRequestMessage request = CreateRequest(HttpMethod.Head, url))
            using (HttpResponseMessage response = _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).GetAwaiter().GetResult()) {
                return MapToUrlResponse(response, url);
            }
        }

        /// <summary>
        /// Descarga un recurso GET y lo guarda en disco sincrónicamente en bloques de memoria para evitar alto consumo de RAM.
        /// </summary>
        public UrlResponse Get(string url, string destinationPath) {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException("La URL no puede estar vacía.", nameof(url));

            using (HttpRequestMessage request = CreateRequest(HttpMethod.Get, url)) {
                try {
                    using (HttpResponseMessage response = _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).GetAwaiter().GetResult()) {
                        if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(destinationPath)) {
                            bool fileSaved = SaveStreamToDiskSync(response, destinationPath);
                            if (!fileSaved) {
                                LogInfoService.Log("No se pudo escribir el archivo en disco.", destinationPath);
                            }
                        }

                        return MapToUrlResponse(response, destinationPath);
                    }
                } catch (Exception ex) {
                    LogInfoService.Log($"Error en GET '{url}': {ex.Message}", ex.StackTrace);
                    throw;
                }
            }
        }

        #endregion

        #region Métodos Asincrónicos Nativo

        /// <summary>
        /// Obtiene encabezados HTTP mediante petición HEAD asincrónica.
        /// </summary>
        public async Task<UrlResponse> HeadersAsync(string url) {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException("La URL no puede estar vacía.", nameof(url));

            using (HttpRequestMessage request = CreateRequest(HttpMethod.Head, url))
            using (HttpResponseMessage response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false)) {
                return MapToUrlResponse(response, url);
            }
        }

        /// <summary>
        /// Descarga un recurso GET y lo guarda en disco de forma asincrónica.
        /// </summary>
        public async Task<UrlResponse> GetAsync(string url, string destinationPath) {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException("La URL no puede estar vacía.", nameof(url));

            using (HttpRequestMessage request = CreateRequest(HttpMethod.Get, url)) {
                try {
                    using (HttpResponseMessage response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false)) {
                        if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(destinationPath)) {
                            bool fileSaved = await SaveStreamToDiskAsync(response, destinationPath).ConfigureAwait(false);
                            if (!fileSaved) {
                                LogInfoService.Log("No se pudo escribir el archivo en disco.", destinationPath);
                            }
                        }

                        return MapToUrlResponse(response, destinationPath);
                    }
                } catch (Exception ex) {
                    LogInfoService.Log($"Error en GET Async '{url}': {ex.Message}", ex.StackTrace);
                    throw;
                }
            }
        }

        #endregion

        #region Métodos Privados de Apoyo

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

        private bool SaveStreamToDiskSync(HttpResponseMessage response, string destinationPath) {
            try {
                EnsureDirectoryExists(destinationPath);

                using (Stream contentStream = response.Content.ReadAsStreamAsync().GetAwaiter().GetResult())
                using (FileStream fileStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize: 8192, useAsync: false)) {
                    contentStream.CopyTo(fileStream);
                }

                return true;
            } catch (Exception ex) {
                LogInfoService.Log($"Error de escritura en disco '{destinationPath}': {ex.Message}", ex.StackTrace);
                return false;
            }
        }

        private async Task<bool> SaveStreamToDiskAsync(HttpResponseMessage response, string destinationPath) {
            try {
                EnsureDirectoryExists(destinationPath);

                using (Stream contentStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                using (FileStream fileStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize: 8192, useAsync: true)) {
                    await contentStream.CopyToAsync(fileStream).ConfigureAwait(false);
                }

                return true;
            } catch (Exception ex) {
                LogInfoService.Log($"Error de escritura en disco '{destinationPath}': {ex.Message}", ex.StackTrace);
                return false;
            }
        }

        private void EnsureDirectoryExists(string filePath) {
            string directory = Path.GetDirectoryName(filePath);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory)) {
                Directory.CreateDirectory(directory);
            }
        }

        private UrlResponse MapToUrlResponse(HttpResponseMessage response, string targetUrl) {
            UrlResponse urlResponse = new UrlResponse {
                LastModified = null,
                Url = targetUrl,
                HttpStatus = (int)response.StatusCode
            };
            urlResponse.LastModified = response.Content.Headers.LastModified?.UtcDateTime;
            var DataStream = new MemoryStream();
            //response.GetResponseStream().CopyTo((Stream)DataStream);
            //var enconder = DetectEncodingWithBOM(DataStream as MemoryStream);
            //// para el caso de que no venga especificado el charset
            //if (enconder == null) {
            //    var DataReader = new StreamReader((Stream)DataStream, Encoding.UTF8);
            //    DataStream.Position = 0;
            //    urlResponse.Body = DataReader.ReadToEnd();
            //} else {
            //    var DataReader = new StreamReader((Stream)DataStream, enconder);
            //    DataStream.Position = 0;
            //    urlResponse._Body = DataReader.ReadToEnd();
            //}
            return urlResponse;
        }

        #endregion
    }
}