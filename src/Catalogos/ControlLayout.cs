using System.Collections.Generic;
using System.Reflection;

namespace Jaeger.SAT.Catalogos {
    /// <summary>
    /// clase para layout de control de origenes
    /// </summary>
    public class ControlLayout {
        /// <summary>
        /// constructor
        /// </summary>
        public ControlLayout() { 
            this.Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            this.Builder = Assembly.GetExecutingAssembly().GetName().Name.ToString();
        }

        /// <summary>
        /// obtener o establecer version del ensamblado
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// obtener o establecer nombre del ensamblado que construyo el archivo
        /// </summary>
        public string Builder { get; set; }

        /// <summary>
        /// obtener o establecer configuracion
        /// </summary>
        public Configuration Configuration { get; set; }

        /// <summary>
        /// obtener o establecer lista de origenes de datos
        /// </summary>
        public List<OriginLayout> Origins { get; set; }
    }
}
