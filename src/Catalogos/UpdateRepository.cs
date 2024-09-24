using Jaeger.SAT.Catalogos.Update;
using Jaeger.SAT.Catalogos.Update.Importers;

namespace Jaeger.SAT.Catalogos {
    public class UpdateRepository {
        public UpdateRepository() { this.SourceFolder = @"C:\Jaeger\Jaeger.Temporal"; }

        public UpdateRepository(string sourceFolder) {
            SourceFolder = sourceFolder;
        }

        public UpdateRepository(Configuration configuration) {
            Configuration = configuration;
        }

        public Configuration Configuration { get; set; }

        public string SourceFolder { get; set; }

        public IImporter Importer { get; set; }

        #region
        public UpdateRepository WithFolderSource(string sourceFolder) {
            this.SourceFolder = sourceFolder;
            return this;
        }

        public UpdateRepository AddImporter(IImporter importer) {
            this.Importer = importer;
            return this;
        }

        public int Run() {
            if (this.Importer != null) {
                if (this.Importer.CheckFile()) {
                    this.Importer.Import(new Helpers.Logger());
                }
            }
            return 0;
        }
        #endregion
    }
}
