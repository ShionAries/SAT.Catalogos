using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Contracts {
    public interface IRetencionEntidadesFederativasCatalogo : IGenericCatalogo<ClaveRetencionEntidadFederativa> {

        ClaveRetencionEntidadFederativa Search(string findId);
    }
}
