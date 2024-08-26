using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// catalogo de formas de pago
    /// </summary>
    public interface IFormaPagoRepository : IRepositoryContext<CveFormaPago> {
        CveFormaPago Search(string findId);
    }
}
