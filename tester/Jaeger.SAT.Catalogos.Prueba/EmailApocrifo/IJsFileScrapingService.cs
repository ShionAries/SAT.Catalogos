namespace Jaeger.SAT.Catalogos.Prueba.EmailApocrifo {
    public interface IJsFileScrapingService {
        Task<IEnumerable<string>> GetEmailsFromJsFilesAsync(IEnumerable<string> fileUrls);
    }
}