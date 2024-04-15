using System;
using System.Linq;
using Jaeger.Catalogos.Abstractions;
using Jaeger.Catalogos.Contracts;
using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Repositories {
    /// <summary>
    /// Catálogo de tipo de contenedor.
    /// </summary>
    public class ContenedorCatalogo : CatalogoContext<CveContenedor>, IClaveContenedorCatalogo {
        public ContenedorCatalogo() {
            this.Title = "Catálogo de tipo de contenedor.";
            this.FileName = "CatalogoContenedor.json";
            this.Version = "";
        }

        public CveContenedor Search(string findId) {
            try {
                var search = new CveContenedor();
                search = this.Items.SingleOrDefault((CveContenedor p) => p.Clave == findId.Trim());
                if (search == null)
                    return new CveContenedor { Clave = findId };
                return search;

            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return new CveContenedor { Clave = findId };
        }

        public override void Load() {
            this.Items = new System.Collections.Generic.List<CveContenedor> { 
                new CveContenedor { Clave = "TC01", TipoDeContenedor = "20'", Descripcion = "Contenedor de 6.1 Mts de longitud", VigenciaIni = new DateTime(2021, 6, 1) },
                new CveContenedor { Clave = "TC02", TipoDeContenedor = "40'", Descripcion = "Contenedor de 12.2 Mts de longitud", VigenciaIni = new DateTime(2021, 6, 1) },
                new CveContenedor { Clave = "TC03", TipoDeContenedor = "45'", Descripcion = "Contenedor de 13.7 Mts de longitud", VigenciaIni = new DateTime(2021, 6, 1) },
                new CveContenedor { Clave = "TC04", TipoDeContenedor = "48'", Descripcion = "Contenedor de 14.6 Mts de longitud", VigenciaIni = new DateTime(2021, 6, 1) },
                new CveContenedor { Clave = "TC05", TipoDeContenedor = "53'", Descripcion = "Contenedor de 16.1 Mts de longitud", VigenciaIni = new DateTime(2021, 6, 1) }
            };
        }
    }
}
