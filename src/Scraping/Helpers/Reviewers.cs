using System;
using System.Collections.Generic;
using Jaeger.SAT.Catalogos.Scraping.Entities;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;

namespace Jaeger.SAT.Catalogos.Scraping.Helpers {
    public class Reviewers {
        protected internal List<IReviewerInterface> reviewer;

        public Reviewers() {
            this.reviewer = new List<IReviewerInterface>();
        }

        public Reviewers CreateWithDefaultReviewers(IResourcesGatewayInterface gateway) {
            this.reviewer.Add(new ScrapingReviewer(gateway));
            this.reviewer.Add(new ConstantReviewer(gateway));
            return this;
        }

        public List<Review> Review(List<IOriginInterface> origins) {
            var response = new List<Review>();
            foreach (var item in origins) {
                var reviewer = this.FindReviewerByOrigin(item);
                var d0 = reviewer.Review(item);
                response.Add(d0);
            }
            return response;
        }

        public IReviewerInterface FindReviewerByOrigin(IOriginInterface origin) {
            foreach (var item in reviewer) {
                if (item.Accepts(origin)) {
                    return item;
                }
            }
            throw new Exception("Unable to review an origin of class %s");
        }
    }
}
