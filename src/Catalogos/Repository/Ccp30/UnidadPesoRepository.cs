using System;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp30 {
    /// <summary>
    /// Catálogo de unidades de medida y embalaje.
    /// </summary>
    public class UnidadPesoRepository : RepositoryContext<CveUnidadPeso>, IUnidadPesoRepository, IRepositoryGeneric {
        public UnidadPesoRepository() {
            Title = "Catálogo de unidades de medida y embalaje.";
            FileName = "CatCcp30UnidadPeso.json";
            Version = "1.0";
        }

        public override CveUnidadPeso Search(string findId) {
            try {
                var search = new CveUnidadPeso();
                search = Items.SingleOrDefault((p) => p.Clave == findId.Trim());
                if (search == null)
                    return new CveUnidadPeso { Clave = findId };
                return search;

            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return new CveUnidadPeso { Clave = findId };
        }

        public System.Collections.Generic.IEnumerable<CveUnidadPeso> GetSearch(string findId) {
            return Items.Where(it => it.Descripcion.ToLower().Contains(findId)).ToList();
        }
    }
}
