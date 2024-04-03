using System;
using System.IO;
using System.Net;
using Jaeger.SAT.Catalogos.Scraping.Entities;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;

namespace Jaeger.SAT.Catalogos.Scraping.Helpers {
    public class WebResourcesGateway : IResourcesGatewayInterface {
        protected internal string sessionCookie;

        public WebResourcesGateway() {

        }

        public UrlResponse Headers(string url) {
            var response = this.obtainResponse("HEAD", url);
            return this.CreateUrlResponseFromResponse(response, url);
        }

        public UrlResponse Get(string url, string destinacion) {
            var response = this.obtainResponse("GET", url);
            if (response.StatusCode == HttpStatusCode.OK && !string.IsNullOrEmpty(destinacion)) {
                using (FileStream destination1 = new FileStream(destinacion, FileMode.Create, FileAccess.Write))
                    response.GetResponseStream().CopyTo((Stream)destination1);
            }

            return this.CreateUrlResponseFromResponse(response, destinacion);
        }

        private UrlResponse CreateUrlResponseFromResponse(HttpWebResponse response, string url) {
            var urlResponse = new UrlResponse().CreateFromResponse(response, url);
            response.Close();
            return urlResponse;
        }

        private HttpWebResponse obtainResponse(string method, string url) {
            //Console.WriteLine("Esperando 10 seg.");
            //System.Threading.Thread.Sleep(10000);
            Console.WriteLine("Iniciando request: " + url);
            HttpWebRequest webRequest;
            HttpWebResponse response;
            webRequest = this.RequestDefault(url);
            webRequest.Method = method;
            //webRequest.ContentType = "application/x-www-form-urlencoded; charset=utf-8";
            webRequest.Headers.Add(HttpRequestHeader.Cookie, this.sessionCookie);
            try {
                response = (HttpWebResponse)webRequest.GetResponse();
            } catch (WebException we) {
                var resp = we.Response as HttpWebResponse;
                Console.WriteLine(we.Message);
                if (resp == null) {
                    throw;
                }
                return resp;
            }
            Console.WriteLine("Request terminado");
            return response;
        }

        private HttpWebRequest RequestDefault(string url) {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            webRequest.AllowAutoRedirect = true;
            webRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:67.0) Gecko/20100101 Firefox/67.0";
            webRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            webRequest.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate, br");
            webRequest.Headers.Set(HttpRequestHeader.AcceptLanguage, "es-MX,es;q=0.8,en-US;q=0.5,en;q=0.3");
            webRequest.ContentType = "application/x-www-form-urlencoded; charset=utf-8";
            webRequest.Headers.Set("Upgrade-Insecure-Requests", "1");
            webRequest.Headers.Set(HttpRequestHeader.Te, "Trailers");
            return webRequest;
        }
    }
}
