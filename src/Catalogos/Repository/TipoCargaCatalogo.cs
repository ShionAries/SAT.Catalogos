using System;
using System.Linq;
using Jaeger.Catalogos.Abstractions;
using Jaeger.Catalogos.Contracts;
using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Repositories {
    /// <summary>
    /// Catálogo del tipo de carga.
    /// </summary>
    public class TipoCargaCatalogo : CatalogoContext<CveClaveTipoCarga>, ICveClaveTipoCargaCatalogo {
        public TipoCargaCatalogo() {
            this.Title = "Catálogo del tipo de carga.";
            this.FileName = "CatalogoTipoCarga.json";
            this.Version = "";
        }

        public CveClaveTipoCarga Search(string findId) {
            try {
                var search = new CveClaveTipoCarga();
                search = this.Items.SingleOrDefault((CveClaveTipoCarga p) => p.Clave == findId.Trim());
                if (search == null)
                    return new CveClaveTipoCarga { Clave = findId };
                return search;

            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return new CveClaveTipoCarga { Clave = findId };
        }

        public override void Load() {
            this.Items = new System.Collections.Generic.List<CveClaveTipoCarga> {
                new CveClaveTipoCarga { Clave = "CGS", Descripcion = "Carga General Suelta", VigenciaIni = new DateTime(2021, 6, 1) },
                new CveClaveTipoCarga { Clave = "CGC", Descripcion = "Carga General Contenerizada", VigenciaIni = new DateTime(2021, 6, 1) },
                new CveClaveTipoCarga { Clave = "GMN", Descripcion = "Gran Mineral", VigenciaIni = new DateTime(2021, 6, 1) },
                new CveClaveTipoCarga { Clave = "GAG", Descripcion = "Granel Agrícola", VigenciaIni = new DateTime(2021, 6, 1) },
                new CveClaveTipoCarga { Clave = "OFL", Descripcion = "Otros Fluidos", VigenciaIni = new DateTime(2021, 6, 1) },
                new CveClaveTipoCarga { Clave = "PYD", Descripcion = "Petróleo y Derivados", VigenciaIni = new DateTime(2021, 6, 1) }
            };
        }
    }
}
