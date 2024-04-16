using System;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Contracts;
using Jaeger.SAT.Catalogos.Repository.Entities;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.Catalogos.Repositories {
    /// <summary>
    /// Carta Porte 3.0 Catálogo de tipo de embalaje.
    /// </summary>
    public class TipoEmbalajeRepository : RepositoryContext<CveTipoEmbalaje>, IClaveTipoEmbalajeRepository, IGeneralRepository {
        public TipoEmbalajeRepository() {
            this.Title = "Catálogo de tipo de embalaje.";
            this.FileName = "CatalogoTipoEmbalaje.json";
            this.Version = "1.0";
        }

        public CveTipoEmbalaje Search(string findId) {
            try {
                var search = new CveTipoEmbalaje();
                search = this.Items.SingleOrDefault((CveTipoEmbalaje p) => p.Clave == findId.Trim());
                if (search == null)
                    return new CveTipoEmbalaje { Clave = findId };
                return search;

            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return new CveTipoEmbalaje { Clave = findId };
        }

        public System.Collections.Generic.IEnumerable<CveTipoEmbalaje> GetSearch(string findId) {
            return this.Items.Where(it => it.Descripcion.Contains(findId)).ToList();
        }
    }
}
