using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Contracts {
    public interface IMetodoPagoCatalogo : IGenericCatalogo<ClaveMetodoPago> {
        ClaveMetodoPago Search(string findId);
    }
}
