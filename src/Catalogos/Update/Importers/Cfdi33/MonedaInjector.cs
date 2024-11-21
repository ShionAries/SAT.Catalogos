using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Cfdi40;
using Jaeger.SAT.Catalogos.Update.Abstracts;

namespace Jaeger.SAT.Catalogos.Update.Importers.Cfdi33 {
    /// <summary>
    /// catalogo de claves de monedas
    /// </summary>
    public class MonedaInjector : AbstractInjector, IInjector {
        public MonedaInjector(DataTable dataTable) : base(dataTable) {
            SkipRows = 3;
        }

        protected override void CheckHeaders() {
            _HeadersMapper = new Dictionary<string, string> {
                { "c_Moneda", "Clave" },
                { "Descripción", "Descripcion" },
                { "Decimales", "Decimales" },
                { "Porcentaje variación", "PorcentajeVariacion" },
                { "Fecha inicio de vigencia", "VigenciaIni" },
                { "Fecha fin de vigencia", "VigenciaFin" },
            };

            var headers = GetHeaders().ToArray();
            if (!ArrayCompare(_HeadersMapper.Select(it => it.Key).ToArray(), headers)) {
                throw new Exception($"The headers did not match on {this.GetType().Name}");
            }
        }

        protected override void CreateRepository() {
            _Repository = new MonedaRepository() { LastUpdate = this.LastUpdate };
        }
    }
}