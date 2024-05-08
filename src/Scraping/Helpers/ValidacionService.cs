using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Jaeger.SAT.Catalogos.Scraping.Helpers {
    /// <summary>
    /// servicio de validacion de formatos
    /// </summary>
    public class ValidacionService {
        /// <summary>
        /// validacion de patron con regex
        /// </summary>
        public static bool RegexValid(string pattern, string value) {
            if (!string.IsNullOrEmpty(value)) {
                return new Regex(pattern).IsMatch(value);
            }
            return false;
        }

        /// <summary>
        /// validar direccion de correo electronico
        /// </summary>
        /// <param name="pEmail"></param>
        /// <returns>verdadero si coincide con la expresion regular</returns>
        public static bool EsCorreo(string pEmail) {
            if (pEmail != null)
                return Regex.IsMatch(pEmail, "^([\\w-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([\\w-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\\]?)$");
            return false;
        }

        /// <summary>
        /// validar formato del registro federal de contribuyentes (RFC)
        /// </summary>
        /// <param name="pRFC">registro fderal de contribuyentes</param>
        /// <returns>verdadero si coincide con la expresion regular</returns>
        public static bool RFC(string pRFC) {
            if (pRFC == null)
                return false;
            return Regex.IsMatch(pRFC, "^[a-zA-Z&ñÑ]{3,4}(([0-9]{2})([0][13456789]|[1][012])([0][1-9]|[12][\\d]|[3][0])|([0-9]{2})([0][13578]|[1][02])([0][1-9]|[12][\\d]|[3][01])|([02468][048]|[13579][26])([0][2])([0][1-9]|[12][\\d])|([0-9]{2})([0][2])([0][1-9]|[1][\\d]|[2][0-8]))(\\w{2}[A|a|0-9]{1})$");
        }

        /// <summary>
        /// validar Clave Única de Registro de Población
        /// </summary>
        /// <param name="pCURP">Clave Única de Registro de Población</param>
        /// <returns>verdadero si coincide con la expresion regular</returns>
        public static bool CURP(string pCURP) {
            if (pCURP == null)
                return false;
            return new Regex("^[A-Z][A,E,I,O,U,X][A-Z]{2}[0-9]{2}[0-1][0-9][0-3][0-9][M,H][A-Z]{2}[B,C,D,F,G,H,J,K,L,M,N,Ñ,P,Q,R,S,T,V,W,X,Y,Z]{3}[0-9,A-Z][0-9]", RegexOptions.IgnoreCase).Match(pCURP).Captures.Count != 0;
        }

        /// <summary>
        /// validar url
        /// </summary>
        /// <param name="pURL">URL</param>
        /// <returns>verdadero si coincide con la expresion regular</returns>
        public static bool URL(string pURL) {
            if (pURL == null)
                return false;
            else
                if (new Regex("^(https?|ftp|file)://[-A-Z0-9+&@#/%?=~_|!:,.;]*[-A-Z0-9+&@#/%=~_|]", RegexOptions.IgnoreCase).Match(pURL).Captures.Count == 0)
                return false;
            return true;
        }

        /// <summary>
        /// validar formato de folio fiscal (uuid)
        /// </summary>
        /// <param name="pUUID">indentificador unico universal</param>
        /// <returns>verdadero si coincide con la expresion regular</returns>
        public static bool UUID(string pUUID) {
            if (pUUID != null) {
                return Regex.IsMatch(pUUID, "[a-f0-9A-F]{8}-[a-f0-9A-F]{4}-[a-f0-9A-F]{4}-[a-f0-9A-F]{4}-[a-f0-9A-F]{12}");
            }
            return false;
        }

        /// <summary>
        /// validar formato de codigo postal
        /// </summary>
        /// <param name="pCodigoPostal"></param>
        /// <returns>verdadero si conincide con la expresion regular</returns>
        public static bool CodigoPostal(string pCodigoPostal) {
            if (pCodigoPostal != null)
                return Regex.IsMatch(pCodigoPostal, "^[0-9]{5,5}([-]?[0-9]{4,4})?$");
            return false;
        }

        /// <summary>
        /// validar cadeena base 64
        /// </summary>
        /// <param name="pBase64">cadena base 64</param>
        /// <returns></returns>
        public static bool IsBase64String(string pBase64) {
            if (pBase64 != null) {
                pBase64 = pBase64.Trim();
                return pBase64.Length % 4 == 0 && Regex.IsMatch(pBase64, @"^[-A-Za-z0-9+=]{1,50}|=[^=]|={3,}$", RegexOptions.None);
            }
            return false;
        }

        public static bool IsValidFormaPago(string cadena) {
            if (new Regex("[0-9]{20}").IsMatch(cadena)) {
                Console.WriteLine("la forma de pago debe ser mayor que 0 y menor que 20 caracteres");
                return false;
            }
            return true;
        }

        public static bool IsValidFolio(string cadena) {
            if (!new Regex("^([^|]{1,40})").IsMatch(cadena)) {
                Console.WriteLine("El folio debe ser mayor que 1 y menor que 40 caracteres");
                return false;
            }
            return true;
        }

        public static bool IsValidNumeroPedimiento(string cadena) {
            if (new Regex("[0-9]{2} [0-9]{2} [0-9]{4} [0-9]{7}").IsMatch(cadena)) {
                Console.WriteLine("El número de pedimiento esta mal gravado.");
                return false;
            }
            return true;
        }

        public static bool IsRequered(string cadena) {
            if (cadena.Count() < 0) {
                Console.WriteLine("Este atributo es requerido");
                return false;
            }
            return true;
        }

        public static bool IsValidConfirmacion(string cadena) {
            if (new Regex("[0-9a-zA-Z]{5}").IsMatch(cadena)) {
                Console.WriteLine("La confirmación debe ser menor que 5");
                return false;
            }
            return true;
        }
    }
}
