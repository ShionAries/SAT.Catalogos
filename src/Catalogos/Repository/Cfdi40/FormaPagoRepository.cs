using System.Linq;
using System.Text.RegularExpressions;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// catalogo de formas de pago
    /// </summary>
    public class FormaPagoRepository : RepositoryContext<CveFormaPago>, IFormaPagoRepository, IGeneralRepository {
        public FormaPagoRepository(System.DateTime? lastUpdate = null) {
            Title = "Catálogo Forma de Pago";
            FileName = "FormaPagoCFDi40.json";
            this.AddLastVersion(lastUpdate);
        }

        public CveFormaPago Search(string findId) {
            if (findId != null) {
                string str = Regex.Replace(findId, @"/[^\d]/g", "");
                CveFormaPago objeto = new CveFormaPago();
                objeto = Items.SingleOrDefault((p) => p.Clave == str);
                return objeto;
            } else {
                return new CveFormaPago { Clave = findId };
            }
        }
    }
}
