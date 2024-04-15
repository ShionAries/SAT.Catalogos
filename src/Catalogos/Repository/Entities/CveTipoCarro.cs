using Jaeger.Catalogos.Contracts;

namespace Jaeger.Catalogos.Entities {
    /// <summary>
    /// Catálogo de tipo de carro.
    /// </summary>
    public class CveTipoCarro : ClaveBaseVigencia, IClaveBaseItem {
        public int Contenedor { get; set; }
    }
}
