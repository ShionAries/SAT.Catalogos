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
        /// <summary>
        /// obtener o establecer URL
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// obtener o establecer status HttpsStatus
        /// </summary>
        public int HttpStatus { get; set; }

        /// <summary>
        /// peticion correcta
        /// </summary>
        public bool IsSuccess {
            get { return this.HttpStatus == 200; }
        }

        /// <summary>
        /// obtener o establecer fecha de actualizacion
        /// </summary>
        public DateTime? LastModified {
            get {
                if (_LastModified > new DateTime(1989, 1, 1))
                    return _LastModified;
                return null;
            }
            set { _LastModified = value; }
        }

        /// <summary>
        /// cuerpo de la peticion
        /// </summary>
        public string Body {
            get { return this._Body; }
            set { this._Body = value; }
        }
        #endregion

        #region metodos publicos
        /// <summary>
        /// metodo para comprobar las fechas
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns>verdero si las fechas coinciden</returns>
        public bool DateMatch(DateTime? dateTime) {
            return this.LastModified.Value.Date == dateTime.Value.Date;
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
            var enconder = DetectEncodingWithBOM(DataStream as MemoryStream);
            // para el caso de que no venga especificado el charset
            if (enconder == null) {
                var DataReader = new StreamReader((Stream)DataStream, Encoding.UTF8);
                DataStream.Position = 0;
                this._Body = DataReader.ReadToEnd();
            } else {
                var DataReader = new StreamReader((Stream)DataStream, enconder);
                DataStream.Position = 0;
                this._Body = DataReader.ReadToEnd();
            }
            return this;
        }
        #endregion

        private Encoding DetectEncodingWithBOM(MemoryStream ms) {
            // Reset stream position to the beginning
            ms.Seek(0, SeekOrigin.Begin);

            byte[] bom = new byte[4]; // Max BOM length for common encodings
            int bytesRead = ms.Read(bom, 0, bom.Length);

            if (bytesRead >= 3 && bom[0] == 0xEF && bom[1] == 0xBB && bom[2] == 0xBF) {
                return Encoding.UTF8; // UTF-8 BOM
            } else if (bytesRead >= 2 && bom[0] == 0xFF && bom[1] == 0xFE) {
                return Encoding.Unicode; // UTF-16 Little Endian BOM
            } else if (bytesRead >= 2 && bom[0] == 0xFE && bom[1] == 0xFF) {
                return Encoding.BigEndianUnicode; // UTF-16 Big Endian BOM
            } else if (bytesRead >= 4 && bom[0] == 0x00 && bom[1] == 0x00 && bom[2] == 0xFE && bom[3] == 0xFF) {
                return Encoding.UTF32; // UTF-32 Little Endian BOM
            } else if (bytesRead >= 4 && bom[0] == 0xFF && bom[1] == 0xFE && bom[2] == 0x00 && bom[3] == 0x00) {
                return Encoding.GetEncoding(12001); // UTF-32 Big Endian BOM (codepage 12001)
            } else if (bytesRead == 4) {
                return Encoding.UTF8;
            }

            // No BOM found, further analysis or default encoding needed
            return null;
        }
    }
}
