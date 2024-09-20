using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using System.Xml;

namespace Jaeger.SAT.Catalogos.Scraping.Helpers {
    internal class XmlSerializerService {

        public static string SerializeObject<T>(T obj) {
            UTF8Encoding utf8WithoutBom = new UTF8Encoding(false);
            string empty = null;
            try {
                string str = null;
                MemoryStream memoryStream = new MemoryStream();
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, utf8WithoutBom);
                xmlTextWriter.Formatting = Formatting.Indented;
                xmlTextWriter.Indentation = 4;
                xmlSerializer.Serialize(xmlTextWriter, obj);
                memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
                str = utf8WithoutBom.GetString(memoryStream.ToArray());
                empty = str;
            } catch (System.Exception ex) {
                Console.WriteLine(ex.Message);
                empty = string.Empty;
            }
            return empty;
        }

        public static T DeserializeObject<T>(string xml) {
            try {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                MemoryStream memoryStream = new MemoryStream(StringToUtf8ByteArray(xml));
                return (T)xmlSerializer.Deserialize(memoryStream);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return default(T);
            }
        }
        
        public static byte[] StringToUtf8ByteArray(string pXmlString) {
            return (new UTF8Encoding(false)).GetBytes(pXmlString);
        }
    }
}
