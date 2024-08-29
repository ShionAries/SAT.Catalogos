using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Cfdi40;

namespace Jaeger.SAT.Catalogos.Update.Importers.Cfdi40 {
    /// <summary>
    /// catalogo de claves de monedas
    /// </summary>
    public class ClavesMonedas : AbstractInjector, IInjector {
        public ClavesMonedas(DataTable dataTable) : base(dataTable) {
            _SkipRows = 3;
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
            _Repository = new MonedaRepository();
        }
    }
}