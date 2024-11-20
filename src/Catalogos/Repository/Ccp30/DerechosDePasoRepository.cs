using System;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp30 {
    /// <summary>
    /// Catálogo derechos de paso.
    /// </summary>
    public class DerechosDePasoRepository : RepositoryContext<CveDerechosDePaso>, IDerechosDePasoRepository, IRepositoryGeneric {
        public DerechosDePasoRepository() {
            this.Description = "Catálogo derechos de paso.";
            this.FileName = "CatCcp30DerechosDePaso.json";
            this.Version = "1.0";
        }

        public override CveDerechosDePaso Search(string findId) {
            try {
                var search = new CveDerechosDePaso();
                search = this.Items.SingleOrDefault((CveDerechosDePaso p) => p.Clave == findId.Trim());
                if (search == null)
                    return new CveDerechosDePaso { Clave = findId };
                return search;

            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return new CveDerechosDePaso { Clave = findId };
        }
    }
}
