using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Ret20;
using Jaeger.SAT.Catalogos.Update.Abstracts;

namespace Jaeger.SAT.Catalogos.Update.Importers.Ret20 {
    /// <summary>
    /// catalogo de retenciones
    /// </summary>
    internal class ClaveRetencionesInjector : AbstractInjector, IInjector {
        public ClaveRetencionesInjector(DataTable dataTable) : base(dataTable) {
            this.SkipRows = 3;
        }

        protected override void CheckHeaders() {
            _HeadersMapper = new Dictionary<string, string> {
                { "c_CveRetenc", "Clave" },
                { "Descripción", "Descripcion" },
                { "Nombre del complemento", "Nombre" },
                { "Fecha inicio de vigencia", "VigenciaIni" },
                { "Fecha fin de vigencia", "VigenciaFin" }
            };

            var headers = GetHeaders().ToArray();
            if (!ArrayCompare(_HeadersMapper.Select(it => it.Key).ToArray(), headers)) {
                throw new Exception($"The headers did not match on {this.GetType().Name}");
            }
        }

        protected override void CreateRepository() {
            var mapper = new Helpers.Mapping.DataNamesMapper<CveRetencion>();
            var resultado = mapper.Map(_DataTable).ToList();
            if (resultado != null) {
                if (resultado.Count() > 0) {
                    _Repository = new ClaveRetencionRepository {
                        Items = resultado.ToList()
                    };
                }
            }
        }
    }
}
