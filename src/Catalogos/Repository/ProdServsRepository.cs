using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Entities;
using Jaeger.SAT.Catalogos.Repository.Interfaces;
using System.Collections.Generic;
using System;
using System.Linq;
namespace Jaeger.SAT.Catalogos.Repository {
    public class ProdServsRepository : RepositoryContext<ClaveProdServ>, IProdServsRepository, IGeneralRepository {
        public ProdServsRepository() {
            this.Version = "3.0";
            this.Revision = "2";
            this.Title = "Catálogo de Productos y Servicios";
            this.FileName = "CatalogProdServs.json";
        }

        public ClaveProdServ Search(string findId) {
            ClaveProdServ objeto = new ClaveProdServ();
            objeto = this.Items.Find((ClaveProdServ p) => p.Clave == findId);
            return objeto;
        }

        public List<ClaveProdServ> Productos(string find) {
            var response = new List<ClaveProdServ>();
            response = this.Items.Where(p => p.Descripcion.Contains(find) | p.PalabrasSimilares.Contains(find)).ToList();
            return response;
        }

        public List<ClaveProdServ> Productos() {
            List<ClaveProdServ> obj = new List<ClaveProdServ>();
            obj = this.Items.Where(p => p.Clave.Contains("000000") | p.Clave.Contains("95000000") & Int32.Parse(p.Clave) >= 10000000 & Int32.Parse(p.Clave) <= 60000000).OrderBy(o => o.Descripcion).ToList();
            return obj;
        }

        public List<ClaveProdServ> Servicios() {
            List<ClaveProdServ> obj = new List<ClaveProdServ>();
            obj = this.Items.Where(p => p.Clave.Contains("000000") & Int32.Parse(p.Clave) > 70000000 & Int32.Parse(p.Clave) < 94000000).OrderBy(o => o.Descripcion).ToList();
            return obj;
        }

        public List<ClaveProdServ> Grupo(string clave) {
            Int32 r1 = Int32.Parse(clave.Substring(0, 2) + "000000");
            Int32 r2 = Int32.Parse(clave.Substring(0, 2) + "990000");
            List<ClaveProdServ> grupo = this.Items.Where(p => p.Clave.Contains("0000") & Int32.Parse(p.Clave) < r2 & Int32.Parse(p.Clave) > r1).OrderBy(o => o.Descripcion).ToList();
            return grupo;
        }

        public List<ClaveProdServ> Clase(string clave) {
            Int32 r1 = Int32.Parse(clave.Substring(0, 4) + "0000");
            Int32 r2 = Int32.Parse(clave.Substring(0, 4) + "9900");
            List<ClaveProdServ> clases = this.Items.Where(p => p.Clave.Contains("00") & Int32.Parse(p.Clave) < r2 & Int32.Parse(p.Clave) > r1).OrderBy(o => o.Descripcion).ToList();
            return clases;
        }

        /// <summary>
        /// obtener listado de productos y servicios a partir de la clase
        /// </summary>
        public List<ClaveProdServ> Clases(string clave) {
            Int32 r1 = Int32.Parse(clave.Substring(0, 6) + "00");
            Int32 r2 = Int32.Parse(clave.Substring(0, 6) + "99");
            List<ClaveProdServ> clases = this.Items.Where(p => Int32.Parse(p.Clave) < r2 & Int32.Parse(p.Clave) > r1).OrderBy(o => o.Descripcion).ToList();
            return clases;
        }
    }
}
