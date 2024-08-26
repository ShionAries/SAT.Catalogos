using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Helpers.Mapping;

namespace Jaeger.SAT.Catalogos.Repository.Articulo69B {
    /// <summary>
    /// Artículo 69-B, primer y segundo párrafo del CFF
    /// </summary>
    public class Articulo69B {
        public Articulo69B() { }

        [JsonProperty("id")]
        [DataNames("Id")]
        public int Id { get; set; }

        /// <summary>
        /// obtener o establecer el Registro Federal de Contribuyentes
        /// </summary>
        [JsonProperty("rfc")]
        [DataNames("RFC")]
        public string RFC { get; set; }

        /// <summary>
        /// obtener o establecer el nombre del contribuyente
        /// </summary>
        [JsonProperty("nombre")]
        [DataNames("Nombre")]
        public string Nombre { get; set; }

        /// <summary>
        /// obtener o establecer la situación del contribuyente
        /// </summary>
        [JsonProperty("situacion")]
        [DataNames("Situacion")]
        public string Situacion { get; set; }

        /// <summary>
        /// Número y fecha de oficio global de presunción SAT
        /// </summary>
        [JsonProperty("OficioGlobalPresuncionSAT")]
        [DataNames("OficioGlobalPresuncionSAT")]
        public string OficioGlobalPresuncionSAT { get; set; }

        /// <summary>
        /// Publicación página SAT presuntos
        /// </summary>
        [JsonProperty("PublicacionPaginaSATPresuntos")]
        [DataNames("PublicacionPaginaSATPresuntos")]
        public string PublicacionPaginaSATPresuntos { get; set; }

        /// <summary>
        /// Número y fecha de oficio global de presunción DOF
        /// </summary>
        [JsonProperty("OficioGlobalPresuncionDOF")]
        [DataNames("OficioGlobalPresuncionDOF")]
        public string OficioGlobalPresuncionDOF { get; set; }

        /// <summary>
        /// Publicación DOF presuntos
        /// </summary>
        [JsonProperty("PublicacionDOFPresuntos", NullValueHandling = NullValueHandling.Ignore)]
        [DataNames("PublicacionDOFPresuntos")]
        public string PublicacionDOFPresuntos { get; set; }

        /// <summary>
        /// Número y fecha de oficio global de contribuyentes que desvirtuaron SAT
        /// </summary>
        [JsonProperty("OficioGlobalContribuyentesDesvirtuaronSAT", NullValueHandling = NullValueHandling.Ignore)]
        [DataNames("OficioGlobalContribuyentesDesvirtuaronSAT")]
        public string OficioGlobalContribuyentesDesvirtuaronSAT { get; set; }

        /// <summary>
        /// Publicación página SAT desvirtuados
        /// </summary>
        [JsonProperty("PublicacionPaginaSATDesvirtuados", NullValueHandling = NullValueHandling.Ignore)]
        [DataNames("PublicacionPaginaSATDesvirtuados")]
        public string PublicacionPaginaSATDesvirtuados { get; set; }

        /// <summary>
        /// Número y fecha de oficio global de contribuyentes que desvirtuaron DOF
        /// </summary>
        [JsonProperty("OficioGlobalContribuyentesDesvirtuaronDOF", NullValueHandling = NullValueHandling.Ignore)]
        [DataNames("OficioGlobalContribuyentesDesvirtuaronDOF")]
        public string OficioGlobalContribuyentesDesvirtuaronDOF { get; set; }

        /// <summary>
        /// Publicación DOF desvirtuados
        /// </summary>
        [JsonProperty("PublicacionDOFDesvirtuados", NullValueHandling = NullValueHandling.Ignore)]
        [DataNames("PublicacionDOFDesvirtuados")]
        public string PublicacionDOFDesvirtuados { get; set; }

        /// <summary>
        /// Número y fecha de oficio global de definitivos SAT
        /// </summary>
        [JsonProperty("OficioGlobalDefinitivosSAT")]
        [DataNames("OficioGlobalDefinitivosSAT")]
        public string OficioGlobalDefinitivosSAT { get; set; }

        /// <summary>
        /// Publicación página SAT definitivos
        /// </summary>
        [JsonProperty("PublicacionPaginaSATDefinitivos")]
        [DataNames("PublicacionPaginaSATDefinitivos")]
        public string PublicacionPaginaSATDefinitivos { get; set; }

        /// <summary>
        /// Número y fecha de oficio global de definitivos DOF
        /// </summary>
        [JsonProperty("OficioGlobalDefinitivosDOF")]
        [DataNames("OficioGlobalDefinitivosDOF")]
        public string OficioGlobalDefinitivosDOF { get; set; }

        /// <summary>
        /// Publicación DOF definitivos
        /// </summary>
        [JsonProperty("PublicacionDOFDefinitivos")]
        [DataNames("PublicacionDOFDefinitivos")]
        public string PublicacionDOFDefinitivos { get; set; }

        /// <summary>
        /// Número y fecha de oficio global de sentencia favorable SAT
        /// </summary>
        [JsonProperty("OficioGlobalSentenciaFavorableSAT")]
        [DataNames("OficioGlobalSentenciaFavorableSAT")]
        public string OficioGlobalSentenciaFavorableSAT { get; set; }

        /// <summary>
        /// Publicación página SAT sentencia favorable
        /// </summary>
        [JsonProperty("PublicacionPaginaSATSentenciaFavorable")]
        [DataNames("PublicacionPaginaSATSentenciaFavorable")]
        public string PublicacionPaginaSATSentenciaFavorable { get; set; }

        /// <summary>
        /// Número y fecha de oficio global de sentencia favorable DOF
        /// </summary>
        [JsonProperty("OficioGlobalSentenciaFavorableDOF")]
        [DataNames("OficioGlobalSentenciaFavorableDOF")]
        public string OficioGlobalSentenciaFavorableDOF { get; set; }

        /// <summary>
        /// Publicación DOF sentencia favorable
        /// </summary>
        [JsonProperty("PublicacionDOFSentenciaFavorable")]
        [DataNames("PublicacionDOFSentenciaFavorable")]
        public string PublicacionDOFSentenciaFavorable { get; set; }
    }
}
