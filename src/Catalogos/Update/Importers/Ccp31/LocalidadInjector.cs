using Jaeger.SAT.Catalogos.Update.Abstracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Jaeger.SAT.Catalogos.Update.Importers.Ccp31 {
    /// <summary>
    /// Carta Porte 3.0: Catalogo de localidades
    /// </summary>
    internal class LocalidadInjector : AbstractInjector, IInjector {
        public LocalidadInjector(DataTable dataTable) : base(dataTable) {
            this.SkipRows = 3;
        }

        protected override void CheckHeaders() {
            this._HeadersMapper = new Dictionary<string, string> {
                { "c_Localidad", "c_Localidad" },
                { "c_Estado", "" },
                { "Descripción", "Descripcion" },
                { "Fecha de inicio de vigencia", "VigenciaIni" },
                { "Fecha de fin de vigencia", "VigenciaFin" }
            };

            var headers = GetHeaders().ToArray();
            if (!ArrayCompare(this._HeadersMapper.Select(it => it.Key).ToArray(), headers)) {
                throw new Exception($"The headers did not match on {this.GetType().Name}");
            }
        }

        protected override void CreateRepository() {
            this._Repository = new Repository.Cfdi40.LocalidadRepository() { LastUpdate = this.LastUpdate };
        }
    }
}
