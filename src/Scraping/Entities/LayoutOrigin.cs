namespace Jaeger.SAT.Catalogos.Scraping.Entities {
    public class LayoutOrigin : Abstracts.OriginResource {
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
