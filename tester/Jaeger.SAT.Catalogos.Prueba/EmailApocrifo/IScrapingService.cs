// See https://aka.ms/new-console-template for more information

namespace Jaeger.SAT.Catalogos.Prueba.EmailApocrifo {
    public interface IScrapingService {
        Task<IEnumerable<string>> GetEmailsFromUrlAsync(string url);
    }
}
