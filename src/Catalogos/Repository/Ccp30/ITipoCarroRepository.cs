using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp30 {
    /// <summary>
    /// Catálogo de tipo de carro.
    /// </summary>
    public interface ITipoCarroRepository : IRepositoryContext<CveTipoCarro> {
        CveTipoCarro Search(string findId);
    }
}
