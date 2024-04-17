using Jaeger.SAT.Catalogos.Helpers.Mapping;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp30 {
    /// <summary>
    /// Carta Porte 3.0, Catálogo de puertos marítimos, estaciones aeroportuarias y estaciones férreas.
    /// </summary>
    public class CveEstaciones : ClaveBaseVigencia, IClaveBaseItem {
        [DataNames("ClaveTransporte")]
        public string ClaveTransporte { get; set; }

        [DataNames("Nacionalidad")]
        public string Nacionalidad { get; set; }

        [DataNames("DesignadorIATA")]
        public string DesignadorIATA { get; set; }

        [DataNames("LineaFerrea")]
        public string LineaFerrea { get; set; }
    }
}
