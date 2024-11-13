namespace Jaeger.SAT.Catalogos.Update.Importers {
    public interface IImporter {
        Scraping.Interfaces.IOrigin Origin { get; set; }
        System.DateTime? LastVersion { get; set; }
        string FileName { get; set; }

        bool CheckFile();

        void Import();
    }
}
