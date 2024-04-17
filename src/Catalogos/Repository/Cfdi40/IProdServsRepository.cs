using System.Collections.Generic;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    public interface IProdServsRepository : IRepositoryContext<CveProdServ> {
        List<CveProdServ> Clase(string clave);
        List<CveProdServ> Clases(string clave);
        List<CveProdServ> Grupo(string clave);
        List<CveProdServ> Productos();
        List<CveProdServ> Productos(string find);
        CveProdServ Search(string findId);
        List<CveProdServ> Servicios();
    }
}
