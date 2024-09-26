using System;
using System.Collections.Generic;
using System.Linq;
using Jaeger.SAT.Catalogos.Scraping.Entities;
using Jaeger.SAT.Catalogos.Scraping.Helpers;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;

namespace Jaeger.SAT.Catalogos {
    public class ScrapingService : ConfigurationService {
        #region declaraciones
        private ScrapingReviewer scrapingReviewer;
        private ConstantReviewer constantReviewer;
        private Upgrader upgrader;
        private List<Review> reviewers;
        private Review reviewer;
        private List<IOrigin> origins;
        private IOrigin origin;
        #endregion

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

        #region propiedades
        public IResourcesGateway Gateway { get; set; }
        #endregion

        #region metodos publicos
        public Review Review(IOrigin origin) {
            this.origin = origin;
            CreateWithDefaultReviewers();
            var reviewer2 = FindReviewerByOrigin(this.origin);
            if (reviewer2 != null) {
                reviewer = reviewer2.Review(this.origin);
                return reviewer;
            }
            return null;
        }

        public void Review(List<IOrigin> origins) {
            this.origins = origins;
            CreateWithDefaultReviewers();
            reviewers = new List<Review>();
            foreach (var item in this.origins) {
                var reviewer = FindReviewerByOrigin(item);
                reviewers.Add(reviewer.Review(item));
            }
        }

        public List<Review> GetReviews() {
            return reviewers;
        }

        public IOrigin GetOrigin() {
            return origin;
        }

        public List<IOrigin> GetOrigins() {
            return origins;
        }

        public void Upgrader() {
            if (reviewer != null) {
                origin = upgrader.UpgradeReview(reviewer);
            } else if (reviewers != null) {
                origins = upgrader.UpgradeReviews(reviewers);
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
