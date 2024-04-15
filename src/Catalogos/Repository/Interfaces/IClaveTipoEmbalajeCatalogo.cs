using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Contracts {
    public interface IClaveTipoEmbalajeCatalogo : IGenericCatalogo<CveTipoEmbalaje> {
        CveTipoEmbalaje Search(string findId);

        System.Collections.Generic.IEnumerable<CveTipoEmbalaje> GetSearch(string findId);
    }
}
