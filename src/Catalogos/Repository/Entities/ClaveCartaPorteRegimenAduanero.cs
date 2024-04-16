using Jaeger.SAT.Catalogos.Helpers.Mapping;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;
using Newtonsoft.Json;

namespace Jaeger.SAT.Catalogos.Repository.Entities {
    /// <summary>
    /// Carta Porte: Regimen Aduanero
    /// </summary>
    [JsonObject("item")]
    public class ClaveCartaPorteRegimenAduanero: ClaveBaseVigencia, IClaveBaseItem {
        public ClaveCartaPorteRegimenAduanero() { }

        [DataNames("ImpExpo")]
        public string ImpoExpo {  get; set; }
    }
}
