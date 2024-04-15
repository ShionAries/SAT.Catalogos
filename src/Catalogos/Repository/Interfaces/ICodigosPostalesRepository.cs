using Jaeger.SAT.Catalogos.Repository.Entities;

namespace Jaeger.SAT.Catalogos.Repository.Interfaces {
    public interface ICodigosPostalesRepository : IRepositoryContext<ClaveCodigoPostal> {
        ClaveCodigoPostal Search(string find);
    }
}
