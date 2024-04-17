using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    public class MonedaRepository : RepositoryContext<CveMoneda>, IMonedaRepository, IGeneralRepository {
        public MonedaRepository() {
            Title = "Catálogo de Monedas";
            FileName = "MonedaCFDI40.json";
        }

        public CveMoneda Search(string findId) {
            CveMoneda objeto = new CveMoneda();
            objeto = Items.SingleOrDefault((p) => p.Clave == findId);
            return objeto;
        }
    }
}
