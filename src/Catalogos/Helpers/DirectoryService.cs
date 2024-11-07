using System;
using System.IO;

namespace Jaeger.SAT.Catalogos.Helpers {
    internal static class DirectoryService {
        /// <summary>
        /// funcion para comprobar si es un directorio
        /// </summary>
        /// <param name="path">ruta valida</param>
        /// <returns>devuelve verdadero si es un directorio</returns>
        public static bool IsDirectory(string path) {
            try {
                var attr = File.GetAttributes(path);
                return attr.HasFlag(FileAttributes.Directory);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        /// <summary>
        /// funcion para comprobar la existencia de un directorio
        /// </summary>
        /// <param name="path">ruta valida</param>
        /// <returns>retorna verdadero si el directorio existe</returns>
        public static bool Exists(string path) { 
            return Directory.Exists(path);
        }
    }
}
