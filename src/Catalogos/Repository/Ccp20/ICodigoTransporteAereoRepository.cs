using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp20 {
    /// <summary>
    /// Catálogo código transporte aéreo.
    /// </summary>
    public interface ICodigoTransporteAereoRepository : IRepositoryContext<CveCodigoTransporteAereo> {
        CveCodigoTransporteAereo Search(string findId);
    }
}
