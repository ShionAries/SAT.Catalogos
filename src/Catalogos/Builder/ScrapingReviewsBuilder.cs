using System.Collections.Generic;
using Jaeger.SAT.Catalogos.Scraping.Entities;
using Jaeger.SAT.Catalogos.Scraping.Helpers;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;

namespace Jaeger.SAT.Catalogos.Builder {
    public class ScrapingReviewsBuilder : ScrapingBuilder, IScrapingServiceReviewsBuilder {
        #region declaraciones
        private List<IOrigin> reviewers;
        private List<IOrigin> origins;
        private Upgrader upgrader;
        #endregion

        public ScrapingReviewsBuilder(IConfiguration configuration) : base(configuration) { }

        public IScrapingReviewServiceBuilder Reviews(List<IOrigin> origins) {
            this.origins = origins;
            CreateDefaultReviewers();
            reviewers = new List<IOrigin>();
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
