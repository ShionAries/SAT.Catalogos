using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Contracts {
    public interface INoLocalizadosCatalogo : IGenericCatalogo<NoLocalizado> {
        NoLocalizado Search(string findId);
    }
}
