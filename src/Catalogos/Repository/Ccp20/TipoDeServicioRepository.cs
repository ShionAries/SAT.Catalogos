using System;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp20 {
    /// <summary>
    /// Catálogo de tipo servicio.
    /// </summary>
    public class TipoDeServicioRepository : RepositoryContext<CveTipoDeServicio>, ITipoDeServicioRepository, IGeneralRepository {
        public TipoDeServicioRepository() {
            this.Title = "Catálogo de tipo servicio.";
            this.FileName = "CatCcp20TipoDeServicio.json";
            this.Version = "1.0";
        }

        public CveTipoDeServicio Search(string findId) {
            try {
                var search = new CveTipoDeServicio();
                search = this.Items.SingleOrDefault((CveTipoDeServicio p) => p.Clave == findId.Trim());
                if (search == null)
                    return new CveTipoDeServicio { Clave = findId };
                return search;

            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return new CveTipoDeServicio { Clave = findId };
        }

        //public override void Load() {
        //    this.Items = new System.Collections.Generic.List<CveTipoDeServicio> {
        //        new CveTipoDeServicio{ Clave = "TS01", Descripcion = "Carros Ferroviarios", Contenedor = 0, VigenciaIni = new DateTime(2021, 12, 1) },
        //        new CveTipoDeServicio{ Clave = "TS02", Descripcion = "Carros Ferroviarios intermodal", Contenedor = 1, VigenciaIni = new DateTime(2021, 12, 1) },
        //        new CveTipoDeServicio{ Clave = "TS03", Descripcion = "Tren unitario de carros ferroviarios", Contenedor = 0, VigenciaIni = new DateTime(2021, 12, 1) },
        //        new CveTipoDeServicio{ Clave = "TS04", Descripcion = "Tren unitario Intermodal", Contenedor = 1, VigenciaIni = new DateTime(2021, 12, 1) }
        //    };
        //}
    }
}
