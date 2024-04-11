using System;
using Jaeger.SAT.Catalogos.Importers;

namespace Jaeger.SAT.Catalogos {
    public class UpdateDatabase {
        private string _SourceFolder;

        public UpdateDatabase(string sourceFolder) {
            this.SourceFolder = sourceFolder;
        }

        /// <summary>
        /// obtener o establecer la carpeta donde estan los archivos de origen
        /// </summary>
        public string SourceFolder {
            get { return this._SourceFolder; }
            set {
                if (string.IsNullOrEmpty(value)) {
                    throw new ArgumentNullException("Invalid source catalog: empty string received");
                }

                if (!Helpers.DirectoryService.IsDirectory(value)) {
                    throw new ArgumentException("Invalid source catalog: is not a directory");
                }
                this._SourceFolder = value;
            }
        }

        public int Run() {
            var importer = this.CreateImporter();
            importer.Import(this.SourceFolder, "");
            Console.WriteLine("Se terminó correctamente con la actualización de la base de datos");
            return 0;
        }

        public SourcesImporter CreateImporter() {
            return new SourcesImporter();
        }
    }
}
