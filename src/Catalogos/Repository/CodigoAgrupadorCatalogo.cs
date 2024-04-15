using Jaeger.Catalogos.Entities;
using System.Text.RegularExpressions;
using Jaeger.Catalogos.Abstractions;
using Jaeger.Catalogos.Contracts;

namespace Jaeger.Catalogos.Repositories {
    public class CodigoAgrupadorCatalogo : CatalogoContext<CodigoAgrupador>, ICodigoAgrupadorCatalogo {
        public CodigoAgrupadorCatalogo() {
            this.Title = "Catálogo Codigo Agrupador";
            this.FileName = "CatalogoCodigoAgrupador.json";
        }

        /// <summary>
        /// retorna un objeto codigo agrupador del catalogo del sat
        /// </summary>
        public CodigoAgrupador Search(string findId) {
            string str = Regex.Replace(findId, "[^\\d]", "");
            CodigoAgrupador objeto = new CodigoAgrupador();
            objeto = this.Items.Find((CodigoAgrupador p) => p.Clave == str);
            return objeto;
        }
    }
}
