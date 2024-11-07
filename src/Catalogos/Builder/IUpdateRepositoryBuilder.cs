using Jaeger.SAT.Catalogos.Scraping.Interfaces;
using Jaeger.SAT.Catalogos.Scraping.ValueObjects;

namespace Jaeger.SAT.Catalogos.Builder {
    public interface IUpdateRepositoryBuilder {
        IUpdateRepositoryServiceOriginBuilder Origin(IOrigin origin);
    }

    public interface IUpdateRepositoryServiceSourceBuilder {
        IUpdateRepositoryServiceImportBuilder Import();
    }

    public interface IUpdateRepositoryServiceOriginBuilder {
        IUpdateRepositoryServiceSourceBuilder Update(SourceIdentifierEnum source);
    }

    public interface IUpdateRepositoryServiceImportBuilder {

    }
}