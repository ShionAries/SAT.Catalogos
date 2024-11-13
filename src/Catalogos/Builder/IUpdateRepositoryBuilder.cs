using Jaeger.SAT.Catalogos.Scraping.Interfaces;
using Jaeger.SAT.Catalogos.Scraping.ValueObjects;

namespace Jaeger.SAT.Catalogos.Builder {
    public interface IUpdateRepositoryBuilder {
        IUpdateRepositoryServiceOriginBuilder Origin(IOrigin origin);
    }

    public interface IUpdateRepositoryServiceSourceBuilder {
    }

    public interface IUpdateRepositoryServiceOriginBuilder {
        IUpdateRepositoryServiceImportBuilder Import();
    }

    public interface IUpdateRepositoryServiceImportBuilder {

    }
}