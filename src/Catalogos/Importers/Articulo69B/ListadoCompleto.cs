using System;
using MiniExcelLibs.Attributes;

namespace Jaeger.SAT.Catalogos.Importers.Articulo69B {
    internal class ListadoCompleto {
        [ExcelColumnName("No")]
        public int No { get; set; }

        [ExcelColumnName("RFC")]
        public string RFC { get; set; }

        [ExcelColumnName("Nombre del Contribuyente")]
        public string NombreContribuyente { get; set; }

        [ExcelColumnName("Situación del contribuyente")]
        public string Situcion { get; set; }

        [ExcelColumnName("Número y fecha de oficio global de presunción SAT")]
        public string NumeroFechaOficio { get; set; }

        [ExcelColumnName("Publicación página SAT presuntos")]
        public string Publicacion1 { get; set; }

        [ExcelColumnName("Número y fecha de oficio global de presunción DOF")]
        public string NumeroFechaOficio1 { get; set; }

        [ExcelColumnName("Publicación DOF presuntos")]
        public string Publicacion2{ get; set; }
    }
}
