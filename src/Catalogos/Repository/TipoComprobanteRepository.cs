using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Entities;
using Jaeger.SAT.Catalogos.Repository.Interfaces;
namespace Jaeger.SAT.Catalogos.Repository {
    public class TipoComprobanteRepository : RepositoryContext<ClaveTipoDeComprobante>, ITipoComprobanteRepository, IGeneralRepository {
        public TipoComprobanteRepository() {
            this.Title = "Catálogo de tipos de Comprobante";
            this.FileName = "CatalogoTipoComprobantes.json";
            this.Version = "1.0";
            this.Revision = "2";

            //this.Items.Add(new ClaveTipoDeComprobante { Clave = "I", Descripcion = "Ingreso", ValorMaximo = new decimal(999999999999999999.999999), VigenciaIni = new DateTime(2017 / 7 / 29) });
            //this.Items.Add(new ClaveTipoDeComprobante { Clave = "E", Descripcion = "Egreso", ValorMaximo = new decimal(999999999999999999.999999), VigenciaIni = new DateTime(2017 / 7 / 29) });
            //this.Items.Add(new ClaveTipoDeComprobante { Clave = "T", Descripcion = "Traslado", ValorMaximo = new decimal(0), VigenciaIni = new DateTime(2017 / 7 / 29) });
            //this.Items.Add(new ClaveTipoDeComprobante { Clave = "N", Descripcion = "Nómina", ValorMaximo = new decimal(999999999999999999.999999), VigenciaIni = new DateTime(2017 / 7 / 29) });
            //this.Items.Add(new ClaveTipoDeComprobante { Clave = "P", Descripcion = "Pago", ValorMaximo = new decimal(999999999999999999.999999), VigenciaIni = new DateTime(2017 / 7 / 29) });
        }
    }
}
