using System.Collections.Generic;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// catalogo de Claves de Productos y Servicios.
    /// </summary>
    public class ProdServsRepository : RepositoryContext<CveProdServ>, IProdServsRepository, IRepositoryGeneric {
        public ProdServsRepository() {
            Version = "3.0";
            Revision = "2";
            Description = "Catálogo de Productos y Servicios";
            FileName = "ProdServsCFDI40.json";
        }

        public override CveProdServ Search(string findId) {
            try {
            var search = Items.Find((p) => p.Clave == findId);
                if (search == null) return new CveProdServ() { Clave = findId };
            return search;
            } catch (System.Exception) {

            }
            return new CveProdServ() { Clave = findId };
        }

        public List<CveProdServ> Productos(string find) {
            var response = new List<CveProdServ>();
            response = Items.Where(p => p.Descripcion.Contains(find) | p.PalabrasSimilares.Contains(find)).ToList();
            return response;
        }

        public List<CveProdServ> Productos() {
            List<CveProdServ> obj = new List<CveProdServ>();
            obj = Items.Where(p => p.Clave.Contains("000000") | p.Clave.Contains("95000000") & int.Parse(p.Clave) >= 10000000 & int.Parse(p.Clave) <= 60000000).OrderBy(o => o.Descripcion).ToList();
            return obj;
        }

        public List<CveProdServ> Servicios() {
            List<CveProdServ> obj = new List<CveProdServ>();
            obj = Items.Where(p => p.Clave.Contains("000000") & int.Parse(p.Clave) > 70000000 & int.Parse(p.Clave) < 94000000).OrderBy(o => o.Descripcion).ToList();
            return obj;
        }

        public List<CveProdServ> Grupo(string clave) {
            int r1 = int.Parse(clave.Substring(0, 2) + "000000");
            int r2 = int.Parse(clave.Substring(0, 2) + "990000");
            List<CveProdServ> grupo = Items.Where(p => p.Clave.Contains("0000") & int.Parse(p.Clave) < r2 & int.Parse(p.Clave) > r1).OrderBy(o => o.Descripcion).ToList();
            return grupo;
        }

        public List<CveProdServ> Clase(string clave) {
            int r1 = int.Parse(clave.Substring(0, 4) + "0000");
            int r2 = int.Parse(clave.Substring(0, 4) + "9900");
            List<CveProdServ> clases = Items.Where(p => p.Clave.Contains("00") & int.Parse(p.Clave) < r2 & int.Parse(p.Clave) > r1).OrderBy(o => o.Descripcion).ToList();
            return clases;
        }

        /// <summary>
        /// obtener listado de productos y servicios a partir de la clase
        /// </summary>
        public List<CveProdServ> Clases(string clave) {
            int r1 = int.Parse(clave.Substring(0, 6) + "00");
            int r2 = int.Parse(clave.Substring(0, 6) + "99");
            List<CveProdServ> clases = Items.Where(p => int.Parse(p.Clave) < r2 & int.Parse(p.Clave) > r1).OrderBy(o => o.Descripcion).ToList();
            return clases;
        }
    }
}
