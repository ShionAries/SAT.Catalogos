using System;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Entities;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.Catalogos.Repositories {
    /// <summary>
    /// Catálogo de localidades. 
    /// </summary>
    public class LocalidadRepository : RepositoryContext<CveLocalidad>, IClaveLocalidadRepository, IGeneralRepository {
        public LocalidadRepository() {
            this.Title = "Catálogo de localidades.";
            this.FileName = "CatalogoLocalidad.json";
            this.Version = "1.0";
        }

        public CveLocalidad Search(string findId) {
            try {
                var search = new CveLocalidad();
                search = this.Items.SingleOrDefault((CveLocalidad p) => p.Clave == findId.Trim());
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
