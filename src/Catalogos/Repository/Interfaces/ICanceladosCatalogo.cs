using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Contracts {
    public interface ICanceladosCatalogo : IGenericCatalogo<Cancelados> {
        Cancelados Search(string findId);
    }
}
