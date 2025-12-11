namespace Jaeger.SAT.Catalogos.Update.Importers {
    /// <summary>
    /// clase abstracta para importador
    /// </summary>
    public abstract class AbstractImporter {
        /// <summary>
        /// constructor
        /// </summary>
        public AbstractImporter() { }

        #region propiedades
        /// <summary>
        /// obtener o establecer la ultima version del catalogo
        /// </summary>
        public System.DateTime? LastVersion { get; set; }

        /// <summary>
        /// obtener o establecer nombre del archivo del origen de los datos
        /// </summary>
        public string FileName { get; set; }
        #endregion
    }
}
