using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Ret20;

namespace Jaeger.SAT.Catalogos.Update.Importers.Retenciones {
    /// <summary>
    /// Retenciones 2.0 Catalogo de Periodicidad
    /// </summary>
    internal class ClavesPeriodicidad : AbstractInjector, IInjector {
        public ClavesPeriodicidad(DataTable dataTable) : base(dataTable) {
            this._SkipRows = 3;
        }

        protected override void CheckHeaders() {
            _HeadersMapper = new Dictionary<string, string> {
                { "c_Periodicidad", "Clave" },
                { "Descripción", "Descripcion" },
                { "Complemento que lo usa", "Complemento" },
                { "Fecha inicio de vigencia", "VigenciaIni" },
                { "Fecha fin de vigencia", "VigenciaFin" }
            };

            var headers = GetHeaders().ToArray();
            if (!ArrayCompare(_HeadersMapper.Select(it => it.Key).ToArray(), headers)) {
                throw new Exception($"The headers did not match on {this.GetType().Name}");
            }
        }

        protected override void CreateRepository() {
            var mapper = new Helpers.Mapping.DataNamesMapper<CveRetencionPeriodicidad>();
            var resultado = mapper.Map(_DataTable).ToList();
            if (resultado != null) {
                if (resultado.Count() > 0) {
                    _Catalogo = new RetencionPeriodicidadRepository {
                        Items = resultado.ToList()
                    };
                }
            }
        }
    }
}
