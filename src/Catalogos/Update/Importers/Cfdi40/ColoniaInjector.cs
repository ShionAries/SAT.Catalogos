using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Cfdi40;
using Jaeger.SAT.Catalogos.Update.Abstracts;

namespace Jaeger.SAT.Catalogos.Update.Importers.Cfdi40 {
    /// <summary>
    /// catalogo de colonias
    /// </summary>
    public class ColoniaInjector : AbstractInjector, IInjector {
        public ColoniaInjector(DataTable dataTable) : base(dataTable) {
            this.SkipRows = 3;
        }

        protected override void CheckHeaders() {
            _HeadersMapper = new Dictionary<string, string> {
                { "c_Colonia", "Clave" },
                { "c_CodigoPostal", "CodigoPostal" },
                { "Nombre del asentamiento", "Descripcion" },
            };

            var headers = GetHeaders().ToArray();
            if (!ArrayCompare(_HeadersMapper.Select(it => it.Key).ToArray(), headers)) {
                throw new Exception($"The headers did not match on {this.GetType().Name}");
            }
        }

        protected override void CreateRepository() {
            this._Repository = new ColoniaRepository(this.LastVersion);
        }
    }
}
