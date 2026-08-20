using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Jaeger.SAT.Catalogos.Prueba.EmailApocrifo {
    public class CorreoApocrifoParserService : ICorreoApocrifoParserService {
        private readonly HttpClient _httpClient;

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

        public CorreoApocrifoParserService(HttpClient httpClient) {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<IEnumerable<CorreoApocrifoInfo>> GetSpoofedEmailsInfoAsync(IEnumerable<string> fileUrls) {
            if (fileUrls == null || !fileUrls.Any())
                throw new ArgumentException("La colección de URLs no puede estar vacía.", nameof(fileUrls));

            List<Task<string>> downloadTasks = new List<Task<string>>();

            foreach (string url in fileUrls) {
                if (!string.IsNullOrWhiteSpace(url)) {
                    downloadTasks.Add(DownloadFileContentUtf8Async(url));
                }
            }

            string[] jsContents = await Task.WhenAll(downloadTasks).ConfigureAwait(false);
            string combinedContent = string.Join("\n", jsContents);

            return ParseJsObjects(combinedContent);
        }

        private async Task<string> DownloadFileContentUtf8Async(string url) {
            try {
                HttpResponseMessage response = await _httpClient.GetAsync(url).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                using (Stream stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8)) {
                    return await reader.ReadToEndAsync().ConfigureAwait(false);
                }
            } catch (HttpRequestException httpEx) {
                throw new InvalidOperationException($"Error de red al consultar {url}: {httpEx.Message}", httpEx);
            } catch (TaskCanceledException taskEx) {
                throw new TimeoutException($"Tiempo de espera agotado al descargar {url}.", taskEx);
            }
        }

        private IEnumerable<CorreoApocrifoInfo> ParseJsObjects(string jsContent) {
            // HashSet configurado con el comparador personalizado para prevenir duplicados automáticamente
            HashSet<CorreoApocrifoInfo> uniqueItems = new HashSet<CorreoApocrifoInfo>(new CorreoApocrifoInfoComparer());

            MatchCollection blockMatches = ObjectBlockRegex.Matches(jsContent);

            foreach (Match block in blockMatches) {
                string blockText = block.Value;

                string acronym = ExtractPropertyValue(AcronymRegex, blockText);
                string standsFor = ExtractPropertyValue(StandsForRegex, blockText);
                string description = ExtractPropertyValue(DescriptionRegex, blockText);

                if (!string.IsNullOrWhiteSpace(standsFor)) {
                    CorreoApocrifoInfo item = new CorreoApocrifoInfo {
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
    }
}