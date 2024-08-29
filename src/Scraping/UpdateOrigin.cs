using System.Collections.Generic;
using System.Linq;
using Jaeger.SAT.Catalogos.Scraping.Helpers;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;

namespace Jaeger.SAT.Catalogos.Scraping {
    public class UpdateOrigin {
        protected IResourcesGateway ResourcesGateway;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="workingFolder">ruta de la carpeta de trabajo</param>
        public UpdateOrigin(string workingFolder = @"C:\Jaeger\Jaeger.Temporal") {
            this.WorkingFolder = workingFolder;
        }

        /// <summary>
        /// obtener o establecer origenes
        /// </summary>
        public IOrigin Origin { get; set; }

        /// <summary>
        /// obtener o establecer carpeta de trabajo
        /// </summary>
        public string WorkingFolder { get; set; }

        #region builder
        public UpdateOrigin WithOrigin(IOrigin origin) {
            this.Origin = origin;
            return this;
        }

        public UpdateOrigin Run() {
            this.ResourcesGateway = new ResourcesGateway();
            var reviewers = new Reviewers().CreateWithDefaultReviewers(this.ResourcesGateway);
            var reviews = reviewers.Review(new List<IOrigin> { this.Origin });
            var notFoundReviews = reviews.Where(it => it.Status.IsNotFound()).ToList();
            var notUpdatedReviews = reviews.Where(it => it.Status.IsNotUpdated()).ToList();
            var upToDateReviews = reviews.Where(it => it.Status.IsUptodate()).ToList();
            var upgrader = new Upgrader(this.ResourcesGateway, this.WorkingFolder);
            var recentOrigins = upgrader.UpgradeReviews(reviews);
            return this;
        }
        #endregion
    }
}
