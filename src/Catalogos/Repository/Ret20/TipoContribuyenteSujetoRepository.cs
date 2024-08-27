using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ret20 {
    /// <summary>
    /// Retenciones 2.0, Catálogo de Tipo de contribuyente sujeto a retención.
    /// </summary>
    public class TipoContribuyenteSujetoRepository : RepositoryContext<CveRetencionTipoContribuyenteSujeto>, ITipoContribuyenteSujetoRepository, IGeneralRepository {
        public TipoContribuyenteSujetoRepository() {
            Title = "Catálogo de Tipo de contribuyente sujeto a retención.";
            FileName = "CatRet20TipoContribuyenteSujetoRetencion.json";
            Version = "1.0";
            Revision = "0";
        }
    }
}
