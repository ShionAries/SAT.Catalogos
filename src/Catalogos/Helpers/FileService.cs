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
    }
}
