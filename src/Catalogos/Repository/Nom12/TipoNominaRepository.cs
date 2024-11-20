using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Nom12 {
    /// <summary>
    /// catalogo de tipos de nomina
    /// </summary>
    public class TipoNominaRepository : RepositoryContext<CveTipoNomina>, ITipoNominaRepository, IRepositoryGeneric {
        public TipoNominaRepository(System.DateTime? lastUpdate = null) {
            Description = "Catálogo de tipos de nómina.";
            FileName = "CatNom12Tipos.json";
            this.AddLastUpdate(lastUpdate);
        }

        public override CveTipoNomina Search(string query) {
            try {
                var search = this.Items.SingleOrDefault(it => it.Clave == query);
                if (search != null)
                    return search;
            } catch (System.Exception) {

            }
            return new CveTipoNomina { Clave = query };
        }
    }
}
