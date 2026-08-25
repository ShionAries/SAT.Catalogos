using System.Linq;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// Catálogo de aduanas (tomado del anexo 22, apéndice I de la RGCE 2017).
    /// </summary>
    public class AduanasRepository : RepositoryContext<CveAduana>, IAduanasRepository, Interfaces.IRepositoryGeneric {
        public AduanasRepository() {
            FileName = "AduanasCFDi40.json";
            Description = "Catálogo de aduanas (tomado del anexo 22, apéndice I de la RGCE 2017).";
            Version = "1.0";
            Revision = "1";
        }

        public override CveAduana Search(string clave) {
            return Items.SingleOrDefault((b) => b.Clave == clave);
        }
    }
}
