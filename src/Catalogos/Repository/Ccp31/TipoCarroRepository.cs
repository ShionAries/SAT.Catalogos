using System;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp31 {
    /// <summary>
    /// Catálogo de tipo de carro.
    /// </summary>
    public class TipoCarroRepository : RepositoryContext<CveTipoCarro>, ITipoCarroRepository, IRepositoryGeneric {
        public TipoCarroRepository(System.DateTime? lastUpdate = null) {
            this.Description = "Catálogo de tipo de carro.";
            this.FileName = "CatCcp31TipoCarro.json";
            this.Version = "1.0";
            this.AddLastUpdate(lastUpdate);
        }

        public override CveTipoCarro Search(string findId) {
            try {
                var search = new CveTipoCarro();
                search = this.Items.SingleOrDefault((CveTipoCarro p) => p.Clave == findId.Trim());
                if (search == null)
                    return new CveTipoCarro { Clave = findId };
                return search;

            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return new CveTipoCarro { Clave = findId };
        }

        //public override void Load() {
        //    this.Items = new System.Collections.Generic.List<CveTipoCarro>() {
        //        new CveTipoCarro{ Clave = "TC01", Descripcion = "Furgón", Contenedor = 0, VigenciaIni = new DateTime(2021, 6, 1) },
        //        new CveTipoCarro{ Clave = "TC02", Descripcion = "Góndola", Contenedor = 0, VigenciaIni = new DateTime(2021, 6, 1) },
        //        new CveTipoCarro{ Clave = "TC03", Descripcion = "Tolva", Contenedor = 0, VigenciaIni = new DateTime(2021, 6, 1) },
        //        new CveTipoCarro{ Clave = "TC04", Descripcion = "Tanque", Contenedor = 0, VigenciaIni = new DateTime(2021, 6, 1) },
        //        new CveTipoCarro{ Clave = "TC05", Descripcion = "Plataforma Intermodal", Contenedor = 1, VigenciaIni = new DateTime(2021, 12, 1) },
        //        new CveTipoCarro{ Clave = "TC06", Descripcion = "Plataforma de Uso General", Contenedor = 0, VigenciaIni = new DateTime(2021, 6, 1) },
        //        new CveTipoCarro{ Clave = "TC07", Descripcion = "Plataforma Automotriz", Contenedor = 0, VigenciaIni = new DateTime(2021, 6, 1) },
        //        new CveTipoCarro{ Clave = "TC08", Descripcion = "Locomotora", Contenedor = 0, VigenciaIni = new DateTime(2021, 12, 1) },
        //        new CveTipoCarro{ Clave = "TC09", Descripcion = "Carro Especial", Contenedor = 0, VigenciaIni = new DateTime(2021, 12, 1) },
        //        new CveTipoCarro{ Clave = "TC10", Descripcion = "Pasajeros", Contenedor = 0, VigenciaIni = new DateTime(2021, 12, 1) },
        //        new CveTipoCarro{ Clave = "TC11", Descripcion = "Mantenimiento de Vía", Contenedor = 0, VigenciaIni = new DateTime(2021, 12, 1) },
        //    };
        //}
    }
}
