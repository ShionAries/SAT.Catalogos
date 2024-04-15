using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Contracts {
    public interface IPeriodicidadCatalogo : IGenericCatalogo<ClavePeriodicidad> {
        ClavePeriodicidad Search(string findId);
    }
}
