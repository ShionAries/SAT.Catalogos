using Jaeger.SAT.Catalogos.Update.Importers;

namespace Jaeger.SAT.Catalogos {
    public class UpdateRepository {
        public UpdateRepository() { this.SourceFolder = @"C:\Jaeger\Jaeger.Temporal"; }

        public UpdateRepository(string sourceFolder) {
            SourceFolder = sourceFolder;
        }

        public string SourceFolder { get; set; }

        #region
        public UpdateRepository WithFolderSource(string sourceFolder) {
            this.SourceFolder = sourceFolder;
            return this;
        }

        public UpdateRepository AddImporter(IImporter importer) {
            return this;
        }

        public int Run() {
            return 0;
        }
        #endregion
    }
}
