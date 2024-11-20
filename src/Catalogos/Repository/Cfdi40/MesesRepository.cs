using System;
using System.Text.RegularExpressions;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// catalogo de meses para comprobante fiscal 4.0
    /// </summary>
    public class MesesRepository : RepositoryContext<CveMeses>, IMesesRepository, IRepositoryGeneric {
        public MesesRepository(System.DateTime? lastUpdate = null) {
            Description = "Catalogo Meses";
            FileName = "MesesCFDI40.json";
            Version = "1.0";
            this.AddLastUpdate(lastUpdate);
        }

        public override CveMeses Search(string findId) {
            string str = Regex.Replace(findId, "[^\\d]", "");
            try {
                var search = Items.SingleOrDefault((p) => p.Clave == str);
                if (search == null) {
                    return new CveMeses { Clave = str };
                }
                return search;
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return new CveMeses { Clave = findId };
        }

        //public override void Load() {
        //    this.Items = new System.Collections.Generic.List<ClaveMeses> {
        //        new ClaveMeses { Clave = "01", Descripcion = "Enero", VigenciaIni = new DateTime(2022, 1, 1) },
        //        new ClaveMeses { Clave = "02", Descripcion = "Febrero", VigenciaIni = new DateTime(2022, 1, 1) },
        //        new ClaveMeses { Clave = "03", Descripcion = "Marzo", VigenciaIni = new DateTime(2022, 1, 1) },
        //        new ClaveMeses { Clave = "04", Descripcion = "Abril", VigenciaIni = new DateTime(2022, 1, 1) },
        //        new ClaveMeses { Clave = "05", Descripcion = "Mayo", VigenciaIni = new DateTime(2022, 1, 1) },
        //        new ClaveMeses { Clave = "06", Descripcion = "Junio", VigenciaIni = new DateTime(2022, 1, 1) },
        //        new ClaveMeses { Clave = "07", Descripcion = "Julio", VigenciaIni = new DateTime(2022, 1, 1) },
        //        new ClaveMeses { Clave = "08", Descripcion = "Agosto", VigenciaIni = new DateTime(2022, 1, 1) },
        //        new ClaveMeses { Clave = "09", Descripcion = "Septiembre", VigenciaIni = new DateTime(2022, 1, 1) },
        //        new ClaveMeses { Clave = "10", Descripcion = "Octibre", VigenciaIni = new DateTime(2022, 1, 1) },
        //        new ClaveMeses { Clave = "11", Descripcion = "Noviembre", VigenciaIni = new DateTime(2022, 1, 1) },
        //        new ClaveMeses { Clave = "12", Descripcion = "Diciembre", VigenciaIni = new DateTime(2022, 1, 1) },
        //        new ClaveMeses { Clave = "13", Descripcion = "Enero-Febrero", VigenciaIni = new DateTime(2022, 1, 1) },
        //        new ClaveMeses { Clave = "14", Descripcion = "Marzo-Abril", VigenciaIni = new DateTime(2022, 1, 1) },
        //        new ClaveMeses { Clave = "15", Descripcion = "Mayo-Junio", VigenciaIni = new DateTime(2022, 1, 1) },
        //        new ClaveMeses { Clave = "16", Descripcion = "Julio-Agosto", VigenciaIni = new DateTime(2022, 1, 1) },
        //        new ClaveMeses { Clave = "17", Descripcion = "Septiembre-Octubre", VigenciaIni = new DateTime(2022, 1, 1) },
        //        new ClaveMeses { Clave = "18", Descripcion = "Noviembre-Diciembre", VigenciaIni = new DateTime(2022, 1, 1) }
        //    };
        //}
    }
}
