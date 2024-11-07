using System.ComponentModel;

namespace Jaeger.SAT.Catalogos.Scraping.ValueObjects {
    public enum SourceIdentifierEnum {
        [Description("CFDI ver. 3.3")]
        CFDIv33,
        [Description("CFDI ver. 4.0")]
        CFDIv40,
        [Description("Retencion 2.0")]
        RETv20,
        [Description("Nómina 1.2")]
        Nomina12,
        [Description("Nóimina Estados")]
        NominaEstados,
        [Description("Artículo 69 No localizados")]
        Articulo69,
        [Description("Artículo 69-B Listado Completo")]
        Articulo69B,
        [Description("CCP 2.0 - Carta Porte 2.0")]
        CPortev20,
        [Description("CCP 3.0 - Carta Porte 3.0")]
        CPortev30,
        [Description("CCP 3.1 - Carta Porte 3.1")]
        CPorteV31,
        REP
    }
}
