using System.Data;

namespace Jaeger.SAT.Catalogos.Database {
    public class DataTableGateway {
        private DataTable _dataTable;
        private Repository repository;

        public DataTableGateway(DataTable dataTable, Repository repository) {
            this._dataTable = dataTable;
            this.repository = repository;
        }

        public DataTable dataTable() {
            return this._dataTable;
        }

        public void recreate() {

        }
    }
}
