using System;
using System.ComponentModel;
using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;
using Jaeger.SAT.Catalogos.Scraping.ValueObjects;

namespace Jaeger.SAT.Catalogos.Scraping.Abstracts {
    /// <summary>
    /// Clase abstracta base para los orígenes de recursos.
    /// </summary>
    public abstract class OriginResource : IOrigin {
        #region Constantes y Campos Privados

        private static readonly DateTime MinValidDate = new DateTime(1989, 1, 1);
        private DateTime? _lastVersion;

        #endregion

        #region Propiedades

        /// <summary>
        /// Obtiene o establece el nombre del recurso de origen.
        /// </summary>
        [DisplayName("Recurso")]
        public string Name { get; set; }

        /// <summary>
        /// Obtiene o establece la URL de consulta de la página.
        /// </summary>
        [DisplayName("URL")]
        public string Url { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de la última actualización del catálogo.
        /// </summary>
        [DisplayName("Actualizado")]
        public DateTime? LastVersion {
            get => (_lastVersion.HasValue && _lastVersion.Value > MinValidDate) ? _lastVersion : null;
            set => _lastVersion = value;
        }

        /// <summary>
        /// Obtiene o establece la URL de descarga del archivo.
        /// </summary>
        [DisplayName("URL de Descarga")]
        public abstract string DownloadUrl { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del archivo de descarga de destino.
        /// </summary>
        public string DestinationFilename { get; set; }

        /// <summary>
        /// Obtiene o establece el texto de referencia para la búsqueda del enlace de descarga.
        /// </summary>
        [DisplayName("Búsqueda por")]
        public string LinkText { get; set; }

        /// <summary>
        /// Obtiene o establece un valor que indica si se permite la actualización.
        /// </summary>
        [DisplayName("Permitir")]
        public bool AllowUpdate { get; set; }

        /// <summary>
        /// Obtiene o establece un valor que indica si se permite la edición.
        /// </summary>
        [JsonIgnore]
        public bool AllowEdit { get; set; }

        /// <summary>
        /// Obtiene o establece el tipo de importador asociado al recurso.
        /// </summary>
        [DisplayName("Importador")]
        [JsonIgnore]
        public Type Importer { get; set; }

        /// <summary>
        /// Obtiene o establece el estado actual del origen.
        /// </summary>
        [JsonIgnore]
        [Browsable(false)]
        public StatusEnum Status { get; set; }

        #endregion

        #region Métodos Públicos

        public virtual bool HasLastVersion() {
            return LastVersion.HasValue;
        }

        public virtual bool HasDownloadUrl() {
            return !string.IsNullOrWhiteSpace(DownloadUrl);
        }

        #endregion

        #region Patrón Builder

        public virtual IOrigin WithDownloadUrl(string downloadUrl) {
            DownloadUrl = downloadUrl;
            return this;
        }

        public virtual IOrigin WithLastModified(DateTime? lastModified) {
            LastVersion = lastModified;
            return this;
        }

        #endregion

        #region Sobrescritura de Igualdad

        public override bool Equals(object obj) {
            if (obj is IOrigin other) {
                return string.Equals(Name, other.Name, StringComparison.Ordinal);
            }

            return false;
        }

        public override int GetHashCode() {
            // Evita NullReferenceException cuando las propiedades son nulas
            int hashName = Name != null ? StringComparer.Ordinal.GetHashCode(Name) : 0;
            int hashUrl = Url != null ? StringComparer.Ordinal.GetHashCode(Url) : 0;
            int hashFile = DestinationFilename != null ? StringComparer.Ordinal.GetHashCode(DestinationFilename) : 0;

            unchecked {
                int hash = 17;
                hash = hash * 31 + hashName;
                hash = hash * 31 + hashUrl;
                hash = hash * 31 + hashFile;
                return hash;
            }
        }

        #endregion
    }
}