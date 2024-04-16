using System;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Entities;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository {
    public class UsoCFDIRepository : RepositoryContext<ClaveUsoCFDI>, IUsoCFDIRepository, IGeneralRepository {
        public UsoCFDIRepository() {
            this.Title = "Catálogo de Uso de CFDI";
            this.FileName = "CatalogoUsoCFDI40.json";
        }

        public ClaveUsoCFDI Search(string findId) {

            try {
                var search = new ClaveUsoCFDI();
                search = this.Items.SingleOrDefault((ClaveUsoCFDI p) => p.Clave == findId.Trim());
                if (search == null)
                    return new ClaveUsoCFDI { Clave = findId };
                return search;

            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return new ClaveUsoCFDI { Clave = findId };
        }
    }
}
