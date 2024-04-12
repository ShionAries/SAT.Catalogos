using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Entities;

namespace Jaeger.SAT.Catalogos.Repository {
    public class UnidadesRepository : RepositoryContext<ClaveUnidad>, IUnidadesRepository, IGeneralRepository {
        public UnidadesRepository() {
            Title = "Catálogo de unidades de medida para los conceptos en el CFDI.";
            FileName = "CatalogoUnidades.json";
        }
        public ClaveUnidad Search(string findId) {
            ClaveUnidad objeto = new ClaveUnidad();
            objeto = Items.Find((p) => p.Clave == findId);
            return objeto;
        }

        public System.Collections.Generic.IEnumerable<ClaveUnidad> GetSearch(string findId) {
            return Items.Where(it => it.Descripcion.Contains(findId)).ToList();
        }
    }
}
