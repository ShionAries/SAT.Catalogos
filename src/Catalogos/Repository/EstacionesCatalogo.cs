using System;
using System.Linq;
using Jaeger.Catalogos.Abstractions;
using Jaeger.Catalogos.Contracts;
using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Repositories {
    /// <summary>
    /// Catálogo de puertos marítimos, estaciones aeroportuarias y estaciones férreas.
    /// </summary>
    public class EstacionesCatalogo : CatalogoContext<CveEstaciones>, IClaveEstacionesCatalogo {
        public EstacionesCatalogo() {
            this.Title = "Catálogo de puertos marítimos, estaciones aeroportuarias y estaciones férreas.";
            this.FileName = "CatalogoEstaciones.json"; 
            this.Version = "2.0";
        }

        public CveEstaciones Search(string findId) {
            try {
                var search = new CveEstaciones();
                search = this.Items.SingleOrDefault((CveEstaciones p) => p.Clave == findId.Trim());
                if (search == null)
                    return new CveEstaciones { Clave = findId };
                return search;

            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return new CveEstaciones { Clave = findId };
        }
    }
}
