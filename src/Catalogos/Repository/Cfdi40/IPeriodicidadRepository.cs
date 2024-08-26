using Jaeger.SAT.Catalogos.Repository.Cfdi40;

namespace Jaeger.SAT.Catalogos.Repository.Interfaces {
    /// <summary>
    /// Catalogo de periodicidad para comprobante fiscal 4.0
    /// </summary>
    public interface IPeriodicidadRepository : IRepositoryContext<CvePeriodicidad> {
        CvePeriodicidad Search(string findId);
    }
}
