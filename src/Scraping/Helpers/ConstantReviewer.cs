using System;
using Jaeger.SAT.Catalogos.Scraping.Entities;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;

namespace Jaeger.SAT.Catalogos.Scraping.Helpers {
    public class ConstantReviewer : Abstracts.Reviewer, IReviewer {

        public ConstantReviewer(IResourcesGateway gateway) {
            this.gateway = gateway;
        }

        /// <summary>
        /// Origen Aceptado
        /// </summary>
        public override bool Accepts(IOrigin origin) {
            return origin is ConstantOrigin;
        }

        public override Review Review(IOrigin origin) {
            if (!(origin is ConstantOrigin)) {
                new Exception("This reviewer can only handle ConstantOrigin objects");
            }

            // obtener la información de la url del origen
            var response = this.gateway.Headers(origin.Url);
            if (!response.IsSuccess) {
                return new Review(origin, new ReviewStatus(ReviewStatus.StatusEnum.NotFound));
            }

            // si el recurso no coincide con la ultima version
            if (!origin.HasLastVersion() || ! response.DateMatch(origin.LastVersion)) {
                return new Review(origin, new ReviewStatus(ReviewStatus.StatusEnum.NotUpdated));
            }

            // entonces el recurso coincide
            return new Review(origin, new ReviewStatus(ReviewStatus.StatusEnum.UpToDate));
        }
    }
}
