using System;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    public class UsoCFDIRepository : RepositoryContext<CveUsoCFDI>, IUsoCFDIRepository, IGeneralRepository {
        public UsoCFDIRepository() {
            Title = "Catálogo de Uso de CFDI";
            FileName = "UsoCFDI40.json";
        }

        public CveUsoCFDI Search(string findId) {

            try {
                var search = new CveUsoCFDI();
                search = Items.SingleOrDefault((p) => p.Clave == findId.Trim());
                if (search == null)
                    return new CveUsoCFDI { Clave = findId };
                return search;

            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return new CveUsoCFDI { Clave = findId };
        }
    }
}
