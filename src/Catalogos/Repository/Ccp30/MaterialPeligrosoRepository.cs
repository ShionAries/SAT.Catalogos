using System;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp30 {
    /// <summary>
    /// Catálogo de materiales peligrosos.
    /// </summary>
    public class MaterialPeligrosoRepository : RepositoryContext<CveMaterialPeligroso>, IMaterialPeligrosoRepository, IRepositoryGeneric {
        public MaterialPeligrosoRepository() {
            Title = "Catálogo de materiales peligrosos.";
            FileName = "CatCcp30MaterialPeligroso.json";
            Version = "1.0";
        }

        public override CveMaterialPeligroso Search(string findId) {
            try {
                var search = new CveMaterialPeligroso();
                search = Items.SingleOrDefault((p) => p.Clave == findId.Trim());
                if (search == null)
                    return new CveMaterialPeligroso { Clave = findId };
                return search;

            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return new CveMaterialPeligroso { Clave = findId };
        }

        public System.Collections.Generic.IEnumerable<CveMaterialPeligroso> GetSearch(string findId) {
            return Items.Where(it => it.Descripcion.ToLower().Contains(findId)).ToList();
        }
    }
}
