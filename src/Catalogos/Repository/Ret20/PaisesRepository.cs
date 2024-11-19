using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ret20 {
    /// <summary>
    /// Retenciones 2.0, Catalogo de Pais
    /// </summary>
    public class PaisesRepository : RepositoryContext<CveRetencionPais>, IPaisesRepository, IRepositoryGeneric {
        public PaisesRepository() {
            Title = "Catálogo de Países (retencion)";
            FileName = "CatRet20Pais.json";
            Revision = "1";
            Version = "1.0";
        }

        public override CveRetencionPais Search(string findId) {
            try {
                var search = this.Items.Find((p) => p.Clave == findId);
                return search;
            } catch (System.Exception) {

            }
            return new CveRetencionPais { Clave = findId };
        }
    }
}
