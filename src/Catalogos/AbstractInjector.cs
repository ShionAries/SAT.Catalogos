using System;
using System.Linq;
using System.Data;
using System.IO;
using System.Collections.Generic;

namespace Jaeger.SAT.Catalogos {
    public abstract class AbstractInjector : IInjectorInterface {
        protected DataTable _DataTable;
        protected int _SkipRows;
        protected Dictionary<string, string> _Expected = new Dictionary<string, string>();

        public AbstractInjector(DataTable dataTable) {
            this._DataTable = dataTable;
        }

        protected bool ForLoop(string[] firstArray, string[] secondArray) {
            if (firstArray.Length != secondArray.Length)
                return false;

            for (int i = 0; i < firstArray.Length; i++) {
                if (firstArray[i] != secondArray[i])
                    return false;
            }

            return true;
        }

        public int Inject(string LoggerInterface = "") {
            var tableName = "";

            //Console.WriteLine($"Verificando encabezado de {filename}...");
            this.CreatingHeaders();

            this.CheckHeaders();
            //Console.WriteLine($"Inyectando contenidos de {filename} a {tableName}...");

            var injected = this.ChangeNamesColumns();
            Console.WriteLine($"Se inyectaron {injected} registros en {tableName}");

            return 0;
        }

        public int ChangeNamesColumns() {
            var inserted = 0;
            for (int i = 0; i < this._DataTable.Columns.Count; i++) {
                this._DataTable.Columns[i].ColumnName = this._Expected[this._DataTable.Columns[i].ColumnName];
            }
            this._DataTable.AcceptChanges();
            this.Fill();
            return inserted;
        }

        public abstract void CheckHeaders();

        public abstract void Fill();

        protected void CreatingHeaders() {
            for (int i = 0; i < this._SkipRows; i++) {
                this._DataTable.Rows[i].Delete();
            }
            var d0 = this._DataTable.Rows[this._SkipRows].ItemArray;
            for (int i = 0; i < d0.Length; i++) {
                if (d0[i].ToString() != "")
                    this._DataTable.Columns[i].ColumnName = d0[i].ToString();
            }
            this._DataTable.Rows[this._SkipRows].Delete();
            this._DataTable.AcceptChanges();
            // eliminar columnas que no tienen encabezados correctos
            List<string> columnNames = this._DataTable.Columns
                .Cast<DataColumn>()
                .Select(column => column.ColumnName).Where(column => column.ToLower().StartsWith("column"))
                .ToList();

            foreach (var item in columnNames) {
                this._DataTable.Columns.Remove(item);
            }
            this._DataTable.AcceptChanges();
        }

        protected List<string> GetHeaders() {
            List<string> columnNames = this._DataTable.Columns
                .Cast<DataColumn>()
                .Select(column => column.ColumnName)
                .ToList();
            return columnNames;
        }
    }
}
