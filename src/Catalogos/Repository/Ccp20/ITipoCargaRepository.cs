using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp20 {
    /// <summary>
    /// Catálogo del tipo de carga.
    /// </summary>
    public interface ITipoCargaRepository : IRepositoryContext<CveTipoCarga> {
        CveTipoCarga Search(string findId);
    }
}
