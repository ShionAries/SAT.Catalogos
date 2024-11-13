using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Cfdi40;
using Jaeger.SAT.Catalogos.Update.Abstracts;

namespace Jaeger.SAT.Catalogos.Update.Importers.Cfdi40 {
    /// <summary>
    /// catalogo de claves de formas de pago
    /// </summary>
    public class FormaDePagoInjector : AbstractInjector, IInjector {

        public FormaDePagoInjector(DataTable dataTable) : base(dataTable) {
            SkipRows = 3;
        }

        protected override void CheckHeaders() {
            // cantidad de filas que debe saltar para encontrar los encabezados
            _HeadersMapper = new Dictionary<string, string> {
                { "c_FormaPago", "Clave"},
                { "Descripción", "Descripcion"},
                { "Bancarizado", "Bancarizado"},
                { "Número de operación", "NumOperacion"},
                { "RFC del Emisor de la cuenta ordenante", "RfcEmisorCtaOrdenante"},
                { "Cuenta Ordenante", "CtaOrdenante"},
                { "Patrón para cuenta ordenante", "PatronCtaOrdenante"},
                { "RFC del Emisor Cuenta de Beneficiario", "RfcEmisorCtaBeneficiario"},
                { "Cuenta de Benenficiario", "CtaDelBeneficiario"},
                { "Patrón para cuenta Beneficiaria", "PatronCtaBeneficiaria"},
                { "Tipo Cadena Pago", "TipoCadenaPago"},
                { "Nombre del Banco emisor de la cuenta ordenante en caso de extranjero", "NombreBancoEmisorCtaOrdenante"},
                { "Fecha inicio de vigencia", "VigenciaIni"},
                { "Fecha fin de vigencia", "VigenciaFin"}
            };

            var headers = this.GetHeaders().ToArray();
            if (!ArrayCompare(_HeadersMapper.Select(it => it.Key).ToArray(), headers)) {
                throw new Exception($"The headers did not match on {this.GetType().Name}");
            }
        }

        protected override void CreateRepository() {
            _Repository = new FormaPagoRepository(this.LastVersion);
        }
    }
}
