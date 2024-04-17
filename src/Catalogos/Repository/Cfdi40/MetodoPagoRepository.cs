using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// catalogo de metodo de pago
    /// </summary>
    public class MetodoPagoRepository : RepositoryContext<CveMetodoPago>, IMetodoPagoRepository, IGeneralRepository {
        public MetodoPagoRepository() {
            Title = "Catálogo Metodo de Pago cfdi 4.0";
            FileName = "MetodoPagoCFDI40.json";
        }

        public CveMetodoPago Search(string findId) {
            CveMetodoPago objeto = new CveMetodoPago();
            objeto = Items.SingleOrDefault((p) => p.Clave == findId);
            return objeto;
        }
    }
}
