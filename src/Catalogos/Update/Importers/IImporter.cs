namespace Jaeger.SAT.Catalogos.Update.Importers {
    public interface IImporter {
        System.DateTime? LastVersion { get; set; }
        string FileName { get; set; }

        bool CheckFile();

        void Import();
    }
}
