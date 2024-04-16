using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository;
using Jaeger.SAT.Catalogos.Repository.Entities;

namespace Jaeger.SAT.Catalogos.Update.Importers.Ccp30 {
    /// <summary>
    /// Carta Porte Catalogo de materiales peligrosos
    /// </summary>
    internal class ClavesMaterialPeligroso : AbstractInjector, IInjector {
        public ClavesMaterialPeligroso(DataTable dataTable) : base(dataTable) {
            this._SkipRows = 3;
        }

        protected override void CheckHeaders() {
            _HeadersMapper = new Dictionary<string, string> {
                { "Clave material peligroso", "Clave" },
                { "Descripción", "Descripcion" },
                { "Clase o div.", "Clase" },
                { "Peligro secundario", "PeligroSecundario" },
                { "Nombre técnico", "NombreTecnico" },
                { "Fecha de inicio de vigencia", "VigenciaIni" },
                { "Fecha de fin de vigencia", "VigenciaFin" },
            };

            var headers = GetHeaders().ToArray();
            if (!ArrayCompare(_HeadersMapper.Select(it => it.Key).ToArray(), headers)) {
                throw new Exception($"The headers did not match on {this.GetType().Name}");
            }
        }

        protected override void Fill() {
            var mapper = new Helpers.Mapping.DataNamesMapper<CveMaterialPeligroso>();
            var resultado = mapper.Map(_DataTable).ToList();
            if (resultado != null) {
                if (resultado.Count() > 0) {
                    _Catalogo = new MaterialPeligrosoRepository {
                        Items = resultado.ToList()
                    };
                }
            }
        }
    }
}
