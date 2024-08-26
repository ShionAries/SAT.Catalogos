using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Nomina {
    /// <summary>
    /// catalogo de tipos de horas extra (nomina)
    /// </summary>
    public class TipoHorasRepository : RepositoryContext<ClaveTipoHoras>, ITipoHorasRepository, IGeneralRepository {
        public TipoHorasRepository() {
            this.Title = "Catálogo de tipos de Hora Extra.";
            this.FileName = "CatalogoNominaTipoHoras.json";
            this.Version = "1.0";
        }
    }
}
