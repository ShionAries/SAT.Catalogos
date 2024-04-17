using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Ccp30;
using Jaeger.SAT.Catalogos.Repository.Repositories;

namespace Jaeger.SAT.Catalogos.Update.Importers.Ccp30 {
    /// <summary>
    /// Carta Porte 3.0 Catalogo tipo permiso
    /// </summary>
    internal class ClavesTipoPermiso : AbstractInjector, IInjector {
        public ClavesTipoPermiso(DataTable dataTable) : base(dataTable) {
            this._SkipRows = 3;
        }

        protected override void CheckHeaders() {
            _HeadersMapper = new Dictionary<string, string> {
                { "Clave", "Clave" },
                { "Descripción", "Descripcion" },
                { "Clave transporte", "ClaveTransporte" },
                { "Fecha de inicio de vigencia", "VigenciaIni" },
                { "Fecha de fin de vigencia", "VigenciaFin" },
            };

            var headers = GetHeaders().ToArray();
            if (!ArrayCompare(_HeadersMapper.Select(it => it.Key).ToArray(), headers)) {
                throw new Exception($"The headers did not match on {this.GetType().Name}");
            }
        }

        protected override void Fill() {
            var mapper = new Helpers.Mapping.DataNamesMapper<CveTipoPermiso>();
            var resultado = mapper.Map(_DataTable).ToList();
            if (resultado != null) {
                if (resultado.Count() > 0) {
                    _Catalogo = new TipoPermisoRepository {
                        Items = resultado.ToList()
                    };
                }
            }
        }
    }
}
