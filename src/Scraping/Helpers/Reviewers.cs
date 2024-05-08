using System;
using System.Collections.Generic;
using Jaeger.SAT.Catalogos.Scraping.Entities;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;

namespace Jaeger.SAT.Catalogos.Scraping.Helpers {
    public class Reviewers {
        protected internal List<IReviewer> reviewer;

        public Reviewers() {
            this.reviewer = new List<IReviewer>();
        }

        public Reviewers CreateWithDefaultReviewers(IResourcesGateway gateway) {
            this.reviewer.Add(new ScrapingReviewer(gateway));
            this.reviewer.Add(new ConstantReviewer(gateway));
            return this;
        }

        public List<Review> Review(List<IOrigin> origins) {
            var response = new List<Review>();
            foreach (var item in origins) {
                var reviewer = this.FindReviewerByOrigin(item);
                response.Add(reviewer.Review(item));
            }
            return response;
        }

        public IReviewer FindReviewerByOrigin(IOrigin origin) {
            foreach (var item in reviewer) {
                if (item.Accepts(origin)) {
                    return item;
                }
            }
            throw new Exception($"Unable to review an origin of class {origin.GetType().Name}");
        }
    }
}
