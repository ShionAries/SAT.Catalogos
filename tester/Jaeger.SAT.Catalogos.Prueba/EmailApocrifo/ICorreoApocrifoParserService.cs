// See https://aka.ms/new-console-template for more information
namespace Jaeger.SAT.Catalogos.Prueba.EmailApocrifo {
    public interface ICorreoApocrifoParserService {
        Task<IEnumerable<CorreoApocrifoInfo>> GetSpoofedEmailsInfoAsync(IEnumerable<string> fileUrls);
    }
}