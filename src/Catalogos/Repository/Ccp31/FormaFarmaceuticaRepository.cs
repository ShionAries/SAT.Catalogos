using System;
using System.Linq;
using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp31 {
    /// <summary>
    /// Catalogo de Forma Farmaceutica
    /// </summary>
    [JsonObject("item")]
    public class FormaFarmaceuticaRepository : RepositoryContext<CveFormaFarmaceutica>, IFormaFarmaceuticaRepository, IRepositoryGeneric {
        public FormaFarmaceuticaRepository(System.DateTime? lastUpdate = null) {
            Title = "Catálogo de Forma Farmacéutica.";
            FileName = "CatCcp31FormaFarmaceutica.json";
            Version = "1.0";
            this.AddLastUpdate(lastUpdate);
        }

        public override CveFormaFarmaceutica Search(string findId) {
            try {
                var search = new CveFormaFarmaceutica();
                search = Items.SingleOrDefault((p) => p.Clave == findId.Trim());
                if (search == null)
                    return new CveFormaFarmaceutica { Clave = findId };
                return search;

            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return new CveFormaFarmaceutica { Clave = findId };
        }
    }
}
