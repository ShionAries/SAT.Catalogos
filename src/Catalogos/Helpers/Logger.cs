using System;

namespace Jaeger.SAT.Catalogos.Helpers {
    public class Logger : ILogger {
        public Logger() { }
        public void Info(string message) {
            Console.WriteLine(message);
        }
    }
}
