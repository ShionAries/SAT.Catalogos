using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Ccp31;
using Jaeger.SAT.Catalogos.Update.Abstracts;

namespace Jaeger.SAT.Catalogos.Update.Importers.Ccp31 {
    /// <summary>
    /// Carta Porte 3.0 Catalogo de tipo de estacion
    /// </summary>
    internal class TipoEstacionInjector : AbstractInjector, IInjector {
        public TipoEstacionInjector(DataTable dataTable) : base(dataTable) {
            this.SkipRows = 3;
        }

        protected override void CheckHeaders() {
            _HeadersMapper = new Dictionary<string, string> {
                { "Clave de estación", "Clave" },
                { "Descripción del tipo de estación", "Descripcion" },
                { "Clave transporte", "ClaveTransporte" },
                { "Fecha inicio de vigencia", "VigenciaIni" },
                { "Fecha fin de vigencia", "VigenciaFin" }
            };

            var headers = GetHeaders().ToArray();
            if (!ArrayCompare(_HeadersMapper.Select(it => it.Key).ToArray(), headers)) {
                throw new Exception($"The headers did not match on {this.GetType().Name}");
            }
        }

        protected override void CreateRepository() {
            _Repository = new TipoEstacionRepository() { LastUpdate = this.LastUpdate };
        }
    }
}
