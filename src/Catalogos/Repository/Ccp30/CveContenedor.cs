using System.ComponentModel;
using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;
using Jaeger.SAT.Catalogos.Helpers.Mapping;

namespace Jaeger.SAT.Catalogos.Repository.Ccp30 {
    /// <summary>
    /// Catálogo de tipo de contenedor.
    /// </summary>
    public class CveContenedor : ClaveBaseVigencia, IClaveBaseItem {
        [DisplayName("Tipo de Contenedor")]
        [JsonProperty("TipoDe", Order = 99)]
        [DataNames("TipoDeContenedor")]
        public string TipoDeContenedor { get; set; }

        public override string Descriptor {
            get { return string.Format("{0} {1} {2}", this.Clave, TipoDeContenedor, this.Descripcion); }
        }
    }
}
