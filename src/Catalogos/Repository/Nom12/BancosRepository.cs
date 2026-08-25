using System.Linq;

namespace Jaeger.SAT.Catalogos.Repository.Nom12 {
    /// <summary>
    /// Nom12: catalogo de bancos SAT
    /// </summary>
    public class BancosRepository : RepositoryContext<CveBanco>, IBancosRepository, Interfaces.IRepositoryGeneric {
        public BancosRepository() {
            Description = "Catálogo de Bancos SAT";
            FileName = "CatNom12Bancos.json";
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
