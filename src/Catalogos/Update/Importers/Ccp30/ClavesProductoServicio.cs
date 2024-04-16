using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Jaeger.Catalogos.Repositories;
using Jaeger.SAT.Catalogos.Repository.Entities;

namespace Jaeger.SAT.Catalogos.Update.Importers.Ccp30 {
    internal class ClavesProductoServicio : AbstractInjector, IInjector {
        public ClavesProductoServicio(DataTable dataTable) : base(dataTable) {
            this._SkipRows = 3;
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

        protected override void Fill() {
            var mapper = new Helpers.Mapping.DataNamesMapper<ClaveProdServCP>();
            var resultado = mapper.Map(_DataTable).ToList();
            if (resultado != null) {
                if (resultado.Count() > 0) {
                    _Catalogo = new CveProdServCPRepository {
                        Items = resultado.ToList()
                    };
                }
            }
        }
    }
}
