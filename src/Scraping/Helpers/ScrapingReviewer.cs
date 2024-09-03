using System;
using Jaeger.SAT.Catalogos.Scraping.Entities;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;

namespace Jaeger.SAT.Catalogos.Scraping.Helpers {
    internal class ScrapingReviewer : Abstracts.Reviewer, IReviewer {

        public ScrapingReviewer(IResourcesGateway gateway) {
            this.gateway = gateway;
        }

        public override bool Accepts(IOrigin origin) {
            return origin is ScrapingOrigin;
        }

        public override Review Review(IOrigin origin) {
            if (!(origin is ScrapingOrigin)) {
                throw new Exception("This reviewer can only handle ScrapingOrigin objects");
            }

            if (!origin.HasDownloadUrl()) {
                try {
                    origin = this.ResolveOrigin(origin as ScrapingOrigin);
                } catch (Exception) {
                    return new Review(origin, new ReviewStatus(ReviewStatus.StatusEnum.NotFound));
                }
            }

            var response = this.gateway.Headers(origin.DownloadUrl);

            // si no se pudo obtener el recurso
            if (!response.IsSuccess) {
                return new Review(origin, new ReviewStatus(ReviewStatus.StatusEnum.NotFound));
            }

            // si el recurso no coincide con la última versión
            if (!origin.HasLastVersion() || !response.DateMatch(origin.LastVersion)) {
                return new Review(origin, new ReviewStatus(ReviewStatus.StatusEnum.NotUpdated));
            }

            // entonces el recurso coincide
            return new Review(origin, new ReviewStatus(ReviewStatus.StatusEnum.UpToDate));
        }

        protected IOrigin ResolveOrigin(ScrapingOrigin origin) {
            var baseResource = this.gateway.Get(origin.Url, "");
            var downloadUrl = this.ResolveHtmlToLink(baseResource, origin.LinkText, origin.LinkPosition);
            if (downloadUrl != null) {
                string parentDirectory = origin.Url.Substring(0, origin.Url.LastIndexOf("/"));
                downloadUrl = parentDirectory + "/" + downloadUrl;
            }
            return origin.WithDownloadUrl(downloadUrl);
        }

        protected string ResolveHtmlToLink(UrlResponse response, string linkText, int linkPosition) {
            return ScrapingReviewerLinkExtractor.FromUrlResponse(response, linkText, linkPosition);
        }
    }
}
