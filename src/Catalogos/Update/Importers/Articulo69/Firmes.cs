using System;
using Jaeger.SAT.Catalogos.Helpers.Mapping;

namespace Jaeger.SAT.Catalogos.Update.Importers.Articulo69 {
    public class Firmes {
        [DataNames("RFC")]
        public string RFC { get; set; }

        [DataNames("RAZÓN SOCIAL")]
        public string RazonSocial { get; set; }

        [DataNames("TIPO PERSONA")]
        public string TipoPersona { get; set; }

        [DataNames("SUPUESTO")]
        public string Supuesto { get; set; }

        [DataNames("FECHAS DE PRIMERA PUBLICACION")]
        public DateTime Fechas { get; set; }

        [DataNames("ENTIDAD FEDERATIVA")]
        public string Entidad { get; set; }
    }
}
