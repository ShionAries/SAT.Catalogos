using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;
using Jaeger.SAT.Catalogos.Scraping.Entities;

namespace Jaeger.SAT.Catalogos.Scraping.Helpers {
    public class OriginsIO {
        private DataContractSerializer _DataSource;
        protected string filePath = @"origins.xml";

        public OriginsIO(string workingFolder = @"C:\Jaeger\Jaeger.Temporal") {
            this.filePath = Path.Combine(workingFolder, filePath);
        }

        public void Serialize(List<IOriginInterface> TheIAnimals) {
            // see note below
            _DataSource = new DataContractSerializer(typeof(List<IOriginInterface>), new List<Type> { typeof(ConstantOrigin), typeof(ScrapingOrigin) });

            using (FileStream fs = new FileStream(filePath, FileMode.Create)) {
                _DataSource.WriteObject(fs, TheIAnimals);
            }
        }

        public List<IOriginInterface> DeSerialize() {
            if (!File.Exists(filePath)) { return null; }
            _DataSource = new DataContractSerializer(typeof(List<IOriginInterface>), new List<Type> { typeof(ConstantOrigin), typeof(ScrapingOrigin) });

            List<IOriginInterface> myOrigins;

            using (FileStream fs = new FileStream(filePath, FileMode.Open)) {
                myOrigins = (List<IOriginInterface>)_DataSource.ReadObject(fs);
            }

            return myOrigins;
        }
    }
}
