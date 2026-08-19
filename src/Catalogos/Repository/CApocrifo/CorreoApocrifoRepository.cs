using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.CApocrifo {
    public class CorreoApocrifoRepository : RepositoryContext<CorreoApocrifo>, ICorreoApocrifoRepository, IRepositoryGeneric {
        public CorreoApocrifoRepository() {
            Description = "Correos de contribuyentes apócrifos";
            FileName = "CorreoApocrifo.json";
        }

        public override CorreoApocrifo Search(string query) {
            CorreoApocrifo correoApocrifo = new CorreoApocrifo();
            correoApocrifo = this.Items.Find(x => x.StandsFor.Equals(query, System.StringComparison.OrdinalIgnoreCase));
            return correoApocrifo;
        }
    }
}
