using System;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp31 {
    /// <summary>
    /// Catalogo de Sector COFEPRIS
    /// </summary>
    public class SectorCofeprisRepository : RepositoryContext<CveTipoSectorCofepris>, ISectorCofeprisRepository, IGeneralRepository {
        public SectorCofeprisRepository(System.DateTime? lastUpdate = null) : base() {
            this.Title = "Catálogo de Sector COFEPRIS.";
            this.FileName = "CatCcp31SectorCOFEPRIS.json";
            this.Version = "1.0";
            this.AddLastVersion(lastUpdate);
        }

        public CveTipoSectorCofepris Search(string findId) {
            try {
                var search = new CveTipoSectorCofepris();
                search = this.Items.SingleOrDefault((CveTipoSectorCofepris p) => p.Clave == findId.Trim());
                if (search == null)
                    return new CveTipoSectorCofepris { Clave = findId };
                return search;

            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return new CveTipoSectorCofepris { Clave = findId };
        }
    }
}
