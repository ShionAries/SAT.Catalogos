using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Cfdi40;
using Jaeger.SAT.Catalogos.Update.Abstracts;

namespace Jaeger.SAT.Catalogos.Update.Importers.Cfdi40 {
    /// <summary>
    /// catalogo de uso de comprobantes
    /// </summary>
    public class ClaveUsoCFDIInjector : AbstractInjector, IInjector {
        public ClaveUsoCFDIInjector(DataTable dataTable) : base(dataTable) {
            SkipRows = 3;
        }

        protected override void CheckHeaders() {
            _HeadersMapper = new Dictionary<string, string> {
                { "c_UsoCFDI", "Clave" },
                { "Descripción", "Descripcion" },
                { "Física", "Fisica" },
                { "Moral", "Moral" },
                { "Fecha inicio de vigencia", "VigenciaIni" },
                { "Fecha fin de vigencia", "VigenciaFin" },
                { "Régimen Fiscal Receptor", "RegimenFiscalReceptor" }
            };

            var headers = GetHeaders().ToArray();
            if (!ArrayCompare(_HeadersMapper.Select(it => it.Key).ToArray(), headers)) {
                throw new Exception($"The headers did not match on {this.GetType().Name}");
            }
        }

        protected override void CreateRepository() {
            _Repository = new UsoCFDIRepository(this.LastVersion);
        }
    }
}