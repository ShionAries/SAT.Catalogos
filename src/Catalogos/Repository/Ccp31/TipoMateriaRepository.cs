using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp31 {
    [JsonObject("item")]
    public class TipoMateriaRepository : RepositoryContext<CveTipoMateria>, ITipoMateriaRepository, IGeneralRepository {
        public TipoMateriaRepository(System.DateTime? lastUpdate = null) {
            Title = "Catálogo de Tipo Materia.";
            FileName = "CatCcp31TipoMateria.json";
            Version = "2.0";
            this.AddLastUpdate(lastUpdate);
        }
    }
}
