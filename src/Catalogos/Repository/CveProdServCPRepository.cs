using System.Collections.Generic;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Contracts;
using Jaeger.SAT.Catalogos.Repository.Entities;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.Catalogos.Repositories {
    /// <summary>
    /// Catálogo de productos y servicios carta porte.
    /// </summary>
    public class CveProdServCPRepository : RepositoryContext<ClaveProdServCP>, IClaveProdServCPRepository, IGeneralRepository {
        public CveProdServCPRepository() {
            this.Title = "Catálogo de productos y servicios carta porte.";
            this.FileName = "CatalogoProdServCPCatalogo.json";
            this.Version = "2.0";
            this.Revision = "A";
        }

        public List<ClaveProdServCP> Productos(string find) {
            var response = new List<ClaveProdServCP>();
            response = this.Items.Where(p => p.Descripcion.ToLower().Contains(find.ToLower()) | p.PalabrasSimilares.ToLower().Contains(find.ToLower())).ToList();
            return response;
        }
    }
}
