using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Nom12 {
    /// <summary>
    /// catalogo de tipos de horas extra (nomina)
    /// </summary>
    public class TipoHorasRepository : RepositoryContext<CveTipoHoras>, ITipoHorasRepository, IGeneralRepository {
        public TipoHorasRepository(System.DateTime? lastUpdate = null) {
            this.Title = "Catálogo de tipos de Hora Extra.";
            this.FileName = "CatNom12TipoHoras.json";
            this.Version = "1.0";
            this.AddLastVersion(lastUpdate);
        }
    }
}
