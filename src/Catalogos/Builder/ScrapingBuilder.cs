using System;
using System.Collections.Generic;
using Jaeger.SAT.Catalogos.Scraping.Entities;
using Jaeger.SAT.Catalogos.Scraping.Helpers;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;
using Jaeger.SAT.Catalogos.Scraping.ValueObjects;

namespace Jaeger.SAT.Catalogos.Builder {
    public class ScrapingBuilder : ConfigurationService, IScrapingBuilder, IScrapingReviewServiceBuilder, IScrapingReviewsServiceBuilder, IScrapingServiceUpgraderBuilder {
        #region declaraciones
        private ScrapingReviewer scrapingReviewer;
        private ConstantReviewer constantReviewer;
        private Upgrader upgrader;
        private IOrigin origin;
        private Review reviewer;
        private SourceIdentifierEnum sourceIdentifier;
        #endregion

        #region constructor
        public ScrapingBuilder() : base() {
            this.Configuration = ConfigurationService.ConfigurationDefault();
            this.Gateway = new ResourcesGateway();
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="configuration">objeto IConfiguration</param>
        public ScrapingBuilder(IConfiguration configuration) : base(configuration) {
            this.Gateway = new ResourcesGateway();
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="gateway">IResourceGateway</param>
        /// <param name="configuration">IConfiguration</param>
        public ScrapingBuilder(IResourcesGateway gateway, IConfiguration configuration = null) : base(configuration) {
            this.Gateway = gateway;
        }
        #endregion

        #region propiedades
        public IResourcesGateway Gateway { get; set; }
        #endregion

        #region builder
        public IScrapingReviewServiceBuilder Review(SourceIdentifierEnum sourceIdentifier) {
            this.sourceIdentifier = sourceIdentifier;
            this.origin = DumpOrigins.GetOrigin(sourceIdentifier);
            this.CreateDefaultReviewers();
            var localReviewer = FindReviewerByOrigin(this.origin);
            if (localReviewer != null) {
                reviewer = localReviewer.Review(this.origin);
            }
            return this;
        }

        public IScrapingReviewServiceBuilder Review(IOrigin origin) {
            this.origin = origin;
            return this;
        }

        public IUpdateRepositoryBuilder Update() {
            return new UpdateRepositoryBuilder(this.Configuration, this.origin, this.sourceIdentifier);
        }

        public IScrapingReviewsServiceBuilder Review(List<IOrigin> origin) {
            return this;
        }

        public virtual IScrapingServiceUpgraderBuilder Upgrader() {
            if (reviewer != null) {
                origin = upgrader.UpgradeReview(reviewer);
            }
            return this;
        }

        public IOrigin GetOrigin() {
            return this.origin;
        }

        public IScrapingServiceReviewsBuilder Reviews() {
            return new ScrapingReviewsBuilder(this.Configuration);
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

        protected void CreateDefaultReviewers() {
            if (scrapingReviewer == null)
                scrapingReviewer = new ScrapingReviewer(Gateway);
            if (constantReviewer == null)
                constantReviewer = new ConstantReviewer(Gateway);
            if (upgrader == null)
                upgrader = new Upgrader(Gateway, Configuration.WorkingFolder);
        }
        #endregion

        public static IScrapingBuilder Create() {
            return new ScrapingBuilder();
        }
    }
}
