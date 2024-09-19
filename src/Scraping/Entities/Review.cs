using Jaeger.SAT.Catalogos.Scraping.Interfaces;
using Jaeger.SAT.Catalogos.Scraping.ValueObjects;

namespace Jaeger.SAT.Catalogos.Scraping.Entities {
    public class Review {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="origin">Origen</param>
        /// <param name="status">status</param>
        public Review(IOrigin origin, StatusEnum status) {
            Origin = origin;
            Status = status;
        }

        /// <summary>
        /// obtener o establecer origen del recurso
        /// </summary>
        public IOrigin Origin { get; set; }

        /// <summary>
        /// obtener o establecer status del origen de recurso
        /// </summary>
        public StatusEnum Status { get; set; }
    }
}
