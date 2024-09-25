namespace Jaeger.SAT.Catalogos.Update.Importers {
    public interface IImporter {
        string FileName { get; set; }

        bool CheckFile();

        void Import();
    }
}
