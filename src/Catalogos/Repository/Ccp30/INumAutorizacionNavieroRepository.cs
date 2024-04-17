using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp30 {
    /// <summary>
    /// Catálogo de número autorización agente naviero consignatario. 
    /// </summary>
    public interface INumAutorizacionNavieroRepository : IRepositoryContext<CveNumAutorizacionNaviero> {
        CveNumAutorizacionNaviero Search(string findId);
    }
}
