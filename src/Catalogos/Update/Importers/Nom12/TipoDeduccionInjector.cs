using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Jaeger.SAT.Catalogos.Repository.Nom12;
using Jaeger.SAT.Catalogos.Update.Abstracts;

namespace Jaeger.SAT.Catalogos.Update.Importers.Nom12 {
    /// <summary>
    /// Nomina Catalogo de tipos de deducciones
    /// </summary>
    internal class TipoDeduccionInjector : AbstractInjector, IInjector {
        public TipoDeduccionInjector(DataTable dataTable) : base(dataTable) {
            this.SkipRows = 3;
        }

        protected override void CheckHeaders() {
            _HeadersMapper = new Dictionary<string, string> {
                { "c_TipoDeduccion", "Clave" },
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
            var mapper = new Helpers.Mapping.DataNamesMapper<CveTipoDeduccion>();
            var resultado = mapper.Map(_DataTable).ToList();
            if (resultado != null) {
                if (resultado.Count() > 0) {
                    _Repository = new TipoDeduccionRepository() {
                        Items = resultado.ToList(),
                        LastUpdate = LastUpdate
                    };
                }
            }
        }
    }
}
