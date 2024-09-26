using System;

namespace Jaeger.SAT.Catalogos {
    /// <summary>
    /// clase para configuracion del servicio
    /// </summary>
    public class Configuration : IConfiguration {
        private string workingFolder;

        /// <summary>
        /// constructor
        /// </summary>
        public Configuration() {
            FileName = "origins.xml";
            WorkingFolder = @"C:\Jaeger\Jaeger.Temporal";
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
        public string WorkingFolder {
            get { return workingFolder; }
            set {
                if (string.IsNullOrEmpty(value)) {
                    throw new ArgumentNullException("Invalid source catalog: empty string received");
                }

                if (!Helpers.DirectoryService.IsDirectory(value)) {
                    throw new ArgumentException("Invalid source catalog: is not a directory");
                }
                workingFolder = value;
            }
        }

        /// <summary>
        /// obtener o establecer ruta completa de archivo log
        /// </summary>
        public string LogFileName { get; set; }
    }
}
