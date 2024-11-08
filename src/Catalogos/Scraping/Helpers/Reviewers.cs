using System;
using System.Collections.Generic;
using Jaeger.SAT.Catalogos.Scraping.Entities;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;

namespace Jaeger.SAT.Catalogos.Scraping.Helpers {
    /// <summary>
    /// revisores
    /// </summary>
    public class Reviewers {
        protected internal List<IReviewer> reviewer;

        /// <summary>
        /// constructor
        /// </summary>
        public Reviewers() {
            this.reviewer = new List<IReviewer>();
        }

        public IResourcesGateway Gateway { get; set; }

        /// <summary>
        /// crear opciones por default
        /// </summary>
        public Reviewers CreateWithDefaultReviewers() {
            this.reviewer.Add(new ScrapingReviewer(this.Gateway));
            this.reviewer.Add(new ConstantReviewer(this.Gateway));
            return this;
        }

        /// <summary>
        /// crear opciones por default
        /// </summary>
        public Reviewers CreateWithDefaultReviewers(IResourcesGateway gateway) {
            this.Gateway = gateway;
            this.CreateWithDefaultReviewers();
            return this;
        }

        public List<IOrigin> Review(List<IOrigin> origins) {
            var response = new List<IOrigin>();
            foreach (var item in origins) {
                var reviewer = this.FindReviewerByOrigin(item);
                response.Add(reviewer.Review(item));
            }
            return response;
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
