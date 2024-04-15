using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Contracts {
    /// <summary>
    /// Catálogo de configuración marítima.
    /// </summary>
    public interface IClaveConfigMaritimaCatalogo : IGenericCatalogo<CveConfigMaritima> {
        CveConfigMaritima Search(string findId);
    }
}
