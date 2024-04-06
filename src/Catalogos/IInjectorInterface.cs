using Jaeger.SAT.Catalogos.Database;

namespace Jaeger.SAT.Catalogos {
    public interface IInjectorInterface {
        void validate();
        int inject(Repository repository, string logger = "");
    }
}
