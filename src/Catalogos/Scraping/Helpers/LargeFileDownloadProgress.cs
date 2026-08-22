using System;

namespace Jaeger.SAT.Catalogos.Scraping.Helpers {
    public class LargeFileDownloadProgress {
        public long BytesDownloaded { get; set; }
        public long? TotalBytes { get; set; }
        public double? Percentage {
            get {
                return TotalBytes.HasValue && TotalBytes > 0
            ? Math.Round((double)BytesDownloaded / TotalBytes.Value * 100, 2)
            : (double?)null;
            }
        }
    }
}