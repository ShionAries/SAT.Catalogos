using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Cfdi40;
using Jaeger.SAT.Catalogos.Update.Abstracts;

namespace Jaeger.SAT.Catalogos.Update.Importers.Cfdi40 {
    /// <summary>
    /// catalogo de claves de productos y servicios
    /// </summary>
    public class ClavesProdServ : AbstractInjector, IInjector {
        public ClavesProdServ(DataTable dataTable) : base(dataTable) {
            _SkipRows = 3;
        }

        protected override void CheckHeaders() {
            _HeadersMapper = new Dictionary<string, string> {
                { "c_ClaveProdServ", "Clave" },
                { "Descripción", "Descripcion" },
                { "Incluir IVA trasladado", "IncluirIvaTrasladado" },
                { "Incluir IEPS trasladado", "IncluirIepsTrasladado" },
                { "Complemento que debe incluir", "Complemento" },
                { "FechaInicioVigencia", "VigenciaIni" },
                { "FechaFinVigencia", "VigenciaFin" },
                { "Estímulo Franja Fronteriza", "Estimulo" },
                { "Palabras similares", "PalabrasSimilares"}
            };

            var headers = GetHeaders().ToArray();
            if (!ArrayCompare(_HeadersMapper.Select(it => it.Key).ToArray(), headers)) {
                throw new Exception($"The headers did not match on {this.GetType().Name}");
            }
        }

        protected override void CreateRepository() {
            _Repository = new ProdServsRepository();
        }
    }
}