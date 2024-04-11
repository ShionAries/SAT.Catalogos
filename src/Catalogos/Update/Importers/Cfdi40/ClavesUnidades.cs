using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository;
using Jaeger.SAT.Catalogos.Repository.Entities;

namespace Jaeger.SAT.Catalogos.Update.Importers.Cfdi40 {
    public class ClavesUnidades : AbstractInjector, IInjector {
        protected IGeneralRepository _Catalogo;
        public ClavesUnidades(DataTable dataTable) : base(dataTable) {
            _SkipRows = 3;
        }

        protected override void CheckHeaders() {
            _HeadersMapper = new Dictionary<string, string> {
                { "c_ClaveUnidad", "Clave" },
                { "Nombre", "Nombre" },
                { "Descripción", "Descripcion" },
                { "Nota", "Notas" },
                { "Fecha de inicio de vigencia", "VigenciaIni" },
                { "Fecha de fin de vigencia", "VigenciaFin" },
                { "Símbolo", "Simbolo" }
            };

            var headers = GetHeaders().ToArray();
            if (!ArrayCompare(_HeadersMapper.Select(it => it.Key).ToArray(), headers)) {
                throw new Exception("The headers did not match on file {$this->sourceFile()}");
            }
        }

        protected override void Fill() {
            var mapper = new Helpers.Mapping.DataNamesMapper<ClaveUnidad>();
            var resultado = mapper.Map(_DataTable).ToList();
            if (resultado != null) {
                if (resultado.Count() > 0) {
                    _Catalogo = new UnidadesCatalogo {
                        Items = resultado.ToList()
                    };
                }
            }
        }
    }
}
