using System;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp31 {
    /// <summary>
    /// catalogo de localidades. 
    /// </summary>
    public class LocalidadRepository : RepositoryContext<CveLocalidad>, ILocalidadRepository, IGeneralRepository {
        public LocalidadRepository(System.DateTime? lastUpdate = null) {
            Title = "Catálogo de localidades.";
            FileName = "CatCcp31Localidad.json";
            Version = "1.0";
            this.AddLastVersion(lastUpdate);
        }

        public CveLocalidad Search(string findId) {
            try {
                var search = new CveLocalidad();
                search = Items.SingleOrDefault((p) => p.Clave == findId.Trim());
                if (search == null)
                    return new CveLocalidad { Clave = findId };
                return search;

            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return new CveLocalidad { Clave = findId };
        }
    }
}
