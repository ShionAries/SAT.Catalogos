using System;

namespace Jaeger.SAT.Catalogos {
    /// <summary>
    /// clase para configuracion del servicio
    /// </summary>
    public class Configuration : IConfiguration {
        private string workingFolder;
        private string temporaryFolder;

        /// <summary>
        /// constructor
        /// </summary>
        public Configuration() {
            FileName = "origins.json";
            this.WorkingFolder = @"C:\Jaeger\Jaeger.Temporal";
            this.TemporaryFolder = @"C:\Jaeger\Jaeger.Temporal";
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="workingFolder"></param>
        public Configuration(string fileName = "origins.json", string workingFolder = @"C:\Jaeger\Jaeger.Temporal") {
            FileName = fileName;
            WorkingFolder = workingFolder;
        }

        /// <summary>
        /// obtener o establecer nombre del archivo del control de origenes
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// obtener o establecer ruta completa de archivo log
        /// </summary>
        public string LogFileName { get; set; }

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
        /// obtener o establecer folder para temporales
        /// </summary>
        public string TemporaryFolder {
            get { return temporaryFolder; }
            set {
                if (string.IsNullOrEmpty(value)) {
                    throw new ArgumentNullException("Invalid source catalog: empty string received");
                }

                if (!Helpers.DirectoryService.IsDirectory(value)) {
                    throw new ArgumentException("Invalid source catalog: is not a directory");
                }
                temporaryFolder = value;
            }
        }
    }
}
