using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;
using System.Linq;

namespace Jaeger.SAT.Catalogos.Repository.Ret20 {
    /// <summary>
    /// Retenciones 2.0, Catalogo Tipo de Documento
    /// </summary>
    public class TipoImpuestoRepository : RepositoryContext<CveRetencionTipoImpuesto>, ITipoImpuestoRepository, IRepositoryGeneric {
        public TipoImpuestoRepository() {
            Title = "Catálogo de tipo impuesto.";
            FileName = "CatRet20TipoImpuesto.json";
            Version = "1.0";
            Revision = "0";
        }

        public override CveRetencionTipoImpuesto Search(string query) {
            try {
                var search = this.Items.SingleOrDefault(it => it.Clave == query);
                if (search != null) return search;
            } catch (System.Exception) {

            }
            return new CveRetencionTipoImpuesto { Clave = query };
        }
    }
}
