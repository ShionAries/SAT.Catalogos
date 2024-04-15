using System;
using System.Linq;
using Jaeger.Catalogos.Abstractions;
using Jaeger.Catalogos.Contracts;
using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Repositories {
    /// <summary>
    /// Catálogo de partes del transporte rentadas o prestadas.
    /// </summary>
    public class ParteTransporteCatalogo : CatalogoContext<CveParteTransporte>, IClaveParteTransporteCatalogo {
        public ParteTransporteCatalogo() {
            this.Title = "Catálogo de partes del transporte rentadas o prestadas.";
            this.FileName = "CatalogoParteTransporte.json";
            this.Version = "1.0";
        }

        public CveParteTransporte Search(string findId) {
            try {
                var search = new CveParteTransporte();
                search = this.Items.SingleOrDefault((CveParteTransporte p) => p.Clave == findId.Trim());
                if (search == null)
                    return new CveParteTransporte { Clave = findId };
                return search;

            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return new CveParteTransporte { Clave = findId };
        }
    }
}
