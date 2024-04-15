using Jaeger.Catalogos.Entities;
using Jaeger.Catalogos.Abstractions;
using Jaeger.Catalogos.Contracts;

namespace Jaeger.Catalogos.Repositories {
    public class OrigenRecursoCatalogo : CatalogoContext<ClaveOrigenRecurso>, IOrigenRecursoCatalogo {
        public OrigenRecursoCatalogo() {
            this.Title = "Catálogo del tipo de origen recurso.";
            this.FileName = "CatalogoNominaOrigenRecurso.json";
            this.Version = "1.0";
            this.Revision = "0";
        }
    }
}
