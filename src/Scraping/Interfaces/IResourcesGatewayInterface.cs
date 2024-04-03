using Jaeger.SAT.Catalogos.Scraping.Entities;

namespace Jaeger.SAT.Catalogos.Scraping.Interfaces {
    public interface IResourcesGatewayInterface {
        /// <summary>
        /// This method retrieves the http-status and last-modification headers and return the UrlResponde containing those data
        /// </summary>
        UrlResponse Headers(string url);

        /// <summary>
        ///  Obtain the web resource using Http GET method and optionally store it into destination
        /// </summary>
        /// <returns>Return the UrlResponse with http-status and last-modification</returns>
        UrlResponse Get(string url, string destination);
    }
}
