using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Entities;
using Jaeger.SAT.Catalogos.Repository.Interfaces;
using System.Linq;
namespace Jaeger.SAT.Catalogos.Repository {
    public class PaisesRepository : RepositoryContext<ClavePais>, IPaisesRepository, IGeneralRepository {
        public PaisesRepository() {
            this.Title = "Catálogo de Paises";
            this.FileName = "CatalogoPaises.json";
            this.Version = "1.0";
        }

        public ClavePais Search(string findId) {
            ClavePais objeto = new ClavePais();
            objeto = this.Items.SingleOrDefault((ClavePais p) => p.Clave == findId);
            return objeto;
        }
    }
}
