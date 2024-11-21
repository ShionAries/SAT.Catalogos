using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// catalogo de paises
    /// </summary>
    public class PaisesRepository : RepositoryContext<CvePais>, IPaisesRepository, IRepositoryGeneric {
        public PaisesRepository() {
            Description = "Catálogo de Paises";
            FileName = "PaisesCFDI40.json";
            Version = "1.0";
        }

        public override CvePais Search(string findId) {
            try {
                var search = this.Items.SingleOrDefault((p) => p.Clave == findId);
                if (search == null) {
                    return new CvePais { Clave = findId };
                }
                return search;
            } catch (System.Exception) {

            }
            return new CvePais { Clave = findId };
        }
    }
}
