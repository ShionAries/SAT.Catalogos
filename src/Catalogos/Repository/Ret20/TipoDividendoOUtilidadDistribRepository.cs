using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ret20 {
    /// <summary>
    /// Retenciones 2.0 , Catalogo de Dividendo o utilidad distribuida
    /// </summary>
    public class TipoDividendoOUtilidadDistribRepository : RepositoryContext<CveTipoDividendoUtilidadDistrib>, ITipoDividendoOUtilidadDistribRepository, IGeneralRepository {
        public TipoDividendoOUtilidadDistribRepository() : base() {
            Title = "Catálogo de Tipo de Dividendo o utilidad distribuida";
            FileName = "CatRet20TipoDividendoOUtilidadDistrib.json";
            Version = "1.0";
            Revision = "0";
        }

        public override CveTipoDividendoUtilidadDistrib Search(string query) {
            try {
                var search = this.Items.SingleOrDefault(it => it.Clave == query);
                if (search != null)
                    return search;
            } catch (System.Exception) {

            }
            return new CveTipoDividendoUtilidadDistrib { Clave = query };
        }
    }
}
