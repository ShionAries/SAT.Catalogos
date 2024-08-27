using System;
using System.Linq;
using Newtonsoft.Json;
using Jaeger.SAT.Catalogos.Repository.Abstracts;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Repository.Ccp31 {
    /// <summary>
    /// catalogo de documentos aduaneros
    /// </summary>
    [JsonObject("item")]
    public class DocumentoAduaneroRepository : RepositoryContext<CveDocumentoAduanero>, IDocuemntoAduaneroRepository, IGeneralRepository { 
        public DocumentoAduaneroRepository() {
            this.Title = "Catálogo de Documentos Aduaneros";
            this.FileName = "CatCcp30DocumentosAduaneros.json";
            this.Version = "1.0";
        }

        public CveDocumentoAduanero Search(string findId) {
            try {
                var search = new CveDocumentoAduanero();
                search = this.Items.SingleOrDefault((CveDocumentoAduanero p) => p.Clave == findId.Trim());
                if (search == null)
                    return new CveDocumentoAduanero { Clave = findId };
                return search;

            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return new CveDocumentoAduanero { Clave = findId };
        }
    }
}
