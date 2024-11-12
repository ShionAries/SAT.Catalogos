using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Cfdi40;
using Jaeger.SAT.Catalogos.Update.Abstracts;

namespace Jaeger.SAT.Catalogos.Update.Importers.Cfdi40 {
    /// <summary>
    /// catalogo de claves de tasas o cuotas
    /// </summary>
    public class ClaveTasaOCuotaInjector : AbstractInjector, IInjector {
        public ClaveTasaOCuotaInjector(DataTable dataTable) : base(dataTable) {
            SkipRows = 3;
        }

        protected override void CheckHeaders() {
            _HeadersMapper = new Dictionary<string, string> {
                { "Rango o Fijo", "RangoOFijo" },
                { "Valor mínimo", "ValorMinimo" },
                { "Valor máximo", "ValorMaximo" },
                { "Impuesto", "Impuesto" },
                { "Factor", "Factor" },
                { "Traslado", "Traslado" },
                { "Retención", "Retencion" },
                { "Fecha inicio de vigencia", "VigenciaIni" },
                { "Fecha fin de vigencia", "VigenciaFin" },
            };

            var headers = GetHeaders().ToArray();
            if (!ArrayCompare(_HeadersMapper.Select(it => it.Key).ToArray(), headers)) {
                throw new Exception($"The headers did not match on {this.GetType().Name}");
            }
        }

        protected override void CreateRepository() {
            _Repository = new TasaOCuotaRepository(this.LastVersion);
        }
    }
}