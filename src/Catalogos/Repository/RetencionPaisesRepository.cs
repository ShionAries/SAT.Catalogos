using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Entities;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository {
    public class RetencionPaisesRepository : RepositoryContext<ClaveRetencionPais>, IRetencionPaisesRepository, IGeneralRepository {
        public RetencionPaisesRepository() {
            Title = "Catálogo de Países (retencion)";
            FileName = "CatalogoRetencionPaises.json";
        }

        public ClaveRetencionPais Search(string findId) {
            var objeto = new ClaveRetencionPais();
            objeto = Items.Find((p) => p.Clave == findId);
            return objeto;
        }
    }
}
