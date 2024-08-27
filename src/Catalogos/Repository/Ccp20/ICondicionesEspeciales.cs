using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp20 {
    /// <summary>
    /// Catalogo de Condiciones Especiales del Transporte
    /// </summary>
    public interface ICondicionesEspeciales : IRepositoryContext<CveCondicionesEspeciales> {
        CveCondicionesEspeciales Search(string findId);
    }
}
