using System.Collections.Generic;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;

namespace Jaeger.SAT.Catalogos.Scraping.Builder {
    public interface IUpdaterServiceBuilder {
        IUpdaterServiceIOriginBuilder Update(IOrigin origin);
        IUpdaterServiceIOriginBuilder Update(List<IOrigin> origin);

        List<IOrigin> Origins { get; }
    }
    public interface IUpdaterServiceIOriginBuilder {
        IUpdaterServiceExecuteBuilder Execute();
    }
    public interface IUpdaterServiceExecuteBuilder {
        IUpdaterServiceDownloadBuilder Download();
    }

    public interface IUpdaterServiceDownloadBuilder {
        
    }
}
