using Jaeger.SAT.Catalogos.Repository.Entities;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Contracts {
    /// <summary>
    /// Catálogo de puertos marítimos, estaciones aeroportuarias y estaciones férreas.
    /// </summary>
    public interface IClaveEstacionesRepository : IRepositoryContext<CveEstaciones> {
        CveEstaciones Search(string findId);
    }
}
