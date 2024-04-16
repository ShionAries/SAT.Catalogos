using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Contracts;
using Jaeger.SAT.Catalogos.Repository.Entities;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository {
    /// <summary>
    /// Cartaporte 3.0 Catalogo de Regimen Aduanero
    /// </summary>
    public class CartaPorte30RegimenAduanero : RepositoryContext<ClaveCartaPorteRegimenAduanero>, ICartaPorte30RegimenAduaneroRepository, IGeneralRepository {

    }
}
