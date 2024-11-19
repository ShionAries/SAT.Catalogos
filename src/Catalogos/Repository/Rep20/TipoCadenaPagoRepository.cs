/// develop: anhe 17072019 1425
/// purpose: catalogo de tipos de cadena de pago aplicables para los complementos de comprobante de pagos.
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;
using System.Linq;

namespace Jaeger.SAT.Catalogos.Repository.Rep20 {
    /// <summary>
    /// Catalogo del tipo de la cadena de pago.
    /// </summary>
    public class TipoCadenaPagoRepository : RepositoryContext<CveTipoCadenaPago>, ITipoCadenaPagoRepository, IGeneralRepository {
        public TipoCadenaPagoRepository() {
            this.Title = "Catálogo de tipo de la cadena de pago.";
            this.FileName = "CatRep20TipoCadenaPago.json";
        }

        public override CveTipoCadenaPago Search(string query) {
            try {
                var search = this.Items.SingleOrDefault(it => it.Clave == query);
                return search;
            } catch (System.Exception) {

            }
            return new CveTipoCadenaPago { Clave = query };
        }
    }
}
