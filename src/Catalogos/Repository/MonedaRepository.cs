using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Entities;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository {
    public class MonedaRepository : RepositoryContext<ClaveMoneda>, IMonedaRepository, IGeneralRepository {
        public MonedaRepository() {
            this.Title = "Catálogo de Monedas";
            this.FileName = "CatalogoMoneda.json";
        }

        public ClaveMoneda Search(string findId) {
            ClaveMoneda objeto = new ClaveMoneda();
            objeto = this.Items.SingleOrDefault((ClaveMoneda p) => p.Clave == findId);
            return objeto;
        }
    }
}
