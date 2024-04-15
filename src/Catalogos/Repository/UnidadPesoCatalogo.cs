using System;
using System.Linq;
using Jaeger.Catalogos.Abstractions;
using Jaeger.Catalogos.Contracts;
using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Repositories {
    /// <summary>
    /// Catálogo de unidades de medida y embalaje.
    /// </summary>
    public class UnidadPesoCatalogo : CatalogoContext<CveClaveUnidadPeso>, IClaveClaveUnidadPesoCatalogo {
        public UnidadPesoCatalogo() {
            this.Title = "Catálogo de unidades de medida y embalaje.";
            this.FileName = "CatalogoUnidadPeso.json";
            this.Version = "1.0";
        }
        public CveClaveUnidadPeso Seach(string findId) {
            try {
                var search = new CveClaveUnidadPeso();
                search = this.Items.SingleOrDefault((CveClaveUnidadPeso p) => p.Clave == findId.Trim());
                if (search == null)
                    return new CveClaveUnidadPeso { Clave = findId };
                return search;

            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return new CveClaveUnidadPeso { Clave = findId };
        }

        public System.Collections.Generic.IEnumerable<CveClaveUnidadPeso> GetSearch(string findId) {
            return this.Items.Where(it => it.Descripcion.ToLower().Contains(findId)).ToList();
        }
    }
}
