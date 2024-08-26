using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// catalogo SAT de codigos postales
    /// </summary>
    public interface ICodigosPostalesRepository : IRepositoryContext<CveCodigoPostal> {
        CveCodigoPostal Search(string find);
    }
}
