using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Cfdi40;

namespace Jaeger.SAT.Catalogos.Update.Importers.Cfdi40 {
    /// <summary>
    /// catalogo de tipos de comprobantes
    /// </summary>
    public class ClavesTipoComprobante : AbstractInjector, IInjector {
        public ClavesTipoComprobante(DataTable dataTable) : base(dataTable) {
            this._SkipRows = 3;
        }

        protected override void CheckHeaders() {
            this._HeadersMapper = new Dictionary<string, string>() {
                { "c_TipoDeComprobante", "Clave" },
                { "Descripción", "Descripcion" },
                { "Valor máximo", "ValorMaximo" },
                { "Fecha inicio de vigencia", "VigenciaIni" },
                { "Fecha fin de vigencia", "VigenciaFin" },
            };

            var headers = GetHeaders().ToArray();
            if (!ArrayCompare(_HeadersMapper.Select(it => it.Key).ToArray(), headers)) {
                throw new Exception($"The headers did not match on {this.GetType().Name}");
            }
        }

        protected override void CreateRepository() {
            for (int i = 0; i < this._DataTable.Rows.Count; i++) {
                if (this._DataTable.Rows[i].ItemArray[0].ToString() == "N") {
                    this._DataTable.Rows[i]["ValorMaximo"] = "999999999999999999.999999";
                } else if (this._DataTable.Rows[i].ItemArray[0].ToString() == "") {
                    this._DataTable.Rows[i].Delete();
                }
            }
            this._DataTable.AcceptChanges();
            _Repository = new TipoComprobanteRepository();
        }
    }
}