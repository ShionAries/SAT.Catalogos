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
        public UpdateOrigin WithWorkingFolder(string workingFilder) {
            this.WorkingFolder = workingFilder;
            return this;
        }

        public UpdateOrigin WithOrigin(IOrigin origin) {
            this.Origin = origin;
            return this;
        }

        public UpdateOrigin Run() {
            this.ResourcesGateway = new ResourcesGateway();
            var reviewers = new Reviewers().CreateWithDefaultReviewers(this.ResourcesGateway);
            var reviews = reviewers.Review(new List<IOrigin> { this.Origin });
            
            var upgrader = new Upgrader(this.ResourcesGateway, this.WorkingFolder).UpgradeReviews(reviews);
            System.Console.WriteLine(upgrader.FirstOrDefault().LastVersion.Value.ToShortDateString());
            return this;
        }
        #endregion
    }
}
