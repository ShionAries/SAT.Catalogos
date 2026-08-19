using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Jaeger.SAT.Catalogos.Prueba.ProductosServicios {
    public interface ISatCatalogService {
        Task<IReadOnlyList<SatProductoServicio>> BuscarAsync(
            string texto,
            CancellationToken cancellationToken);

        Task ActualizarAsync(
            string destinationPath,
            CancellationToken cancellationToken);
    }
}