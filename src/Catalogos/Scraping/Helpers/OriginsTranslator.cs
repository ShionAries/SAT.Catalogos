using System.Collections.Generic;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;
using Jaeger.SAT.Catalogos.Scraping.Entities;

namespace Jaeger.SAT.Catalogos.Scraping.Helpers {
    public class OriginsTranslator {
        /// <summary>
        /// constructor
        /// </summary>
        public OriginsTranslator() { }

        public List<IOrigin> OriginFromLayout(List<LayoutOrigin> origins) {
            if (origins == null)
                return null;

            var response = new List<IOrigin>();
            foreach (var item in origins) {
                response.Add(this.OriginFromLayout(item));
            }
            return response;
        }

        public IOrigin OriginFromLayout(LayoutOrigin item) {
            if (item.Type.ToLower() == typeof(ConstantOrigin).Name.ToLower()) {
                return this.ConstantOriginFromLayout(item);
            } else if (item.Type.ToLower() == typeof(ScrapingOrigin).Name.ToLower()) {
                return this.ScrapingOriginFromLayout(item);
            }
            return null;
        }

        public List<LayoutOrigin> OriginToLayout(List<IOrigin> origins) {
            var layouts = new List<LayoutOrigin>();
            foreach (var origin in origins) {
                layouts.Add(this.OriginToLayout(origin));
            }
            return layouts;
        }

        private LayoutOrigin OriginToLayout(IOrigin origin) {
            return new LayoutOrigin {
                LinkPosition = origin.LinkPosition,
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

        private IOrigin ConstantOriginFromLayout(LayoutOrigin item) {
            return new ConstantOrigin() {
                LinkPosition = item.LinkPosition,
                DestinationFilename = item.DestinationFilename,
                Url = item.Url,
                DownloadUrl = item.DownloadUrl,
                LastVersion = item.LastVersion,
                LinkText = item.LinkText,
                Name = item.Name,
                AllowUpdate = item.AllowUpdate,
            };
        }

        private IOrigin ScrapingOriginFromLayout(LayoutOrigin item) {
            return new ScrapingOrigin() {
                LinkPosition = item.LinkPosition,
                DestinationFilename = item.DestinationFilename,
                Url = item.Url,
                DownloadUrl = item.DownloadUrl,
                LastVersion = item.LastVersion,
                LinkText = item.LinkText,
                Name = item.Name,
                AllowUpdate = item.AllowUpdate,
            };
        }
    }
}
