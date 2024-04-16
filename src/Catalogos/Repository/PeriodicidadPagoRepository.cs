using System;
using System.Linq;
using System.Text.RegularExpressions;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Entities;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository {
    /// <summary>
    /// Nomina: catalogo de periodicidad del pago
    /// </summary>
    public class PeriodicidadPagoRepository : RepositoryContext<ClavePeriodicidadPago>, IPeriodicidadPagoRepository, IGeneralRepository{
        public PeriodicidadPagoRepository() {
            this.Title = "Catalogo Exportación";
            this.FileName = "PeriodicidadCatalogo.json";
            this.Version = "1.0";
        }

        public ClavePeriodicidadPago Search(string findId) {
            string str = Regex.Replace(findId, "[^\\d]", "");
            try {
                var _response = new ClavePeriodicidadPago();
                _response = this.Items.SingleOrDefault((ClavePeriodicidadPago p) => p.Clave == str);
                return _response;
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return new ClavePeriodicidadPago { Clave = findId };
        }
    }
}
