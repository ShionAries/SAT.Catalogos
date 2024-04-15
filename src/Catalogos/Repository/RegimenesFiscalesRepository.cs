using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Entities;
using Jaeger.SAT.Catalogos.Repository.Interfaces;
using System.Text.RegularExpressions;
using System;
using System.Linq;
namespace Jaeger.SAT.Catalogos.Repository {
    /// <summary>
    /// Catálogo de régimen fiscal.
    /// </summary>
    public class RegimenesFiscalesRepository : RepositoryContext<ClaveRegimenFiscal>, IRegimenesFiscalesRepository, IGeneralRepository {
        public RegimenesFiscalesRepository() {
            this.Title = "Catálogo Remimenes Fiscales";
            this.FileName = "CatalogoRegimenesFiscales.json";
        }

        public ClaveRegimenFiscal Search(string findId) {
            if (findId != null) {
                string str = Regex.Replace(findId, "[^\\d]", "");
                try {
                    ClaveRegimenFiscal objeto = new ClaveRegimenFiscal();
                    objeto = this.Items.SingleOrDefault((ClaveRegimenFiscal p) => p.Clave == str);
                    return objeto;
                } catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }
            }
            return new ClaveRegimenFiscal { Clave = findId };
        }
    }
}
