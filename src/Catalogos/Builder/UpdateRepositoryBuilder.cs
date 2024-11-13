using System;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;
using Jaeger.SAT.Catalogos.Update.Importers;

namespace Jaeger.SAT.Catalogos.Builder {
    public class UpdateRepositoryBuilder : ConfigurationService, IUpdateRepositoryBuilder, IUpdateRepositoryServiceSourceBuilder, IUpdateRepositoryServiceOriginBuilder, IUpdateRepositoryServiceImportBuilder {
        #region declaraciones
        private IImporter importer;
        private IOrigin origin;
        #endregion

        #region constructor
        public UpdateRepositoryBuilder() : base() {
            this.Configuration = ConfigurationService.ConfigurationDefault();
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="configuration">objeto IConfiguration</param>
        public UpdateRepositoryBuilder(IConfiguration configuration, IOrigin origin) : base(configuration) {
            this.origin = origin;
        }
        #endregion

        public IUpdateRepositoryServiceOriginBuilder Origin(IOrigin origin) {
            this.origin = origin;
            return this;
        }


        public IUpdateRepositoryServiceImportBuilder Import() {
            object[] parameters = new object[] { this.origin, this.Configuration };
            this.importer = (IImporter)Activator.CreateInstance(this.origin.Importer, parameters);
            this.importer.Origin = origin;
            this.importer.Import();
            return this;
        }
    }
}