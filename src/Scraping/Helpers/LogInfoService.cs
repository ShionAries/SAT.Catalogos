using System;
using System.IO;

namespace Jaeger.SAT.Catalogos.Scraping.Helpers {
    /// <summary>
    /// Clase para looger de informacion
    /// </summary>
    internal class LogInfoService {
        static readonly string path = @"C:\Jaeger\Jaeger.Log";

        internal static void Log(string title, string stackTrace) {
            if (!Directory.Exists(path)) {
                Directory.CreateDirectory(path);
            }
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            stringBuilder.AppendLine("-------------------------------------------------->");
            stringBuilder.AppendLine($"{DateTime.Now:dd/MM/yyyy HH:mm:ss}: {title}\r\n");
            stringBuilder.AppendLine(stackTrace);
            stringBuilder.AppendLine("");
            using (StreamWriter streamWriter = new StreamWriter(Path.Combine(path, "Jaeger_SAT_Catalogos_Scraping.log"), true))
                streamWriter.Write(stringBuilder.ToString());
        }
    }
}
