using System.Linq;
using Jaeger.SAT.Catalogos.Abstractions;
using Jaeger.SAT.Catalogos.Entities;

namespace Jaeger.SAT.Catalogos.Database.Repository {
    public class UnidadesCatalogo : CatalogoContext<ClaveUnidad>, IUnidadesCatalogo {
        public UnidadesCatalogo() {
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
