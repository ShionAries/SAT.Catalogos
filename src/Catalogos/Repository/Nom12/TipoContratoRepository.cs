using System.Linq;

namespace Jaeger.SAT.Catalogos.Repository.Nom12 {
    /// <summary>
    /// catalogo de tipos de contrato (nomina)
    /// </summary>
    public class TipoContratoRepository : RepositoryContext<CveTipoContrato>, ITipoContratoRepository, Interfaces.IRepositoryGeneric {
        public TipoContratoRepository() : base() {
            this.Description = "Catálogo de tipos de contrato";
            this.FileName = "CatNom12TipoContrato.json";
            this.Version = "1.0";
            this.Revision = "0";
        }

        public override CveTipoContrato Search(string query) {
            try {
                var search = this.Items.SingleOrDefault(it => it.Clave == query);
                if (search != null) {
                    return search;
                }
            } catch (System.Exception) {

            }
            return new CveTipoContrato() { Clave = query };
        }
    }
}
