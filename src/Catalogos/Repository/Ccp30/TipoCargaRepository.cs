using System;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp30 {
    /// <summary>
    /// Catálogo del tipo de carga.
    /// </summary>
    public class TipoCargaRepository : RepositoryContext<CveTipoCarga>, ITipoCargaRepository, IGeneralRepository {
        public TipoCargaRepository() {
            Title = "Catálogo del tipo de carga.";
            FileName = "CatalogoTipoCarga.json";
            Version = "";
        }

        public CveTipoCarga Search(string findId) {
            try {
                var search = new CveTipoCarga();
                search = Items.SingleOrDefault((p) => p.Clave == findId.Trim());
                if (search == null)
                    return new CveTipoCarga { Clave = findId };
                return search;

            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return new CveTipoCarga { Clave = findId };
        }

        //public override void Load() {
        //    Items = new System.Collections.Generic.List<CveClaveTipoCarga> {
        //        new CveClaveTipoCarga { Clave = "CGS", Descripcion = "Carga General Suelta", VigenciaIni = new DateTime(2021, 6, 1) },
        //        new CveClaveTipoCarga { Clave = "CGC", Descripcion = "Carga General Contenerizada", VigenciaIni = new DateTime(2021, 6, 1) },
        //        new CveClaveTipoCarga { Clave = "GMN", Descripcion = "Gran Mineral", VigenciaIni = new DateTime(2021, 6, 1) },
        //        new CveClaveTipoCarga { Clave = "GAG", Descripcion = "Granel Agrícola", VigenciaIni = new DateTime(2021, 6, 1) },
        //        new CveClaveTipoCarga { Clave = "OFL", Descripcion = "Otros Fluidos", VigenciaIni = new DateTime(2021, 6, 1) },
        //        new CveClaveTipoCarga { Clave = "PYD", Descripcion = "Petróleo y Derivados", VigenciaIni = new DateTime(2021, 6, 1) }
        //    };
        //}
    }
}
