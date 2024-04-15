using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Contracts {
    /// <summary>
    /// Catálogo de tipo de tráfico ferroviario.
    /// </summary>
    public interface IClaveTipoDeTraficoCatalogo : IGenericCatalogo<CveTipoDeTrafico> {
        CveTipoDeTrafico Search(string findId);
    }
}
