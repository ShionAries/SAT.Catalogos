using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Nom12 {
    public class BancosRepository : RepositoryContext<CveBanco>, IBancosRepository, IRepositoryGeneric {
        public BancosRepository(System.DateTime? lastUpdate = null) {
            Description = "Catálogo de Bancos SAT";
            FileName = "CatNom12Bancos.json";
            this.AddLastUpdate(lastUpdate);
        }

        public override CveBanco Search(string findId) {
            try {
                var search = this.Items.SingleOrDefault((p) => p.Clave == findId);
                if (search == null) {
                    return new CveBanco() { Clave = findId };
                }
                return search;
            } catch (System.Exception) {

            }
            return new CveBanco() { Clave = findId };
        }
    }
}
