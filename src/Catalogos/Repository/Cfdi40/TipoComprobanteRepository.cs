using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Cfdi40 {
    /// <summary>
    /// catalogo de tipos de comprobantes
    /// </summary>
    public class TipoComprobanteRepository : RepositoryContext<CveTipoDeComprobante>, ITipoComprobanteRepository, IGeneralRepository {
        public TipoComprobanteRepository(System.DateTime? lastUpdate = null) {
            Title = "Catálogo de tipos de Comprobante";
            FileName = "TipoComprobantes40.json";
            Version = "1.0";
            Revision = "2";
            this.AddLastUpdate(lastUpdate);
            //this.Items.Add(new ClaveTipoDeComprobante { Clave = "I", Descripcion = "Ingreso", ValorMaximo = new decimal(999999999999999999.999999), VigenciaIni = new DateTime(2017 / 7 / 29) });
            //this.Items.Add(new ClaveTipoDeComprobante { Clave = "E", Descripcion = "Egreso", ValorMaximo = new decimal(999999999999999999.999999), VigenciaIni = new DateTime(2017 / 7 / 29) });
            //this.Items.Add(new ClaveTipoDeComprobante { Clave = "T", Descripcion = "Traslado", ValorMaximo = new decimal(0), VigenciaIni = new DateTime(2017 / 7 / 29) });
            //this.Items.Add(new ClaveTipoDeComprobante { Clave = "N", Descripcion = "Nómina", ValorMaximo = new decimal(999999999999999999.999999), VigenciaIni = new DateTime(2017 / 7 / 29) });
            //this.Items.Add(new ClaveTipoDeComprobante { Clave = "P", Descripcion = "Pago", ValorMaximo = new decimal(999999999999999999.999999), VigenciaIni = new DateTime(2017 / 7 / 29) });
        }
    }
}
