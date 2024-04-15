using Jaeger.Catalogos.Abstractions;
using Jaeger.Catalogos.Contracts;
using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Repositories {
    /// <summary>
    /// Catálogo de Tipo de contribuyente sujeto a retención.
    /// </summary>
    public class RetencionTipoContribuyenteSujetoCatalogo : CatalogoContext<ClaveRetencionTipoContribuyenteSujeto>, IRetencionTipoContribuyenteSujetoCatalogo, ICatalogo {
        public RetencionTipoContribuyenteSujetoCatalogo() {
            this.Title = "Catálogo de Tipo de contribuyente sujeto a retención.";
            this.FileName = "CatalogoTipoContribuyenteSujetoRetencion.json";
            this.Version = "1.0";
            this.Revision = "0";
        }
    }
}
