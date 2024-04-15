using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Entities;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository {
    /// <summary>
    /// Catálogo de Tipo de contribuyente sujeto a retención.
    /// </summary>
    public class RetencionTipoContribuyenteSujetoRepository : RepositoryContext<ClaveRetencionTipoContribuyenteSujeto>, IRetencionTipoContribuyenteSujetoRepository, IGeneralRepository {
        public RetencionTipoContribuyenteSujetoRepository() {
            this.Title = "Catálogo de Tipo de contribuyente sujeto a retención.";
            this.FileName = "CatalogoTipoContribuyenteSujetoRetencion.json";
            this.Version = "1.0";
            this.Revision = "0";
        }
    }
}
