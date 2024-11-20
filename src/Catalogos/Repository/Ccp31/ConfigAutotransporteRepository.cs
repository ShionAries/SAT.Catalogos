using System;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp31 {
    /// <summary>
    /// Catálogo de configuración autotransporte federal.
    /// </summary>
    public class ConfigAutotransporteRepository : RepositoryContext<CveConfigAutotransporte>, IConfigAutotransporteCatalogo, IRepositoryGeneric {
        public ConfigAutotransporteRepository(System.DateTime? lastUpdate = null) {
            Description = "Catálogo de configuración autotransporte federal.";
            FileName = "CatCcp31ConfigAutotransporteC.json";
            Version = "2.0";
            this.AddLastUpdate(lastUpdate);
        }

        public override CveConfigAutotransporte Search(string findId) {
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
