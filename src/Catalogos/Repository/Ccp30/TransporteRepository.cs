using System;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;

namespace Jaeger.SAT.Catalogos.Repository.Ccp30 {
    /// <summary>
    /// Catálogo de la clave del transporte
    /// </summary>
    public class TransporteRepository : RepositoryContext<CveTransporte>, ITransporteRepository {
        public TransporteRepository() {
            Title = "Catálogo de la clave del transporte.";
            FileName = "CatCcp30CveTransporte.json";
            Version = "2.0";
        }

        public override CveTransporte Search(string findId) {
            try {
                var search = new CveTransporte();
                search = Items.SingleOrDefault((p) => p.Clave == findId.Trim());
                if (search == null)
                    return new CveTransporte { Clave = findId };
                return search;

            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return new CveTransporte { Clave = findId };
        }

        //public override void Load() {
        //    this.Items = new System.Collections.Generic.List<CveTransporte> {
        //        new CveTransporte { Clave = "01", Descripcion = "Autotransporte", VigenciaIni = new DateTime(2021, 12, 1) },
        //        new CveTransporte { Clave = "02", Descripcion = "Transporte Marítimo", VigenciaIni = new DateTime(2021, 12, 1) },
        //        new CveTransporte { Clave = "03", Descripcion = "Transporte Aéreo", VigenciaIni = new DateTime(2021, 12, 1) },
        //        new CveTransporte { Clave = "04", Descripcion = "Transporte Ferroviario", VigenciaIni = new DateTime(2021, 12, 1) }
        //    };
        //}
    }
}
