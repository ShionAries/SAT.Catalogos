using System.Linq;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// catalogo SAT de codigos postales
    /// </summary>
    public class CodigoPostalRepository : RepositoryContext<CveCodigoPostal>, ICodigosPostalesRepository, Interfaces.IRepositoryGeneric {
        public CodigoPostalRepository() {
            Description = "Catálogo de códigos postales.";
            FileName = "CodigoPostalCFDi40.json";
            Version = "2.0";
        }

        public override CveCodigoPostal Search(string find) {
            CveCodigoPostal objeto = new CveCodigoPostal();
            objeto = Items.SingleOrDefault((p) => p.Clave == find);
            return objeto;
        }
    }
}
