using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Jaeger.Catalogos.Repositories;
using Jaeger.SAT.Catalogos.Repository.Entities;

namespace Jaeger.SAT.Catalogos.Update.Importers.Retenciones {
    /// <summary>
    /// Retenciones 2.0 Catalogo de Ejercicio
    /// </summary>
    internal class ClavesEjercicio : AbstractInjector, IInjector {
        public ClavesEjercicio(DataTable dataTable) : base(dataTable) {
            this._SkipRows = 3;
        }

        protected override void CheckHeaders() {
            _HeadersMapper = new Dictionary<string, string> {
                { "c_Ejercicio", "Clave" },
                { "Descripción", "Descripcion" },
                { "Fecha inicio de vigencia", "VigenciaIni" },
                { "Fecha fin de vigencia", "VigenciaFin" }
            };

            var headers = GetHeaders().ToArray();
            if (!ArrayCompare(_HeadersMapper.Select(it => it.Key).ToArray(), headers)) {
                throw new Exception($"The headers did not match on {this.GetType().Name}");
            }
        }

        protected override void Fill() {
            var mapper = new Helpers.Mapping.DataNamesMapper<ClaveRetencionEjercicio>();
            var resultado = mapper.Map(_DataTable).ToList();
            if (resultado != null) {
                if (resultado.Count() > 0) {
                    _Catalogo = new RetencionEjercicioRepository {
                        Items = resultado.ToList()
                    };
                }
            }
        }
    }
}
