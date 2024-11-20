using System;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// Catálogo de colonias.
    /// </summary>
    public class ColoniaRepository : RepositoryContext<CveColonia>, IColoniaRepository, IRepositoryGeneric {
        public ColoniaRepository(System.DateTime? lastUpdate = null) {
            Title = "Catálogo de colonias.";
            FileName = "ColoniaCFDi40.json";
            Version = "2.0";
            this.AddLastUpdate(lastUpdate);
        }

        public override CveColonia Search(string findId) {
            try {
                var search = new CveColonia();
                search = Items.SingleOrDefault((p) => p.Clave == findId.Trim());
                if (search == null)
                    return new CveColonia { Clave = findId };
                return search;

            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return new CveColonia { Clave = findId };
        }
    }
}
