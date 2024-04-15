namespace Jaeger.SAT.Catalogos.Update.Importers {
    public interface IImporter {
        string _FileSource { get; set; }
        bool CheckFile();
        void Import(Helpers.ILogger logger);
    }
}
