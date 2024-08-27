// develop: 240220222107
// purpose: catalogo SAT
using Jaeger.SAT.Catalogos.Helpers.Mapping;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;
using Newtonsoft.Json;

namespace Jaeger.SAT.Catalogos.Repository.Ccp31 {
    /// <summary>
    /// Carta Porte 3.0, Catálogo de unidades de medida y embalaje.
    /// </summary>
    public class CveUnidadPeso : ClaveBaseVigencia, IClaveBaseItem {
        [DataNames("Nombre")]
        public string Nombre { get; set; }

        [DataNames("Nota")]
        public string Nota { get; set; }

        [DataNames("Simbolo")]
        public string Simbolo { get; set; }

        [DataNames("Bandera")]
        public string Bandera { get; set; }

        [JsonIgnore]
        public override string Descriptor {
            get { return string.Format("{0}: {1}", Clave, Nombre); }
        }
    }
}
