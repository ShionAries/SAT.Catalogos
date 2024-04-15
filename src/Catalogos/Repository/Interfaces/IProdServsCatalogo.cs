using System.Collections.Generic;
using Jaeger.Catalogos.Contracts;
using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Contracts {
    public interface IProdServsCatalogo : IGenericCatalogo<ClaveProdServ> {
        List<ClaveProdServ> Clase(string clave);
        List<ClaveProdServ> Clases(string clave);
        List<ClaveProdServ> Grupo(string clave);
        List<ClaveProdServ> Productos();
        List<ClaveProdServ> Productos(string find);
        ClaveProdServ Search(string findId);
        List<ClaveProdServ> Servicios();
    }
}
