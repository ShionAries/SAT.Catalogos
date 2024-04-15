using System;
using System.Linq;
using Jaeger.Catalogos.Abstractions;
using Jaeger.Catalogos.Contracts;
using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Repositories {
    /// <summary>
    /// Catálogo de contenedores marítimos.
    /// </summary>
    public class ContenedorMaritimoCatalogo : CatalogoContext<CveContenedorMaritimo>, IClaveContenedorMaritimoCatalogo {
        public ContenedorMaritimoCatalogo() {
            this.Title = "Catálogo de contenedores marítimos.";
            this.FileName = "CatalogoContenedorMaritimo.json";
            this.Version = "";
        }

        public CveContenedorMaritimo Search(string findId) {
            try {
                var search = new CveContenedorMaritimo();
                search = this.Items.SingleOrDefault((CveContenedorMaritimo p) => p.Clave == findId.Trim());
                if (search == null)
                    return new CveContenedorMaritimo { Clave = findId };
                return search;

            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return new CveContenedorMaritimo { Clave = findId };
        }
    }
}
