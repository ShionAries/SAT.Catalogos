using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Ccp30;

namespace Jaeger.SAT.Catalogos.Update.Importers.Ccp30 {
    /// <summary>
    /// Carta Porte 3.0 Codigo de Tipo de Servicio
    /// </summary>
    internal class TipoDeServicio : AbstractInjector, IInjector {
        public TipoDeServicio(DataTable dataTable) : base(dataTable) {
            this._SkipRows = 3;
        }

        protected override void CheckHeaders() {
            _HeadersMapper = new Dictionary<string, string> {
                { "Clave", "Clave" },
                { "Descripción", "Descripcion" },
                { "Contenedor", "Contenedor" },
                { "Fecha de inicio de vigencia", "VigenciaIni" },
                { "Fecha de fin de vigencia", "VigenciaFin" }
            };

            var headers = GetHeaders().ToArray();
            if (!ArrayCompare(_HeadersMapper.Select(it => it.Key).ToArray(), headers)) {
                throw new Exception($"The headers did not match on {this.GetType().Name}");
            }
        }

        protected override void Fill() {
            if (this._DataTable != null) {
                if (this._DataTable.Rows.Count > 0) {
                    this._Catalogo = new TipoDeServicioRepository();
                    var inserted = this._Catalogo.Import(this._DataTable);
                    Console.WriteLine($"Registros: {inserted}");
                }
            }
        }
    }
}
