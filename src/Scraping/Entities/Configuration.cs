namespace Jaeger.SAT.Catalogos.Scraping.Entities {
    /// <summary>
    /// clase para configuracion del servicio
    /// </summary>
    public class Configuration {
        /// <summary>
        /// constructor
        /// </summary>
        public Configuration() {
            this.FileName = "origins.xml";
            this.WorkingFolder = @"C:\Jaeger\Jaeger.Temporal";
        }

        public Configuration(string fileName = "origins.xml", string workingFolder = @"C:\Jaeger\Jaeger.Temporal") {
            FileName = fileName;
            WorkingFolder = workingFolder;
        }

        /// <summary>
        /// obtener o establecer nombre del archivo del control de origenes
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// obtener o establecer folder temporal de trabajo
        /// </summary>
        public string WorkingFolder { get; set; }

        /// <summary>
        /// obtener o establecer ruta completa de archivo log
        /// </summary>
        public string LogFileName {  get; set; }
    }
}
