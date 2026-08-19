using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jaeger.SAT.Catalogos.Repository.CApocrifo;
using Jaeger.SAT.Catalogos.Update.Abstracts;

namespace Jaeger.SAT.Catalogos.Update.Importers.CApocrifo {
    internal class CorreoApocrifoInjector : AbstractInjector, IInjector {
        public CorreoApocrifoInjector(DataTable dataTable) : base(dataTable) {
            this.SkipRows = 0;
        }

        protected override void CheckHeaders() {
            this._HeadersMapper = new Dictionary<string, string>();
            this._HeadersMapper["correo"] = "Correo";
        }

        protected override void CreateRepository() {
            this._Repository = new CorreoApocrifoRepository() { LastUpdate = this.LastUpdate };
        }
    }
}
