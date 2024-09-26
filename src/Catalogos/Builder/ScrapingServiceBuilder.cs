using System;
using System.Collections.Generic;
using Jaeger.SAT.Catalogos.Scraping.Abstracts;
using Jaeger.SAT.Catalogos.Scraping.Entities;
using Jaeger.SAT.Catalogos.Scraping.Helpers;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;
using Jaeger.SAT.Catalogos.Scraping.ValueObjects;

namespace Jaeger.SAT.Catalogos.Builder {
    public class ScrapingServiceBuilder : ConfigurationService, IScrapingServiceBuilder, IScrapingReviewServiceBuilder, IScrapingReviewsServiceBuilder, IScrapingServiceUpgraderBuilder {
        #region declaraciones
        private ScrapingReviewer scrapingReviewer;
        private ConstantReviewer constantReviewer;
        private Upgrader upgrader;
        private IOrigin origin;
        private Review reviewer;
        #endregion

        #region constructor
        public ScrapingServiceBuilder() : base() {
            this.Configuration = ConfigurationService.ConfigurationDefault();
            this.Gateway = new ResourcesGateway();
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="configuration">objeto IConfiguration</param>
        public ScrapingServiceBuilder(IConfiguration configuration) : base(configuration) {
            this.Gateway = new ResourcesGateway();
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="gateway">IResourceGateway</param>
        /// <param name="configuration">IConfiguration</param>
        public ScrapingServiceBuilder(IResourcesGateway gateway, IConfiguration configuration = null) : base(configuration) {
            this.Gateway = gateway;
        }
        #endregion

        #region propiedades
        public IResourcesGateway Gateway { get; set; }
        #endregion

        #region builder
        public IScrapingReviewServiceBuilder Review(SourceIdentifierEnum sourceIdentifier) {
            this.origin = DumpOrigins.GetOrigin(sourceIdentifier);
            this.CreateWithDefaultReviewers();
            var reviewer2 = FindReviewerByOrigin(this.origin);
            if (reviewer2 != null) {
                reviewer = reviewer2.Review(this.origin);
            }
            return this;
        }

        public IScrapingReviewServiceBuilder Review(IOrigin origin) {
            this.origin = origin;
            return this;
        }

        public IScrapingReviewsServiceBuilder Review(List<IOrigin> origin) {
            return this;
        }

        public IScrapingServiceUpgraderBuilder Upgrader() {
            if (reviewer != null) {
                origin = upgrader.UpgradeReview(reviewer);
            }
            return this;
        }

        public IOrigin GetOrigin() {
            return this.origin;
        }
        #endregion

        #region metodos privados
        protected IReviewer FindReviewerByOrigin(IOrigin origin) {
            if (scrapingReviewer.Accepts(origin))
                return scrapingReviewer;
            if (constantReviewer.Accepts(origin))
                return constantReviewer;

            throw new Exception($"Unable to review an origin of class {origin.GetType().Name}");
        }

        protected void CreateWithDefaultReviewers() {
            if (scrapingReviewer == null)
                scrapingReviewer = new ScrapingReviewer(Gateway);
            if (constantReviewer == null)
                constantReviewer = new ConstantReviewer(Gateway);
            if (upgrader == null)
                upgrader = new Upgrader(Gateway, Configuration.WorkingFolder);
        }
        #endregion

        public static IScrapingServiceBuilder Create() {
            return new ScrapingServiceBuilder();
        }
    }
}
