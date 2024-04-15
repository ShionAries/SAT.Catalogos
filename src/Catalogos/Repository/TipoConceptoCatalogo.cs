using System.Linq;
using System.ComponentModel;
using Jaeger.Catalogos.Abstractions;
using Jaeger.Catalogos.Contracts;
using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Repositories {
    public class TipoConceptoCatalogo : CatalogoContext<TipoConcepto>, ITipoConceptoCatalogo {
        public enum TipoMovimientoEnum {
            Cargo,
            Abono
        }

        public TipoConceptoCatalogo() {
            this.Title = "Catálogo tipos de concepto";
            this.FileName = "CatalogoTipoConcepto.json";
            this.Version = "1.0";
            this.Revision = "0";
        }

        public BindingList<TipoConcepto> GetList(TipoMovimientoEnum tipo) {
            var result = new BindingList<TipoConcepto>(this.Items.Where(it => it.Tipo.ToUpper() == tipo.ToString().ToUpper()).ToList());
            return result;
        }
    }
}
