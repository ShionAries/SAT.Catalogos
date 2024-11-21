using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Cfdi40;
using Jaeger.SAT.Catalogos.Update.Abstracts;

namespace Jaeger.SAT.Catalogos.Update.Importers.Cfdi33 {
    /// <summary>
    /// catalogo de claves de unidades de medida
    /// </summary>
    public class UnidadInjector : AbstractInjector, IInjector {
        public UnidadInjector(DataTable dataTable) : base(dataTable) {
            SkipRows = 3;
        }

        protected override void CheckHeaders() {
            _HeadersMapper = new Dictionary<string, string> {
                { "c_ClaveUnidad", "Clave" },
                { "Nombre", "Nombre" },
                { "Descripción", "Descripcion" },
                { "Nota", "Notas" },
                { "Fecha de inicio de vigencia", "VigenciaIni" },
                { "Fecha de fin de vigencia", "VigenciaFin" },
                { "Símbolo", "Simbolo" }
            };

            var headers = GetHeaders().ToArray();
            if (!ArrayCompare(_HeadersMapper.Select(it => it.Key).ToArray(), headers)) {
                throw new Exception($"The headers did not match on {this.GetType().Name}");
            }
        }

        protected override void CreateRepository() {
            _Repository = new UnidadesRepository() { LastUpdate = this.LastUpdate };
        }
    }
}
