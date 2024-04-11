using System.Linq;
using System.Text.RegularExpressions;
using Jaeger.SAT.Catalogos.Abstractions;
using Jaeger.SAT.Catalogos.Entities;

namespace Jaeger.SAT.Catalogos.Database.Repository {
    /// <summary>
    /// catalogo de formas de pago
    /// </summary>
    public class FormaPagoCatalogo : CatalogoContext<ClaveFormaPago>, IFormaPagoCatalogo {
        public FormaPagoCatalogo() {
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
