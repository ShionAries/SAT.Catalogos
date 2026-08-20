using System;
using System.Collections.Generic;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.CApocrifo;

namespace Jaeger.SAT.Catalogos.Update.Importers.CApocrifo {
    internal class CorreoApocrifoInjector : IInjector {
        protected internal ICorreoApocrifoRepository _Repository;
        protected internal List<CorreoApocrifo> _DataTable;

        public CorreoApocrifoInjector(List<CorreoApocrifo> dataTable) : base() {
            this._DataTable = dataTable;
        }

        public int Inject() {
            this.CreateRepository();
            if (this._Repository != null) {
                return this._Repository.Items.Count();
            }
            return 0;
        }

        protected virtual void CreateRepository() {
            this._Repository = new CorreoApocrifoRepository {
                LastUpdate = DateTime.Now,
                Items = this._DataTable
            };
            this._Repository.Save();
            Console.WriteLine($"Se inyectaron {this._Repository.Items.Count()} registros en {this._DataTable}");
        }
    }
}
