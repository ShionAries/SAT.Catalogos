using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository;

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

        protected override void Fill() {
            if (this._DataTable != null) {
                if (this._DataTable.Rows.Count > 0) {
                    this._Catalogo = new Articulo69Repository {
                        Builder = "SAT.Catálogos.Repository"
                    };
                    this._Catalogo.Import(this._DataTable);
                    this._Catalogo.Save();
                }
            }
        }
    }
}
