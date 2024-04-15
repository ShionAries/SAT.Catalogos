using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Contracts;
using Jaeger.SAT.Catalogos.Repository.Entities;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.Catalogos.Repositories {
    public class RetencionPeriodoRepository : RepositoryContext<ClaveRetencionPeriodo>, IRetencionPeriodoRepository, IGeneralRepository {
        public RetencionPeriodoRepository() {
            this.Title = "Catálogo de periodicidad Retenciones";
            this.FileName = "CatalogoPeriodicidad.json";
            this.Version = "1.0";
            this.Revision = "0";

            //this.Items = new List<ClaveRetencionPeriodicidad>();
            //this.Items.Add(new ClaveRetencionPeriodicidad { Clave = "01", Descripcion = "Semanal", VigenciaIni = new System.DateTime(2019, 01, 06) });
            //this.Items.Add(new ClaveRetencionPeriodicidad { Clave = "02", Descripcion = "Mensual", VigenciaIni = new System.DateTime(2019, 01, 06) });
        }
    }
}
