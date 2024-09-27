using System;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp31 {
    /// <summary>
    /// Catálogo de puertos marítimos, estaciones aeroportuarias y estaciones férreas.
    /// </summary>
    public class EstacionesRepository : RepositoryContext<CveEstaciones>, IEstacionesRepository, IGeneralRepository {
        public EstacionesRepository(System.DateTime? lastUpdate = null) {
            Title = "Catálogo de puertos marítimos, estaciones aeroportuarias y estaciones férreas.";
            FileName = "CatCcp31Estaciones.json";
            Version = "2.0";
            this.AddLastVersion(lastUpdate);
        }

        public CveEstaciones Search(string findId) {
            try {
                var search = new CveEstaciones();
                search = Items.SingleOrDefault((p) => p.Clave == findId.Trim());
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
