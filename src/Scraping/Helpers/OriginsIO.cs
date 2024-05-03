using System.Text;
using System.IO;
using System.Collections.Generic;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;
using Jaeger.SAT.Catalogos.Scraping.Entities;

namespace Jaeger.SAT.Catalogos.Scraping.Helpers {
    public class OriginsIO {
        protected string fileName = @"origins.xml";
        protected string workingFolder;
        protected OriginsTranslator translator;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="workingFolder">directorio de trabajo</param>
        public OriginsIO(string workingFolder = @"C:\Jaeger\Jaeger.Temporal") {
            this.workingFolder = workingFolder;
            this.translator = new OriginsTranslator();
        }

        /// <summary>
        /// carga de archivo
        /// </summary>
        public List<IOrigin> ReadFile() {
            return this.translator.OriginFromLayout(this.OriginsFromString());
        }

        private List<LayoutOrigin> OriginsFromString() {
            if (!File.Exists(this.BuildPath())) { return null; }
            Encoding utf8WithoutBom = new UTF8Encoding(false);
            return this.ReadOrigin(File.ReadAllText(this.BuildPath(), utf8WithoutBom));
        }

        private List<LayoutOrigin> ReadOrigin(string content) {
            return XmlSerializerService.DeserializeObject<List<LayoutOrigin>>(content);
        }

        public void WriteFile(List<IOrigin> origins) {
            Encoding utf8WithoutBom = new UTF8Encoding(false);
            File.WriteAllText(this.BuildPath(), this.OriginsToString(origins), utf8WithoutBom);
        }

        private string OriginsToString(List<IOrigin> origins) {
            return XmlSerializerService.SerializeObject(this.translator.OriginToLayout(origins));
        }

        protected string BuildPath() {
            return Path.Combine(this.workingFolder, this.fileName);
        }
    }
}
