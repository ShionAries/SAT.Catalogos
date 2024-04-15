using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Contracts {
    /// <summary>
    /// Catálogo de puertos marítimos, estaciones aeroportuarias y estaciones férreas.
    /// </summary>
    public interface IClaveEstacionesCatalogo : IGenericCatalogo<CveEstaciones> {
        CveEstaciones Search(string findId);
    }
}
