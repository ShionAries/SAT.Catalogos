using Jaeger.Catalogos.Entities;
using Jaeger.Catalogos.Abstractions;
using Jaeger.Catalogos.Contracts;

namespace Jaeger.Catalogos.Repositories {
    public class CanceladosCatalogo : CatalogoContext<Cancelados>, ICanceladosCatalogo {
        public CanceladosCatalogo() {
            this.Title = "Catálogo Lista Negra Cancelados";
            this.FileName = "CatalogoListaNegraCancelados.json";
        }

        /// <summary>
        /// retorna un objeto codigo agrupador del catalogo del sat
        /// </summary>
        public Cancelados Search(string findId) {
            Cancelados objeto = new Cancelados();
            objeto = this.Items.Find((Cancelados p) => p.RFC == findId);
            return objeto;
        }
    }
}
