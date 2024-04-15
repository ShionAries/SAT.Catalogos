using Jaeger.Catalogos.Entities;
using Jaeger.Catalogos.Abstractions;
using Jaeger.Catalogos.Contracts;

namespace Jaeger.Catalogos.Repositories {
    public class NoLocalizadosCatalogo : CatalogoContext<NoLocalizado>, INoLocalizadosCatalogo {
        public NoLocalizadosCatalogo() {
            this.Title = "Lista Negra: No localizados";
            this.FileName = "CatalogoListaNegraNoLocalizados";
        }

        public NoLocalizado Search(string findId) {
            NoLocalizado objeto = new NoLocalizado();
            objeto = this.Items.Find((NoLocalizado p) => p.RFC == findId);
            return objeto;
        }
    }
}
