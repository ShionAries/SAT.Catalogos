namespace Jaeger.SAT.Catalogos.Update.Importers {
    public interface IImporter {
        string FileSource { get; set; }
        bool CheckFile();
        void Import(Helpers.ILogger logger);
    }
}
