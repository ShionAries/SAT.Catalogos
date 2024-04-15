using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Contracts {
    /// <summary>
    /// Catálogo derechos de paso.
    /// </summary>
    public interface IClaveDerechosDePasoCatalogo : IGenericCatalogo<CveDerechosDePaso> {
        CveDerechosDePaso Search(string findId);
    }
}
