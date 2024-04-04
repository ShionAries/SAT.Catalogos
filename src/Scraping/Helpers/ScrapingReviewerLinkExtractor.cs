using System;
using System.Text.RegularExpressions;
using Jaeger.SAT.Catalogos.Scraping.Entities;

namespace Jaeger.SAT.Catalogos.Scraping.Helpers {
    public class ScrapingReviewerLinkExtractor {
        public static string FromUrlResponse(UrlResponse response, string linkText, int linkPosition) {
            string pattern = @"href\s*=\s*""(?:[""'](?<1>[^""']*)[""']|(?<1>[^>\s]+))"">" + linkText;
            RegexOptions options = RegexOptions.Multiline;
            var matches = Regex.Matches(response.Body, pattern, options);
            foreach (Match m in matches) {
                if (m.Value.Contains(linkText)) {
                    if (m.Groups.Count == 2) {
                        Console.WriteLine("'{0}' found at index {1}.", m.Groups[1].Value, m.Index);
                        linkPosition = m.Index;
                        return m.Groups[1].Value;
                    }
                }
            }
            return string.Empty;
        }
    }
}
