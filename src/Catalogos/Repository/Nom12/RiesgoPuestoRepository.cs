using System.Linq;

namespace Jaeger.SAT.Catalogos.Repository.Nom12 {
    /// <summary>
    /// Catalogo de clases en que deben inscribirse los patrones.
    /// </summary>
    public class RiesgoPuestoRepository : RepositoryContext<CveRiesgoPuesto>, IRiesgoPuestoRepository, Interfaces.IRepositoryGeneric {
        public RiesgoPuestoRepository() : base() {
            this.Description = "Catálogo de clases en que deben inscribirse los patrones.";
            this.FileName = "CatNom12RiesgoPuesto.json";
            this.Version = "2.0";
            this.Revision = "0";
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
