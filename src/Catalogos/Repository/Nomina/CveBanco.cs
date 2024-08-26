// develop: 161120162142
// purpose: clase para contener elemento del catalogo de bancos SAT
// rev.: 180120182344: actulizamos la clase
using System.ComponentModel;
using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;
using Jaeger.SAT.Catalogos.Helpers.Mapping;

namespace Jaeger.SAT.Catalogos.Repository.Nomina {
    [JsonObject("item")]
    public class CveBanco : ClaveBaseVigencia, IClaveBaseItem {
        [DisplayName("Razon Social")]
        [JsonProperty("rso", Order = 15)]
        [DataNames("RazonSocial")]
        public string RazonSocial { get; set; }
    }
}