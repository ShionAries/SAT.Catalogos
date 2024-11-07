namespace Jaeger.SAT.Catalogos {
    public class ConfigurationService {
        public IConfiguration Configuration { get; set; }

        public ConfigurationService() { 
            this.Configuration = new Configuration();
        }

        public ConfigurationService(IConfiguration configuration) {
            this.Configuration = configuration;
        }

        public static IConfiguration ConfigurationDefault() {
            return new Configuration();
        }
    }
}
