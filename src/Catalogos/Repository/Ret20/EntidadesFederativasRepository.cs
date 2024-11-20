using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ret20 {
    /// <summary>
    /// Retenciones 2.0, Catalogo de entidades federativas (retenciones)
    /// </summary>
    public class EntidadesFederativasRepository : RepositoryContext<CveRetencionEntidadFederativa>, IEntidadesFederativasRepository, IRepositoryGeneric {
        public EntidadesFederativasRepository() {
            Description = "Catálogo de Entidades Federativas";
            FileName = "CatRet20EntidadesFederativas.json";
            Version = "1.0";
            Revision = "0";
        }

        public override CveRetencionEntidadFederativa Search(string findId) {
            try {
                var search = Items.Find((p) => p.Clave == findId);
                if (search != null)
                    return search;
            } catch (System.Exception) {

            }
            return new CveRetencionEntidadFederativa { Clave = findId };
        }
    }
}
