using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// Catálogo de aduanas (tomado del anexo 22, apéndice I de la RGCE 2017).
    /// </summary>
    public class AduanasRepository : RepositoryContext<CveAduana>, IAduanasRepository, IGeneralRepository {
        public AduanasRepository() {
            FileName = "AduanasCFDi40.json";
            Title = "Catálogo de aduanas (tomado del anexo 22, apéndice I de la RGCE 2017).";
            Version = "1.0";
            Revision = "1";
        }

        public AduanasRepository(System.DateTime? lastUpdate = null) {
            FileName = "AduanasCFDi40.json";
            Title = "Catálogo de aduanas (tomado del anexo 22, apéndice I de la RGCE 2017).";
            Version = "1.0";
            Revision = "1";
            this.AddLastUpdate(lastUpdate);
        }

        public override CveAduana Search(string clave) {
            return Items.SingleOrDefault((b) => b.Clave == clave);
        }
    }
}
