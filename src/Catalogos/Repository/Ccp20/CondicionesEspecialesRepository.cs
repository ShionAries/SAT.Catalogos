using System;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp20 {
    /// <summary>
    /// Catalogo de Condiciones Especiales del Transporte
    /// </summary>
    public class CondicionesEspecialesRepository : RepositoryContext<CveCondicionesEspeciales>, ICondicionesEspeciales, IGeneralRepository {
        public CondicionesEspecialesRepository() : base() {
            this.Title = "Catálogo de Condiciones especiales del Transporte";
            this.FileName = "CatCcp20CondicionesEspeciales.json";
            this.Version = "1.0";
        }

        public CveCondicionesEspeciales Search(string findId) {
            try {
                var search = new CveCondicionesEspeciales();
                search = this.Items.SingleOrDefault((CveCondicionesEspeciales p) => p.Clave == findId.Trim());
                if (search == null)
                    return new CveCondicionesEspeciales { Clave = findId };
                return search;

            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return new CveCondicionesEspeciales { Clave = findId };
        }
    }
}
