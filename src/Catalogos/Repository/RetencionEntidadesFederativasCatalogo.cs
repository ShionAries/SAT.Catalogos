using Jaeger.Catalogos.Abstractions;
using Jaeger.Catalogos.Contracts;
using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Repositories {
    /// <summary>
    /// catalogo de entidades federativas (retenciones)
    /// </summary>
    public class RetencionEntidadesFederativasCatalogo : CatalogoContext<ClaveRetencionEntidadFederativa>, IRetencionEntidadesFederativasCatalogo, ICatalogo {
        public RetencionEntidadesFederativasCatalogo() {
            this.Title = "Catálogo de Entidades Federativas";
            this.FileName = "CatalogoEntidadesFederativas.json";
        }

        public ClaveRetencionEntidadFederativa Search(string findId) {
            ClaveRetencionEntidadFederativa objeto = new ClaveRetencionEntidadFederativa();
            objeto = this.Items.Find((ClaveRetencionEntidadFederativa p) => p.Clave == findId);
            return objeto;
        }
    }
}
