using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Contracts {
    /// <summary>
    /// Catálogo de partes del transporte rentadas o prestadas.
    /// </summary>
    public interface IClaveParteTransporteCatalogo : IGenericCatalogo<CveParteTransporte> {
        CveParteTransporte Search(string findId);
    }
}
