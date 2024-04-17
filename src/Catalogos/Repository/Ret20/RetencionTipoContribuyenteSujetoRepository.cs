using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ret20 {
    /// <summary>
    /// Retenciones 2.0, Catálogo de Tipo de contribuyente sujeto a retención.
    /// </summary>
    public class RetencionTipoContribuyenteSujetoRepository : RepositoryContext<CveRetencionTipoContribuyenteSujeto>, IRetencionTipoContribuyenteSujetoRepository, IGeneralRepository {
        public RetencionTipoContribuyenteSujetoRepository() {
            Title = "Catálogo de Tipo de contribuyente sujeto a retención.";
            FileName = "CatalogoTipoContribuyenteSujetoRetencion.json";
            Version = "1.0";
            Revision = "0";
        }
    }
}
