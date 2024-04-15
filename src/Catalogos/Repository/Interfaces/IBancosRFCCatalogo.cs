using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Contracts {
    public interface IBancosRFCCatalogo : IGenericCatalogo<ClaveBancoRFC> {
        ClaveBancoRFC Search(string findId);
    }
}
