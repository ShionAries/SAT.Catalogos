using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// catalogo de monedas
    /// </summary>
    public class MonedaRepository : RepositoryContext<CveMoneda>, IMonedaRepository, IRepositoryGeneric {
        public MonedaRepository() {
            Description = "Catálogo de Monedas";
            FileName = "MonedaCFDI40.json";
        }

        public override CveMoneda Search(string findId) {
            CveMoneda objeto = new CveMoneda();
            objeto = Items.SingleOrDefault((p) => p.Clave == findId);
            return objeto;
        }
    }
}
