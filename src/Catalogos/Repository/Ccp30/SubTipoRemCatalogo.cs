using System;
using System.Collections.Generic;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp30 {
    /// <summary>
    /// Catálogo de tipo de remolque.
    /// </summary>
    public class SubTipoRemCatalogo : RepositoryContext<CveSubTipoRemolque>, ISubTipoRemCatalogo, IRepositoryGeneric {
        public SubTipoRemCatalogo() {
            this.Description = "Catálogo de tipo de remolque.";
            this.FileName = "CatCcp30TipoRemolque.json";
            this.Version = "1.0";
        }

        public override CveSubTipoRemolque Search(string findId) {
            try {
                var search = new CveSubTipoRemolque();
                search = this.Items.SingleOrDefault((CveSubTipoRemolque p) => p.Clave == findId.Trim());
                if (search == null)
                    return new CveSubTipoRemolque { Clave = findId };
                return search;
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return new CveSubTipoRemolque { Clave = findId };
        }

        /// <summary>
        /// buscar descripcion
        /// </summary>
        public IEnumerable<CveSubTipoRemolque> GetSearchBy(string descripcion) {
            try {
                if (descripcion != null && descripcion.Length > 0) {
                    var search = this.Items.Where(it => it.Descriptor.ToLower().Contains(descripcion.ToLower()));
                    return search;
                }
                return this.Items;
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return new List<CveSubTipoRemolque>();
        }
    }
}
