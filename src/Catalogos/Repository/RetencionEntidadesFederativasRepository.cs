using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Contracts;
using Jaeger.SAT.Catalogos.Repository.Entities;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository {
    /// <summary>
    /// catalogo de entidades federativas (retenciones)
    /// </summary>
    public class RetencionEntidadesFederativasRepository : RepositoryContext<ClaveRetencionEntidadFederativa>, IRetencionEntidadesFederativasRepository, IGeneralRepository {
        public RetencionEntidadesFederativasRepository() {
            Title = "Catálogo de Entidades Federativas";
            FileName = "CatalogoEntidadesFederativas.json";
        }

        public ClaveRetencionEntidadFederativa Search(string findId) {
            ClaveRetencionEntidadFederativa objeto = new ClaveRetencionEntidadFederativa();
            objeto = Items.Find((p) => p.Clave == findId);
            return objeto;
        }
    }
}
