using System.Collections.Generic;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;

namespace Jaeger.SAT.Catalogos.Builder {
    public interface IScrapingBuilder {
        IResourcesGateway Gateway { get; set; }
        IScrapingOriginServiceBuilder Origin(IOrigin origin);
        IOrigin GetOrigin();
    }

    public interface IScrapingOriginServiceBuilder {
        IScrapingReviewServiceBuilder Review();
    }

    public interface IScrapingReviewServiceBuilder {
        IScrapingServiceUpgraderBuilder Upgrader();
    }

    public interface IScrapingServiceUpgraderBuilder {
        IOrigin GetOrigin();
    }
}
