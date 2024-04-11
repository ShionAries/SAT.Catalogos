namespace Jaeger.SAT.Catalogos.Update.Importers {
    public interface IImporter {
        bool CheckFile();
        void Import(Helpers.ILogger logger);
    }
}
