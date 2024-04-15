using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Contracts {
    /// <summary>
    /// Catálogo del tipo de carga.
    /// </summary>
    public interface ICveClaveTipoCargaCatalogo : IGenericCatalogo<CveClaveTipoCarga> {
        CveClaveTipoCarga Search(string findId);
    }
}
