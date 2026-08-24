namespace Jaeger.SAT.Catalogos.Repository.Cert {
    public class CertificadosRepository : RepositoryContext<Certificate>, ICertificadosRepository {
        public CertificadosRepository() {
            this.Description = "Catálogo de Certificados";
            this.FileName = "CatalogoCertificados.json";
        }

        /// <summary>
        /// recuperar certificado por el numero de serie
        /// </summary>
        /// <param name="serial">numero de serie del certificado</param>
        /// <returns>objeto Certificate</returns>
        public override Certificate Search(string serial) {
            Certificate objeto = new Certificate();
            objeto = this.Items.Find((Certificate p) => p.Serial == serial);
            return (objeto == null ? null : objeto);
        }
    }
}
