using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Cfdi40;
using Jaeger.SAT.Catalogos.Update.Abstracts;

namespace Jaeger.SAT.Catalogos.Update.Importers.Cfdi40 {
    /// <summary>
    /// Catálogo de números de pedimento operados por aduana y ejercicio.
    /// </summary>
    public class ClavesNumeroPedimentoAduanal : AbstractInjector, IInjector {
        public ClavesNumeroPedimentoAduanal(DataTable dataTable) : base(dataTable) {
            _SkipRows = 3;
        }

        protected override void CheckHeaders() {
            _HeadersMapper = new Dictionary<string, string> {
                { "c_Aduana", "Clave" },
                { "Patente", "Patente" },
                { "Ejercicio", "Ejercicio" },
                { "Cantidad", "Cantidad" },
                { "Fecha inicio de vigencia", "VigenciaIni" },
                { "Fecha fin de vigencia", "VigenciaFin" },
            };

            var headers = GetHeaders().ToArray();
            if (!ArrayCompare(_HeadersMapper.Select(it => it.Key).ToArray(), headers)) {
                throw new Exception($"The headers did not match on {this.GetType().Name}");
            }
        }

        protected override void CreateRepository() {
            _Repository = new NumPedimentoAduanaRepository(this.LastVersion);
        }
    }
}