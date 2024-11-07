using Jaeger.SAT.Catalogos.Scraping.Interfaces;
using Jaeger.SAT.Catalogos.Scraping.ValueObjects;
using Jaeger.SAT.Catalogos.Update.Importers;

namespace Jaeger.SAT.Catalogos.Builder {
    public class UpdateRepositoryBuilder : ConfigurationService, IUpdateRepositoryBuilder, IUpdateRepositoryServiceSourceBuilder, IUpdateRepositoryServiceOriginBuilder, IUpdateRepositoryServiceImportBuilder {
        #region declaraciones
        private IImporter importer;
        private IOrigin origin;
        private SourceIdentifierEnum sourceIdentifier;
        #endregion

        #region constructor
        public UpdateRepositoryBuilder() : base() {
            this.Configuration = ConfigurationService.ConfigurationDefault();
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="configuration">objeto IConfiguration</param>
        public UpdateRepositoryBuilder(IConfiguration configuration, IOrigin origin, SourceIdentifierEnum source) : base(configuration) {
            this.origin = origin;
            this.sourceIdentifier=source;
        }
        #endregion

        public IUpdateRepositoryServiceSourceBuilder Update(SourceIdentifierEnum source) {
            this.importer = this.GetImporter(source);
            return this;
        }

        public IUpdateRepositoryServiceOriginBuilder Origin(IOrigin origin) {
            this.origin = origin;
            return this;
        }


        public IUpdateRepositoryServiceImportBuilder Import() {
            this.importer.Import();
            return this;
        }

        protected virtual IImporter GetImporter(SourceIdentifierEnum source) {
            switch (source) {
                case SourceIdentifierEnum.CFDIv33:
                    break;
                case SourceIdentifierEnum.CFDIv40:
                    return new Cfdi40Catalogos(this.Configuration);
                case SourceIdentifierEnum.RETv20:
                    break;
                case SourceIdentifierEnum.Nomina12:
                    break;
                case SourceIdentifierEnum.NominaEstados:
                    break;
                case SourceIdentifierEnum.Articulo69:
                    return new Articulo69Catalogos(this.Configuration);
                case SourceIdentifierEnum.Articulo69B:
                    return new Articulo69BCatalogos(this.Configuration) { FileName = this.origin.DestinationFilename, LastVersion = this.origin.LastVersion };
                case SourceIdentifierEnum.CPortev20:
                    break;
                case SourceIdentifierEnum.CPortev30:
                    break;
                case SourceIdentifierEnum.CPorteV31:
                    break;
                case SourceIdentifierEnum.REP:
                    break;
            }
            return null;
        }
    }
}