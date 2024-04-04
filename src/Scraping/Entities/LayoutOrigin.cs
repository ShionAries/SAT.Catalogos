namespace Jaeger.SAT.Catalogos.Scraping.Entities {
    public class LayoutOrigin : Abstracts.OriginResource {
        public LayoutOrigin() { }

        public override string DownloadUrl { get; set; }

        public string Type {  get; set; }
    }
}
