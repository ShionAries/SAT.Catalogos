using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Nom12 {
    /// <summary>
    /// catalogo de tipos de nomina
    /// </summary>
    public class TipoNominaRepository : RepositoryContext<CveTipoNomina>, ITipoNominaRepository, IGeneralRepository {
        public TipoNominaRepository(System.DateTime? lastUpdate = null) {
            Title = "Catálogo de tipos de nómina.";
            FileName = "CatNom12Tipos.json";
            this.AddLastUpdate(lastUpdate);
        }
    }
}
