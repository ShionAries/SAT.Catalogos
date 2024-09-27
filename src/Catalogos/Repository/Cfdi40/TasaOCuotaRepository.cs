using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// catalogo de tasas o cuotas de impuestos.
    /// </summary>
    public class TasaOCuotaRepository : RepositoryContext<CveTasaOCuota>, ITasaOCuotaRepository, IGeneralRepository {
        public TasaOCuotaRepository(System.DateTime? lastUpdate = null) {
            Title = "Catálogo de tasas o cuotas de impuestos.";
            FileName = "TasaOCuotaCFDI40.json";
            Version = "2.0";
            Revision = "0";
            this.AddLastUpdate(lastUpdate);
        }
    }
}
