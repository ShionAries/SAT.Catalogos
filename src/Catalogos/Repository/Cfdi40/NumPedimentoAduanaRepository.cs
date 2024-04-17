using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    public class NumPedimentoAduanaRepository : RepositoryContext<CveNumPedimentoAduana>, INumPedimentoAduanaRepository, IGeneralRepository {
        public NumPedimentoAduanaRepository() {
            Title = "Catálogo de números de pedimento operados por aduana y ejercicio.";
            FileName = "NumPedimentoAduanaCFDI40.json";
            Version = "31.0";
            Revision = "0";
        }
    }
}
