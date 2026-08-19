// See https://aka.ms/new-console-template for more information
namespace Jaeger.SAT.Catalogos.Prueba.EmailApocrifo {
    public interface ISatEmailParserService {
        Task<IEnumerable<SatSpoofedEmailInfo>> GetSpoofedEmailsInfoAsync(IEnumerable<string> fileUrls);
    }
}