using System;
using Jaeger.SAT.Catalogos.Scraping.Entities;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;
using Jaeger.SAT.Catalogos.Scraping.ValueObjects;

namespace Jaeger.SAT.Catalogos.Scraping.Helpers {
    /// <summary>
    /// clase revisor para origen constante
    /// </summary>
    internal class ScrapingReviewer : Abstracts.Reviewer, IReviewer {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="gateway">IResourcesGateway</param>
        public ScrapingReviewer(IResourcesGateway gateway) {
            this.gateway = gateway;
        }

        /// <summary>
        /// Origen Aceptado
        /// </summary>
        public override bool Accepts(IOrigin origin) {
            return origin is ScrapingOrigin;
        }

        public override IOrigin Review(IOrigin origin) {
            if (!(origin is ScrapingOrigin)) {
                throw new Exception("This reviewer can only handle ScrapingOrigin objects");
            }

            if (!origin.HasDownloadUrl()) {
                try {
                    origin = this.ResolveOrigin(origin as ScrapingOrigin);
                } catch (Exception) {
                    origin.Status = StatusEnum.NotFound;
                    return origin;
                }
            }

            var response = this.gateway.Headers(origin.DownloadUrl);

            // si no se pudo obtener el recurso
            if (!response.IsSuccess) {
                origin.Status = StatusEnum.NotFound;
                return origin;
            }

            // si el recurso no coincide con la última versión
            if (!origin.HasLastVersion() || !response.DateMatch(origin.LastVersion)) {
               origin.Status = StatusEnum.NotUpdated;
                return origin;
            }

            // entonces el recurso coincide
            origin.Status = StatusEnum.UpToDate;
            return origin;
        }

        protected IOrigin ResolveOrigin(ScrapingOrigin origin) {
            var baseResource = this.gateway.Get(origin.Url, "");
            var downloadUrl = this.ResolveHtmlToLink(baseResource, origin.LinkText);
            if (downloadUrl != null) {
                string parentDirectory = origin.Url.Substring(0, origin.Url.LastIndexOf("/"));
                downloadUrl = parentDirectory + "/" + downloadUrl;
            }
            return origin.WithDownloadUrl(downloadUrl);
        }

        protected string ResolveHtmlToLink(UrlResponse response, string linkText) {
            return ScrapingReviewerLinkExtractor.FromUrlResponse(response, linkText);
        }
    }
}
