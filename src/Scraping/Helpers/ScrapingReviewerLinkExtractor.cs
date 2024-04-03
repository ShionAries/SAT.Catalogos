using System;
using HtmlAgilityPack;
using Jaeger.SAT.Catalogos.Scraping.Entities;

namespace Jaeger.SAT.Catalogos.Scraping.Helpers {
    public class ScrapingReviewerLinkExtractor {
        public static string FromUrlResponse(UrlResponse response, string linkText, int linkPosition) {
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
