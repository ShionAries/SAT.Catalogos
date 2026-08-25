using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Jaeger.SAT.Catalogos.Repository.Nom12 {
    /// <summary>
    /// Nomina: catalogo de periodicidad del pago
    /// </summary>
    public class PeriodicidadPagoRepository : RepositoryContext<CvePeriodicidadPago>, IPeriodicidadPagoRepository, Interfaces.IRepositoryGeneric{
        public PeriodicidadPagoRepository() : base() {
            this.Description = "Catalogo Exportación";
            this.FileName = "CatNom12PeriodicidadPago.json";
            this.Version = "1.0";
            this.Revision = "0";
        }

        public override CvePeriodicidadPago Search(string findId) {
            string str = Regex.Replace(findId, "[^\\d]", "");
            try {
                var _response = new CvePeriodicidadPago();
                _response = this.Items.SingleOrDefault((CvePeriodicidadPago p) => p.Clave == str);
                return _response;
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return new CvePeriodicidadPago { Clave = findId };
        }
    }
}
