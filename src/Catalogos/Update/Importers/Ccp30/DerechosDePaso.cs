using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Ccp30;
using Jaeger.SAT.Catalogos.Update.Abstracts;

namespace Jaeger.SAT.Catalogos.Update.Importers.Ccp30 {
    /// <summary>
    /// Carta Porte 3.0 Codigo derechos de paso
    /// </summary>
    internal class DerechosDePaso : AbstractInjector, IInjector {
        public DerechosDePaso(DataTable dataTable) : base(dataTable) {
            this._SkipRows = 3;
        }

        protected override void CheckHeaders() {
            _HeadersMapper = new Dictionary<string, string> {
                { "Clave del derecho de paso", "Clave" },
                { "Derecho de paso", "DerechoDePaso" },
                { "Entre", "Entre" },
                { "Hasta", "Hasta" },
                { "Otorga/Recibe", "OtorgaRecibe" },
                { "Concesionario", "Concesionario" },
                { "Fecha de inicio de vigencia", "VigenciaIni" },
                { "Fecha de fin de vigencia", "VigenciaFin" }
            };

            var headers = GetHeaders().ToArray();
            if (!ArrayCompare(_HeadersMapper.Select(it => it.Key).ToArray(), headers)) {
                throw new Exception($"The headers did not match on {this.GetType().Name}");
            }
        }

        protected override void CreateRepository() {
            this._Repository = new DerechosDePasoRepository();
        }
    }
}
