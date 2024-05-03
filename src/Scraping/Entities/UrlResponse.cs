using System;
using System.IO;
using System.Net;
using System.Text;

namespace Jaeger.SAT.Catalogos.Scraping.Entities {
    /// <summary>
    /// clase para respuesta del servicio
    /// </summary>
    public class UrlResponse {
        #region declaraciones
        private DateTime? _LastModified;
        private string _Body;
        #endregion

        /// <summary>
        /// constructor
        /// </summary>
        public UrlResponse() { }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="url">URL</param>
        /// <param name="httpstatus">status http</param>
        /// <param name="lastmodified">fecha de ultima modificacion</param>
        /// <param name="body">cuerpo de la respuesta</param>
        public UrlResponse(string url, int httpstatus, DateTime? lastmodified, string body = "") {
            this.Url = url;
            this.HttpStatus = httpstatus;
            this.LastModified = lastmodified;
            this._Body = body;
        }

        #region propiedades
        public string Url { get; set; }

        public int HttpStatus { get; set; }

        public bool IsSuccess {
            get { return this.HttpStatus == 200; }
        }

        public DateTime? LastModified {
            get {
                if (_LastModified > new DateTime(1989, 1, 1))
                    return _LastModified;
                return null;
            }
            set { _LastModified = value; }
        }

        public string Body {
            get { return this._Body; }
        }
        #endregion

        public bool DateMatch(DateTime? dateTime) {
            return this.LastModified == dateTime;
        }

        /// <summary>
        /// formatear respuesta
        /// </summary>
        /// <param name="response">HttpWebResponse</param>
        /// <param name="url">URL</param>
        public UrlResponse CreateFromResponse(HttpWebResponse response, string url) {
            this.LastModified = null;
            this.Url = url;
            this.HttpStatus = (int)response.StatusCode;
            this.LastModified = response.LastModified;
            var DataStream = new MemoryStream();
            response.GetResponseStream().CopyTo((Stream)DataStream);
            var DataReader = new StreamReader((Stream)DataStream, Encoding.Default);
            DataStream.Position = 0;
            this._Body = DataReader.ReadToEnd();
            return this;
        }
    }
}
