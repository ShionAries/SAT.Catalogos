using System.Linq;
using System.Text.RegularExpressions;
using Jaeger.SAT.Catalogos.Repository.Entities;

namespace Jaeger.SAT.Catalogos.Repository {
    /// <summary>
    /// catalogo de formas de pago
    /// </summary>
    public class FormaPagoRepository : RepositoryContext<ClaveFormaPago>, IFormaPagoRepository , IGeneralRepository {
        public FormaPagoRepository() {
            Title = "Catálogo Forma de Pago";
            FileName = "CatalogoFormaPago33.json";
        }

        public ClaveFormaPago Search(string findId) {
            if (findId != null) {
                string str = Regex.Replace(findId, @"/[^\d]/g", "");
                ClaveFormaPago objeto = new ClaveFormaPago();
                objeto = Items.SingleOrDefault((p) => p.Clave == str);
                return objeto;
            } else {
                return new ClaveFormaPago { Clave = findId };
            }
        }
    }
}
