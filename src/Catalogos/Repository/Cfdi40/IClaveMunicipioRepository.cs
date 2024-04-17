using Jaeger.SAT.Catalogos.Repository.Cfdi40;

namespace Jaeger.SAT.Catalogos.Repository.Interfaces {
    /// <summary>
    /// Catálogo de municipios.
    /// </summary>
    public interface IClaveMunicipioRepository : IRepositoryContext<CveMunicipio> {
        CveMunicipio Search(string findId);
    }
}
