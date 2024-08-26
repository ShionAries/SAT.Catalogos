using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Ccp30;

namespace Jaeger.SAT.Catalogos.Update.Importers.Ccp30 {
    /// <summary>
    /// Carta Porte 3.0 Catalogo de tipo de estacion
    /// </summary>
    internal class NumAutorizacionNaviero : AbstractInjector, IInjector {
        public NumAutorizacionNaviero(DataTable dataTable) : base(dataTable) {
            this._SkipRows = 3;
        }

        protected override void CheckHeaders() {
            _HeadersMapper = new Dictionary<string, string> {
                { "Número de autorización", "NumAutorizacion" },
                { "Inicio de vigencia", "VigenciaIni" },
                { "Fin de vigencia", "VigenciaFin" }
            };

            var headers = GetHeaders().ToArray();
            if (!ArrayCompare(_HeadersMapper.Select(it => it.Key).ToArray(), headers)) {
                throw new Exception($"The headers did not match on {this.GetType().Name}");
            }
        }

        protected override void CreateRepository() {
            _Catalogo = new NumAutorizacionNavieroRepository();
        }
    }
}
