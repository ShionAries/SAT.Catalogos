using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Contracts {
    /// <summary>
    /// Catálogo de tipo de carro.
    /// </summary>
    public interface IClaveTipoCarroCatalogo : IGenericCatalogo<CveTipoCarro> {
        CveTipoCarro Search(string findId);
    }
}
