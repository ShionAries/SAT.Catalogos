using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp30 {
    /// <summary>
    /// Nodo condicional para indicar los datos de la(s) figura(s) del transporte que interviene(n) en el traslado de los bienes y/o mercancías realizado 
    /// a través de los distintos medios de transporte dentro del territorio nacional, cuando el dueño de dicho medio sea diferente del emisor del 
    /// comprobante con el complemento Carta Porte.
    /// </summary>
    public class FiguraTransporteRepository : RepositoryContext<CveFiguraTransporte>, IFiguraTransporteRepository, IGeneralRepository {
        public FiguraTransporteRepository() {
            Title = "Catálogo de figura transporte.";
            FileName = "CatCcp30FiguraTransporte.json";
            Version = "2.0";
        }

        public override CveFiguraTransporte Search(string query) {
            try {
                var search = this.Items.SingleOrDefault((p) => p.Clave == query);
                if (search == null) {
                    return new CveFiguraTransporte() { Clave = query };
                }
                return search;
            } catch (System.Exception) {
                return new CveFiguraTransporte() { Clave = query };
            }
        }

        //public override void Load() {
        //    this.Items = new System.Collections.Generic.List<CveFiguraTransporte> { 
        //        new CveFiguraTransporte("01", "Operador", new DateTime(2021, 12, 1)),
        //        new CveFiguraTransporte("02", "Propietario", new DateTime(2021, 12, 1)),
        //        new CveFiguraTransporte("03", "Arrendador", new DateTime(2021, 12, 1)),
        //        new CveFiguraTransporte("04", "Notificado", new DateTime(2021, 12, 1))
        //        new CveFiguraTransporte("05", "Integrante de Coordinados", new DateTime(2021, 12, 1))
        //    };
        //}
    }
}
