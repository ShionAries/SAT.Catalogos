using System.Linq;

namespace Jaeger.SAT.Catalogos.Repository.Nom12 {
    /// <summary>
    /// catalogo del tipo de incapacidad
    /// </summary>
    public class TipoIncapacidadRepository : RepositoryContext<CveTipoIncapacidad>, ITipoIncapacidadRepository, Interfaces.IRepositoryGeneric {
        public TipoIncapacidadRepository() : base() {
            this.Description = "Catálogo del tipo de incapacidad.";
            this.FileName = "CatNom12TipoIncapacidad.json";
            this.Version = "1.0";
        }

        public override CveTipoIncapacidad Search(string query) {
            try {
                var search = this.Items.SingleOrDefault(it => it.Clave == query);
                if (search != null) return search;
            } catch (System.Exception) {

            }
            return new CveTipoIncapacidad { Clave = query };
        }
    }
}
