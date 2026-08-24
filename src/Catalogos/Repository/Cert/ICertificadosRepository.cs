using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Cert {
    public interface ICertificadosRepository : IRepositoryContext<Certificate>, IRepositoryGeneric {
        new Certificate Search(string serial);
    }
}
