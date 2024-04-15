using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Contracts {
    public interface ICodigoAgrupadorCatalogo : IGenericCatalogo<CodigoAgrupador> {
        CodigoAgrupador Search(string findId);
    }
}
