using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Jaeger.SAT.Catalogos.Database;
using Jaeger.SAT.Catalogos.Database.Repository;

namespace Jaeger.SAT.Catalogos.Importers.Cfdi40 {
    public class ClavesUnidades : AbstractInjector, IInjectorInterface {
        protected IUnidadesCatalogo _Catalogo;
        public ClavesUnidades(DataTable dataTable) : base(dataTable) {
            this._SkipRows = 3;
        }

        public override void CheckHeaders() {
            this._Expected = new Dictionary<string, string> {
                { "c_ClaveUnidad", "Clave" },
                { "Nombre", "Nombre" },
                { "Descripción", "Descripcion" },
                { "Nota", "Notas" },
                { "Fecha de inicio de vigencia", "VigenciaIni" },
                { "Fecha de fin de vigencia", "VigenciaFin" },
                { "Símbolo", "Simbolo" }
            };
            
            var headers = this.GetHeaders().ToArray();
            if (!this.ForLoop(_Expected.Select(it => it.Key).ToArray(), headers)) {
                throw new Exception("The headers did not match on file {$this->sourceFile()}");
            }
        }

        public override void Fill() {
            var mapper = new Helpers.Mapping.DataNamesMapper<Entities.ClaveUnidad>();
            var resultado = mapper.Map(this._DataTable).ToList();
            if (resultado != null) {
                if (resultado.Count() > 0) {
                    this._Catalogo = new UnidadesCatalogo {
                        Items = resultado.ToList()
                    };
                }
            }
        }
    }
}
