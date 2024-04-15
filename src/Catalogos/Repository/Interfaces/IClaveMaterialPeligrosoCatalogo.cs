using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Contracts {
    /// <summary>
    /// Catálogo de materiales peligrosos.
    /// </summary>
    public interface IClaveMaterialPeligrosoCatalogo : IGenericCatalogo<CveMaterialPeligroso> {
        CveMaterialPeligroso Search(string findId);

        System.Collections.Generic.IEnumerable<CveMaterialPeligroso> GetSearch(string findId);
    }
}
