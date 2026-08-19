// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;

namespace Jaeger.SAT.Catalogos.Prueba.EmailApocrifo {
    public class SatEmailScraper : IScrapingService {
        private readonly HttpClient _httpClient;

        // Regex compilado para optimizar rendimiento en ejecuciones repetidas
        private static readonly Regex EmailRegex = new Regex(
            @"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public SatEmailScraper(HttpClient httpClient) {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<IEnumerable<string>> GetEmailsFromUrlAsync(string url) {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException("La URL no puede estar vacía.", nameof(url));

            try {
                // ConfigureAwait(false) previene deadlocks en contextos de sincronización antiguos
                HttpResponseMessage response = await _httpClient.GetAsync(url).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                string htmlContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                return ExtractEmailsFromHtml(htmlContent);
            } catch (HttpRequestException httpEx) {
                throw new InvalidOperationException($"Error de red al consultar el portal del SAT: {httpEx.Message}", httpEx);
            } catch (TaskCanceledException taskEx) {
                throw new TimeoutException("La solicitud HTTP excedió el tiempo de espera.", taskEx);
            } catch (Exception ex) {
                throw new Exception($"Error inesperado durante la ejecución: {ex.Message}", ex);
            }
        }

        private IEnumerable<string> ExtractEmailsFromHtml(string html) {
            MatchCollection matches = EmailRegex.Matches(html);
            HashSet<string> uniqueEmails = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (Match match in matches) {
                uniqueEmails.Add(match.Value.ToLowerInvariant());
            }

            return uniqueEmails;
        }
    }
}