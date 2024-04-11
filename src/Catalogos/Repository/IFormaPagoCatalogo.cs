using Jaeger.SAT.Catalogos.Repository.Entities;

namespace Jaeger.SAT.Catalogos.Repository {
    public interface IFormaPagoCatalogo : ICatalogoGeneric<ClaveFormaPago> {
        ClaveFormaPago Search(string findId);
    }
}
