using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Jaeger.SAT.Catalogos.Prueba.ProductosServicios {
    public sealed class SatCatalogDownloader : ISatCatalogDownloader {
        private readonly HttpClient _httpClient;
        private readonly string _catalogUrl;

        public SatCatalogDownloader(
            HttpClient httpClient,
            string catalogUrl) {
            if (httpClient == null)
                throw new ArgumentNullException(nameof(httpClient));

            if (string.IsNullOrWhiteSpace(catalogUrl))
                throw new ArgumentException(
                    "Debe especificar la URL del catálogo.",
                    nameof(catalogUrl));

            _httpClient = httpClient;
            _catalogUrl = catalogUrl;
        }

        public async Task<string> DownloadAsync(
            string destinationPath,
            CancellationToken cancellationToken) {
            if (string.IsNullOrWhiteSpace(destinationPath))
                throw new ArgumentException(
                    "Debe especificar el archivo destino.",
                    nameof(destinationPath));

            string fullPath =
                Path.GetFullPath(destinationPath);

            string directory =
                Path.GetDirectoryName(fullPath);

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            try {
                using (HttpResponseMessage response =
                    await _httpClient.GetAsync(
                        _catalogUrl,
                        HttpCompletionOption.ResponseHeadersRead,
                        cancellationToken)
                    .ConfigureAwait(false)) {
                    response.EnsureSuccessStatusCode();

                    using (Stream input =
                        await response.Content.ReadAsStreamAsync()
                            .ConfigureAwait(false))
                    using (FileStream output =
                        new FileStream(
                            fullPath,
                            FileMode.Create,
                            FileAccess.Write,
                            FileShare.None)) {
                        await input.CopyToAsync(
                            output,
                            81920,
                            cancellationToken)
                            .ConfigureAwait(false);
                    }
                }

                return fullPath;
            } catch (HttpRequestException ex) {
                throw new InvalidOperationException(
                    "Error HTTP descargando el catálogo del SAT.",
                    ex);
            } catch (TaskCanceledException ex) {
                throw new InvalidOperationException(
                    "La descarga del catálogo del SAT fue cancelada.",
                    ex);
            } catch (IOException ex) {
                throw new InvalidOperationException(
                    "Error guardando el catálogo del SAT.",
                    ex);
            }
        }
    }
}