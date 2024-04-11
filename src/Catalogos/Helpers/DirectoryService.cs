using System;
using System.IO;

namespace Jaeger.SAT.Catalogos.Helpers {
    internal static class DirectoryService {
        public static bool IsDirectory(string path) {
            try {
                var attr = File.GetAttributes(path);
                return attr.HasFlag(FileAttributes.Directory);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public static bool Exists(string path) { 
            return Directory.Exists(path);
        }
    }
}
