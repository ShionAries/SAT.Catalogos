using System;
using System.Linq;
using System.Text.RegularExpressions;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Nom12 {
    /// <summary>
    /// Nomina: catalogo de periodicidad del pago
    /// </summary>
    public class PeriodicidadPagoRepository : RepositoryContext<CvePeriodicidadPago>, IPeriodicidadPagoRepository, IGeneralRepository{
        public PeriodicidadPagoRepository(System.DateTime? lastUpdate = null) {
            this.Title = "Catalogo Exportación";
            this.FileName = "CatNom12PeriodicidadPago.json";
            this.Version = "1.0";
            this.AddLastUpdate(lastUpdate);
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
