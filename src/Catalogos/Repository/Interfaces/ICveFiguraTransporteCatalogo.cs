using Jaeger.Catalogos.Entities;

namespace Jaeger.Catalogos.Contracts {
    /// <summary>
    /// Nodo condicional para indicar los datos de la(s) figura(s) del transporte que interviene(n) en el traslado de los bienes y/o mercancías realizado 
    /// a través de los distintos medios de transporte dentro del territorio nacional, cuando el dueño de dicho medio sea diferente del emisor del 
    /// comprobante con el complemento Carta Porte.
    /// </summary>
    public interface ICveFiguraTransporteCatalogo : IGenericCatalogo<CveFiguraTransporte> {
    }
}
