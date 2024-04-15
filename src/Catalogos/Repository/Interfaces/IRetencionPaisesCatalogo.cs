using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Contracts {
    public interface IRetencionPaisesCatalogo : IGenericCatalogo<ClaveRetencionPais> {

        ClaveRetencionPais Search(string findId);
    }
}
