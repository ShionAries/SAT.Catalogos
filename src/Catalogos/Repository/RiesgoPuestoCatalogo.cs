using Jaeger.Catalogos.Entities;
using Jaeger.Catalogos.Contracts;
using Jaeger.Catalogos.Abstractions;

namespace Jaeger.Catalogos.Repositories {
    public class RiesgoPuestoCatalogo : CatalogoContext<ClaveRiesgoPuesto>, IRiesgoPuestoCatalogo {
        public RiesgoPuestoCatalogo() {
            this.Title = "Catálogo de clases en que deben inscribirse los patrones.";
            this.FileName = "CatalogoNominaRiesgoPuesto.json";
            this.Version = "2.0";
        }
    }
}
