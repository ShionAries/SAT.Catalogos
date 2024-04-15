using System.ComponentModel;
using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Contracts {
    public interface ITipoConceptoCatalogo : IGenericCatalogo<TipoConcepto> {
        BindingList<TipoConcepto> GetList(Repositories.TipoConceptoCatalogo.TipoMovimientoEnum tipo);
    }
}
