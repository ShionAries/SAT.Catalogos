using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Jaeger.Catalogos.Repositories;
using Jaeger.SAT.Catalogos.Repository.Entities;

namespace Jaeger.SAT.Catalogos.Update.Importers.Ccp30 {
    /// <summary>
    /// Carta Porte 3.0 Catalogo de tipo de estacion
    /// </summary>
    internal class ClavesEstaciones : AbstractInjector, IInjector {
        public ClavesEstaciones(DataTable dataTable) : base(dataTable) {
            this._SkipRows = 3;
        }

        protected override void CheckHeaders() {
            _HeadersMapper = new Dictionary<string, string> {
                { "Clave identificación", "Clave" },
                { "Descripción", "Descripcion" },
                { "Clave transporte", "ClaveTransporte" },
                { "Nacionalidad", "Nacionalidad" },
                { "Designador IATA", "DesignadorIATA" },
                { "Línea férrea", "LineaFerrea" },
                { "Fecha de inicio de vigencia", "VigenciaIni" },
                { "Fecha de fin de vigencia", "VigenciaFin" }
            };

            var headers = GetHeaders().ToArray();
            if (!ArrayCompare(_HeadersMapper.Select(it => it.Key).ToArray(), headers)) {
                throw new Exception($"The headers did not match on {this.GetType().Name}");
            }
        }

        protected override void Fill() {
            var mapper = new Helpers.Mapping.DataNamesMapper<CveEstaciones>();
            var resultado = mapper.Map(_DataTable).ToList();
            if (resultado != null) {
                if (resultado.Count() > 0) {
                    _Catalogo = new EstacionesRepository {
                        Items = resultado.ToList()
                    };
                }
            }
        }
    }
}
