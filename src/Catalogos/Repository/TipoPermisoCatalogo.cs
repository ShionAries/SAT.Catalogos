using System;
using System.Linq;
using Jaeger.Catalogos.Abstractions;
using Jaeger.Catalogos.Contracts;
using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Repositories {
    /// <summary>
    /// Catálogo tipo permiso.
    /// </summary>
    public class TipoPermisoCatalogo : CatalogoContext<CveTipoPermiso>, IClaveTipoPermisoCatalogo {
        public TipoPermisoCatalogo() {
            this.Title = "Catálogo tipo permiso.";
            this.FileName = "CatalogoTipoPermiso.json";
            this.Version = "2.0";
        }

        public CveTipoPermiso Search(string findId) {
            try {
                var search = new CveTipoPermiso();
                search = this.Items.SingleOrDefault((CveTipoPermiso p) => p.Clave == findId.Trim());
                if (search == null)
                    return new CveTipoPermiso { Clave = findId };
                return search;

            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return new CveTipoPermiso { Clave = findId };
        }
    }
}
