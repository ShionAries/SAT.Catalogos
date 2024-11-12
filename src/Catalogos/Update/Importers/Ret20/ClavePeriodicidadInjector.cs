using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Ret20;
using Jaeger.SAT.Catalogos.Update.Abstracts;

namespace Jaeger.SAT.Catalogos.Update.Importers.Ret20 {
    /// <summary>
    /// Retenciones 2.0 Catalogo de Periodicidad
    /// </summary>
    internal class ClavePeriodicidadInjector : AbstractInjector, IInjector {
        public ClavePeriodicidadInjector(DataTable dataTable) : base(dataTable) {
            this.SkipRows = 3;
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
                    _Repository = new PeriodicidadRepository {
                        Items = resultado.ToList()
                    };
                }
            }
        }
    }
}
