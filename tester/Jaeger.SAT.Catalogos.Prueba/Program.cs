// See https://aka.ms/new-console-template for more information
using Jaeger.SAT.Catalogos.Prueba.EmailApocrifo;

namespace SatScrapingTool {
    public class Program {
        public static async Task Main(string[] args) {
            await EmailFake();
        }

        public static async Task EmailFake() {
            List<string> targetUrls = new List<string>
            {
                "https://www.sat.gob.mx/minisitio/BuscadorCorreosFalsos/scripts_correos.js",
                "https://www.sat.gob.mx/minisitio/BuscadorCorreosFalsos/scripts_correos2.js"
            };

            using (HttpClient client = new HttpClient()) {
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64)");

                ICorreoApocrifoParserService parserService = new CorreoApocrifoParserService(client);

                try {
                    Console.WriteLine("Procesando scripts JS para mapear objetos completos...");

                    IEnumerable<CorreoApocrifoInfo> results = await parserService.GetSpoofedEmailsInfoAsync(targetUrls);
                    List<CorreoApocrifoInfo> resultList = results.ToList();

                    Console.WriteLine($"\nSe mapearon con éxito {resultList.Count} registros completos.\n");

                    // Mostrar los primeros 3 registros
                    foreach (CorreoApocrifoInfo item in resultList.Take(13)) {
                        Console.WriteLine($"Acronym:     {item.Acronym}");
                        Console.WriteLine($"StandsFor:   {item.StandsFor}");
                        Console.WriteLine($"Description: {item.Description}");
                        Console.WriteLine(new string('-', 60));
                    }
                } catch (Exception ex) {
                    Console.WriteLine($"Error de ejecución: {ex.Message}");
                }
            }
        }
        public static async Task EmailFake2() {
            // Ajustar la ruta si los .js se encuentran en algún subdirectorio como /js/ o /assets/
            List<string> jsUrls = new List<string>
            {   
                "https://www.sat.gob.mx/minisitio/BuscadorCorreosFalsos/scripts_correos.js",
                //"https://www.sat.gob.mx/minisitio/BuscadorCorreosFalsos/scripts_correos2.js"
            };

            using (HttpClient client = new HttpClient()) {
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64)");

                IJsFileScrapingService scraper = new JsFileEmailScraper(client);

                try {
                    Console.WriteLine("Iniciando descarga concurrente de archivos JS...");

                    IEnumerable<string> emails = await scraper.GetEmailsFromJsFilesAsync(jsUrls);
                    List<string> emailList = emails.ToList();

                    Console.WriteLine($"\nOperación completada. Se extrajeron {emailList.Count} correos únicos.");

                    foreach (string email in emailList.Take(10)) {
                        Console.WriteLine($"- {email}");
                    }
                } catch (Exception ex) {
                    Console.WriteLine($"Error crítico: {ex.Message}");
                }
            }
        }
        public static async Task EmailFake1() {
            string urlSat = "http://omawww.sat.gob.mx/contacto/contactenos/Paginas/lista_correos_apocrifos.aspx";

            using (HttpClient client = new HttpClient()) {
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64)");

                IScrapingService scraper = new Jaeger.SAT.Catalogos.Prueba.EmailApocrifo.SatEmailScraper(client);

                try {
                    Console.WriteLine("Iniciando descarga de correos apócrifos del SAT...");

                    IEnumerable<string> emails = await scraper.GetEmailsFromUrlAsync(urlSat);
                    List<string> emailList = emails.ToList();

                    Console.WriteLine($"\nSe encontraron {emailList.Count} correos únicos.");

                    // Imprimir los primeros 10 como demostración
                    foreach (string email in emailList.Take(20)) {
                        Console.WriteLine($"- {email}");
                    }
                } catch (Exception ex) {
                    Console.WriteLine($"Error crítico: {ex.Message}");
                }
            }
        }

        //public static async Task EmialFake() {
        //            using (HttpClient httpClient = new HttpClient()) {
        //        httpClient.Timeout = TimeSpan.FromSeconds(30);

        //        ISatProductoServicioScraper scraper =
        //            new SatProductoServicioScraper(httpClient);

        //        try {
        //            var resultados =                        await scraper.BuscarAsync("computadora");

        //            foreach (ProductoServicioSat producto in resultados) {
        //                Console.WriteLine(
        //                    "{0} - {1}",
        //                    producto.Clave,
        //                    producto.Descripcion);
        //            }
        //        } catch (SatScrapingException ex) {
        //            Console.WriteLine(ex.Message);
        //        }
        //    }
        //}


        //public class Program {
        //    public static async Task Main(string[] args) {
        //        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        //        using (HttpClient httpClient = new HttpClient()) {
        //            httpClient.Timeout =                    TimeSpan.FromMinutes(5);

        //            const string catalogUrl = "http://omawww.sat.gob.mx/tramitesyservicios/Paginas/documentos/catCFDI_V_4_20260806.xls";

        //            ISatCatalogDownloader downloader =
        //                new SatCatalogDownloader(
        //                    httpClient,
        //                    catalogUrl);

        //            SatCatalogParser parser =
        //                new SatCatalogParser();

        //            ISatCatalogService service =
        //                new SatCatalogService(
        //                    downloader,
        //                    parser);

        //            await service.ActualizarAsync(
        //                @"C:\SAT\CatalogoSAT.xls",
        //                CancellationToken.None);

        //            IReadOnlyList<SatProductoServicio>
        //                resultados =
        //                    await service.BuscarAsync(
        //                        "computadora",
        //                        CancellationToken.None);

        //            foreach (
        //                SatProductoServicio producto
        //                in resultados) {
        //                Console.WriteLine(
        //                    "{0} - {1}",
        //                    producto.ClaveProdServ,
        //                    producto.Descripcion);
        //            }
        //        }
        //    }
        //}
    }
}