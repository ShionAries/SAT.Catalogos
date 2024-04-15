using System;
using System.Linq;
using Jaeger.Catalogos.Abstractions;
using Jaeger.Catalogos.Contracts;
using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Repositories {
    /// <summary>
    /// Catálogo de configuración marítima.
    /// </summary>
    public class ConfigMaritimaCatalogo : CatalogoContext<CveConfigMaritima>, IClaveConfigMaritimaCatalogo {
        public ConfigMaritimaCatalogo() {
            this.Title = "Catálogo de configuración marítima.";
            this.FileName = "CatalogoConfigMaritima.json";
            this.Version = "";
        }

        public CveConfigMaritima Search(string findId) {
            try {
                var search = new CveConfigMaritima();
                search = this.Items.SingleOrDefault((CveConfigMaritima p) => p.Clave == findId.Trim());
                if (search == null)
                    return new CveConfigMaritima { Clave = findId };
                return search;

            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return new CveConfigMaritima { Clave = findId };
        }
    }
}
