using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Jaeger.SAT.Catalogos.Repository.Nom12;
using Jaeger.SAT.Catalogos.Update.Abstracts;

namespace Jaeger.SAT.Catalogos.Update.Importers.Nom12 {
    /// <summary>
    /// Nomina Catalogo de tipos de horas extra
    /// </summary>
    internal class TipoIncapacidadInjector : AbstractInjector, IInjector {
        public TipoIncapacidadInjector(DataTable dataTable) : base(dataTable) {
            this.SkipRows = 3;
        }

        protected override void CheckHeaders() {
            _HeadersMapper = new Dictionary<string, string> {
                { "c_TipoIncapacidad", "Clave" },
                { "Descripción", "Descripcion" }
            };

            var headers = GetHeaders().ToArray();
            if (!ArrayCompare(_HeadersMapper.Select(it => it.Key).ToArray(), headers)) {
                throw new Exception($"The headers did not match on {this.GetType().Name}");
            }
        }

        protected override void CreateRepository() {
            var mapper = new Helpers.Mapping.DataNamesMapper<CveTipoIncapacidad>();
            var resultado = mapper.Map(_DataTable).ToList();
            if (resultado != null) {
                if (resultado.Count() > 0) {
                    _Repository = new TipoIncapacidadRepository() {
                        Items = resultado.ToList(),
                        LastUpdate = this.LastUpdate,
                    };
                }
            }
        }
    }
}
