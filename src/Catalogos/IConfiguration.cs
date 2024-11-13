namespace Jaeger.SAT.Catalogos {
    /// <summary>
    /// clase para configuracion del servicio
    /// </summary>
    public interface IConfiguration {
        /// <summary>
        /// obtener o establecer nombre del archivo del control de origenes
        /// </summary>
        string FileName { get; set; }

        /// <summary>
        /// obtener o establecer ruta completa de archivo log
        /// </summary>
        string LogFileName { get; set; }

        /// <summary>
        /// obtener o establecer folder temporal de trabajo
        /// </summary>
        string WorkingFolder { get; set; }
    }
}
