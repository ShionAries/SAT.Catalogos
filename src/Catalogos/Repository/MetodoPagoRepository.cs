using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Entities;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository {
    /// <summary>
    /// catalogo de metodo de pago
    /// </summary>
    public class MetodoPagoRepository : RepositoryContext<ClaveMetodoPago>, IMetodoPagoRepository , IGeneralRepository {
        public MetodoPagoRepository() {
            this.Title = "Catálogo Metodo de Pago cfdi 4.0";
            this.FileName = "CatalogoMetodoPago40.json";
        }

        public ClaveMetodoPago Search(string findId) {
            ClaveMetodoPago objeto = new ClaveMetodoPago();
            objeto = this.Items.SingleOrDefault((ClaveMetodoPago p) => p.Clave == findId);
            return objeto;
        }
    }
}
