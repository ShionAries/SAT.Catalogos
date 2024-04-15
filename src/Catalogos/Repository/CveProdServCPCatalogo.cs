using Jaeger.Catalogos.Abstractions;
using Jaeger.Catalogos.Contracts;
using Jaeger.Catalogos.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Jaeger.Catalogos.Repositories {
    /// <summary>
    /// Catálogo de productos y servicios carta porte.
    /// </summary>
    public class CveProdServCPCatalogo : CatalogoContext<CveProdServCP>, ICveProdServCPCatalogo {
        public CveProdServCPCatalogo() {
            this.Title = "Catálogo de productos y servicios carta porte.";
            this.FileName = "CatalogoProdServCPCatalogo.json";
            this.Version = "2.0";
            this.Revision = "A";
        }

        public List<CveProdServCP> Productos(string find) {
            var response = new List<CveProdServCP>();
            response = this.Items.Where(p => p.Descripcion.ToLower().Contains(find.ToLower()) | p.PalabrasSimilares.ToLower().Contains(find.ToLower())).ToList();
            return response;
        }
    }
}
