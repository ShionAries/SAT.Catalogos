using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp31 {
    /// <summary>
    /// catalogo de municipios.
    /// </summary>
    public interface IMunicipioRepository : IRepositoryContext<CveMunicipio> {
        CveMunicipio Search(string findId);
    }
}
