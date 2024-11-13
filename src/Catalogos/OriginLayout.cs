namespace Jaeger.SAT.Catalogos {
    /// <summary>
    /// layout de origen
    /// </summary>
    public class OriginLayout : Scraping.Abstracts.OriginResource {
        /// <summary>
        /// constructor
        /// </summary>
        public OriginLayout() { }

        /// <summary>
        /// obtener o establecer link de descarga del recurso
        /// </summary>
        public override string DownloadUrl { get; set; }

        /// <summary>
        /// obtener o establecer nombre de la instancia 
        /// </summary>
        public string Type { get; set; }

        public int Hash {
            get { return this.GetHashCode(); }
        }
    }
}
