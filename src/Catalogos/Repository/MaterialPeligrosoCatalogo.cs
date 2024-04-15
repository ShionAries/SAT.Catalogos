using System;
using System.Linq;
using Jaeger.Catalogos.Abstractions;
using Jaeger.Catalogos.Contracts;
using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Repositories {
    /// <summary>
    /// Catálogo de materiales peligrosos.
    /// </summary>
    public class MaterialPeligrosoCatalogo : CatalogoContext<CveMaterialPeligroso>, IClaveMaterialPeligrosoCatalogo {
        public MaterialPeligrosoCatalogo() {
            this.Title = "Catálogo de materiales peligrosos.";
            this.FileName = "CatalogoMaterialPeligroso.json";
            this.Version = "2.0";
        }

        public CveMaterialPeligroso Search(string findId) {
            try {
                var search = new CveMaterialPeligroso();
                search = this.Items.SingleOrDefault((CveMaterialPeligroso p) => p.Clave == findId.Trim());
                if (search == null)
                    return new CveMaterialPeligroso { Clave = findId };
                return search;

            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return new CveMaterialPeligroso { Clave = findId };
        }

        public System.Collections.Generic.IEnumerable<CveMaterialPeligroso> GetSearch(string findId) {
            return this.Items.Where(it => it.Descripcion.ToLower().Contains(findId)).ToList();
        }
    }
}
