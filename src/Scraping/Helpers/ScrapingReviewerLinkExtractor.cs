using System;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using Jaeger.SAT.Catalogos.Scraping.Entities;

namespace Jaeger.SAT.Catalogos.Scraping.Helpers {
    public class ScrapingReviewerLinkExtractor {
        public static string FromUrlResponse(UrlResponse response, string linkText, int linkPosition) {
            //string pattern = @"(<a.*?>.*?</a>)";
            string pattern = @"href\s*=\s*""(?:[""'](?<1>[^""']*)[""']|(?<1>[^>\s]+))"">" + linkText;
            RegexOptions options = RegexOptions.Multiline;
            var g0 = Regex.Matches(response.Body, pattern, options);
            foreach (Match m in g0) {
                if (m.Value.Contains(linkText)) {
                    if (m.Groups.Count == 2) {
                        Console.WriteLine("'{0}' found at index {1}.", m.Groups[1].Value, m.Index);
                        return m.Groups[1].Value;
                    }
                }
            }
            return string.Empty;
        }

        public static string FromUrlResponse2(string response, string linkText, int linkPosition) {
            string pattern = @"href\s*=\s*(?:[""'](?<1>[^""']*)[""']|(?<1>[^>\s]+))";

            RegexOptions options = RegexOptions.Multiline;
            var d0 = Regex.Matches(response, pattern, options);
            foreach (Match m in Regex.Matches(response, pattern, options)) {
                    Console.WriteLine("'{0}' found at index {1}.", m.Groups[1].Value, m.Index);
                return m.Groups[1].Value;
            }
            return string.Empty;
        }

        public static string FromUrlResponse1(UrlResponse response, string linkText, int linkPosition) {
            var doct = new HtmlDocument();
            doct.LoadHtml(response.Body);
            foreach (HtmlNode link in doct.DocumentNode.SelectNodes("//a[@href]")) {
                if (link.InnerText.Contains(linkText)) {
                    HtmlAttribute att = link.Attributes["href"];
                    if (att.Value.Contains("a")) {
                        Console.WriteLine(linkPosition);
                        // showing output
                        Console.WriteLine(att.Value);
                        return att.Value;
                    }
                }
            }
            return "";
        }
    }
}
