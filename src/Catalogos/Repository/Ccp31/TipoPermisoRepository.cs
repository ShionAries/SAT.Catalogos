using System;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp31 {
    /// <summary>
    /// Catálogo tipo permiso.
    /// </summary>
    public class TipoPermisoRepository : RepositoryContext<CveTipoPermiso>, ITipoPermisoRepository, IGeneralRepository {
        public TipoPermisoRepository(System.DateTime? lastUpdate = null) {
            Title = "Catálogo tipo permiso.";
            FileName = "CatCcp31TipoPermiso.json";
            Version = "2.0";
            this.AddLastVersion(lastUpdate);
        }

        public CveTipoPermiso Search(string findId) {
            try {
                var search = new CveTipoPermiso();
                search = Items.SingleOrDefault((p) => p.Clave == findId.Trim());
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
