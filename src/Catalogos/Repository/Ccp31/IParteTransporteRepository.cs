using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp31 {
    /// <summary>
    /// Catálogo de partes del transporte rentadas o prestadas.
    /// </summary>
    public interface IParteTransporteRepository : IRepositoryContext<CveParteTransporte> {
        CveParteTransporte Search(string findId);
    }
}
