using System;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp31 {
    /// <summary>
    /// Catálogo de tipo de estación.
    /// </summary>
    public class TipoEstacionRepository : RepositoryContext<CveTipoEstacion>, ITipoEstacionRepository, IRepositoryGeneric {
        public TipoEstacionRepository(System.DateTime? lastUpdate = null) {
            Title = "Catálogo de tipo de estación.";
            FileName = "CatCcp31CveTipoEstacion.json";
            Version = "1.0";
            this.AddLastUpdate(lastUpdate);
        }

        public override CveTipoEstacion Search(string findId) {
            try {
                var search = new CveTipoEstacion();
                search = Items.SingleOrDefault((p) => p.Clave == findId.Trim());
                if (search == null)
                    return new CveTipoEstacion { Clave = findId };
                return search;

            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return new CveTipoEstacion { Clave = findId };
        }

        //public override void Load() {
        //    this.Items = new System.Collections.Generic.List<CveTipoEstacion> {
        //        new CveTipoEstacion { Clave = "01", Descripcion = "Origen Nacional", ClaveTransporte = "02, 03 y 04", VigenciaIni = new DateTime(2021, 6, 1) },
        //        new CveTipoEstacion { Clave = "02", Descripcion = "Intermedia", ClaveTransporte = "02, 03 y 04", VigenciaIni = new DateTime(2021, 6, 1) },
        //        new CveTipoEstacion { Clave = "03", Descripcion = "Destino Final Nacional", ClaveTransporte = "02, 03 y 04", VigenciaIni = new DateTime(2021, 6, 1) },
        //    };
        //}
    }
}
