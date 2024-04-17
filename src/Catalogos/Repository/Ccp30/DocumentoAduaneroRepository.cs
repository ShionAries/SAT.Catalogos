using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp30 {
    [JsonObject("item")]
    public class DocumentoAduaneroRepository : RepositoryContext<CveDocumentoAduanero>, IDocuemntoAduaneroRepository, IGeneralRepository { }
}
