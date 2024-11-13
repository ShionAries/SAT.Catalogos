using System.Data;
using Jaeger.SAT.Catalogos.Update.Importers.Rep20;

namespace Jaeger.SAT.Catalogos.Update.Importers {
    /// <summary>
    /// Catalogo del tipo de la cadena de pago.
    /// </summary>
    public class RecepcionPago20Importer : AbstractXlsImporter, IImporter {
        public RecepcionPago20Importer() : base() {
            this.FileName = "catPagos.xls";
        }

        public RecepcionPago20Importer(Scraping.Interfaces.IOrigin origin, IConfiguration configuration) : base(origin, configuration) { }

        public override Injectors CreateInjectors(DataSet dataSet) {
            return new Injectors {
                Items = new System.Collections.Generic.List<IInjector> {
                    new TIpoCadenaPagoImporter(dataSet.Tables["c_TIpoCadenaPago"]),
                }
            };
        }
    }
}
