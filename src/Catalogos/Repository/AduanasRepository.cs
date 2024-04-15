using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Entities;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository {
    /// <summary>
    /// Catálogo de aduanas (tomado del anexo 22, apéndice I de la RGCE 2017).
    /// </summary>
    public class AduanasRepository : RepositoryContext<ClaveAduana>, IAduanasRepository, IGeneralRepository {
        public AduanasRepository() {
            this.FileName = "CatalogoAduanas.json";
            this.Title = "Catálogo de aduanas (tomado del anexo 22, apéndice I de la RGCE 2017).";
            this.Version = "1.0";
            this.Revision = "1";
        }

        public ClaveAduana Search(string clave) {
            return this.Items.SingleOrDefault((ClaveAduana b) => b.Clave == clave);
        }
    }
}
