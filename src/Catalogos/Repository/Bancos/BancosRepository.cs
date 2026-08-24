using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Bancos {
    public class BancosRepository : RepositoryContext<ClaveBanco>, IBancosRepository, IRepositoryGeneric {
        public BancosRepository() {
            this.Description = "Catálogo de Bancos SAT";
            this.FileName = "CatalogoBancos.json";
        }

        public override ClaveBanco Search(string findId) {
            var objeto = new ClaveBanco();
            objeto = this.Items.SingleOrDefault((ClaveBanco p) => p.Clave == findId);
            return objeto;
        }
    }
}
