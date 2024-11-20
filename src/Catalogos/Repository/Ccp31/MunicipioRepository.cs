using System;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp31 {
    /// <summary>
    /// catalogo de municipios.
    /// </summary>
    public class MunicipioRepository : RepositoryContext<CveMunicipio>, IMunicipioRepository, IRepositoryGeneric {
        public MunicipioRepository(System.DateTime? lastUpdate = null) {
            Description = "Catálogo de municipios.";
            FileName = "SatCcp31Municipio.json";
            Version = "1.0";
            this.AddLastUpdate(lastUpdate);
        }

        public override CveMunicipio Search(string findId) {
            try {
                var search = new CveMunicipio();
                search = Items.SingleOrDefault((p) => p.Clave == findId.Trim());
                if (search == null)
                    return new CveMunicipio { Clave = findId };
                return search;

            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return new CveMunicipio { Clave = findId };
        }
    }
}
