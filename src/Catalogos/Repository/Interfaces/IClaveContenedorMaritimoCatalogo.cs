using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Contracts {
    /// <summary>
    /// Catálogo de contenedores marítimos.
    /// </summary>
    public interface IClaveContenedorMaritimoCatalogo : IGenericCatalogo<CveContenedorMaritimo> {
        CveContenedorMaritimo Search(string findId);
    }
}
