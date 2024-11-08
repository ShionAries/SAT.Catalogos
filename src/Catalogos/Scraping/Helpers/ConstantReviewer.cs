using System;
using Jaeger.SAT.Catalogos.Scraping.Entities;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;
using Jaeger.SAT.Catalogos.Scraping.ValueObjects;

namespace Jaeger.SAT.Catalogos.Scraping.Helpers {
    /// <summary>
    /// clase revisor para origen constante
    /// </summary>
    internal class ConstantReviewer : Abstracts.Reviewer, IReviewer {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="gateway">IResourcesGateway</param>
        public ConstantReviewer(IResourcesGateway gateway) {
            this.gateway = gateway;
        }

        /// <summary>
        /// Origen Aceptado
        /// </summary>
        public override bool Accepts(IOrigin origin) {
            return origin is ConstantOrigin;
        }

        public override IOrigin Review(IOrigin origin) {
            if (!(origin is ConstantOrigin)) {
                new Exception("This reviewer can only handle ConstantOrigin objects");
            }

            // obtener la información de la url del origen
            var response = this.gateway.Headers(origin.Url);
            if (!response.IsSuccess) {
                origin.Status = StatusEnum.NotFound;
                return origin;
            }

            // si el recurso no coincide con la ultima version
            if (!origin.HasLastVersion() || !response.DateMatch(origin.LastVersion)) {
                origin.Status = StatusEnum.NotUpdated;
                return origin;
            }

            // entonces el recurso coincide
            origin.Status = StatusEnum.UpToDate;
            return origin;
        }
    }
}
