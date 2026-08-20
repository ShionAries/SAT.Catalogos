using System.Text.RegularExpressions;

namespace Jaeger.SAT.Catalogos.Prueba.EmailApocrifo {
    public class JsFileEmailScraper : IJsFileScrapingService {
        private readonly HttpClient _httpClient;

        private static readonly Regex EmailRegex = new Regex(
            @"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public JsFileEmailScraper(HttpClient httpClient) {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<IEnumerable<string>> GetEmailsFromJsFilesAsync(IEnumerable<string> fileUrls) {
            if (fileUrls == null || !fileUrls.Any())
                throw new ArgumentException("La lista de URLs no puede estar vacía.", nameof(fileUrls));

            // Preparamos las tareas para ejecución concurrente
            List<Task<string>> downloadTasks = new List<Task<string>>();

            foreach (string url in fileUrls) {
                if (!string.IsNullOrWhiteSpace(url)) {
                    downloadTasks.Add(DownloadFileContentAsync(url));
                }
            }

            try {
                // Disparamos todas las peticiones I/O al mismo tiempo
                string[] jsContents = await Task.WhenAll(downloadTasks).ConfigureAwait(false);

                // Consolidamos el texto de todos los archivos en un solo bloque
                string combinedContent = string.Join(" ", jsContents);

                return ExtractEmailsFromText(combinedContent);
            } catch (Exception ex) {
                throw new Exception($"Error maestro al procesar los archivos JS: {ex.Message}", ex);
            }
        }

        private async Task<string> DownloadFileContentAsync(string url) {
            try {
                HttpResponseMessage response = await _httpClient.GetAsync(url).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            } catch (HttpRequestException httpEx) {
                throw new InvalidOperationException($"Error de red al consultar {url}: {httpEx.Message}", httpEx);
            } catch (TaskCanceledException taskEx) {
                throw new TimeoutException($"Tiempo de espera excedido al consultar {url}.", taskEx);
            }
        }

        private IEnumerable<string> ExtractEmailsFromText(string text) {
            MatchCollection matches = EmailRegex.Matches(text);
            HashSet<string> uniqueEmails = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (Match match in matches) {
                uniqueEmails.Add(match.Value.ToLowerInvariant());
            }

            return uniqueEmails;
        }
    }
}