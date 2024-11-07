using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// catalogo de unidades de medida para los conceptos en el CFDI.
    /// </summary>
    public class UnidadesRepository : RepositoryContext<CveUnidad>, IUnidadesRepository, IGeneralRepository {
        public UnidadesRepository(System.DateTime? lastUpdate = null) {
            Title = "Catálogo de unidades de medida para los conceptos en el CFDI.";
            FileName = "UnidadesCFDI40.json";
            this.AddLastUpdate(lastUpdate);
        }
        public CveUnidad Search(string findId) {
            CveUnidad objeto = new CveUnidad();
            objeto = Items.Find((p) => p.Clave == findId);
            return objeto;
        }

        public System.Collections.Generic.IEnumerable<CveUnidad> GetSearch(string findId) {
            return Items.Where(it => it.Descripcion.Contains(findId)).ToList();
        }
    }
}
