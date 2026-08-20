using System.Linq;
using System.Collections.Generic;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;
using Jaeger.SAT.Catalogos.Scraping.Entities;

namespace Jaeger.SAT.Catalogos {
    /// <summary>
    /// clase para traduccion de origenes
    /// </summary>
    public class OriginsTranslator {
        private bool isDefault = false;

        /// <summary>
        /// constructor
        /// </summary>
        public OriginsTranslator() {
            isDefault = false;
        }

        /// <summary>
        /// obtener si la lista de origenes interna
        /// </summary>
        public bool IsDefault {
            get { return isDefault; }
        }

        #region metodos publicos
        /// <summary>
        /// metodo para obtener origenes desde layouts
        /// </summary>
        /// <param name="layouts"></param>
        /// <returns></returns>
        protected List<IOrigin> OriginFromLayout(List<OriginLayout> layouts) {
            var dump = new DumpOrigins().Origins;
            if (layouts == null) {
                isDefault = true;
            } else {
                for (int i = 0; i < dump.Count; i++) {
                    var search = layouts.Where(it => it.Hash == dump[i].GetHashCode()).FirstOrDefault();
                    if (search != null) {
                        dump[i].AllowUpdate = true;
                        if (search.LastVersion != null) {
                            dump[i].LastVersion = search.LastVersion;
                        }
                    }
                }
            }

            return dump;
        }

        /// <summary>
        /// metodo para obtener layout desde origen
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected IOrigin OriginFromLayout(OriginLayout item) {
            if (item.Type.ToLower() == typeof(ConstantOrigin).Name.ToLower()) {
                return ConstantOriginFromLayout(item);
            } else if (item.Type.ToLower() == typeof(ScrapingOrigin).Name.ToLower()) {
                return ScrapingOriginFromLayout(item);
            }
            return null;
        }

        /// <summary>
        /// metodo para obtener layouts desde origenes
        /// </summary>
        /// <param name="origins"></param>
        /// <returns></returns>
        protected List<OriginLayout> OriginToLayout(List<IOrigin> origins) {
            var layouts = new List<OriginLayout>();
            foreach (var origin in origins) {
                layouts.Add(OriginToLayout(origin));
            }
            return layouts;
        }
        #endregion

        #region metodos privados
        /// <summary>
        /// metodo para obtener layout desde origen
        /// </summary>
        /// <param name="origin"></param>
        /// <returns></returns>
        private OriginLayout OriginToLayout(IOrigin origin) {
            return new OriginLayout {
                DestinationFilename = origin.DestinationFilename,
                Url = origin.Url,
                DownloadUrl = origin.DownloadUrl,
                LastVersion = origin.LastVersion,
                LinkText = origin.LinkText,
                Name = origin.Name,
                Type = origin.GetType().Name,
                AllowUpdate = origin.AllowUpdate,
            };
        }

        /// <summary>
        /// metodo para obtener origen constante desde layout
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private IOrigin ConstantOriginFromLayout(OriginLayout item) {
            return new ConstantOrigin() {
                DestinationFilename = item.DestinationFilename,
                Url = item.Url,
                DownloadUrl = item.DownloadUrl,
                LastVersion = item.LastVersion,
                LinkText = item.LinkText,
                Name = item.Name,
                AllowUpdate = item.AllowUpdate,
            };
        }

        /// <summary>
        /// metodo para obtener origen scraping desde layout
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private IOrigin ScrapingOriginFromLayout(OriginLayout item) {
            return new ScrapingOrigin() {
                DestinationFilename = item.DestinationFilename,
                Url = item.Url,
                DownloadUrl = item.DownloadUrl,
                LastVersion = item.LastVersion,
                LinkText = item.LinkText,
                Name = item.Name,
                AllowUpdate = item.AllowUpdate,
            };
        }
        #endregion
    }
}
