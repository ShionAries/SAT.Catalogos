namespace Jaeger.SAT.Catalogos.Importers {
    public interface IImporter {
        bool CheckFile();
        void Import(Helpers.ILoggerInterface logger);
    }
}
