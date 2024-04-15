using System;
using System.Linq;
using Jaeger.Catalogos.Entities;
using Jaeger.Catalogos.Contracts;
using Jaeger.Catalogos.Abstractions;
using System.Text.RegularExpressions;

namespace Jaeger.Catalogos.Repositories {
    /// <summary>
    /// Catalogo de periodicidad para comprobante fiscal 4.0
    /// </summary>
    public class PeriodicidadCatalogo : CatalogoContext<ClavePeriodicidad>, IPeriodicidadCatalogo {
        public PeriodicidadCatalogo() {
            this.Title = "Catalogo Exportación";
            this.FileName = "PeriodicidadCatalogo.json";
            this.Version = "1.0";
        }

        public override void Load() {
            this.Items = new System.Collections.Generic.List<ClavePeriodicidad> {
                new ClavePeriodicidad { Clave = "01", Descripcion = "Diario", VigenciaIni = new System.DateTime(2022, 1, 1) },
                new ClavePeriodicidad { Clave = "02", Descripcion = "Semanal", VigenciaIni = new System.DateTime(2022, 1, 1) },
                new ClavePeriodicidad { Clave = "03", Descripcion = "Quincenal", VigenciaIni = new System.DateTime(2022, 1, 1) },
                new ClavePeriodicidad { Clave = "04", Descripcion = "Mensual", VigenciaIni = new System.DateTime(2022, 1, 1) },
                new ClavePeriodicidad { Clave = "05", Descripcion = "Bimestral", VigenciaIni = new System.DateTime(2022, 1, 1) },
            };
        }

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
