using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;

namespace Jaeger.SAT.Catalogos {
    /// <summary>
    /// Clase para el servicio de gestión y persistencia de orígenes.
    /// </summary>
    public class OriginService : OriginsTranslator, IOriginService {
        #region Campos Privados y Estáticos

        private static readonly Encoding Utf8WithoutBom = new UTF8Encoding(false);

        private static readonly JsonSerializerSettings JsonSettings = new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore,
            DateFormatString = "dd/MM/yyyy"
        };

        #endregion

        #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="OriginService"/> con la configuración especificada.
        /// </summary>
        /// <param name="configuration">Configuración del servicio.</param>
        public OriginService(IConfiguration configuration) {
            Configuration = configuration ?? new Configuration();
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="OriginService"/> con la configuración por defecto.
        /// </summary>
        public OriginService() : this(new Configuration()) {
        }

        #endregion

        #region Propiedades

        /// <summary>
        /// Obtiene o establece el control de layout actual.
        /// </summary>
        public ControlLayout Control { get; set; }

        /// <summary>
        /// Obtiene o establece la configuración del servicio.
        /// </summary>
        public IConfiguration Configuration { get; set; }

        /// <summary>
        /// Obtiene o establece la lista de orígenes de datos actuales.
        /// </summary>
        public List<IOrigin> DataSource { get; set; }

        #endregion

        #region Métodos Públicos

        /// <summary>
        /// Carga la configuración del archivo local y obtiene la lista de orígenes.
        /// </summary>
        public IOriginService GetAll() {
            Control = OriginsFromString();

            if (Control == null) {
                Control = new ControlLayout {
                    Configuration = (Configuration)Configuration
                };
            }

            DataSource = OriginFromLayout(Control.Origins);
            return this;
        }

        /// <summary>
        /// Almacena los datos del catálogo en el archivo de persistencia local.
        /// </summary>
        public IOriginService Save() {
            WriteFile();
            return this;
        }

        #endregion

        #region Métodos Protegidos (Builder / I/O)

        /// <summary>
        /// Construye la ruta completa del archivo de control basándose en la configuración.
        /// </summary>
        protected string BuildPath() {
            if (Configuration == null)
                throw new InvalidOperationException("La configuración no se encuentra inicializada.");

            return Path.Combine(Configuration.WorkingFolder ?? string.Empty, Configuration.FileName ?? string.Empty);
        }

        /// <summary>
        /// Deserializa una cadena JSON al objeto <see cref="ControlLayout"/>.
        /// </summary>
        protected ControlLayout ReadOrigin(string content) {
            if (string.IsNullOrWhiteSpace(content))
                return null;

            try {
                return JsonConvert.DeserializeObject<ControlLayout>(content, JsonSettings);
            } catch (Exception ex) {
                // NOTA: Se recomienda reemplazar Console.WriteLine por un sistema de Logging (p. ej. ILogger)
                Console.WriteLine($"Error al deserializar el archivo de control: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Lee y deserializa el archivo de origen desde la ruta configurada.
        /// </summary>
        protected ControlLayout OriginsFromString() {
            string path = BuildPath();

            if (!File.Exists(path))
                return null;

            string content = File.ReadAllText(path, Utf8WithoutBom);
            return ReadOrigin(content);
        }

        /// <summary>
        /// Serializa y escribe el estado actual en el archivo de control.
        /// </summary>
        protected void WriteFile() {
            string path = BuildPath();

            // Garantizar que la carpeta de destino exista antes de intentar escribir
            string folder = Path.GetDirectoryName(path);
            if (!string.IsNullOrEmpty(folder) && !Directory.Exists(folder)) {
                Directory.CreateDirectory(folder);
            }

            Control = new ControlLayout {
                Configuration = (Configuration)Configuration,
                Origins = OriginToLayout(DataSource)
            };

            string jsonContent = JsonConvert.SerializeObject(Control, Formatting.Indented, JsonSettings);
            File.WriteAllText(path, jsonContent, Utf8WithoutBom);
        }

        #endregion
    }
}