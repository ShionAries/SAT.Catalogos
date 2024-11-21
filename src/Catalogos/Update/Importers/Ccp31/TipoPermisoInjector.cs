using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Ccp31;
using Jaeger.SAT.Catalogos.Update.Abstracts;

namespace Jaeger.SAT.Catalogos.Update.Importers.Ccp31 {
    /// <summary>
    /// Carta Porte 3.0 Catalogo tipo permiso
    /// </summary>
    internal class TipoPermisoInjector : AbstractInjector, IInjector {
        public TipoPermisoInjector(DataTable dataTable) : base(dataTable) {
            this.SkipRows = 3;
        }

        protected override void CheckHeaders() {
            this._HeadersMapper = new Dictionary<string, string> {
                { "Clave", "Clave" },
                { "Descripción", "Descripcion" },
                { "Clave transporte", "ClaveTransporte" },
                { "Fecha de inicio de vigencia", "VigenciaIni" },
                { "Fecha de fin de vigencia", "VigenciaFin" },
            };

            var headers = GetHeaders().ToArray();
            if (!ArrayCompare(this._HeadersMapper.Select(it => it.Key).ToArray(), headers)) {
                throw new Exception($"The headers did not match on {this.GetType().Name}");
            }
        }

        protected override void CreateRepository() {
            this._Repository = new TipoPermisoRepository() { LastUpdate = this.LastUpdate };
        }
    }
}
