using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Jaeger.SAT.Catalogos.Prueba.ProductosServicios {
    public sealed class SatCatalogService : ISatCatalogService {
        private readonly ISatCatalogDownloader _downloader;
        private readonly SatCatalogParser _parser;

        private IReadOnlyList<SatProductoServicio> _catalog;

        public SatCatalogService(
            ISatCatalogDownloader downloader,
            SatCatalogParser parser) {
            if (downloader == null)
                throw new ArgumentNullException(nameof(downloader));

            if (parser == null)
                throw new ArgumentNullException(nameof(parser));

            _downloader = downloader;
            _parser = parser;
        }

        public async Task ActualizarAsync(
            string destinationPath,
            CancellationToken cancellationToken) {
            string file =
                await _downloader.DownloadAsync(
                    destinationPath,
                    cancellationToken)
                .ConfigureAwait(false);

            _catalog = _parser.Parse(file);
        }

        public Task<IReadOnlyList<SatProductoServicio>> BuscarAsync(
            string texto,
            CancellationToken cancellationToken) {
            if (string.IsNullOrWhiteSpace(texto)) {
                return Task.FromResult<
                    IReadOnlyList<SatProductoServicio>>(
                    new List<SatProductoServicio>());
            }

            if (_catalog == null) {
                throw new InvalidOperationException(
                    "El catálogo no ha sido cargado.");
            }

            cancellationToken.ThrowIfCancellationRequested();

            string search =
                texto.Trim();

            IReadOnlyList<SatProductoServicio> result =
                _catalog
                    .Where(x =>
                        x.ClaveProdServ.IndexOf(
                            search,
                            StringComparison.OrdinalIgnoreCase) >= 0
                        ||
                        x.Descripcion.IndexOf(
                            search,
                            StringComparison.OrdinalIgnoreCase) >= 0)
                    .ToList();

            return Task.FromResult(result);
        }
    }
}