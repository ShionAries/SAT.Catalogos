using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Nom12 {
    /// <summary>
    /// catalogo de tipos de contrato (nomina)
    /// </summary>
    public class TipoContratoRepository : RepositoryContext<CveTipoContrato>, ITipoContratoRepository, IGeneralRepository {
        public TipoContratoRepository(System.DateTime? lastUpdate = null) {
            this.Title = "Catálogo de tipos de contrato";
            this.FileName = "CatNom12TipoContrato.json";
            this.Version = "1.0";
            this.Revision = "0";
            this.AddLastUpdate(lastUpdate);
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
