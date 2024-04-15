using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Contracts {
    public interface ICertificadosCatalogo : IGenericCatalogo<Certificate> {
        Certificate Search(string serial);
    }
}
