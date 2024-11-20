using System.Linq;
using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp30 {
    [JsonObject("item")]
    public class TipoMateriaRepository : RepositoryContext<CveTipoMateria>, ITipoMateriaRepository, IRepositoryGeneric {
        public TipoMateriaRepository() {
            Description = "Catálogo de Tipo Materia.";
            FileName = "CatCcp30TipoMateria.json";
            Version = "2.0";
        }

        public override CveTipoMateria Search(string query) {
            try {
                var search = Items.SingleOrDefault((p) => p.Clave == query.Trim());
                if (search == null) {
                    return new CveTipoMateria { Clave = query };
                }
                return search;
            } catch (System.Exception ex) {
                System.Console.WriteLine(ex.Message);
            }
            return new CveTipoMateria { Clave = query };
        }
    }
}
