using System;
using System.Collections.Generic;
using System.Linq;
using Jaeger.Catalogos.Abstractions;
using Jaeger.Catalogos.Contracts;
using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Repositories {
    public class CartaPorteEstadosCatalogo : CatalogoContext<CveEstado>, ICveEstadoCatalogo {
        public CartaPorteEstadosCatalogo() {
            this.Title = "Catálogo de Estados.";
            this.FileName = "CatalogoCartaPorteEstados.json";
            this.Version = "1.0";
        }

        public IEnumerable<CveEstado> GetSearchBy(string descripcion) {
            try {
                if (descripcion != null && descripcion.Length > 0) {
                    var search = this.Items.Where(it => it.Descriptor.ToLower().Contains(descripcion.ToLower()));
                    return search;
                }
                return this.Items;
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return new List<CveEstado>();
        }

        public CveEstado Search(string descripcion) {
            try {
                var search = new CveEstado();
                search = this.Items.SingleOrDefault((CveEstado p) => p.Clave == descripcion.Trim());
                if (search == null)
                    return new CveEstado { Clave = descripcion };
                return search;

            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return new CveEstado { Clave = descripcion };
        }
    }
}
