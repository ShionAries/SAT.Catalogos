using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Contracts {
    public interface IPaisesCatalogo : IGenericCatalogo<ClavePais> {
        ClavePais Search(string findId);
    }
}
