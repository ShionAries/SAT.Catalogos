using Jaeger.SAT.Catalogos.Repository.Entities;

namespace Jaeger.SAT.Catalogos.Repository.Interfaces {
    /// <summary>
    /// Catálogo de localidades. 
    /// </summary>
    public interface IClaveLocalidadRepository : IRepositoryContext<CveLocalidad> {
        CveLocalidad Search(string findId);
    }
}
