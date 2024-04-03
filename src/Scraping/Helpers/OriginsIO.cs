using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;
using Jaeger.SAT.Catalogos.Scraping.Entities;

namespace Jaeger.SAT.Catalogos.Scraping.Helpers {
    public static class OriginsIO {
        private static DataContractSerializer _DataSource;

        public static string filePath = @"D:\bitbucket\github\SAT.Catalogos\tester\Tester\bin\Debug\origins.xml";

        public static void Serialize(List<IOriginInterface> TheIAnimals) {
            // see note below
            _DataSource = new DataContractSerializer(typeof(List<IOriginInterface>), new List<Type> { typeof(ConstantOrigin), typeof(ScrapingOrigin) });

            using (FileStream fs = new FileStream(filePath, FileMode.Create)) {
                _DataSource.WriteObject(fs, TheIAnimals);
            }
        }

        public static List<IOriginInterface> DeSerialize() {
            _DataSource = new DataContractSerializer(typeof(List<IOriginInterface>), new List<Type> { typeof(ConstantOrigin), typeof(ScrapingOrigin) });

            List<IOriginInterface> myOrigins;

            using (FileStream fs = new FileStream(filePath, FileMode.Open)) {
                myOrigins = (List<IOriginInterface>)_DataSource.ReadObject(fs);
            }

            return myOrigins;
        }
    }
}
