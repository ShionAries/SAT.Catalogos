using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Ccp30;

namespace Jaeger.SAT.Catalogos.Update.Importers.Ccp30 {
    /// <summary>
    /// Carta Porte Claves de Transporte
    /// </summary>
    internal class ClavesTransporte : AbstractInjector, IInjector {
        public ClavesTransporte(DataTable dataTable) : base(dataTable) {
            this._SkipRows = 3;
        }

        protected override void CheckHeaders() {
            _HeadersMapper = new Dictionary<string, string> {
                { "Clave transporte", "Clave" },
                { "Descripción del tipo de transporte", "Descripcion" },
                { "Fecha inicio de vigencia", "VigenciaIni" },
                { "Fecha fin de vigencia", "VigenciaFin" }
            };

            var headers = GetHeaders().ToArray();
            if (!ArrayCompare(_HeadersMapper.Select(it => it.Key).ToArray(), headers)) {
                throw new Exception($"The headers did not match on {this.GetType().Name}");
            }
        }

        protected override void Fill() {
            var mapper = new Helpers.Mapping.DataNamesMapper<CveRegimenAduanero>();
            var resultado = mapper.Map(_DataTable).ToList();
            if (resultado != null) {
                if (resultado.Count() > 0) {
                    _Catalogo = new RegimenAduaneroRepository {
                        Items = resultado.ToList()
                    };
                }
            }
        }
    }
}
