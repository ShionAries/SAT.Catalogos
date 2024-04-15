using System.Collections.Generic;
using Jaeger.SAT.Catalogos.Repository.Entities;

namespace Jaeger.SAT.Catalogos.Repository.Interfaces {
    public interface IProdServsRepository : IRepositoryContext<ClaveProdServ> {
        List<ClaveProdServ> Clase(string clave);
        List<ClaveProdServ> Clases(string clave);
        List<ClaveProdServ> Grupo(string clave);
        List<ClaveProdServ> Productos();
        List<ClaveProdServ> Productos(string find);
        ClaveProdServ Search(string findId);
        List<ClaveProdServ> Servicios();
    }
}
