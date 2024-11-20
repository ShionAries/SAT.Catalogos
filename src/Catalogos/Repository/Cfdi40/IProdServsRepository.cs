using System.Collections.Generic;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// catalogo de Claves de Productos y Servicios.
    /// </summary>
    public interface IProdServsRepository : IRepositoryContext<CveProdServ> {
        List<CveProdServ> Clase(string clave);
        List<CveProdServ> Clases(string clave);
        List<CveProdServ> Grupo(string clave);
        List<CveProdServ> Productos();
        List<CveProdServ> Productos(string find);
        List<CveProdServ> Servicios();
    }
}
