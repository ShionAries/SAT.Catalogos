using System;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp31 {
    /// <summary>
    /// Catálogo código transporte aéreo.
    /// </summary>
    public class CodigoTransporteAereoRepository : RepositoryContext<CveCodigoTransporteAereo>, ICodigoTransporteAereoRepository, IGeneralRepository {
        public CodigoTransporteAereoRepository(System.DateTime? lastUpdate = null) {
            Title = "Catálogo código transporte aéreo.";
            FileName = "CatCcp31CodigoTransporteAereo.json";
            Version = "1.0";
            this.AddLastVersion(lastUpdate);
        }

        public CveCodigoTransporteAereo Search(string findId) {
            try {
                var search = new CveCodigoTransporteAereo();
                search = Items.SingleOrDefault((p) => p.Clave == findId.Trim());
                if (search == null)
                    return new CveCodigoTransporteAereo { Clave = findId };
                return search;

            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return new CveCodigoTransporteAereo { Clave = findId };
        }
    }
}
