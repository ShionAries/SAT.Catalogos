using System;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp20 {
    /// <summary>
    /// Catálogo de número autorización agente naviero consignatario. 
    /// </summary>
    public class NumAutorizacionNavieroRepository : RepositoryContext<CveNumAutorizacionNaviero>, INumAutorizacionNavieroRepository, IGeneralRepository {
        public NumAutorizacionNavieroRepository() {
            this.Title = "Catálogo de número autorización agente naviero consignatario. ";
            this.FileName = "CatCcp20NumAutorizacionNaviero.json";
            this.Version = "2.0";
        }

        public CveNumAutorizacionNaviero Search(string findId) {
            try {
                var search = new CveNumAutorizacionNaviero();
                search = this.Items.SingleOrDefault((CveNumAutorizacionNaviero p) => p.NumAutorizacion == findId.Trim());
                if (search == null)
                    return new CveNumAutorizacionNaviero { NumAutorizacion = findId };
                return search;

            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return new CveNumAutorizacionNaviero { NumAutorizacion = findId };
        }
    }
}
