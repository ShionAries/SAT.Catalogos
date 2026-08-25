namespace Jaeger.SAT.Catalogos.Repository.Nom12 {
    /// <summary>
    /// Nomina: Catalogo de tipos de periodicidad de pago.
    /// </summary>
    [Newtonsoft.Json.JsonObject("item")]
    public class CvePeriodicidadPago : Abstracts.ClaveBaseVigencia, Interfaces.IClaveBaseItem {
        public CvePeriodicidadPago() { }

        /// <summary>
        /// el formato de la clave es de 2 digitos, por lo que se debe formatear a 2 digitos
        /// </summary>
        [System.ComponentModel.DisplayName("Clave")]
        [Newtonsoft.Json.JsonProperty("clv", Order = 0)]
        [Helpers.Mapping.DataNames("Clave")]
        public new string Clave {
            get {
                var numero = int.Parse(base.Clave);
                return numero.ToString("00");
            }
            set {
                base.Clave = int.Parse(value).ToString("00");
            }
        }
    }
}
