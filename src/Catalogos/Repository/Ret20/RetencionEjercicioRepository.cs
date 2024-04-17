using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ret20 {
    /// <summary>
    /// Retenciones 2.0, Catalogo de Ejercicio
    /// </summary>
    public class RetencionEjercicioRepository : RepositoryContext<CveRetencionEjercicio>, IRetencionEjercicioRepository, IGeneralRepository {
        public RetencionEjercicioRepository() {
            Title = "Retenciones: Catálogo Ejercicio";
            FileName = "EjercicioRet20.json";
            Version = "1.0";
            Revision = "0";
        }
    }
}
