using Jaeger.SAT.Catalogos.Scraping.Entities;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;

namespace Jaeger.SAT.Catalogos.Scraping.Abstracts {
    public abstract class Reviewer {
        protected internal IResourcesGateway gateway;

        /// <summary>
        /// Origen Aceptado
        /// </summary>
        public abstract bool Accepts(IOrigin origin);

        public abstract Review Review(IOrigin origin);
    }
}
