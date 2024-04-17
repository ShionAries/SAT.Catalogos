using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ret20 {
    /// <summary>
    /// Retenciones 2.0, Catalogo de Pais
    /// </summary>
    public class RetencionPaisesRepository : RepositoryContext<CveRetencionPais>, IRetencionPaisesRepository, IGeneralRepository {
        public RetencionPaisesRepository() {
            Title = "Catálogo de Países (retencion)";
            FileName = "PaisesRet20.json";
            Revision = "1";
            Version = "1.0";
        }

        public CveRetencionPais Search(string findId) {
            var objeto = new CveRetencionPais();
            objeto = Items.Find((p) => p.Clave == findId);
            return objeto;
        }
    }
}
