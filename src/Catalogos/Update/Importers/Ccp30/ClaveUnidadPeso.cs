using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Jaeger.Catalogos.Repositories;
using Jaeger.SAT.Catalogos.Repository.Ccp30;

namespace Jaeger.SAT.Catalogos.Update.Importers.Ccp30 {
    /// <summary>
    /// Carta Porte 3.0 Catalogo de unidad y embalaje
    /// </summary>
    internal class ClaveUnidadPeso : AbstractInjector, IInjector {
        public ClaveUnidadPeso(DataTable dataTable) : base(dataTable) {
            this._SkipRows = 3;
        }

        protected override void CheckHeaders() {
            _HeadersMapper = new Dictionary<string, string> {
                { "Clave unidad", "Clave" },
                { "Nombre", "Nombre" },
                { "Descripción", "Descripcion" },
                { "Nota", "Nota" },
                { "Fecha de inicio de vigencia", "VigenciaIni" },
                { "Fecha de fin de vigencia", "VigenciaFin" },
                { "Símbolo", "Simbolo" },
                { "Bandera", "Bandera" }
            };

            var headers = GetHeaders().ToArray();
            if (!ArrayCompare(_HeadersMapper.Select(it => it.Key).ToArray(), headers)) {
                throw new Exception($"The headers did not match on {this.GetType().Name}");
            }
        }

        protected override void Fill() {
            var mapper = new Helpers.Mapping.DataNamesMapper<CveUnidadPeso>();
            var resultado = mapper.Map(_DataTable).ToList();
            if (resultado != null) {
                if (resultado.Count() > 0) {
                    _Catalogo = new UnidadPesoRepository {
                        Items = resultado.ToList()
                    };
                }
            }
        }
    }
}
