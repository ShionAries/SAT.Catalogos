using System;
using System.Collections.Generic;
using System.Linq;
using Jaeger.SAT.Catalogos.Scraping.Helpers;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;

namespace Jaeger.SAT.Catalogos {
    public class ScrapingService : ConfigurationService {
        #region declaraciones
        private ScrapingReviewer scrapingReviewer;
        private ConstantReviewer constantReviewer;
        private Upgrader upgrader;
        private List<IOrigin> origins;
        private IOrigin origin;
        #endregion

        #region constructor
        /// <summary>
        /// constructor
        /// </summary>
        public ScrapingService() : base() {
            Gateway = new ResourcesGateway();
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="configuration">objeto IConfiguration</param>
        public ScrapingService(IConfiguration configuration) : base(configuration) {
            Gateway = new ResourcesGateway();
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="gateway">IResourceGateway</param>
        /// <param name="configuration">IConfiguration</param>
        public ScrapingService(IResourcesGateway gateway, IConfiguration configuration = null) : base(configuration) {
            Gateway = gateway;
        }
        #endregion

        #region propiedades
        public IResourcesGateway Gateway { get; set; }
        #endregion

        #region metodos publicos
        public IOrigin Review(IOrigin origin) {
            this.origin = origin;
            this.CreateWithDefaultReviewers();
            var localReview = this.FindReviewerByOrigin(this.origin);
            if (localReview != null) {
                this.origin = localReview.Review(this.origin);
                return this.origin;
            }
            return null;
        }

        public void Review(List<IOrigin> origins) {
            this.origins = origins;
            this.CreateWithDefaultReviewers();
            for (int i = 0; i < this.origins.Count(); i++) {
                var localReviewer = this.FindReviewerByOrigin(this.origins[i]);
                this.origins[i] = localReviewer.Review(this.origins[i]);
            }
        }

        public IOrigin GetOrigin() {
            return origin;
        }

        public List<IOrigin> GetOrigins() {
            return origins;
        }

        public void Upgrader() {
            if (this.origin != null) {
                origin = upgrader.UpgradeReview(this.origin);
            } else if (this.origins != null) {
                origins = upgrader.UpgradeReviews(this.origins);
            }
        }
        #endregion

        #region metodos privados
        private IReviewer FindReviewerByOrigin(IOrigin origin) {
            if (scrapingReviewer.Accepts(origin))
                return scrapingReviewer;
            if (constantReviewer.Accepts(origin))
                return constantReviewer;

            throw new Exception($"Unable to review an origin of class {origin.GetType().Name}");
        }

        private void CreateWithDefaultReviewers() {
            if (scrapingReviewer == null)
                scrapingReviewer = new ScrapingReviewer(Gateway);
            if (constantReviewer == null)
                constantReviewer = new ConstantReviewer(Gateway);
            if (upgrader == null)
                upgrader = new Upgrader(Gateway, Configuration.WorkingFolder);
        }
        #endregion

        #region metodos estaticos
        public ScrapingService Create() {
            return new ScrapingService(ConfigurationDefault());
        }

        public ScrapingService Create(IConfiguration configuration) {
            return new ScrapingService(configuration);
        }
        #endregion
    }
}
