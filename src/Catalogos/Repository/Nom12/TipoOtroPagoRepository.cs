using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Nom12 {
    /// <summary>
    /// catalogo de otro tipo pago (nomina)
    /// </summary>
    public class TipoOtroPagoRepository : RepositoryContext<CveTipoOtroPago>, ITipoOtroPagoRepository, IRepositoryGeneric {
        public TipoOtroPagoRepository(System.DateTime? lastUpdate = null) {
            this.Description = "Catálogo de otro tipo de pago.";
            this.FileName = "CatNom12TipoOtroPago.json";
            this.Version = "2";
            this.AddLastUpdate(lastUpdate);
        }

        public override CveTipoOtroPago Search(string query) {
            try {
                var search = this.Items.SingleOrDefault(it => it.Clave == query);
                if (search != null)
                    return search;
            } catch (System.Exception) {

            }
            return new CveTipoOtroPago { Clave = query };
        }
    }
}
