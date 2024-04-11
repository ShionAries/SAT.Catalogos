using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Jaeger.SAT.Catalogos.Database;
using Jaeger.SAT.Catalogos.Database.Repository;

namespace Jaeger.SAT.Catalogos.Importers.Cfdi40 {
    public class FormasDePago : AbstractInjector, IInjectorInterface {
        protected IFormaPagoCatalogo _Catalogo;
        public FormasDePago(DataTable dataTable) : base(dataTable) {
            this._SkipRows = 3;
        }

        public override void CheckHeaders() {
            
            // cantidad de filas que debe saltar para encontrar los encabezados
            this._Expected = new Dictionary<string, string> {
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
            if (!this.ForLoop(_Expected.Select(it => it.Key).ToArray(), headers)) {
                throw new Exception("The headers did not match on file {$this->sourceFile()}");
            }
        }

        public override void Fill() {
            var mapper = new Helpers.Mapping.DataNamesMapper<Entities.ClaveFormaPago>();
            var resultado = mapper.Map(this._DataTable).ToList();
            if (resultado != null) {
                if (resultado.Count() > 0) {
                    this._Catalogo = new FormaPagoCatalogo {
                        Items = resultado.ToList()
                    };
                }
            }
        }
    }
}
