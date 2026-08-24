using System;
using System.ComponentModel;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Jaeger.SAT.Catalogos.Repository.Cert {
    [JsonObject("item")]
    public class Certificate {
        private char[] chrCountryName;
        private string strState;
        private string strLocality;
        private string strOrganizationName;
        private string strOrganizationalUnitName;
        private string strCommonName;
        private string strEmail;
        private string strPassword;
        private string strCertificateNumber;
        private string strBase64;
        private DateTime beginDateExpiration1;
        private DateTime endDateExpiration1;

        /// <summary>
        /// constructor
        /// </summary>
        public Certificate() {
            this.chrCountryName = new char[2];
            this.strState = string.Empty;
            this.strLocality = string.Empty;
            this.strOrganizationName = string.Empty;
            this.strOrganizationalUnitName = string.Empty;
            this.strCommonName = string.Empty;
            this.strEmail = string.Empty;
            this.strPassword = string.Empty;
            this.strCertificateNumber = string.Empty;
            this.strBase64 = string.Empty;
        }

        [DisplayName("Valido desde")]
        [JsonProperty("beginDate")]
        [XmlAttribute("ValidoDesde")]
        public DateTime BeginDateExpiration {
            get {
                DateTime firstGoodDate = new DateTime(1900, 1, 1);
                return this.beginDateExpiration1;
            }
            set {
                this.beginDateExpiration1 = value;
            }
        }

        [DisplayName("Expira")]
        [JsonProperty("enddate")]
        [XmlAttribute("Expira")]
        public DateTime EndDateExpiration {
            get {
                return this.endDateExpiration1;
            }
            set {
                this.endDateExpiration1 = value;
            }
        }

        [DisplayName("Nombre Común")]
        [JsonProperty("name")]
        [XmlAttribute("CommonName")]
        public string CommonName {
            get {
                return this.strCommonName;
            }
            set {
                this.strCommonName = value;
            }
        }

        /// <summary>
        /// Pais
        /// </summary>
        [DisplayName("Pais")]
        [JsonProperty("country")]
        [XmlAttribute("CountryName")]
        public char[] CountryName {
            get {
                return this.chrCountryName;
            }
            set {
                this.chrCountryName = value;
            }
        }

        /// <summary>
        /// correo electronico
        /// </summary>
        [DisplayName("Correo")]
        [JsonProperty("mail")]
        [XmlAttribute("Email")]
        public string Email {
            get {
                return this.strEmail;
            }
            set {
                this.strEmail = value;
            }
        }

        /// <summary>
        /// Localidad
        /// </summary>
        [DisplayName("Localidad")]
        [JsonProperty("locality")]
        [XmlAttribute("Locality")]
        public string Locality {
            get {
                return this.strLocality;
            }
            set {
                this.strLocality = value;
            }
        }

        [DisplayName("Unidad de la Organización")]
        [JsonProperty("unitName")]
        [XmlAttribute("OrganizationalUnitName")]
        public string OrganizationalUnitName {
            get {
                return this.strOrganizationalUnitName;
            }
            set {
                this.strOrganizationalUnitName = value;
            }
        }

        [DisplayName("Nombre de la organización")]
        [JsonProperty("organization")]
        [XmlAttribute("OrganizationName")]
        public string OrganizationName {
            get {
                return this.strOrganizationName;
            }
            set {
                this.strOrganizationName = value;
            }
        }

        [DisplayName("Constraseña")]
        [JsonProperty("password")]
        [XmlAttribute("Pass")]
        public string Password {
            get {
                return this.strPassword;
            }
            set {
                this.strPassword = value;
            }
        }

        [DisplayName("No. de Serie")]
        [JsonProperty("serial")]
        [XmlAttribute("Serial")]
        public string Serial {
            get {
                return this.strCertificateNumber;
            }
            set {
                this.strCertificateNumber = value;
            }
        }

        [DisplayName("Estado")]
        [JsonProperty("state")]
        [XmlAttribute("State")]
        public string State {
            get {
                return this.strState;
            }
            set {
                this.strState = value;
            }
        }

        /// <summary>
        /// Certificado en base64
        /// </summary>
        [DisplayName("Certificado Base64")]
        [JsonProperty("b64")]
        [XmlAttribute("base64")]
        public string CerB64 {
            get {
                return this.strBase64;
            }
            set {
                this.strBase64 = value;
            }
        }
    }
}
