using System;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp31 {
    /// <summary>
    /// Catalogo de Regimen Aduanero
    /// </summary>
    public class RegimenAduaneroRepository : RepositoryContext<CveRegimenAduanero>, IRegimenAduaneroRepository, IRepositoryGeneric {
        public RegimenAduaneroRepository() {
            Description = "Catálogo de Régimen Aduanero";
            FileName = "CatCcp31RegimenAduanero.json";
            Version = "1.0";
        }

        public override CveRegimenAduanero Search(string findId) {
            try {
                var search = this.Items.SingleOrDefault((CveRegimenAduanero p) => p.Clave == findId.Trim());
                if (search == null)
                    return new CveRegimenAduanero { Clave = findId };
                return search;

            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return new CveRegimenAduanero { Clave = findId };
        }
    }
}
