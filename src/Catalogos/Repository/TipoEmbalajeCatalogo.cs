using System;
using System.Linq;
using Jaeger.Catalogos.Abstractions;
using Jaeger.Catalogos.Contracts;
using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Repositories {
    /// <summary>
    /// Catálogo de tipo de embalaje.
    /// </summary>
    public class TipoEmbalajeCatalogo : CatalogoContext<CveTipoEmbalaje>, IClaveTipoEmbalajeCatalogo {
        public TipoEmbalajeCatalogo() {
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
