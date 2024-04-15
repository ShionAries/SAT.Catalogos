using Jaeger.Catalogos.Abstractions;
using Jaeger.Catalogos.Contracts;
using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Repositories {
    public class RetencionPaisesCatalogo : CatalogoContext<ClaveRetencionPais>, IRetencionPaisesCatalogo, ICatalogo {
        public RetencionPaisesCatalogo() {
            this.Title = "Catálogo de Países (retencion)";
            this.FileName = "CatalogoRetencionPaises.json";
        }

        public ClaveRetencionPais Search(string findId) {
            var objeto = new ClaveRetencionPais();
            objeto = this.Items.Find((ClaveRetencionPais p) => p.Clave == findId);
            return objeto;
        }
    }
}
