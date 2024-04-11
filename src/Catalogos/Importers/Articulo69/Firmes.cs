using System;
using MiniExcelLibs.Attributes;

namespace Jaeger.SAT.Catalogos.Importers.Articulo69 {
    public class Firmes {
        [ExcelColumnName("RFC")]
        public string RFC { get; set; }

        [ExcelColumnName("RAZÓN SOCIAL")]
        public string RazonSocial { get; set; }

        [ExcelColumnName("TIPO PERSONA")]
        public string TipoPersona { get; set; }

        [ExcelColumnName("SUPUESTO")]
        public string Supuesto { get; set; }

        [ExcelColumnName("FECHAS DE PRIMERA PUBLICACION")]
        public DateTime Fechas { get; set; }

        [ExcelColumnName("ENTIDAD FEDERATIVA")]
        public string Entidad { get; set; }
    }
}
