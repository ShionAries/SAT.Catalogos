using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Ccp31;

namespace Jaeger.SAT.Catalogos.Update.Importers.Ccp31 {
    /// <summary>
    /// Carta Porte 3.0 Catalogo Parte Transporte
    /// </summary>
    internal class ParteTransporte : AbstractInjector, IInjector {
        public ParteTransporte(DataTable dataTable) : base(dataTable) {
            this._SkipRows = 3;
        }

        protected override void CheckHeaders() {
            _HeadersMapper = new Dictionary<string, string> {
                { "Clave", "Clave" },
                { "Descripción", "Descripcion" },
                { "Fecha de inicio de vigencia", "VigenciaIni" },
                { "Fecha de fin de vigencia", "VigenciaFin" },
            };

            var headers = GetHeaders().ToArray();
            if (!ArrayCompare(_HeadersMapper.Select(it => it.Key).ToArray(), headers)) {
                throw new Exception($"The headers did not match on {this.GetType().Name}");
            }
        }

        protected override void CreateRepository() {
            this._Catalogo = new ParteTransporteRepository();
        }
    }
}
