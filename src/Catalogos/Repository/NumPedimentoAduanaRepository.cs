using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Entities;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository {
    public class NumPedimentoAduanaRepository : RepositoryContext<ClaveNumPedimentoAduana>, INumPedimentoAduanaRepository, IGeneralRepository {
        public NumPedimentoAduanaRepository() {
            Title = "Catálogo de números de pedimento operados por aduana y ejercicio.";
            FileName = "CatalogoNumPedimentoAduana.json";
            Version = "31.0";
            Revision = "0";
        }
    }
}
