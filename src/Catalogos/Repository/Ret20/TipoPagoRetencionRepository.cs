using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ret20 {
    /// <summary>
    /// Retenciones 2.0, Catalogo tipo de pago de la retencion
    /// </summary>
    public class TipoPagoRetencionRepository : RepositoryContext<CveTipoDividendoUtilidadDistrib>, ITipoPagoRepository, IGeneralRepository {
        public TipoPagoRetencionRepository() {
            Title = "Retenciones: Catálogo tipo pago de la retención.";
            FileName = "CatRet20TipoPagoRet.json";
            Version = "1.0";
            Revision = "1";
        }
    }
}
