using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jaeger.SAT.Catalogos.Scraping.Helpers;
using Jaeger.SAT.Catalogos.Scraping.Interfaces;

namespace Jaeger.SAT.Catalogos.Scraping {
    public interface IScrapingService {
        IResourcesGateway Gateway { get; set; }
        IScrapingService Set(IResourcesGateway gateway);
        IScraping1Service Review(IOrigin origin);
        IScraping2Service Review(List<IOrigin> origins);
    }

    public interface IScraping1Service {
        IScraping3Service Execute();
    }

    public interface IScraping2Service {
        IScraping4Service Execute();
    }

    public interface IScraping3Service {
        IScraping5Service Download();

    }

    public interface IScraping4Service {
        IScraping6Service Download();

    }

    public interface IScraping5Service { }
    public interface IScraping6Service { }

    public class ScrapingService : IScrapingService, IScraping1Service, IScraping2Service, IScraping3Service, IScraping4Service, IScraping5Service, IScraping6Service {
        public ScrapingService() { }

        public IResourcesGateway Gateway { get; set; }
        IResourcesGateway IScrapingService.Gateway { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IScrapingService Set(IResourcesGateway gateway) {
            this.Gateway = gateway;
            return this;
        }

        public IScrapingService Review(IOrigin origin) {
            return this;
        }

        IScrapingService IScrapingService.Set(IResourcesGateway gateway) {
            throw new NotImplementedException();
        }

        IScraping1Service IScrapingService.Review(IOrigin origin) {
            throw new NotImplementedException();
        }

        IScraping2Service IScrapingService.Review(List<IOrigin> origins) {
            throw new NotImplementedException();
        }

        IScraping3Service IScraping1Service.Execute() {
            throw new NotImplementedException();
        }

        IScraping4Service IScraping2Service.Execute() {
            throw new NotImplementedException();
        }

        IScraping5Service IScraping3Service.Download() {
            throw new NotImplementedException();
        }

        IScraping6Service IScraping4Service.Download() {
            throw new NotImplementedException();
        }
    }

    public class Prueba {
        Prueba() {
            IScrapingService service = new ScrapingService().Set(new ResourcesGateway());
            service.Review(new Entities.ScrapingOrigin()).Execute();
            service.Review(new List<IOrigin>() { new Entities.ScrapingOrigin(), new Entities.ConstantOrigin() }).Execute().Download();
        }
    }
}
