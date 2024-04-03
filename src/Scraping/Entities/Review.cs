using Jaeger.SAT.Catalogos.Scraping.Interfaces;

namespace Jaeger.SAT.Catalogos.Scraping.Entities {
    public class Review {
        public Review(IOriginInterface origin, ReviewStatus status) {
            Origin = origin;
            Status = status;
        }

        public IOriginInterface Origin { get; set; }

        public ReviewStatus Status { get; set; }
    }
}
