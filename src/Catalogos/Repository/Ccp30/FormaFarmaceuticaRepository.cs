using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;
using Newtonsoft.Json;

namespace Jaeger.SAT.Catalogos.Repository.Ccp30 {
    [JsonObject("item")]
    public class FormaFarmaceuticaRepository : RepositoryContext<CveFormaFarmaceutica>, IFormaFarmaceuticaRepository, IGeneralRepository { }
}
