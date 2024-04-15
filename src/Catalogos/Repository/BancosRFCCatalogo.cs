using System.Linq;
using Jaeger.Catalogos.Entities;
using Jaeger.Catalogos.Abstractions;
using Jaeger.Catalogos.Contracts;

namespace Jaeger.Catalogos.Repositories {
    public class BancosRFCCatalogo : CatalogoContext<ClaveBancoRFC>, IBancosRFCCatalogo {
        public BancosRFCCatalogo() {
            this.Title = "Catálogo de Banco con RFC";
            this.FileName = "CatalogoBancosRFC.json";
        }

        public ClaveBancoRFC Search(string findId) {
            ClaveBancoRFC objeto = new ClaveBancoRFC();
            objeto = this.Items.FirstOrDefault((ClaveBancoRFC p) => p.Clave == findId);
            return objeto;
        }
    }
}
