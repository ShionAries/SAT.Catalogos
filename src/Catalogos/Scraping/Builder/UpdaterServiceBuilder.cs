using System;
using System.Collections.Generic;
using Jaeger.SAT.Catalogos.Scraping.Entities;
using Jaeger.SAT.Catalogos.Scraping.Helpers;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;

namespace Jaeger.SAT.Catalogos.Scraping.Builder {
    public class UpdaterServiceBuilder : IUpdaterServiceBuilder, IUpdaterServiceIOriginBuilder, IUpdaterServiceExecuteBuilder, IUpdaterServiceDownloadBuilder {
        private List<IOrigin> LOrigins;
        protected internal List<IReviewer> reviewer;
        protected internal List<Review> reviews;
        public UpdaterServiceBuilder() {
            this.Gateway = new ResourcesGateway();
            this.reviewer = new List<IReviewer>();
            this.LOrigins = new List<IOrigin>();
            this.reviewer.Add(new ScrapingReviewer(this.Gateway));
            this.reviewer.Add(new ConstantReviewer(this.Gateway));
        }

        public List<IOrigin> Origins {
            get { return this.LOrigins; }
        }

        public IResourcesGateway Gateway { get; set; }

        public IUpdaterServiceIOriginBuilder Update(IOrigin origin) {
            this.LOrigins.Add(origin);
            return this;
        }
        public IUpdaterServiceIOriginBuilder Update(List<IOrigin> origin) {
            this.LOrigins = origin;
            return this;
        }

        public IUpdaterServiceExecuteBuilder Execute() {
            this.reviews = new List<Review>();
            foreach (var item in this.LOrigins) {
                var reviewer = this.FindReviewerByOrigin(item);
                this.reviews.Add(reviewer.Review(item));
            }
            return this;
        }

        public IUpdaterServiceDownloadBuilder Download() {
            var upgrader = new Upgrader(this.Gateway, @"C:\Jaeger\Jaeger.Temporal");
            this.LOrigins = upgrader.UpgradeReviews(reviews);
            return this;
        }

        private IReviewer FindReviewerByOrigin(IOrigin origin) {
            foreach (var item in reviewer) {
                if (item.Accepts(origin)) {
                    return item;
                }
            }
            throw new Exception($"Unable to review an origin of class {origin.GetType().Name}");
        }
    }
}
