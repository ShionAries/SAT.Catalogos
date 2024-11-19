using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Nom12 {
    /// <summary>
    /// Catalogo de clases en que deben inscribirse los patrones.
    /// </summary>
    public class RiesgoPuestoRepository : RepositoryContext<CveRiesgoPuesto>, IRiesgoPuestoRepository, IGeneralRepository {
        public RiesgoPuestoRepository(System.DateTime? lastUpdate = null) {
            Title = "Catálogo de clases en que deben inscribirse los patrones.";
            FileName = "CatNom12RiesgoPuesto.json";
            Version = "2.0";
            this.AddLastUpdate(lastUpdate);
        }

        public override CveRiesgoPuesto Search(string query) {
            try {
                var search = this.Items.SingleOrDefault(it => it.Clave == query);
                if (search != null)
                    return search;
            } catch (System.Exception) {

            }
            return new CveRiesgoPuesto { Clave = query };
        }
    }
}
