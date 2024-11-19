using System.Collections.Generic;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp31 {
    /// <summary>
    /// Catálogo de productos y servicios carta porte.
    /// </summary>
    public class ProdServCPRepository : RepositoryContext<CveProdServCP>, IProdServCPRepository, IGeneralRepository {
        public ProdServCPRepository(System.DateTime? lastUpdate = null) {
            Title = "Catálogo de productos y servicios carta porte.";
            FileName = "CatCcp31ProdServCP.json";
            Version = "2.0";
            Revision = "A";
            this.AddLastUpdate(lastUpdate);
        }

        public override CveProdServCP Search(string query) {
            try {
                var search = this.Items.SingleOrDefault(it => it.Clave == query);
                if (search == null) {
                    search = new CveProdServCP() { Clave = query };
                }
                return search;
            } catch (System.Exception) {

            }
            return new CveProdServCP() { Clave = query };
        }

        public List<CveProdServCP> Productos(string find) {
            var response = new List<CveProdServCP>();
            response = Items.Where(p => p.Descripcion.ToLower().Contains(find.ToLower()) | p.PalabrasSimilares.ToLower().Contains(find.ToLower())).ToList();
            return response;
        }
    }
}
