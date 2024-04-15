using System;
using System.Linq;
using Jaeger.Catalogos.Abstractions;
using Jaeger.Catalogos.Contracts;
using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Repositories {
    /// <summary>
    /// Catálogo de número autorización agente naviero consignatario. 
    /// </summary>
    public class NumAutorizacionNavieroCatalogo : CatalogoContext<CveNumAutorizacionNaviero>, IClaveNumAutorizacionNavieroCatalogo {
        public NumAutorizacionNavieroCatalogo() {
            this.Title = "Catálogo de número autorización agente naviero consignatario. ";
            this.FileName = "CatalogoNumAutorizacionNaviero.json";
            this.Version = "";
        }

        public CveNumAutorizacionNaviero Search(string findId) {
            try {
                var search = new CveNumAutorizacionNaviero();
                search = this.Items.SingleOrDefault((CveNumAutorizacionNaviero p) => p.Clave == findId.Trim());
                if (search == null)
                    return new CveNumAutorizacionNaviero { Clave = findId };
                return search;

            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return new CveNumAutorizacionNaviero { Clave = findId };
        }
    }
}
