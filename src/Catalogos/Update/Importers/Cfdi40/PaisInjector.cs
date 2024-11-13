using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Cfdi40;
using Jaeger.SAT.Catalogos.Update.Abstracts;

namespace Jaeger.SAT.Catalogos.Update.Importers.Cfdi40 {
    /// <summary>
    /// catalogo de claves de paises
    /// </summary>
    public class PaisInjector : AbstractInjector, IInjector {
        public PaisInjector(DataTable dataTable) : base(dataTable) {
            SkipRows = 3;
        }

        protected override void CheckHeaders() {
            _HeadersMapper = new Dictionary<string, string> {
                { "c_Pais", "Clave" },
                { "Descripción", "Descripcion" },
                { "Formato de código postal", "FormatoCodigoPostal" },
                { "Formato de Registro de Identidad Tributaria", "FormatoRegistroIden" },
                { "Validación del Registro de Identidad Tributaria", "ValidacionRegistroIden" },
                { "Agrupaciones", "Agrupaciones" },
            };

            var headers = GetHeaders().ToArray();
            if (!ArrayCompare(_HeadersMapper.Select(it => it.Key).ToArray(), headers)) {
                throw new Exception($"The headers did not match on {this.GetType().Name}");
            }
        }

        protected override void CreateRepository() {
            _Repository = new PaisesRepository(this.LastVersion);
        }
    }
}