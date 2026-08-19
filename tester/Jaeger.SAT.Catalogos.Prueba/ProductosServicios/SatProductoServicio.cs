using System;

namespace Jaeger.SAT.Catalogos.Prueba.ProductosServicios {
    public sealed class SatProductoServicio {
        public string ClaveProdServ { get; set; }

        public string Descripcion { get; set; }

        public string IncluirIvaTrasladado { get; set; }

        public string IncluirIepsTrasladado { get; set; }

        public string Complemento { get; set; }

        public override string ToString() {
            return string.Format(
                "{0} - {1}",
                ClaveProdServ,
                Descripcion);
        }
    }
}