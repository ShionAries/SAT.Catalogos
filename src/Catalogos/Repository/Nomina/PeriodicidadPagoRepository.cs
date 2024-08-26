using System;
using System.Linq;
using System.Text.RegularExpressions;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Nomina {
    /// <summary>
    /// Nomina: catalogo de periodicidad del pago
    /// </summary>
    public class PeriodicidadPagoRepository : RepositoryContext<CvePeriodicidadPago>, IPeriodicidadPagoRepository, IGeneralRepository{
        public PeriodicidadPagoRepository() {
            this.Title = "Catalogo Exportación";
            this.FileName = "CatalogoNominaPeriodicidadPago.json";
            this.Version = "1.0";
        }

        public CvePeriodicidadPago Search(string findId) {
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
