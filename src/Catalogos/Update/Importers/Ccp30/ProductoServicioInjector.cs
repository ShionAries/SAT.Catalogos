using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Ccp30;
using Jaeger.SAT.Catalogos.Update.Abstracts;

namespace Jaeger.SAT.Catalogos.Update.Importers.Ccp30 {
    /// <summary>
    /// Carta Porte 3.0: Catalogo de productos 
    /// </summary>
    internal class ProductoServicioInjector : AbstractInjector, IInjector {
        public ProductoServicioInjector(DataTable dataTable) : base(dataTable) {
            this.SkipRows = 3;
        }

        protected override void CheckHeaders() {
            _HeadersMapper = new Dictionary<string, string> {
                { "c_ClaveProdServ", "Clave" },
                { "Descripción", "Descripcion" },
                { "Palabras similares", "PalabrasSimilares" },
                { "Material Peligroso", "MaterialPeligroso" },
                { "FechaInicioVigencia", "VigenciaIni" },
                { "FechaFinVigencia", "VigenciaFin" },
            };

            var headers = GetHeaders().ToArray();
            if (!ArrayCompare(_HeadersMapper.Select(it => it.Key).ToArray(), headers)) {
                throw new Exception($"The headers did not match on {this.GetType().Name}");
            }
        }

        protected override void CreateRepository() {
            _Repository = new ProdServCPRepository();
        }
    }
}
