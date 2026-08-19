using System;
using System.IO;

namespace Jaeger.SAT.Catalogos.Helpers {
    internal static class FileService {

        public static Stream ReadFileStrem(string fileName) {
            return new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        }

        /// <summary>
        /// funcion para comprobar si un archivo existe
        /// </summary>
        /// <param name="fileSource">ruta del archivo</param>
        /// <returns>verdadro si el archivo existe</returns>
        public static bool Exists(string fileSource) {
            return File.Exists(fileSource);
        }

        public static string ReadFileText(string archivo) {
            string str;
            string empty = string.Empty;
            if (!File.Exists(archivo)) {
                throw new Exception(string.Concat("No existe el archivo: ", archivo));
            }
            try {
                StreamReader streamReader = File.OpenText(archivo);
                empty = streamReader.ReadToEnd();
                streamReader.Close();
                streamReader.Dispose();
                streamReader = null;
                str = empty;
            } catch (Exception exception) {
                throw exception;
            }
            return str;
        }
    }
}
