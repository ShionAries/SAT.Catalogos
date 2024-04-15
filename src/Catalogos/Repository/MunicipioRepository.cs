using System;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Entities;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.Catalogos.Repositories {
    /// <summary>
    /// Catálogo de municipios.
    /// </summary>
    public class MunicipioRepository : RepositoryContext<CveMunicipio>, IClaveMunicipioRepository, IGeneralRepository {
        public MunicipioRepository() {
            this.Title = "Catálogo de municipios.";
            this.FileName = "CatalogoMunicipio.json";
            this.Version = "1.0";
        }

        public CveMunicipio Search(string findId) {
            try {
                var search = new CveMunicipio();
                search = this.Items.SingleOrDefault((CveMunicipio p) => p.Clave == findId.Trim());
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
