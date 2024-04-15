using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository;

namespace Jaeger.SAT.Catalogos.Update.Importers.Cfdi40 {
    /// <summary>
    /// Catalogo de Patentes Aduanales
    /// </summary>
    public class ClavesPatenteAduanal : AbstractInjector, IInjector {
        public ClavesPatenteAduanal(DataTable dataTable) : base(dataTable) {
            _SkipRows = 3;
        }

        protected override void CheckHeaders() {
            _HeadersMapper = new Dictionary<string, string> {
                { "C_PatenteAduanal", "Clave" },
                { "Inicio de vigencia de la patente", "VigenciaIni" },
                { "Fin de vigencia de la patente", "VigenciaFin" },
            };

            var headers = GetHeaders().ToArray();
            if (!ArrayCompare(_HeadersMapper.Select(it => it.Key).ToArray(), headers)) {
                throw new Exception($"The headers did not match on {this.GetType().Name}");
            }
        }

        protected override void Fill() {
            this._Catalogo = new PatenteAduanalRepository();
            var items = this._Catalogo.Import(this._DataTable);
            Console.WriteLine($"Total de items importados{items}");
        }
    }
}