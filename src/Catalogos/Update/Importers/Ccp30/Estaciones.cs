using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Ccp30;
using Jaeger.SAT.Catalogos.Update.Abstracts;

namespace Jaeger.SAT.Catalogos.Update.Importers.Ccp30 {
    /// <summary>
    /// Carta Porte 3.0 Catalogo de tipo de estacion
    /// </summary>
    internal class Estaciones : AbstractInjector, IInjector {
        public Estaciones(DataTable dataTable) : base(dataTable) {
            this._SkipRows = 3;
        }

        protected override void CheckHeaders() {
            _HeadersMapper = new Dictionary<string, string> {
                { "Clave identificación", "Clave" },
                { "Descripción", "Descripcion" },
                { "Clave transporte", "ClaveTransporte" },
                { "Nacionalidad", "Nacionalidad" },
                { "Designador IATA", "DesignadorIATA" },
                { "Línea férrea", "LineaFerrea" },
                { "Fecha de inicio de vigencia", "VigenciaIni" },
                { "Fecha de fin de vigencia", "VigenciaFin" }
            };

            var headers = GetHeaders().ToArray();
            if (!ArrayCompare(_HeadersMapper.Select(it => it.Key).ToArray(), headers)) {
                throw new Exception($"The headers did not match on {this.GetType().Name}");
            }
        }

        protected override void CreateRepository() {
            _Repository = new EstacionesRepository();
        }
    }
}
