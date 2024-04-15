using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Entities;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository {
    /// <summary>
    /// catalogo SAT de codigos postales
    /// </summary>
    public class CodigoPostalRepository : RepositoryContext<ClaveCodigoPostal>, ICodigosPostalesRepository, IGeneralRepository {
        public CodigoPostalRepository() {
            this.Title = "Catálogo de códigos postales.";
            this.FileName = "CatalogoCodigoPostal.json";
            this.Version = "2.0";
        }

        public ClaveCodigoPostal Search(string find) {
            ClaveCodigoPostal objeto = new ClaveCodigoPostal();
            objeto = this.Items.SingleOrDefault((ClaveCodigoPostal p) => p.Clave == find);
            return objeto;
        }
    }
}
