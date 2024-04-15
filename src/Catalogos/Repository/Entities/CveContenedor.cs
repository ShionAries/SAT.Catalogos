// develop: 240220222107
// purpose: catalogo SAT
using Newtonsoft.Json;
using System.ComponentModel;
using System.Xml.Serialization;
using Jaeger.Catalogos.Contracts;

namespace Jaeger.Catalogos.Entities {
    /// <summary>
    /// Catálogo de tipo de contenedor.
    /// </summary>
    public class CveContenedor : ClaveBaseVigencia, IClaveBaseItem {
        [DisplayName("Tipo de Contenedor")]
        [JsonProperty("TipoDe", Order = 99)]
        [XmlAttribute("TipoDe")]
        public string TipoDeContenedor { get; set; }

        public override string Descriptor {
            get { return string.Format("{0} {1} {2}", this.Clave, this.TipoDeContenedor, this.Descripcion); }
        }
    }
}
