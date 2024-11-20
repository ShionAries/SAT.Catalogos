using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;
using System.Linq;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// catalogo de tasas o cuotas de impuestos.
    /// </summary>
    public class TasaOCuotaRepository : RepositoryContext<CveTasaOCuota>, ITasaOCuotaRepository, IRepositoryGeneric {
        public TasaOCuotaRepository(System.DateTime? lastUpdate = null) {
            Description = "Catálogo de tasas o cuotas de impuestos.";
            FileName = "TasaOCuotaCFDI40.json";
            Version = "2.0";
            Revision = "0";
            this.AddLastUpdate(lastUpdate);
        }

        public override CveTasaOCuota Search(string query) {
            try {
                var search = this.Items.SingleOrDefault(it => it.Impuesto == query);
                if (search == null) {
                    return new CveTasaOCuota();
                }
                return search;
            } catch (System.Exception) {

            }
            return new CveTasaOCuota { Impuesto = query };
        }
    }
}
