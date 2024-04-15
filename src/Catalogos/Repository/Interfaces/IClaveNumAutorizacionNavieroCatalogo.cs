using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Contracts {
    /// <summary>
    /// Catálogo de número autorización agente naviero consignatario. 
    /// </summary>
    public interface IClaveNumAutorizacionNavieroCatalogo : IGenericCatalogo<CveNumAutorizacionNaviero> {
        CveNumAutorizacionNaviero Search(string findId);
    }
}
