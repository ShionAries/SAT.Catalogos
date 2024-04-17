using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ret20 {
    /// <summary>
    /// Retenciones 2.0, Catalogo de Periodos
    /// </summary>
    public class RetencionPeriodoRepository : RepositoryContext<CveRetencionPeriodo>, IRetencionPeriodoRepository, IGeneralRepository {
        public RetencionPeriodoRepository() {
            Title = "Catálogo de periodicidad Retenciones";
            FileName = "CatalogoPeriodicidad.json";
            Version = "1.0";
            Revision = "0";

            //this.Items = new List<ClaveRetencionPeriodicidad>();
            //this.Items.Add(new ClaveRetencionPeriodicidad { Clave = "01", Descripcion = "Semanal", VigenciaIni = new System.DateTime(2019, 01, 06) });
            //this.Items.Add(new ClaveRetencionPeriodicidad { Clave = "02", Descripcion = "Mensual", VigenciaIni = new System.DateTime(2019, 01, 06) });
        }
    }
}
