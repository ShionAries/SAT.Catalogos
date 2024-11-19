using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ret20 {
    /// <summary>
    /// Retenciones 2.0, Catalogo de Periodicidad
    /// </summary>
    public class PeriodicidadRepository : RepositoryContext<CveRetencionPeriodicidad>, IPeriodicidadRepository, IGeneralRepository {
        public PeriodicidadRepository() {
            Title = "Catálogo de periodicidad Retenciones";
            FileName = "CatRet20Periodicidad.json";
            Version = "1.0";
            Revision = "0";

            //this.Items = new List<ClaveRetencionPeriodicidad>();
            //this.Items.Add(new ClaveRetencionPeriodicidad { Clave = "01", Descripcion = "Semanal", VigenciaIni = new System.DateTime(2019, 01, 06) });
            //this.Items.Add(new ClaveRetencionPeriodicidad { Clave = "02", Descripcion = "Mensual", VigenciaIni = new System.DateTime(2019, 01, 06) });
        }

        public override CveRetencionPeriodicidad Search(string query) {
            try {
                var search = this.Items.SingleOrDefault(it => it.Clave == query);
                if (search != null) return search;
            } catch (System.Exception) {

            }
            return new CveRetencionPeriodicidad { Clave = query };
        }
    }
}
