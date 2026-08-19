// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks;
using System.Xml;
using HtmlAgilityPack;

public sealed class SatProductoServicioScraper : ISatProductoServicioScraper {
    private const string Url =
        "http://pys.sat.gob.mx/PyS/catPyS.aspx";

    private readonly HttpClient _httpClient;

    public SatProductoServicioScraper(HttpClient httpClient) {
        if (httpClient == null)
            throw new ArgumentNullException(nameof(httpClient));

        _httpClient = httpClient;
    }

    public async Task<IReadOnlyList<ProductoServicioSat>> BuscarAsync(
        string texto,
        CancellationToken cancellationToken = default(CancellationToken)) {
        if (string.IsNullOrWhiteSpace(texto))
            throw new ArgumentException(
                "Debe especificar el texto de búsqueda.",
                nameof(texto));

        try {
            string html = await DescargarPaginaAsync(cancellationToken)
                .ConfigureAwait(false);

            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(html);

            IDictionary<string, string> campos =
                ObtenerCamposOcultos(document);

            string tablaResultados =
                ObtenerTablaResultados(document);

            if (string.IsNullOrWhiteSpace(tablaResultados)) {
                return new List<ProductoServicioSat>();
            }

            return ParsearResultados(tablaResultados);
        } catch (HttpRequestException ex) {
            throw new SatScrapingException(
                "No fue posible comunicarse con el SAT.",
                ex);
        } catch (TaskCanceledException ex) {
            throw new SatScrapingException(
                "La consulta al SAT fue cancelada o excedió el tiempo límite.",
                ex);
        } catch (SatScrapingException) {
            throw;
        } catch (Exception ex) {
            throw new SatScrapingException(
                "Ocurrió un error procesando el catálogo del SAT.",
                ex);
        }
    }

    private async Task<string> DescargarPaginaAsync(
        CancellationToken cancellationToken) {
        using (HttpResponseMessage response =
            await _httpClient.GetAsync(
                Url,
                cancellationToken).ConfigureAwait(false)) {
            if (!response.IsSuccessStatusCode) {
                throw new HttpRequestException(
                    string.Format(
                        "El SAT respondió con HTTP {0}.",
                        (int)response.StatusCode));
            }

            return await response.Content.ReadAsStringAsync()
                .ConfigureAwait(false);
        }
    }

    private static IDictionary<string, string> ObtenerCamposOcultos(
        HtmlDocument document) {
        Dictionary<string, string> result =
            new Dictionary<string, string>(
                StringComparer.OrdinalIgnoreCase);

        HtmlNodeCollection inputs =
            document.DocumentNode.SelectNodes(
                "//input[@type='hidden']");

        if (inputs == null)
            return result;

        foreach (HtmlNode input in inputs) {
            string name = input.GetAttributeValue("name", null);

            if (string.IsNullOrWhiteSpace(name))
                continue;

            string value =
                input.GetAttributeValue("value", string.Empty);

            result[name] = WebUtility.HtmlDecode(value);
        }

        return result;
    }

    private static string ObtenerTablaResultados(
        HtmlDocument document) {
        HtmlNode table =
            document.DocumentNode.SelectSingleNode(
                "//table[contains(@id,'gv') or " +
                "contains(@id,'Grid') or " +
                "contains(@class,'grid')]");

        return table == null
            ? null
            : table.OuterHtml;
    }

    private static IReadOnlyList<ProductoServicioSat> ParsearResultados(
        string html) {
        HtmlDocument document = new HtmlDocument();
        document.LoadHtml(html);

        List<ProductoServicioSat> resultados =
            new List<ProductoServicioSat>();

        HtmlNodeCollection rows =
            document.DocumentNode.SelectNodes("//tr");

        if (rows == null)
            return resultados;

        foreach (HtmlNode row in rows) {
            HtmlNodeCollection cells =
                row.SelectNodes("./th|./td");

            if (cells == null || cells.Count < 2)
                continue;

            string clave = LimpiarTexto(cells[0].InnerText);
            string descripcion = LimpiarTexto(cells[1].InnerText);

            if (string.IsNullOrWhiteSpace(clave))
                continue;

            if (!EsClaveProductoServicio(clave))
                continue;

            resultados.Add(
                new ProductoServicioSat {
                    Clave = clave,
                    Descripcion = descripcion
                });
        }

        return resultados;
    }

    private static bool EsClaveProductoServicio(string value) {
        string clave = value.Trim();

        if (clave.Length != 8)
            return false;

        return clave.All(char.IsDigit);
    }

    private static string LimpiarTexto(string value) {
        if (string.IsNullOrWhiteSpace(value))
            return string.Empty;

        return HtmlEntity.DeEntitize(value)
            .Replace("\r", " ")
            .Replace("\n", " ")
            .Replace("\t", " ")
            .Trim();
    }
}

public sealed class ProductoServicioSat {
    public string Clave { get; set; }
    public string Descripcion { get; set; }
    public string Incluye { get; set; }
    public string Excluye { get; set; }

    public override string ToString() {
        return string.Format("{0} - {1}", Clave, Descripcion);
    }
}
public sealed class SatScrapingException : Exception {
    public SatScrapingException(string message)
        : base(message) {
    }

    public SatScrapingException(
        string message,
        Exception innerException)
        : base(message, innerException) {
    }
}

public interface ISatProductoServicioScraper {
    Task<IReadOnlyList<ProductoServicioSat>> BuscarAsync(
        string texto,
        CancellationToken cancellationToken = default(CancellationToken));
}