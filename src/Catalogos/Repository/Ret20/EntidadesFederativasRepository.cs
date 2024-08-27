using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ret20 {
    /// <summary>
    /// Retenciones 2.0, Catalogo de entidades federativas (retenciones)
    /// </summary>
    public class EntidadesFederativasRepository : RepositoryContext<CveRetencionEntidadFederativa>, IEntidadesFederativasRepository, IGeneralRepository {
        public EntidadesFederativasRepository() {
            Title = "Catálogo de Entidades Federativas";
            FileName = "CatRet20EntidadesFederativas.json";
            Version = "1.0";
            Revision = "0";
        }

        public CveRetencionEntidadFederativa Search(string findId) {
            CveRetencionEntidadFederativa objeto = new CveRetencionEntidadFederativa();
            objeto = Items.Find((p) => p.Clave == findId);
            return objeto;
        }
    }
}
