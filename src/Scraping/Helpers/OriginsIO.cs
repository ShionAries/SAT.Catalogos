using System.Text;
using System.IO;
using System.Collections.Generic;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;
using Jaeger.SAT.Catalogos.Scraping.Entities;

namespace Jaeger.SAT.Catalogos.Scraping.Helpers {
    public class OriginsIO {
        protected string filePath = @"origins.xml";
        protected OriginsTranslator translator;

        public OriginsIO(string workingFolder = @"C:\Jaeger\Jaeger.Temporal") {
            this.filePath = Path.Combine(workingFolder, filePath);
            this.translator = new OriginsTranslator();
        }

        public List<IOriginInterface> ReadFile(string filePath = "") {
            if (string.IsNullOrEmpty(filePath))
                filePath = this.filePath;
            return this.translator.OriginFromLayout(this.OriginsFromString(filePath).Origins);
        }

        private LayoutOrigins OriginsFromString(string filePath = "") {
            Encoding utf8WithoutBom = new UTF8Encoding(false);
            return this.ReadOrigin(File.ReadAllText(filePath, utf8WithoutBom));
        }

        private LayoutOrigins ReadOrigin(string content) {
            return XmlSerializerService.DeserializeObject<LayoutOrigins>(content);
        }

        public void WriteFile(List<IOriginInterface> origins) {
            Encoding utf8WithoutBom = new UTF8Encoding(false);
            File.WriteAllText(filePath, this.OriginsToString(origins), utf8WithoutBom);
        }

        private string OriginsToString(List<IOriginInterface> origins) {
            var layout = new LayoutOrigins {
                Origins = new OriginsTranslator().OriginToLayout(origins)
            };

            return XmlSerializerService.SerializeObject(layout);
        }
    }
}
