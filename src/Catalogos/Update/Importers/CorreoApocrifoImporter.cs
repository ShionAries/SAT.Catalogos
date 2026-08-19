using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using Jaeger.SAT.Catalogos.Helpers;
using Jaeger.SAT.Catalogos.Repository.CApocrifo;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;
using Jaeger.SAT.Catalogos.Update.Importers.CApocrifo;

namespace Jaeger.SAT.Catalogos.Update.Importers {
    public class CorreoApocrifoImporter : StandarImporter, IImporter {
        private string _FileName = "scripts_correos2.js";

        private static readonly Regex ObjectBlockRegex = new Regex(
            @"\{[^{}]*\}",
            RegexOptions.Compiled | RegexOptions.Singleline);

        private static readonly Regex AcronymRegex = new Regex(
            @"acronym\s*:\s*'(?<val>.*?)'",
            RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase);

        private static readonly Regex StandsForRegex = new Regex(
            @"standsFor\s*:\s*'(?<val>.*?)'",
            RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase);

        private static readonly Regex DescriptionRegex = new Regex(
            @"description\s*:\s*'(?<val>.*?)'",
            RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase);

        private static readonly Regex HtmlTagsRegex = new Regex(
            @"<[^>]*>",
            RegexOptions.Compiled);

        private static readonly Regex MultipleSpacesRegex = new Regex(
            @"\s+",
            RegexOptions.Compiled);

        public CorreoApocrifoImporter() : base() {
            this.FileName = this._FileName;
        }

        public CorreoApocrifoImporter(IOrigin origin, IConfiguration configuration) : base() {
            this.Origin = origin;
            this.Configuration = configuration;
            this.FileName = this._FileName;
        }

        public new void Import() {
            var d2 = new List<CorreoApocrifo>();
            if (this.CheckFile()) {
                var stream = FileService.ReadFileStrem(this.GetFullPath());
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8)) {
                    var d0 = reader.ReadToEnd();
                    d2 = ParseJsObjects(d0).ToList();
                }
            }
            var injector = new CorreoApocrifoInjector(d2);
            injector.Inject();
        }

        private IEnumerable<CorreoApocrifo> ParseJsObjects(string jsContent) {
            // HashSet configurado con el comparador personalizado para prevenir duplicados automáticamente
            HashSet<CorreoApocrifo> uniqueItems = new HashSet<CorreoApocrifo>(new SatSpoofedEmailInfoComparer());

            MatchCollection blockMatches = ObjectBlockRegex.Matches(jsContent);

            foreach (Match block in blockMatches) {
                string blockText = block.Value;

                string acronym = ExtractPropertyValue(AcronymRegex, blockText);
                string standsFor = ExtractPropertyValue(StandsForRegex, blockText);
                string description = ExtractPropertyValue(DescriptionRegex, blockText);

                if (!string.IsNullOrWhiteSpace(standsFor)) {
                    CorreoApocrifo item = new CorreoApocrifo {
                        Acronym = acronym,
                        StandsFor = standsFor.ToLowerInvariant(),
                        Description = description
                    };

                    // Intenta agregarlo; si el correo ya existe dentro del HashSet, se ignora la segunda aparición
                    uniqueItems.Add(item);
                }
            }

            return uniqueItems;
        }

        private string ExtractPropertyValue(Regex propertyRegex, string blockText) {
            Match match = propertyRegex.Match(blockText);
            if (match.Success) {
                string rawValue = match.Groups["val"].Value;

                string withoutHtml = HtmlTagsRegex.Replace(rawValue, string.Empty);
                string decoded = WebUtility.HtmlDecode(withoutHtml);
                string normalizedSpaces = MultipleSpacesRegex.Replace(decoded, " ");

                return normalizedSpaces.Trim();
            }

            return string.Empty;
        }

        private class SatSpoofedEmailInfoComparer : IEqualityComparer<CorreoApocrifo> {
            public bool Equals(CorreoApocrifo x, CorreoApocrifo y) {
                if (ReferenceEquals(x, y))
                    return true;
                if (x is null || y is null)
                    return false;

                // La duplicidad se define si tienen el mismo correo electrónico (case-insensitive)
                return string.Equals(x.StandsFor, y.StandsFor, StringComparison.OrdinalIgnoreCase);
            }

            public int GetHashCode(CorreoApocrifo obj) {
                if (obj is null || obj.StandsFor is null)
                    return 0;
                return obj.StandsFor.ToLowerInvariant().GetHashCode();
            }
        }
    }
}
