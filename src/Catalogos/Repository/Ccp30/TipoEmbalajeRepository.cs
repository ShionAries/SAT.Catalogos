using System;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp30 {
    /// <summary>
    /// Carta Porte 3.0 Catálogo de tipo de embalaje.
    /// </summary>
    public class TipoEmbalajeRepository : RepositoryContext<CveTipoEmbalaje>, ITipoEmbalajeRepository, IGeneralRepository {
        public TipoEmbalajeRepository() {
            Title = "Catálogo de tipo de embalaje.";
            FileName = "CatCcp30TipoEmbalaje.json";
            Version = "1.0";
        }

        public CveTipoEmbalaje Search(string findId) {
            try {
                var search = new CveTipoEmbalaje();
                search = Items.SingleOrDefault((p) => p.Clave == findId.Trim());
                if (search == null)
                    return new CveTipoEmbalaje { Clave = findId };
                return search;

            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return new CveTipoEmbalaje { Clave = findId };
        }

        public System.Collections.Generic.IEnumerable<CveTipoEmbalaje> GetSearch(string findId) {
            return Items.Where(it => it.Descripcion.Contains(findId)).ToList();
        }
    }
}
