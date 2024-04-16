using System;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Contracts;
using Jaeger.SAT.Catalogos.Repository.Entities;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Repositories {
    /// <summary>
    /// Catálogo tipo permiso.
    /// </summary>
    public class TipoPermisoRepository : RepositoryContext<CveTipoPermiso>, IClaveTipoPermisoRepository, IGeneralRepository {
        public TipoPermisoRepository() {
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
