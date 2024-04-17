using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp30 {
    public class RegimenAduaneroRepository : RepositoryContext<CveRegimenAduanero>, IRegimenAduaneroRepository, IGeneralRepository {
        public RegimenAduaneroRepository() {
            Title = "Catálogo de Régimen Aduanero";
            FileName = "RegimenAduaneroCcp30.json";
            Version = "1.0";
            Revision = "2";
        }
    }
}
