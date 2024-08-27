using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ret20 {
    /// <summary>
    /// Retenciones 2.0, Catalogo Tipo de Documento
    /// </summary>
    public class TipoImpuestoRepository : RepositoryContext<CveRetencionTipoImpuesto>, ITipoImpuestoRepository, IGeneralRepository {
        public TipoImpuestoRepository() {
            Title = "Catálogo de tipo impuesto.";
            FileName = "CatRet20TipoImpuesto.json";
            Version = "1.0";
            Revision = "0";
        }
    }
}
