using System;
using System.Linq;
using System.Data;
using System.IO;
using System.Collections.Generic;

namespace Jaeger.SAT.Catalogos.Update {
    public abstract class AbstractInjector : IInjectorInterface {
        protected DataTable _DataTable;
        protected int _SkipRows;
        protected Dictionary<string, string> _Expected = new Dictionary<string, string>();

        public AbstractInjector(DataTable dataTable) {
            _DataTable = dataTable;
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

        public int Inject(Helpers.ILoggerInterface logger) {
            //logger.Info($"Verificando encabezado de {filename}...");
            CreatingHeaders();

            CheckHeaders();
            //Console.WriteLine($"Inyectando contenidos de {filename} a {tableName}...");

            var injected = ChangeNamesColumns();
            //Console.WriteLine($"Se inyectaron {injected} registros en {tableName}");

            return 0;
        }

        public int ChangeNamesColumns() {
            var inserted = 0;
            for (int i = 0; i < _DataTable.Columns.Count; i++) {
                _DataTable.Columns[i].ColumnName = _Expected[_DataTable.Columns[i].ColumnName];
            }
            _DataTable.AcceptChanges();
            Fill();
            return inserted;
        }

        public abstract void CheckHeaders();

        public abstract void Fill();

        protected void CreatingHeaders() {
            for (int i = 0; i < _SkipRows; i++) {
                _DataTable.Rows[i].Delete();
            }
            var d0 = _DataTable.Rows[_SkipRows].ItemArray;
            for (int i = 0; i < d0.Length; i++) {
                if (d0[i].ToString() != "")
                    _DataTable.Columns[i].ColumnName = d0[i].ToString();
            }
            _DataTable.Rows[_SkipRows].Delete();
            _DataTable.AcceptChanges();
            // eliminar columnas que no tienen encabezados correctos
            List<string> columnNames = _DataTable.Columns
                .Cast<DataColumn>()
                .Select(column => column.ColumnName).Where(column => column.ToLower().StartsWith("column"))
                .ToList();

            foreach (var item in columnNames) {
                _DataTable.Columns.Remove(item);
            }
            _DataTable.AcceptChanges();
        }

        protected List<string> GetHeaders() {
            List<string> columnNames = _DataTable.Columns
                .Cast<DataColumn>()
                .Select(column => column.ColumnName)
                .ToList();
            return columnNames;
        }
    }
}
