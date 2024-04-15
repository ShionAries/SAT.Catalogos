using System.Collections.Generic;
using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Contracts {
    public interface ICveProdServCPCatalogo : IGenericCatalogo<CveProdServCP> {
        List<CveProdServCP> Productos(string find);
    }
}
