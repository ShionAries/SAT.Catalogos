using System;
using System.Collections.Generic;
using System.Linq;
using Jaeger.SAT.Catalogos.Scraping.Entities;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;

namespace Jaeger.SAT.Catalogos {
    /// <summary>
    /// Clase para traducción de orígenes.
    /// </summary>
    public class OriginsTranslator {
        #region Propiedades

        /// <summary>
        /// Obtiene un valor que indica si se utilizó la lista de orígenes interna/predeterminada.
        /// </summary>
        public bool IsDefault { get; protected set; }

        #endregion

        #region Métodos Protegidos

        /// <summary>
        /// Método para obtener orígenes desde una lista de layouts.
        /// </summary>
        /// <param name="layouts">Colección de layouts de origen.</param>
        /// <returns>Lista de objetos que implementan <see cref="IOrigin"/>.</returns>
        protected List<IOrigin> OriginFromLayout(List<OriginLayout> layouts) {
            var dump = new DumpOrigins().Origins;

            if (layouts == null) {
                IsDefault = true;
                return dump;
            }

            // O(N): Creamos un diccionario con el Hash para búsquedas O(1)
            var layoutsByHash = layouts
                .Where(l => l != null)
                .GroupBy(l => l.Hash)
                .ToDictionary(g => g.Key, g => g.First());

            foreach (var origin in dump) {
                int originHash = origin.GetHashCode();

                if (layoutsByHash.TryGetValue(originHash, out var search)) {
                    origin.AllowUpdate = true;
                    if (search.LastVersion != null) {
                        origin.LastVersion = search.LastVersion;
                    }
                }
            }

            return dump;
        }

        /// <summary>
        /// Método para obtener un origen individual desde un layout.
        /// </summary>
        /// <param name="item">Instancia del layout.</param>
        /// <returns>Instancia de <see cref="IOrigin"/> o null si no coincide el tipo.</returns>
        protected IOrigin OriginFromLayout(OriginLayout item) {
            if (item == null || string.IsNullOrEmpty(item.Type))
                return null;

            if (string.Equals(item.Type, nameof(ConstantOrigin), StringComparison.OrdinalIgnoreCase)) {
                return ConstantOriginFromLayout(item);
            }

            if (string.Equals(item.Type, nameof(ScrapingOrigin), StringComparison.OrdinalIgnoreCase)) {
                return ScrapingOriginFromLayout(item);
            }

            return null;
        }

        /// <summary>
        /// Método para obtener layouts desde una lista de orígenes.
        /// </summary>
        /// <param name="origins">Colección de orígenes.</param>
        /// <returns>Lista de <see cref="OriginLayout"/>.</returns>
        protected List<OriginLayout> OriginToLayout(List<IOrigin> origins) {
            if (origins == null)
                return new List<OriginLayout>();

            return origins.Select(OriginToLayout).ToList();
        }

        #endregion

        #region Métodos Privados

        /// <summary>
        /// Mapea un objeto <see cref="IOrigin"/> a <see cref="OriginLayout"/>.
        /// </summary>
        private OriginLayout OriginToLayout(IOrigin origin) {
            if (origin == null)
                return null;

            return new OriginLayout {
                DestinationFilename = origin.DestinationFilename,
                Url = origin.Url,
                DownloadUrl = origin.DownloadUrl,
                LastVersion = origin.LastVersion,
                LinkText = origin.LinkText,
                Name = origin.Name,
                Type = origin.GetType().Name,
                AllowUpdate = origin.AllowUpdate
            };
        }

        /// <summary>
        /// Mapea un layout a una instancia de <see cref="ConstantOrigin"/>.
        /// </summary>
        private IOrigin ConstantOriginFromLayout(OriginLayout item) {
            return PopulateOrigin(new ConstantOrigin(), item);
        }

        /// <summary>
        /// Mapea un layout a una instancia de <see cref="ScrapingOrigin"/>.
        /// </summary>
        private IOrigin ScrapingOriginFromLayout(OriginLayout item) {
            return PopulateOrigin(new ScrapingOrigin(), item);
        }

        /// <summary>
        /// Método auxiliar para copiar las propiedades comunes desde un <see cref="OriginLayout"/> a una instancia de <see cref="IOrigin"/>.
        /// </summary>
        private T PopulateOrigin<T>(T target, OriginLayout source) where T : IOrigin {
            target.DestinationFilename = source.DestinationFilename;
            target.Url = source.Url;
            target.DownloadUrl = source.DownloadUrl;
            target.LastVersion = source.LastVersion;
            target.LinkText = source.LinkText;
            target.Name = source.Name;
            target.AllowUpdate = source.AllowUpdate;

            return target;
        }

        #endregion
    }
}