using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jaeger.SAT.CFDI.Catalogos.Interfaces {
    public interface IOriginInterface {
        DateTime? lastVersion { get; set; }
        string destinationFilename { get; set; }
        string downloadUrl { get; set; }
    }
}
