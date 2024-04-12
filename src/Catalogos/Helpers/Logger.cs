using System;
using System.IO;

namespace Jaeger.SAT.Catalogos.Helpers {
    public class Logger : ILogger {
        public static string FileName;
        public Logger() {
            Logger.FileName = "C:\\Jaeger\\Jaeger.Log\\jaeger_sat_catalogo.log";
        }

        public void Info(string message) {
            Console.WriteLine(message);
            Logger.LogWrite(message);
        }

        static public bool LogDelete() {
            try {
                File.Delete(Logger.FileName);
                return true;
            } catch (Exception e) {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static void LogWrite(string mensaje) {
            try {
                if (!File.Exists(Logger.FileName)) {
                    File.Create(Logger.FileName).Close();
                }
                var streamWriter = File.AppendText(Logger.FileName);
                object[] type = new object[] { mensaje, "|", DateTime.Now.ToString("s") };
                streamWriter.WriteLine(string.Concat(type));
                streamWriter.Close();
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
