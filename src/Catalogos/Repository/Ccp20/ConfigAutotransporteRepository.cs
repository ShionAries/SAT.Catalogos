using System;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp20 {
    /// <summary>
    /// Catálogo de configuración autotransporte federal.
    /// </summary>
    public class ConfigAutotransporteRepository : RepositoryContext<CveConfigAutotransporte>, IConfigAutotransporteCatalogo, IGeneralRepository {
        public ConfigAutotransporteRepository() {
            Title = "Catálogo de configuración autotransporte federal.";
            FileName = "CatCcp20ConfigAutotransporteC.json";
            Version = "2.0";
        }

        public CveConfigAutotransporte Search(string findId) {
            try {
                var search = new CveConfigAutotransporte();
                search = Items.SingleOrDefault((p) => p.Clave == findId.Trim());
                if (search == null)
                    return new CveConfigAutotransporte { Clave = findId };
                return search;

            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return new CveConfigAutotransporte { Clave = findId };
        }
    }
}
