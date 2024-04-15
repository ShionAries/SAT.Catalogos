using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Contracts {
    /// <summary>
    /// Catálogo de la clave del transporte.
    /// </summary>
    public interface IClaveTransporteCatalogo : IGenericCatalogo<CveTransporte> {
        CveTransporte Search(string findId);
    }
}
