using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository;
using Jaeger.SAT.Catalogos.Repository.Cfdi40;

namespace Jaeger.SAT.Catalogos.Update.Importers.Cfdi40 {
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

        protected override void Fill() {
            var mapper = new Helpers.Mapping.DataNamesMapper<CveProdServ>();
            var resultado = mapper.Map(_DataTable).ToList();
            if (resultado != null) {
                if (resultado.Count() > 0) {
                    _Catalogo = new ProdServsRepository {
                        Items = resultado.ToList()
                    };
                }
            }
        }
    }
}