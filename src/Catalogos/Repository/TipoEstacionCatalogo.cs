using System;
using System.Linq;
using Jaeger.Catalogos.Abstractions;
using Jaeger.Catalogos.Contracts;
using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Repositories {
    /// <summary>
    /// Catálogo de tipo de estación.
    /// </summary>
    public class TipoEstacionCatalogo : CatalogoContext<CveTipoEstacion>, ICveTipoEstacionCatalogo {
        public TipoEstacionCatalogo() {
            this.Title = "Catálogo de tipo de estación.";
            this.FileName = "CatalogoCveTipoEstacion.json";
            this.Version = "1.0";
        }

        public CveTipoEstacion Search(string findId) {
            try {
                var search = new CveTipoEstacion();
                search = this.Items.SingleOrDefault((CveTipoEstacion p) => p.Clave == findId.Trim());
                if (search == null)
                    return new CveTipoEstacion { Clave = findId };
                return search;

            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return new CveTipoEstacion { Clave = findId };
        }

        public override void Load() {
            this.Items = new System.Collections.Generic.List<CveTipoEstacion> {
                new CveTipoEstacion { Clave = "01", Descripcion = "Origen Nacional", ClaveTranspote = "02, 03 y 04", VigenciaIni = new DateTime(2021, 6, 1) },
                new CveTipoEstacion { Clave = "02", Descripcion = "Intermedia", ClaveTranspote = "02, 03 y 04", VigenciaIni = new DateTime(2021, 6, 1) },
                new CveTipoEstacion { Clave = "03", Descripcion = "Destino Final Nacional", ClaveTranspote = "02, 03 y 04", VigenciaIni = new DateTime(2021, 6, 1) },
            };
        }
    }
}
