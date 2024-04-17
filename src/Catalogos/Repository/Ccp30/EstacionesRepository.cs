using System;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Ccp30;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.Catalogos.Repositories {
    /// <summary>
    /// Catálogo de puertos marítimos, estaciones aeroportuarias y estaciones férreas.
    /// </summary>
    public class EstacionesRepository : RepositoryContext<CveEstaciones>, IEstacionesRepository, IGeneralRepository {
        public EstacionesRepository() {
            this.Title = "Catálogo de puertos marítimos, estaciones aeroportuarias y estaciones férreas.";
            this.FileName = "CatalogoEstaciones.json"; 
            this.Version = "2.0";
        }

        public CveEstaciones Search(string findId) {
            try {
                var search = new CveEstaciones();
                search = this.Items.SingleOrDefault((CveEstaciones p) => p.Clave == findId.Trim());
                if (search == null)
                    return new CveEstaciones { Clave = findId };
                return search;

            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return new CveEstaciones { Clave = findId };
        }
    }
}
