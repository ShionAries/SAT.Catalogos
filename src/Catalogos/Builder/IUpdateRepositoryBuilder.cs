using Jaeger.SAT.Catalogos.Scraping.Interfaces;

namespace Jaeger.SAT.Catalogos.Builder {
    /// <summary>
    /// interfaz para constructor de servicios de actualizacion de repositorios
    /// </summary>
    public interface IUpdateRepositoryBuilder {
        IUpdateRepositoryServiceOriginBuilder Origin(IOrigin origin);
    }

    /// <summary>
    /// interfaz para constructor de servicios de origenes de actualizacion de repositorios
    /// </summary>
    public interface IUpdateRepositoryServiceSourceBuilder { }

    /// <summary>
    /// interfaz para constructor de servicios de origen de actualizacion de repositorios
    /// </summary>
    public interface IUpdateRepositoryServiceOriginBuilder {
        IUpdateRepositoryServiceImportBuilder Import();
    }

    /// <summary>
    /// interfaz para constructor de servicios de importacion de actualizacion de repositorios
    /// </summary>
    public interface IUpdateRepositoryServiceImportBuilder { }
}