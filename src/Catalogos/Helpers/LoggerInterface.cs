using System;

namespace Jaeger.SAT.Catalogos.Helpers {
    public class LoggerInterface : ILoggerInterface {
        public LoggerInterface() { }
        public void Info(string message) {
            Console.WriteLine(message);
        }
    }
}
