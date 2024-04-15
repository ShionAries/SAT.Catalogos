/// develop: 310520181137 
/// purpose: clave de entidades federativas para el comprobante de retenciones
using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Entities {
    [JsonObject("item")]
    public class ClaveRetencionEntidadFederativa : ClaveBaseVigencia, IClaveBase {
        public ClaveRetencionEntidadFederativa() { }
    }
}
