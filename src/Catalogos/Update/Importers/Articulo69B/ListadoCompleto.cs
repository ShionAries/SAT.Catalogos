using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Articulo69B;
using Jaeger.SAT.Catalogos.Update.Abstracts;

namespace Jaeger.SAT.Catalogos.Update.Importers.Articulo69B {
    internal class ListadoCompleto : AbstractInjector, IInjector {

        public ListadoCompleto(DataTable dataTable) : base(dataTable) {
            this._SkipRows = 1;
        }

        protected override void CheckHeaders() {
            this._HeadersMapper = new Dictionary<string, string>() {
                { "No", "Id" },
                { "RFC", "RFC"},
                { "Nombre del Contribuyente", "Nombre" },
                { "Situación del contribuyente", "Situacion" },
                { "Número y fecha de oficio global de presunción SAT", "OficioGlobalPresuncionSAT" },
                { "Publicación página SAT presuntos", "PublicacionPaginaSATPresuntos" },
                { "Número y fecha de oficio global de presunción DOF", "OficioGlobalPresuncionDOF"},
                { "Publicación DOF presuntos","PublicacionDOFPresuntos" },
                { "Número y fecha de oficio global de contribuyentes que desvirtuaron SAT", "OficioGlobalContribuyentesDesvirtuaronSAT" },
                { "Publicación página SAT desvirtuados", "PublicacionPaginaSATDesvirtuados" },
                { "Número y fecha de oficio global de contribuyentes que desvirtuaron DOF", "OficioGlobalContribuyentesDesvirtuaronDOF" },
                { "Publicación DOF desvirtuados", "PublicacionDOFDesvirtuados" },
                { "Número y fecha de oficio global de definitivos SAT", "OficioGlobalDefinitivosSAT" },
                { "Publicación página SAT definitivos", "PublicacionPaginaSATDefinitivos" },
                { "Número y fecha de oficio global de definitivos DOF", "OficioGlobalDefinitivosDOF" },
                { "Publicación DOF definitivos", "PublicacionDOFDefinitivos" },
                { "Número y fecha de oficio global de sentencia favorable SAT", "OficioGlobalSentenciaFavorableSAT" },
                { "Publicación página SAT sentencia favorable", "PublicacionPaginaSATSentenciaFavorable" },
                { "Número y fecha de oficio global de sentencia favorable DOF", "OficioGlobalSentenciaFavorableDOF" },
                { "Publicación DOF sentencia favorable" , "PublicacionDOFSentenciaFavorable"}
            };

            var headers = this.GetHeaders().ToArray();
            if (!ArrayCompare(_HeadersMapper.Select(it => it.Key).ToArray(), headers)) {
                throw new Exception($"The headers did not match on file {this.GetType().Name}");
            }
        }

        protected override void CreateRepository() {
            this._Repository = new Articulo69BRepository();
        }
    }
}
