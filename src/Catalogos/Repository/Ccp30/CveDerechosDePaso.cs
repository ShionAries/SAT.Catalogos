using Jaeger.SAT.Catalogos.Helpers.Mapping;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp30 {
    /// <summary>
    /// Catálogo derechos de paso.
    /// </summary>
    public class CveDerechosDePaso : ClaveBaseVigenciaSingle, IClaveBaseVigencia {
        /// <summary>
        /// Clave del derecho de paso
        /// </summary>
        [DataNames("Clave")]
        public string Clave { get; set; }

        /// <summary>
        /// Derecho de paso
        /// </summary>
        [DataNames("DerechoDePaso")]
        public string DerechoDePaso { get; set; }

        [DataNames("Entre")]
        public string Entre { get; set; }

        [DataNames("Hasta")]
        public string Hasta { get; set; }

        [DataNames("OtorgaRecibe")]
        public string OtorgaRecibe { get; set; }

        [DataNames("Concesionario")]
        public string Concesionario { get; set; }
    }
}
