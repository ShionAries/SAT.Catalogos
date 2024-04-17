using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// catalogo de impuestos
    /// </summary>
    public class ImpuestosRepository : RepositoryContext<CveImpuesto>, IImpuestosRepository, IGeneralRepository {
        public ImpuestosRepository() {
            Title = "Catálogo de impuestos";
            FileName = "ImpuestosCFDI40.json";
            Version = "1.0";
            Revision = "0";
        }
    }
}
