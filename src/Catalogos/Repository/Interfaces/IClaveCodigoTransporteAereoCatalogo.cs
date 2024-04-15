using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Contracts {
    /// <summary>
    /// Catálogo código transporte aéreo.
    /// </summary>
    public interface IClaveCodigoTransporteAereoCatalogo : IGenericCatalogo<CveCodigoTransporteAereo> {
        CveCodigoTransporteAereo Search(string findId);
    }
}
