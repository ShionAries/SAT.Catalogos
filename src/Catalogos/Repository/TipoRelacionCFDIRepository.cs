using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Entities;
using Jaeger.SAT.Catalogos.Repository.Interfaces;
using System.Text.RegularExpressions;
using System;
using System.Linq;

namespace Jaeger.SAT.Catalogos.Repository {
    /// <summary>
    /// Catalogo de tipos de relacion entre CFDI.
    /// </summary>
    public class TipoRelacionCFDIRepository : RepositoryContext<ClaveTipoRelacionCFDI>, ITipoRelacionCFDIRepository, IGeneralRepository {
        public TipoRelacionCFDIRepository() {
            this.Title = "Catálogo de tipos de relación entre CFDI.";
            this.FileName = "CatalogoTipoRelacionCFDI.json";
        }

        public ClaveTipoRelacionCFDI Search(string findId) {
            var _search = Regex.Replace(findId, "[^\\d]", "");
            try {
                var _response = new ClaveTipoRelacionCFDI();
                _response = this.Items.SingleOrDefault((ClaveTipoRelacionCFDI p) => p.Clave == _search);
                return _response;
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return new ClaveTipoRelacionCFDI { Clave = findId };
        }
    }
}
