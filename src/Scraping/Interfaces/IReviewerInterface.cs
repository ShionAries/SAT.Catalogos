using Jaeger.SAT.Catalogos.Scraping.Entities;

namespace Jaeger.SAT.Catalogos.Scraping.Interfaces {
    public interface IReviewerInterface {
        bool Accepts(IOriginInterface origin);

        Review Review(IOriginInterface origin);
    }
}
