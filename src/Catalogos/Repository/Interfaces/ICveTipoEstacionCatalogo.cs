using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Contracts {
    public interface ICveTipoEstacionCatalogo : IGenericCatalogo<CveTipoEstacion> {
        CveTipoEstacion Search(string findId);
    }
}
