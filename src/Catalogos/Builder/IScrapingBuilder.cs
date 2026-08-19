using Jaeger.SAT.Catalogos.Scraping.Interfaces;

namespace Jaeger.SAT.Catalogos.Builder {
    /// <summary>
    /// interfaz para constructor de servicios de scraping
    /// </summary>
    public interface IScrapingBuilder {
        IResourcesGateway Gateway { get; set; }
        IScrapingOriginServiceBuilder Origin(IOrigin origin);
        IOrigin GetOrigin();
    }

    /// <summary>
    /// interfaz para constructor de servicios de origenes de scraping
    /// </summary>
    public interface IScrapingOriginServiceBuilder {
        IScrapingReviewServiceBuilder Review();
    }

    /// <summary>
    /// interfaz para constructor de servicios de revision de scraping
    /// </summary>
    public interface IScrapingReviewServiceBuilder {
        IScrapingServiceUpgraderBuilder Upgrader();
    }

    /// <summary>
    /// interfaz para constructor de servicios de actualizacion de scraping
    /// </summary>
    public interface IScrapingServiceUpgraderBuilder {
        IOrigin GetOrigin();
    }
}
