using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Nom12 {
    public class BancosRepository : RepositoryContext<CveBanco>, IBancosRepository, IGeneralRepository {
        public BancosRepository(System.DateTime? lastUpdate = null) {
            Title = "Catálogo de Bancos SAT";
            FileName = "CatNom12Bancos.json";
            this.AddLastUpdate(lastUpdate);
        }

        public CveBanco Search(string findId) {
            var objeto = new CveBanco();
            objeto = Items.SingleOrDefault((p) => p.Clave == findId);
            return objeto;
        }
    }
}
