// develop: 240220222107
// purpose: catalogo SAT
using System;
using Jaeger.Catalogos.Contracts;

namespace Jaeger.Catalogos.Entities {
    /// <summary>
    /// Catálogo de figura transporte.
    /// </summary>
    public class CveFiguraTransporte : ClaveBaseVigencia, IClaveBaseItem {
        public CveFiguraTransporte() { }
        public CveFiguraTransporte(string clave, string descripcion, DateTime? InicioVigencia, DateTime? FinVigencia = null) {
            this.Clave = clave; 
            this.Descripcion = descripcion; 
            this.VigenciaIni = InicioVigencia; 
            this.VigenciaFin = FinVigencia; 
        }

    }
}
