using System;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp30 {
    /// <summary>
    /// Catálogo de contenedores marítimos.
    /// </summary>
    public class ContenedorMaritimoRepository : RepositoryContext<CveContenedorMaritimo>, IContenedorMaritimoRepository, IRepositoryGeneric {
        public ContenedorMaritimoRepository() {
            this.Title = "Catálogo de contenedores marítimos.";
            this.FileName = "CatCcp30ContenedorMaritimo.json";
            this.Version = "1.0";
        }

        public override CveContenedorMaritimo Search(string findId) {
            try {
                var search = new CveContenedorMaritimo();
                search = this.Items.SingleOrDefault((CveContenedorMaritimo p) => p.Clave == findId.Trim());
                if (search == null)
                    return new CveContenedorMaritimo { Clave = findId };
                return search;

            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return new CveContenedorMaritimo { Clave = findId };
        }
    }
}
