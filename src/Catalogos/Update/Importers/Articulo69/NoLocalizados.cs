using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Articulo69;
using Jaeger.SAT.Catalogos.Update.Abstracts;

namespace Jaeger.SAT.Catalogos.Update.Importers.Articulo69 {
    internal class NoLocalizados : AbstractInjector, IInjector {
        public NoLocalizados(DataTable dataTable) : base(dataTable) {
            this._SkipRows = -1;
        }

        protected override void CheckHeaders() {
            this._HeadersMapper = new Dictionary<string, string>() {
                { "RFC", "RFC" },
                { "RAZÓN SOCIAL", "RazonSocial" },
                { "TIPO PERSONA", "TipoPersona" },
                { "SUPUESTO", "Supuesto" },
                { "FECHAS DE PRIMERA PUBLICACION", "FechaPrimeraPublicacion" },
                { "ENTIDAD FEDERATIVA", "EntidadFederativa" }
            };

            var headers = this.GetHeaders().ToArray();
            if (!ArrayCompare(_HeadersMapper.Select(it => it.Key).ToArray(), headers)) {
                throw new Exception($"The headers did not match on file {this.GetType().Name}");
            }
        }

        protected override void FixDataTable() {
            // para este caso omitimos este metodo porque el archivo CSV ya contiene los encabezados en la primera
            // fila
        }

        protected override void CreateRepository() {
            this._Repository = new Articulo69Repository();
        }
    }
}
