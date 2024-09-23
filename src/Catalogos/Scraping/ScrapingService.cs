using System;
using System.Collections.Generic;
using System.Linq;
using Jaeger.SAT.Catalogos.Scraping.Entities;
using Jaeger.SAT.Catalogos.Scraping.Helpers;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;

namespace Jaeger.SAT.Catalogos.Scraping {
    public class ScrapingService {
        private ScrapingReviewer scrapingReviewer;
        private ConstantReviewer constantReviewer;
        private Upgrader upgrader;
        private List<Review> reviewers;
        private Review reviewer;
        private List<IOrigin> origins;
        private IOrigin origin;

        public ScrapingService() {
            this.Gateway = new ResourcesGateway();
            this.Configuration = new Configuration();
        }

        public ScrapingService(Configuration configuration) {
            this.Gateway = new ResourcesGateway();
            this.Configuration = configuration;
        }

        public ScrapingService(IResourcesGateway gateway, Configuration configuration = null) {
            this.Gateway = gateway;
            if (configuration != null)
                this.Configuration = configuration;
        }
        #region propiedades
        public IResourcesGateway Gateway { get; set; }

        public Configuration Configuration { get; set; }
        #endregion

        #region metodos publicos
        public Review Review(IOrigin origin) {
            this.origin = origin;
            this.CreateWithDefaultReviewers();
            var reviewer2 = this.FindReviewerByOrigin(this.origin);
            if (reviewer2 != null) {
                this.reviewer = reviewer2.Review(this.origin);
                return reviewer;
            }
            return null;
        }

        public void Review(List<IOrigin> origins) {
            this.origins = origins;
            this.CreateWithDefaultReviewers();
            this.reviewers = new List<Review>();
            foreach (var item in this.origins) {
                var reviewer = this.FindReviewerByOrigin(item);
                reviewers.Add(reviewer.Review(item));
            }
        }

        public List<Review> GetReviews() {
            return this.reviewers;
        }

        public IOrigin GetOrigin() {
            return this.origin;
        }

        public List<IOrigin> GetOrigins() {
            return this.origins;
        }

        public void Upgrader() {
            if (this.reviewer != null) {
                this.origin = this.upgrader.UpgradeReview(this.reviewer);
            } else if (this.reviewers != null) {
                this.origins = this.upgrader.UpgradeReviews(this.reviewers);
            }
        }
        #endregion

        #region metodos privados
        private IReviewer FindReviewerByOrigin(IOrigin origin) {
            if (this.scrapingReviewer.Accepts(origin))
                return this.scrapingReviewer;
            if (this.constantReviewer.Accepts(origin))
                return this.constantReviewer;

            throw new Exception($"Unable to review an origin of class {origin.GetType().Name}");
        }

        private void CreateWithDefaultReviewers() {
            if (this.scrapingReviewer == null)
                this.scrapingReviewer = new ScrapingReviewer(this.Gateway);
            if (this.constantReviewer == null)
                this.constantReviewer = new ConstantReviewer(this.Gateway);
            if (this.upgrader == null)
                this.upgrader = new Upgrader(this.Gateway, this.Configuration.WorkingFolder);
        }
        #endregion
    }
}
