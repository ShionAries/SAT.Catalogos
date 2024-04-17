using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Helpers.Mapping;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp30 {
    /// <summary>
    /// Carta Porte 3.0: Catalogo de Regimen Aduanero
    /// </summary>
    [JsonObject("item")]
    public class CveRegimenAduanero : ClaveBaseVigencia, IClaveBaseItem {
        public CveRegimenAduanero() { }

        [DataNames("ImpExpo")]
        public string ImpoExpo { get; set; }
    }
}
