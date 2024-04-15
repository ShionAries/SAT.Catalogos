using System;
using System.Collections.Generic;
using System.Linq;
using Jaeger.Catalogos.Abstractions;
using Jaeger.Catalogos.Contracts;
using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Repositories {
    /// <summary>
    /// Catálogo de tipo de remolque.
    /// </summary>
    public class SubTipoRemCatalogo : CatalogoContext<CveSubTipoRem>, IClaveSubTipoRemCatalogo {
        public SubTipoRemCatalogo() {
            this.Title = "Catálogo de tipo de remolque.";
            this.FileName = "CatalogoSubTipoRem.json";
            this.Version = "1.0";
        }

        public CveSubTipoRem Search(string findId) {
            try {
                var search = new CveSubTipoRem();
                search = this.Items.SingleOrDefault((CveSubTipoRem p) => p.Clave == findId.Trim());
                if (search == null)
                    return new CveSubTipoRem { Clave = findId };
                return search;

            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return new CveSubTipoRem { Clave = findId };
        }

        /// <summary>
        /// buscar descripcion
        /// </summary>
        public IEnumerable<CveSubTipoRem> GetSearchBy(string descripcion) {
            try {
                if (descripcion != null && descripcion.Length > 0) {
                    var search = this.Items.Where(it => it.Descriptor.ToLower().Contains(descripcion.ToLower()));
                    return search;
                }
                return this.Items;
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return new List<CveSubTipoRem>();
        }
    }
}
