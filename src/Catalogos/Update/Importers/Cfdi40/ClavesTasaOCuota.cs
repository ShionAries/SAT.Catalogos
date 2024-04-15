using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository;
using Jaeger.SAT.Catalogos.Repository.Entities;

namespace Jaeger.SAT.Catalogos.Update.Importers.Cfdi40 {
    public class ClavesTasaOCuota : AbstractInjector, IInjector {
        public ClavesTasaOCuota(DataTable dataTable) : base(dataTable) {
            _SkipRows = 3;
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

        protected override void Fill() {
            var mapper = new Helpers.Mapping.DataNamesMapper<ClaveTasaOCuota>();
            var resultado = mapper.Map(_DataTable).ToList();
            if (resultado != null) {
                if (resultado.Count() > 0) {
                    _Catalogo = new TasaOCuotaRepository {
                        Items = resultado.ToList()
                    };
                }
            }
        }
    }
}