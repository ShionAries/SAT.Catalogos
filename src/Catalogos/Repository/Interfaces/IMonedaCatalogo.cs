using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Contracts {
    public interface IMonedaCatalogo : IGenericCatalogo<ClaveMoneda> {
        ClaveMoneda Search(string findId);
    }
}
