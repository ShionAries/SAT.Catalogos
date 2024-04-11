using Jaeger.SAT.Catalogos.Abstractions;
using Jaeger.SAT.Catalogos.Entities;

namespace Jaeger.SAT.Catalogos.Database {
    public interface IFormaPagoCatalogo : ICatalogoGeneric<ClaveFormaPago> {
        ClaveFormaPago Search(string findId);
    }
}
