using System;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Entities;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.Catalogos.Repositories {
    /// <summary>
    /// Catálogo de unidades de medida y embalaje.
    /// </summary>
    public class UnidadPesoRepository : RepositoryContext<CveClaveUnidadPeso>, IClaveClaveUnidadPesoRepository, IGeneralRepository {
        public UnidadPesoRepository() {
            this.Title = "Catálogo de unidades de medida y embalaje.";
            this.FileName = "CatalogoUnidadPeso.json";
            this.Version = "1.0";
        }
        public CveClaveUnidadPeso Seach(string findId) {
            try {
                var search = new CveClaveUnidadPeso();
                search = this.Items.SingleOrDefault((CveClaveUnidadPeso p) => p.Clave == findId.Trim());
                if (search == null)
                    return new CveClaveUnidadPeso { Clave = findId };
                return search;

            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return new CveClaveUnidadPeso { Clave = findId };
        }

        public System.Collections.Generic.IEnumerable<CveClaveUnidadPeso> GetSearch(string findId) {
            return this.Items.Where(it => it.Descripcion.ToLower().Contains(findId)).ToList();
        }
    }
}
