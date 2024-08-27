using System;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp20 {
    /// <summary>
    /// Catálogo tipo permiso.
    /// </summary>
    public class TipoPermisoRepository : RepositoryContext<CveTipoPermiso>, ITipoPermisoRepository, IGeneralRepository {
        public TipoPermisoRepository() {
            Title = "Catálogo tipo permiso.";
            FileName = "CatCcp20TipoPermiso.json";
            Version = "2.0";
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
