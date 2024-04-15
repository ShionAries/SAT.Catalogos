using System;
using System.Linq;
using Jaeger.Catalogos.Abstractions;
using Jaeger.Catalogos.Contracts;
using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Repositories {
    /// <summary>
    /// Catálogo derechos de paso.
    /// </summary>
    public class DerechosDePasoCatalogo : CatalogoContext<CveDerechosDePaso>, IClaveDerechosDePasoCatalogo {
        public DerechosDePasoCatalogo() {
            this.Title = "Catálogo derechos de paso.";
            this.FileName = "CatalogoDerechosDePaso.json";
            this.Version = "";
        }

        public CveDerechosDePaso Search(string findId) {
            try {
                var search = new CveDerechosDePaso();
                search = this.Items.SingleOrDefault((CveDerechosDePaso p) => p.Clave == findId.Trim());
                if (search == null)
                    return new CveDerechosDePaso { Clave = findId };
                return search;

            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return new CveDerechosDePaso { Clave = findId };
        }
    }
}
