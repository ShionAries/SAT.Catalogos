using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// catalogo SAT de codigos postales
    /// </summary>
    public class CodigoPostalRepository : RepositoryContext<CveCodigoPostal>, ICodigosPostalesRepository, IGeneralRepository {
        public CodigoPostalRepository(System.DateTime? lastUpdate = null) {
            Title = "Catálogo de códigos postales.";
            FileName = "CodigoPostalCFDi40.json";
            Version = "2.0";
            this.AddLastVersion(lastUpdate);
        }

        public CveCodigoPostal Search(string find) {
            CveCodigoPostal objeto = new CveCodigoPostal();
            objeto = Items.SingleOrDefault((p) => p.Clave == find);
            return objeto;
        }
    }
}
