using System;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp31 {
    /// <summary>
    /// Catalogo de Ubicaciones Polos ISTMO
    /// </summary>
    public class RegistroISTMORepository : RepositoryContext<CveRegistroISTMO>, IRegistroISTMORepository, IRepositoryGeneric {
        public RegistroISTMORepository() : base() {
            this.Description = "Catálogo de Ubicaciones Polos ISTMO";
            this.FileName = "CatCcp31RegistroISTMO.json";
            this.Version = "1.0";
        }

        public override CveRegistroISTMO Search(string findId) {
            try {
                var search = new CveRegistroISTMO();
                search = this.Items.SingleOrDefault((CveRegistroISTMO p) => p.Clave == findId.Trim());
                if (search == null)
                    return new CveRegistroISTMO { Clave = findId };
                return search;

            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return new CveRegistroISTMO { Clave = findId };
        }
    }
}
