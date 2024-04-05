using System;
using System.Collections.Generic;
using System.Data;

namespace Jaeger.SAT.Catalogos.Importers.Cfdi40 {
    public class FormasDePago : AbstractCsvInjector, IInjectorInterface {
        public FormasDePago(string sourceFile) : base(sourceFile) {
        }

        public override void checkHeaders(CsvFile csv) {
            var expected = new List<string>{
                "c_FormaPago",
                "Descripción",
                "Bancarizado",
                "Número de operación",
                "RFC del Emisor de la cuenta ordenante",
                "Cuenta Ordenante",
                "Patrón para cuenta ordenante",
                "RFC del Emisor Cuenta de Beneficiario",
                "Cuenta de Benenficiario",
                "Patrón para cuenta Beneficiaria",
                "Tipo Cadena Pago",
                "Nombre del Banco emisor de la cuenta ordenante en caso de extranjero",
                "Fecha inicio de vigencia",
                "Fecha fin de vigencia",
            };
            throw new NotImplementedException();
        }

        public override DataTable dataTable() {
            throw new NotImplementedException();
        }
    }
}
