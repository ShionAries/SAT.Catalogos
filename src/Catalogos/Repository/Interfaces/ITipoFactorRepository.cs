using Jaeger.SAT.Catalogos.Repository.Entities;

namespace Jaeger.SAT.Catalogos.Repository.Interfaces {
    /// <summary>
    /// Catálogo tipo de factor para impuestos en CFDI 3.3
    /// </summary>
    public interface ITipoFactorRepository : IRepositoryContext<ClaveTipoFactor> {
        ClaveTipoFactor Search(string findId);
    }
}
