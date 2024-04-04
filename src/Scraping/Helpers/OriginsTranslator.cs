using System.Collections.Generic;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;
using Jaeger.SAT.Catalogos.Scraping.Entities;

namespace Jaeger.SAT.Catalogos.Scraping.Helpers {
    public class OriginsTranslator {
        public OriginsTranslator() { }

        public List<IOriginInterface> OriginFromLayout(List<LayoutOrigin> origins) {
            if (origins == null)
                return null;

            var response = new List<IOriginInterface>();
            foreach (var item in origins) {
                response.Add(this.OriginFromLayout(item));
            }
            return response;
        }

        public IOriginInterface OriginFromLayout(LayoutOrigin item) {
            if (item.Type.ToLower() == typeof(ConstantOrigin).Name.ToLower()) {
                return this.ConstantOriginFromLayout(item);
            } else if (item.Type.ToLower() == typeof(ScrapingOrigin).Name.ToLower()) {
                return this.ScrapingOriginFromLayout(item);
            }
            return null;
        }

        public List<LayoutOrigin> OriginToLayout(List<IOriginInterface> origins) {
            var layouts = new List<LayoutOrigin>();
            foreach (var origin in origins) {
                layouts.Add(this.OriginToLayout(origin));
            }
            return layouts;
        }

        public LayoutOrigin OriginToLayout(IOriginInterface origin) {
            return new LayoutOrigin {
                LinkPosition = origin.LinkPosition,
                DestinationFilename = origin.DestinationFilename,
                Url = origin.Url,
                DownloadUrl = origin.DownloadUrl,
                LastVersion = origin.LastVersion,
                LinkText = origin.LinkText,
                Name = origin.Name,
                Type = origin.GetType().Name
            };
        }

        private IOriginInterface ConstantOriginFromLayout(LayoutOrigin item) {
            var d1 = new ConstantOrigin() {
                LinkPosition = item.LinkPosition,
                DestinationFilename = item.DestinationFilename,
                Url = item.Url,
                DownloadUrl = item.DownloadUrl,
                LastVersion = item.LastVersion,
                LinkText = item.LinkText,
                Name = item.Name
            };

            return d1;
        }

        private IOriginInterface ScrapingOriginFromLayout(LayoutOrigin item) {
            var d1 = new ScrapingOrigin() {
                LinkPosition = item.LinkPosition,
                DestinationFilename = item.DestinationFilename,
                Url = item.Url,
                DownloadUrl = item.DownloadUrl,
                LastVersion = item.LastVersion,
                LinkText = item.LinkText,
                Name = item.Name
            };

            return d1;
        }
    }
}
