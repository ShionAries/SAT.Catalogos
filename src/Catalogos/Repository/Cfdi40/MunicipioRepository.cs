using System;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// Catálogo de municipios.
    /// </summary>
    public class MunicipioRepository : RepositoryContext<CveMunicipio>, IClaveMunicipioRepository, IGeneralRepository {
        public MunicipioRepository() {
            Title = "Catálogo de municipios.";
            FileName = "MunicipioCFDI40.json";
            Version = "1.0";
        }

        public CveMunicipio Search(string findId) {
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
