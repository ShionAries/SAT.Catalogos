using Jaeger.SAT.Catalogos.Scraping.Helpers;
using System.Collections.Generic;

namespace Jaeger.SAT.Catalogos.Scraping.Interfaces {
    public interface IOriginService {
        ControlLayout Control { get; set; }

        /// <summary>
        /// obtener o establecer configuracion
        /// </summary>
        IConfiguration Configuration { get; set; }

        /// <summary>
        /// obtener si la lista de origenes interna
        /// </summary>
        bool IsDefault { get; }

        /// <summary>
        /// obtener o establecer lista de origines de datos
        /// </summary>
        List<IOrigin> DataSource { get; set; }

        /// <summary>
        /// obtener listado de origenes
        /// </summary>
        IOriginService GetAll();

        IOriginService Save();
    }
}
