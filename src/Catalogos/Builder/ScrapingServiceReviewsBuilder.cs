using System.Collections.Generic;
using Jaeger.SAT.Catalogos.Scraping.Entities;
using Jaeger.SAT.Catalogos.Scraping.Helpers;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;

namespace Jaeger.SAT.Catalogos.Builder {
    public class ScrapingServiceReviewsBuilder : ScrapingServiceBuilder, IScrapingServiceReviewsBuilder {
        #region declaraciones
        private List<Review> reviewers;
        private List<IOrigin> origins;
        private Upgrader upgrader;
        #endregion

        public ScrapingServiceReviewsBuilder(IConfiguration configuration) : base(configuration) { }

        public IScrapingReviewServiceBuilder Reviews(List<IOrigin> origins) {
            this.origins = origins;
            CreateWithDefaultReviewers();
            reviewers = new List<Review>();
            foreach (var item in this.origins) {
                var reviewer = FindReviewerByOrigin(item);
                reviewers.Add(reviewer.Review(item));
            }
            return this;
        }

        public override IScrapingServiceUpgraderBuilder Upgrader() {
            if (reviewers != null) {
                origins = this.upgrader.UpgradeReviews(reviewers);
            }
            return this;
        }
    }
}
