namespace Jaeger.SAT.Catalogos.Scraping.Entities {
    /// <summary>
    /// layout de origen
    /// </summary>
    public class LayoutOrigin : Abstracts.OriginResource {
        /// <summary>
        /// constructor
        /// </summary>
        public LayoutOrigin() { }

        /// <summary>
        /// obtener o establecer link de descarga del recurso
        /// </summary>
        public override string DownloadUrl { get; set; }

        /// <summary>
        /// obtener o establecer nombre de la instancia 
        /// </summary>
        public string Type {  get; set; }
    }
}
