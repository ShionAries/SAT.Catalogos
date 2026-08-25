using System.Linq;

namespace Jaeger.SAT.Catalogos.Repository.Nom12 {
    /// <summary>
    /// catalogo de tipos de horas extra (nomina)
    /// </summary>
    public class TipoHorasRepository : RepositoryContext<CveTipoHoras>, ITipoHorasRepository, Interfaces.IRepositoryGeneric {
        public TipoHorasRepository() : base() {
            this.Description = "Catálogo de tipos de Hora Extra.";
            this.FileName = "CatNom12TipoHoras.json";
            this.Version = "1.0";
        }

        public override CveTipoHoras Search(string query) {
            try {
                var search = this.Items.SingleOrDefault(it => it.Clave == query);
                if (search != null) return search;
            } catch (System.Exception) {

            }
            return new CveTipoHoras() { Clave = query };
        }
    }
}
