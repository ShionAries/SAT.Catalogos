using System;

namespace Jaeger.SAT.Catalogos.Repository.Interfaces {
    /// <summary>
    /// Interface para clave SAT simple con vigencia
    /// </summary>
    public interface IClaveBaseVigencia {
        DateTime? VigenciaIni { get; set; }
        DateTime? VigenciaFin { get; set; }
    }
}
