using System;
using Jaeger.SAT.Catalogos.Scraping.Helpers;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;

namespace Jaeger.SAT.Catalogos.Builder {
    public class ScrapingBuilder : ConfigurationService, IScrapingBuilder, IScrapingOriginServiceBuilder, IScrapingReviewServiceBuilder, IScrapingServiceUpgraderBuilder {
        #region declaraciones
        private ScrapingReviewer scrapingReviewer;
        private ConstantReviewer constantReviewer;
        private Upgrader upgrader;
        private IOrigin origin;
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
        public IScrapingOriginServiceBuilder Origin(IOrigin origin) {
            this.origin = origin;
            return this;
        }

        public IScrapingReviewServiceBuilder Review() {
            this.CreateDefaultReviewers();
            var localReviewer = FindReviewerByOrigin(this.origin);
            if (localReviewer != null) {
                this.origin = localReviewer.Review(this.origin);
            }
            return this;
        }

        public virtual IScrapingServiceUpgraderBuilder Upgrader() {
            this.CreateDefaultReviewers();
            if (this.origin != null) {
                origin = upgrader.UpgradeReview(this.origin);
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

        protected void CreateDefaultReviewers() {
            if (scrapingReviewer == null)
                scrapingReviewer = new ScrapingReviewer(this.Gateway);
            if (constantReviewer == null)
                constantReviewer = new ConstantReviewer(this.Gateway);
            if (upgrader == null)
                upgrader = new Upgrader(this.Gateway, this.Configuration.WorkingFolder);
        }
        #endregion

        public static IScrapingBuilder Create() {
            return new ScrapingBuilder();
        }
    }
}
