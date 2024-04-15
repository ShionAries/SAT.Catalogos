using System;
using System.Linq;
using Jaeger.Catalogos.Abstractions;
using Jaeger.Catalogos.Contracts;
using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Repositories {
    /// <summary>
    /// Catálogo de configuración autotransporte federal.
    /// </summary>
    public class ConfigAutotransporteCatalogo : CatalogoContext<CveConfigAutotransporte>, IClaveConfigAutotransporteCatalogo {
        public ConfigAutotransporteCatalogo() {
            this.Title = "Catálogo de configuración autotransporte federal.";
            this.FileName = "CatalogoConfigAutotransporteC.json";
            this.Version = "2.0";
        }

        public CveConfigAutotransporte Search(string findId) {
            try {
                var search = new CveConfigAutotransporte();
                search = this.Items.SingleOrDefault((CveConfigAutotransporte p) => p.Clave == findId.Trim());
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
