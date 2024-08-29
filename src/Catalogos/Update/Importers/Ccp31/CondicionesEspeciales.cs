using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Jaeger.SAT.Catalogos.Update.Importers.Ccp31 {
    /// <summary>
    /// Catalogo de Condiciones especiales del Transporte
    /// </summary>
    internal class CondicionesEspeciales : AbstractInjector, IInjector {
        public CondicionesEspeciales(DataTable dataTable) : base(dataTable) {
            this._SkipRows = 3;
        }

        protected override void CheckHeaders() {
            _HeadersMapper = new Dictionary<string, string> {
                { "Clave", "Clave" },
                { "Descripción", "Descripcion" },
                { "Fecha inicio de vigencia", "VigenciaIni" },
                { "Fecha fin de vigencia", "VigenciaFin" },
            };

            var headers = GetHeaders().ToArray();
            if (!ArrayCompare(_HeadersMapper.Select(it => it.Key).ToArray(), headers)) {
                throw new Exception($"The headers did not match on {this.GetType().Name}");
            }
        }

        protected override void CreateRepository() {
            this._Repository = new SAT.Catalogos.Repository.Ccp31.CondicionesEspecialesRepository();
        }
    }
}
