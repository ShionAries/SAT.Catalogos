using System.Linq;

namespace Jaeger.SAT.Catalogos.Repository.Nom12 {
    /// <summary>
    /// catalogo de otro tipo pago (nomina)
    /// </summary>
    public class TipoOtroPagoRepository : RepositoryContext<CveTipoOtroPago>, ITipoOtroPagoRepository, Interfaces.IRepositoryGeneric {
        public TipoOtroPagoRepository() : base() {
            this.Description = "Catálogo de otro tipo de pago.";
            this.FileName = "CatNom12TipoOtroPago.json";
            this.Version = "2";
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
