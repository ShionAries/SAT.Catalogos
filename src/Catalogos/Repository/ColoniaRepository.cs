using System;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Entities;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository {
    /// <summary>
    /// Catálogo de colonias.
    /// </summary>
    public class ColoniaRepository : RepositoryContext<ClaveColonia>, IClaveColoniaRepository, IGeneralRepository {
        public ColoniaRepository() {
            this.Title = "Catálogo de colonias.";
            this.FileName = "CatalogoColonia.json";
            this.Version = "2.0";
        }

        public ClaveColonia Search(string findId) {
            try {
                var search = new ClaveColonia();
                search = this.Items.SingleOrDefault((ClaveColonia p) => p.Clave == findId.Trim());
                if (search == null)
                    return new ClaveColonia { Clave = findId };
                return search;

            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return new ClaveColonia { Clave = findId };
        }
    }
}
