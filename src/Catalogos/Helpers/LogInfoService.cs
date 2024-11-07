namespace Jaeger.SAT.Catalogos.Helpers {
    /// <summary>
    /// Clase para looger de informacion
    /// </summary>
    internal class LogInfoService {
        static readonly string path = @"C:\Jaeger\Jaeger.Log";

        internal static void Log(string title, string stackTrace) {
            if (!System.IO.Directory.Exists(path)) {
                System.IO.Directory.CreateDirectory(path);
            }
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            stringBuilder.AppendLine("-------------------------------------------------->");
            stringBuilder.AppendLine($"{System.DateTime.Now:dd/MM/yyyy HH:mm:ss}: {title}\r\n");
            stringBuilder.AppendLine(stackTrace);
            stringBuilder.AppendLine("");
            using (System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(System.IO.Path.Combine(path, "Jaeger_SAT_Catalogos_Scraping.log"), true))
                streamWriter.Write(stringBuilder.ToString());
        }
    }
}
