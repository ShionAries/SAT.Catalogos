using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;
using Newtonsoft.Json;

namespace Jaeger.SAT.Catalogos.Repository.Ccp31 {
    [JsonObject("item")]
    public class TipoMateriaRepository : RepositoryContext<CveTipoMateria>, ITipoMateriaRepository, IGeneralRepository {
        public TipoMateriaRepository() {
            Title = "Catálogo de Tipo Materia.";
            FileName = "CatCcp31TipoMateria.json";
            Version = "2.0";
        }
    }
}
