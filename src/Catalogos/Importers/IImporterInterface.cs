using Jaeger.SAT.Catalogos.Database;

namespace Jaeger.SAT.Catalogos.Importers {
    public interface IImporterInterface {
        void import(string source, Repository repository, string logger);
    }
}
