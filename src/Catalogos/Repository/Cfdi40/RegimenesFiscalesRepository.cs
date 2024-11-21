using System;
using System.Text.RegularExpressions;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// catalogo de regimen fiscal.
    /// </summary>
    public class RegimenesFiscalesRepository : RepositoryContext<CveRegimenFiscal>, IRegimenesFiscalesRepository, IRepositoryGeneric {
        public RegimenesFiscalesRepository() {
            Description = "Catálogo Remimenes Fiscales";
            FileName = "RegimenesFiscalesCFDI40.json";
        }

        public override CveRegimenFiscal Search(string findId) {
            if (findId != null) {
                string str = Regex.Replace(findId, "[^\\d]", "");
                try {
                    CveRegimenFiscal objeto = new CveRegimenFiscal();
                    objeto = Items.SingleOrDefault((p) => p.Clave == str);
                    return objeto;
                } catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }
            }
            return new CveRegimenFiscal { Clave = findId };
        }
    }
}
