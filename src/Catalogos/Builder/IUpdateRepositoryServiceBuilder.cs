using Jaeger.SAT.Catalogos.Scraping.Helpers;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;
using Jaeger.SAT.Catalogos.Scraping.ValueObjects;

namespace Jaeger.SAT.Catalogos.Builder {
    public interface IUpdateRepositoryServiceBuilder {
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