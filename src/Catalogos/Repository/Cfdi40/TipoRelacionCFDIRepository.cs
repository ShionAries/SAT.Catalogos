using System.Text.RegularExpressions;
using System;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// Catalogo de tipos de relacion entre CFDI.
    /// </summary>
    public class TipoRelacionCFDIRepository : RepositoryContext<CveTipoRelacionCFDI>, ITipoRelacionCFDIRepository, IGeneralRepository {
        public TipoRelacionCFDIRepository(System.DateTime? lastUpdate = null) {
            Title = "Catálogo de tipos de relación entre CFDI.";
            FileName = "TipoRelacionCFDI40.json";
            this.AddLastVersion(lastUpdate);
        }

        public CveTipoRelacionCFDI Search(string findId) {
            var _search = Regex.Replace(findId, "[^\\d]", "");
            try {
                var _response = new CveTipoRelacionCFDI();
                _response = Items.SingleOrDefault((p) => p.Clave == _search);
                return _response;
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return new CveTipoRelacionCFDI { Clave = findId };
        }
    }
}
