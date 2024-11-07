using System.Collections.Generic;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;
using Jaeger.SAT.Catalogos.Scraping.ValueObjects;

namespace Jaeger.SAT.Catalogos.Builder {
    public interface IScrapingBuilder {
        IResourcesGateway Gateway { get; set; }
        IScrapingReviewServiceBuilder Review(SourceIdentifierEnum sourceIdentifier);
        IScrapingReviewServiceBuilder Review(IOrigin origin);
        IOrigin GetOrigin();
        IScrapingServiceReviewsBuilder Reviews();
    }

    public interface IScrapingReviewServiceBuilder {
        IScrapingServiceUpgraderBuilder Upgrader();
    }

    public interface IScrapingReviewsServiceBuilder {
    }

    public interface IScrapingServiceUpgraderBuilder {
        IOrigin GetOrigin();
        IUpdateRepositoryBuilder Update();

    }

    public interface IScrapingServiceReviewsBuilder {
        IScrapingReviewServiceBuilder Reviews(List<IOrigin> origins);
    }
}
