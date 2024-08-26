using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Jaeger.SAT.Catalogos.Repository.Nomina;

namespace Jaeger.SAT.Catalogos.Update.Importers.Nomina {
    /// <summary>
    /// Nomina Catalogo de tipos de percepciones
    /// </summary>
    internal class ClavesTipoPercepcion : AbstractInjector, IInjector {
        public ClavesTipoPercepcion(DataTable dataTable) : base(dataTable) {
            this._SkipRows = 3;
        }

        protected override void CheckHeaders() {
            _HeadersMapper = new Dictionary<string, string> {
                { "c_TipoPercepcion", "Clave" },
                { "Descripción", "Descripcion" },
                { "Fecha inicio de vigencia", "VigenciaIni" },
                { "Fecha fin de vigencia", "VigenciaFin" }
            };

            var headers = GetHeaders().ToArray();
            if (!ArrayCompare(_HeadersMapper.Select(it => it.Key).ToArray(), headers)) {
                throw new Exception($"The headers did not match on {this.GetType().Name}");
            }
        }

        protected override void CreateRepository() {
            var mapper = new Helpers.Mapping.DataNamesMapper<ClaveTipoPercepcion>();
            var resultado = mapper.Map(_DataTable).ToList();
            if (resultado != null) {
                if (resultado.Count() > 0) {
                    _Catalogo = new TipoPercepcionRepository {
                        Items = resultado.ToList()
                    };
                }
            }
        }
    }
}
