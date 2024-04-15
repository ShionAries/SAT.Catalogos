using System;
using System.Linq;
using System.Text.RegularExpressions;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Entities;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository {
    /// <summary>
    /// Catalogo de periodicidad para comprobante fiscal 4.0
    /// </summary>
    public class PeriodicidadRepository : RepositoryContext<ClavePeriodicidad>, IPeriodicidadRepository , IGeneralRepository {
        public PeriodicidadRepository() {
            this.Title = "Catalogo Exportación";
            this.FileName = "PeriodicidadCatalogo.json";
            this.Version = "1.0";
        }

        //public override void Load() {
        //    this.Items = new System.Collections.Generic.List<ClavePeriodicidad> {
        //        new ClavePeriodicidad { Clave = "01", Descripcion = "Diario", VigenciaIni = new System.DateTime(2022, 1, 1) },
        //        new ClavePeriodicidad { Clave = "02", Descripcion = "Semanal", VigenciaIni = new System.DateTime(2022, 1, 1) },
        //        new ClavePeriodicidad { Clave = "03", Descripcion = "Quincenal", VigenciaIni = new System.DateTime(2022, 1, 1) },
        //        new ClavePeriodicidad { Clave = "04", Descripcion = "Mensual", VigenciaIni = new System.DateTime(2022, 1, 1) },
        //        new ClavePeriodicidad { Clave = "05", Descripcion = "Bimestral", VigenciaIni = new System.DateTime(2022, 1, 1) },
        //    };
        //}

        public ClavePeriodicidad Search(string findId) {
            string str = Regex.Replace(findId, "[^\\d]", "");
            try {
                var _response = new ClavePeriodicidad();
                _response = this.Items.SingleOrDefault((ClavePeriodicidad p) => p.Clave == str);
                return _response;
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return new ClavePeriodicidad { Clave = findId };
        }
    }
}
