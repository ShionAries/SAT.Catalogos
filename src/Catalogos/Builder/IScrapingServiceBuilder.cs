using System.Collections.Generic;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;
using Jaeger.SAT.Catalogos.Scraping.ValueObjects;

namespace Jaeger.SAT.Catalogos.Builder {
    public interface IScrapingServiceBuilder {
        IResourcesGateway Gateway { get; set; }
        IScrapingReviewServiceBuilder Review(SourceIdentifierEnum sourceIdentifier);
        IScrapingReviewServiceBuilder Review(IOrigin origin);
        IOrigin GetOrigin();
    }

    public interface IScrapingReviewServiceBuilder {
        IScrapingServiceUpgraderBuilder Upgrader();
    }

    public interface IScrapingReviewsServiceBuilder {

    }

    public interface IScrapingServiceUpgraderBuilder {

    }

    public interface IUpdateServiceBuilder {

    }
}
