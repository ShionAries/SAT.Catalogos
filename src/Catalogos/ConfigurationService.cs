namespace Jaeger.SAT.Catalogos {
    /// <summary>
    /// clase para servicio de configuracion
    /// </summary>
    public class ConfigurationService {
        /// <summary>
        /// constructor
        /// </summary>
        public ConfigurationService() { 
            this.Configuration = new Configuration();
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="configuration"></param>
        public ConfigurationService(IConfiguration configuration) {
            this.Configuration = configuration;
        }

        /// <summary>
        /// obtener o establecer configuracion
        /// </summary>
        public IConfiguration Configuration { get; set; }

        /// <summary>
        /// obtener configuracion por default
        /// </summary>
        /// <returns></returns>
        public static IConfiguration ConfigurationDefault() {
            return new Configuration();
        }
    }
}
