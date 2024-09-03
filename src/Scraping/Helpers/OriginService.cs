using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jaeger.SAT.Catalogos.Scraping.Entities;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;

namespace Jaeger.SAT.Catalogos.Scraping.Helpers {
    public class OriginService : OriginsTranslator {
        public OriginService() {
            this.FileName = "origins.xml";
            this.WorkingFolder = @"C:\Jaeger\Jaeger.Temporal";
        }

        public string FileName { get; set; }

        public string WorkingFolder { get; set; }

        public List<IOrigin> DataSource { get; set; }

        public OriginService(string name) { }

        public OriginService GetAll() { 
            this.DataSource = this.OriginFromLayout(this.OriginsFromString());
            return this; 
        }

        public OriginService SaveChanges() {
            this.WriteFile();
            return this; 
        }

        public OriginService Delete() { 
            return this; 
        }

        public OriginService Add(IOrigin origin) { 
            if (this.DataSource == null) {
                this.DataSource = new List<IOrigin>();
            }
            this.DataSource.Add(origin);
            return this; 
        }

        #region
        protected string BuildPath() {
            return Path.Combine(this.WorkingFolder, this.FileName);
        }

        protected List<LayoutOrigin> ReadOrigin(string content) {
            return XmlSerializerService.DeserializeObject<List<LayoutOrigin>>(content);
        }

        protected List<LayoutOrigin> OriginsFromString() {
            if (!File.Exists(this.BuildPath())) { return null; }
            Encoding utf8WithoutBom = new UTF8Encoding(false);
            return this.ReadOrigin(File.ReadAllText(this.BuildPath(), utf8WithoutBom));
        }

        protected void WriteFile() {
            Encoding utf8WithoutBom = new UTF8Encoding(false);
            File.WriteAllText(this.BuildPath(), this.OriginsToString(this.DataSource), utf8WithoutBom);
        }

        protected string OriginsToString(List<IOrigin> origins) {
            return XmlSerializerService.SerializeObject(this.OriginToLayout(origins));
        }
        #endregion
    }
}
