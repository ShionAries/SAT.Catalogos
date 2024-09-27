using System;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp31 {
    /// <summary>
    /// Catálogo de partes del transporte rentadas o prestadas.
    /// </summary>
    public class ParteTransporteRepository : RepositoryContext<CveParteTransporte>, IParteTransporteRepository, IGeneralRepository {
        public ParteTransporteRepository(System.DateTime? lastUpdate = null) {
            this.Title = "Catálogo de partes del transporte rentadas o prestadas.";
            this.FileName = "CatCcp31ParteTransporte.json";
            this.Version = "1.0";
            this.AddLastVersion(lastUpdate);
        }

        public CveParteTransporte Search(string findId) {
            try {
                var search = new CveParteTransporte();
                search = this.Items.SingleOrDefault((CveParteTransporte p) => p.Clave == findId.Trim());
                if (search == null)
                    return new CveParteTransporte { Clave = findId };
                return search;

            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return new CveParteTransporte { Clave = findId };
        }
    }
}
