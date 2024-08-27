using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp20 {
    /// <summary>
    /// Catálogo de puertos marítimos, estaciones aeroportuarias y estaciones férreas.
    /// </summary>
    public interface IEstacionesRepository : IRepositoryContext<CveEstaciones> {
        CveEstaciones Search(string findId);
    }
}
