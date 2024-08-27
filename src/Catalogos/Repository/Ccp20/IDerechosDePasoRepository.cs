using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp20 {
    /// <summary>
    /// Catálogo derechos de paso.
    /// </summary>
    public interface IDerechosDePasoRepository : IRepositoryContext<CveDerechosDePaso> {
        CveDerechosDePaso Search(string findId);
    }
}
