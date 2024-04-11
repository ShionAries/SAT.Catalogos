using System.IO;

namespace Jaeger.SAT.Catalogos.Helpers {
    internal static class FileService {
        public static Stream ReadFileStrem(string key) {
            var fileName = key;
            return new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        }
    }
}
