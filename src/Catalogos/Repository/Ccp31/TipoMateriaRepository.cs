using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;
using System.Linq;

namespace Jaeger.SAT.Catalogos.Repository.Ccp31 {
    [JsonObject("item")]
    public class TipoMateriaRepository : RepositoryContext<CveTipoMateria>, ITipoMateriaRepository, IRepositoryGeneric {
        public TipoMateriaRepository(System.DateTime? lastUpdate = null) {
            Description = "Catálogo de Tipo Materia.";
            FileName = "CatCcp31TipoMateria.json";
            Version = "2.0";
            this.AddLastUpdate(lastUpdate);
        }

        public override CveTipoMateria Search(string query) {
            try {
                var search = this.Items.SingleOrDefault(it => it.Clave == query);
                if (search == null) {
                    return new CveTipoMateria() { Clave = query };
                }
                return search;
            } catch (System.Exception) {

            }
            return new CveTipoMateria() { Clave = query };
        }
    }
}
