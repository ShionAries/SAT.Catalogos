using System;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;
using Jaeger.SAT.Catalogos.Update.Importers;

namespace Jaeger.SAT.Catalogos.Builder {
    /// <summary>
    /// clase para constructor de servicios de actualizacion de repositorios
    /// </summary>
    public class UpdateRepositoryBuilder : ConfigurationService, IUpdateRepositoryBuilder, IUpdateRepositoryServiceSourceBuilder, IUpdateRepositoryServiceOriginBuilder, IUpdateRepositoryServiceImportBuilder {
        #region declaraciones
        private IImporter importer;
        private IOrigin origin;
        #endregion

        #region constructor
        /// <summary>
        /// constructor
        /// </summary>
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

        /// <summary>
        /// metodo para definir el origen de datos
        /// </summary>
        /// <param name="origin">interface de origen</param>
        /// <returns></returns>
        public IUpdateRepositoryServiceOriginBuilder Origin(IOrigin origin) {
            this.origin = origin;
            return this;
        }

        /// <summary>
        /// metodo para definir la importacion de datos
        /// </summary>
        /// <returns></returns>
        public IUpdateRepositoryServiceImportBuilder Import() {
            object[] parameters = new object[] { this.origin, this.Configuration };
            this.importer = (IImporter)Activator.CreateInstance(this.origin.Importer, parameters);
            this.importer.Origin = origin;
            this.importer.Import();
            return this;
        }
    }
}