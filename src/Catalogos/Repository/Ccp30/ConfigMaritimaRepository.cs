using System;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp30 {
    /// <summary>
    /// Catálogo de configuración marítima.
    /// </summary>
    public class ConfigMaritimaRepository : RepositoryContext<CveConfigMaritima>, IConfigMaritimaRepository, IRepositoryGeneric {
        public ConfigMaritimaRepository() {
            this.Description = "Catálogo de configuración marítima.";
            this.FileName = "CatCcp30ConfigMaritima.json";
            this.Version = "1.0";
        }

        public override CveConfigMaritima Search(string findId) {
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
