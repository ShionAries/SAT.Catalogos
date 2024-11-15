using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;
using System.Linq;

namespace Jaeger.SAT.Catalogos.Repository.Ret20 {
    /// <summary>
    /// Retenciones 2.0, Catalogo de Ejercicio
    /// </summary>
    public class EjercicioRepository : RepositoryContext<CveRetencionEjercicio>, IEjercicioRepository, IGeneralRepository {
        public EjercicioRepository() {
            Title = "Retenciones: Catálogo Ejercicio";
            FileName = "CatRet20Ejercicio.json";
            Version = "1.0";
            Revision = "0";
        }

        public override CveRetencionEjercicio Search(string query) {
            try {
                var search = this.Items.SingleOrDefault(it => it.Clave == query);
                if (search != null)
                    return search;
            } catch (System.Exception) {

            }
            return new CveRetencionEjercicio { Clave = query };
        }
    }
}
