using System.Collections.Generic;

namespace Jaeger.SAT.Catalogos.Scraping.Entities {
    public class LayoutOrigins {
        public LayoutOrigins() {
            this.WorkingFolder = @"C:\Jaeger\Jaeger.Temporal";
            this.Origins = new List<LayoutOrigin>();
        }

        public string WorkingFolder { get; set; }

        public List<LayoutOrigin> Origins { get; set; }
    }
}
