using System;
using System.Linq;
using Jaeger.Catalogos.Abstractions;
using Jaeger.Catalogos.Contracts;
using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Repositories {
    /// <summary>
    /// Catálogo código transporte aéreo.
    /// </summary>
    public class CodigoTransporteAereoCatalogo : CatalogoContext<CveCodigoTransporteAereo>, IClaveCodigoTransporteAereoCatalogo {
        public CodigoTransporteAereoCatalogo() {
            this.Title = "Catálogo código transporte aéreo.";
            this.FileName = "CatalogoCodigoTransporteAereo.json";
            this.Version = "";
        }

        public CveCodigoTransporteAereo Search(string findId) {
            try {
                var search = new CveCodigoTransporteAereo();
                search = this.Items.SingleOrDefault((CveCodigoTransporteAereo p) => p.Clave == findId.Trim());
                if (search == null)
                    return new CveCodigoTransporteAereo { Clave = findId };
                return search;

            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return new CveCodigoTransporteAereo { Clave = findId };
        }
    }
}
