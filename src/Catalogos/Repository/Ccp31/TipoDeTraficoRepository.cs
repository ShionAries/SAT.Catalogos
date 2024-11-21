using System;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp31 {
    /// <summary>
    /// Catálogo de tipo de tráfico ferroviario.
    /// </summary>
    public class TipoDeTraficoRepository : RepositoryContext<CveTipoDeTrafico>, ITipoDeTraficoRepository, IRepositoryGeneric {
        public TipoDeTraficoRepository() {
            Description = "Catálogo de tipo de tráfico ferroviario";
            FileName = "CatCcp31TipoDeTrafico.json";
            Version = "1.0";
        }

        public override CveTipoDeTrafico Search(string findId) {
            try {
                var search = new CveTipoDeTrafico();
                search = Items.SingleOrDefault((p) => p.Clave == findId.Trim());
                if (search == null)
                    return new CveTipoDeTrafico { Clave = findId };
                return search;

            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return new CveTipoDeTrafico { Clave = findId };
        }

        //public override void Load() {
        //    this.Items = new List<CveTipoDeTrafico>() { 
        //        new CveTipoDeTrafico { Clave = "TT01", Descripcion = "Tráfico local", VigenciaIni = new DateTime(2021, 12, 1) },
        //        new CveTipoDeTrafico { Clave = "TT02", Descripcion = "Tráfico interlineal remitido", VigenciaIni = new DateTime(2021, 12, 1) },
        //        new CveTipoDeTrafico { Clave = "TT03", Descripcion = "Tráfico interlineal recibido", VigenciaIni = new DateTime(2021, 12, 1) },
        //        new CveTipoDeTrafico { Clave = "TT04", Descripcion = "Tráfico interlineal en tránsito", VigenciaIni = new DateTime(2021, 12, 1) }
        //    };
        //}
    }
}
