using Jaeger.SAT.Catalogos.Scraping.Entities;

namespace Jaeger.SAT.Catalogos.Scraping.Interfaces {
    public interface IReviewer {
        bool Accepts(IOrigin origin);

        IOrigin Review(IOrigin origin);
    }
}
