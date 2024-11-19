using System.Linq;
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

        public override CveRetencionTipoContribuyenteSujeto Search(string query) {
            try {
                var search = this.Items.SingleOrDefault(it => it.Clave == query);
                if (search != null)
                    return search;
            } catch (System.Exception) {

            }
            return new CveRetencionTipoContribuyenteSujeto { Clave = query };
        }
    }
}
