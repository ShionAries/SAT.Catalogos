using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Nom12 {
    /// <summary>
    /// Nomina Catalogo de tipos de deducciones
    /// </summary>
    public class TipoDeduccionRepository : RepositoryContext<CveTipoDeduccion>, ITipoDeduccionRepository, IGeneralRepository {
        public TipoDeduccionRepository() {
            Title = "Catálogo de tipos de deducciones.";
            FileName = "CatNom12TipoDeduccion.json";
            Version = "3.0";
            Revision = "0";
        }
    }
}
