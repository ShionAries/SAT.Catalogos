using Jaeger.SAT.Catalogos.Repository.Cfdi40;

namespace Jaeger.SAT.Catalogos.Repository.Interfaces {
    public interface ICodigosPostalesRepository : IRepositoryContext<CveCodigoPostal> {
        CveCodigoPostal Search(string find);
    }
}
