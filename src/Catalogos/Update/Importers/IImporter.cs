namespace Jaeger.SAT.Catalogos.Update.Importers {
    /// <summary>
    /// interfaz de importador de catalogos
    /// </summary>
    public interface IImporter {
        /// <summary>
        /// obtener o establecer el origen de datos
        /// </summary>
        Scraping.Interfaces.IOrigin Origin { get; set; }

        /// <summary>
        /// obtener o establecer la ultima version importada
        /// </summary>
        System.DateTime? LastVersion { get; set; }

        /// <summary>
        /// obtener o establecer nombre del archivo a importar
        /// </summary>
        string FileName { get; set; }

        /// <summary>
        /// obtener si el archivo a importar existe
        /// </summary>
        /// <returns></returns>
        bool CheckFile();

        /// <summary>
        /// proceso de importacion
        /// </summary>
        void Import();
    }
}
