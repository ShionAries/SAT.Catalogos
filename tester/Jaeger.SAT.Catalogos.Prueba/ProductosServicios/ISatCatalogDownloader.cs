using System.Threading;
using System.Threading.Tasks;

namespace Jaeger.SAT.Catalogos.Prueba.ProductosServicios {
    public interface ISatCatalogDownloader {
        Task<string> DownloadAsync(
            string destinationPath,
            CancellationToken cancellationToken);
    }
}