using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Rep20;

namespace Jaeger.SAT.Catalogos.Update.Importers.Rep20 {
    /// <summary>
    /// Catalogo del tipo de la cadena de pago.
    /// </summary>
    internal class TIpoCadenaPagoImporter : AbstractInjector, IInjector {
        public TIpoCadenaPagoImporter(DataTable dataTable) : base(dataTable) {
            this._SkipRows = 3;
        }

        protected override void CheckHeaders() {
            _HeadersMapper = new Dictionary<string, string> {
                { "c_TipoCadena", "Clave" },
                { "Descripción", "Descripcion" }
            };

            var headers = GetHeaders().ToArray();
            if (!ArrayCompare(_HeadersMapper.Select(it => it.Key).ToArray(), headers)) {
                throw new Exception($"The headers did not match on {this.GetType().Name}");
            }
        }

        protected override void CreateRepository() {
            this._Repository = new TipoCadenaPagoRepository();
        }
    }
}
