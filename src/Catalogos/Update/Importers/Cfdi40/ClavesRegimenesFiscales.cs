using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository;
using Jaeger.SAT.Catalogos.Repository.Cfdi40;

namespace Jaeger.SAT.Catalogos.Update.Importers.Cfdi40 {
    public class ClavesRegimenesFiscales : AbstractInjector, IInjector {
        public ClavesRegimenesFiscales(DataTable dataTable) : base(dataTable) {
            _SkipRows = 4;
        }

        protected override void CheckHeaders() {
            _HeadersMapper = new Dictionary<string, string> {
                { "c_RegimenFiscal", "Clave" },
                { "Descripción", "Descripcion" },
                { "Física", "Fisica" },
                { "Moral", "Moral" },
                { "Fecha de inicio de vigencia", "VigenciaIni" },
                { "Fecha de fin de vigencia", "VigenciaFin" },
            };

            var headers = GetHeaders().ToArray();
            if (!ArrayCompare(_HeadersMapper.Select(it => it.Key).ToArray(), headers)) {
                throw new Exception($"The headers did not match on {this.GetType().Name}");
            }
        }

        protected override void Fill() {
            var mapper = new Helpers.Mapping.DataNamesMapper<CveRegimenFiscal>();
            var resultado = mapper.Map(_DataTable).ToList();
            if (resultado != null) {
                if (resultado.Count() > 0) {
                    _Catalogo = new RegimenesFiscalesRepository {
                        Items = resultado.ToList()
                    };
                }
            }
        }
    }
}