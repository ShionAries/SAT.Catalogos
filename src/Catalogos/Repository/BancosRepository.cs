using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Entities;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository {
    public class BancosRepository : RepositoryContext<ClaveBanco>, IBancosRepository, IGeneralRepository {
        public BancosRepository() {
            Title = "Catálogo de Bancos SAT";
            FileName = "CatalogoBancos.json";
        }

        public ClaveBanco Search(string findId) {
            var objeto = new ClaveBanco();
            objeto = Items.SingleOrDefault((p) => p.Clave == findId);
            return objeto;
        }
    }
}
