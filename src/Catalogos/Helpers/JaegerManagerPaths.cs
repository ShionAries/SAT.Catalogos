using System;
using System.IO;
using Jaeger.SAT.Catalogos.Abstractions;

namespace Jaeger.SAT.Catalogos.Helpers {
    public class JaegerManagerPaths {
        public static string DefaulPath = "C:\\Jaeger";

        public JaegerManagerPaths(string path = "") {
            if (!DirectoryService.IsDirectory(path)) {
                throw new ArgumentException("The path is not a directory", "path");
            }
            
            if (!string.IsNullOrEmpty(path)) {
                DefaulPath = path;
            }
        }

        /// <summary>
        /// resolver todas las rutas del directorio de trabajo local
        /// </summary>
        public static string JaegerPath(PathsEnum path, string nameFile = "") {
            string segundo = string.Concat("Jaeger.", Enum.GetName(typeof(PathsEnum), path));
            string resultado = DefaulPath;

            if (Directory.Exists(Path.Combine(DefaulPath, segundo))) {
                resultado = Path.Combine(DefaulPath, segundo);
            } else {
                try {
                    Directory.CreateDirectory(Path.Combine(DefaulPath, segundo));
                    resultado = Path.Combine(DefaulPath, segundo);
                } catch (Exception e) {
                    Console.WriteLine(string.Concat("HelperJaegerPaths", e.Message));
                    resultado = DefaulPath;
                }
            }

            // si nos envian un nombre de archivo para la ruta lo agregamos.
            if (nameFile != "") {
                resultado = Path.Combine(resultado, nameFile);
            }

            return resultado;
        }

        /// <summary>
        /// crear directorios de trabajo para la aplciacion
        /// </summary>
        public static void CreatePaths() {
            string[] directorios = Enum.GetNames(typeof(PathsEnum));

            // verificamos el directorio raiz
            if (!(Directory.Exists(DefaulPath))) {
                try {
                    Directory.CreateDirectory(DefaulPath);
                } catch (Exception e) {
                    Console.WriteLine(string.Concat("HelperJaegerPaths: ", e.Message));
                }
            }

            if (!(Directory.Exists(DefaulPath))) {
                // creamos los demas directorios
                foreach (string item in directorios) {
                    Directory.CreateDirectory(Path.Combine(DefaulPath, item));
                }
            }
        }
    }
}
