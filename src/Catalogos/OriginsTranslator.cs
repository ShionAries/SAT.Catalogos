using System.Collections.Generic;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;
using Jaeger.SAT.Catalogos.Scraping.Entities;
using System.Linq;

namespace Jaeger.SAT.Catalogos {
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
        protected List<IOrigin> OriginFromLayout(List<OriginLayout> layouts) {
            var dump = new DumpOrigins().Origins;
            if (layouts == null) {
                isDefault = true;
            } else {
                for (int i = 0; i < dump.Count; i++) {
                    var search = layouts.Where(it => it.Hash == dump[i].GetHashCode()).FirstOrDefault();
                    if (search != null) {
                        dump[i].AllowUpdate = search.AllowUpdate;
                        if (search.LastVersion != null) {
                            dump[i].LastVersion = search.LastVersion;
                        }
                    }
                }
            }

            return dump;
        }

        protected IOrigin OriginFromLayout(OriginLayout item) {
            if (item.Type.ToLower() == typeof(ConstantOrigin).Name.ToLower()) {
                return ConstantOriginFromLayout(item);
            } else if (item.Type.ToLower() == typeof(ScrapingOrigin).Name.ToLower()) {
                return ScrapingOriginFromLayout(item);
            }
            return null;
        }

        protected List<OriginLayout> OriginToLayout(List<IOrigin> origins) {
            var layouts = new List<OriginLayout>();
            foreach (var origin in origins) {
                layouts.Add(OriginToLayout(origin));
            }
            return layouts;
        }
        #endregion

        #region metodos privados
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
