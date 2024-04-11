using System.Linq;
using System.Data;
using System.Collections.Generic;
using System;

namespace Jaeger.SAT.Catalogos.Update {
    public abstract class AbstractInjector : IInjector {
        protected DataTable _DataTable;
        protected int _SkipRows;
        protected Dictionary<string, string> _HeadersMapper;

        public AbstractInjector(DataTable dataTable) {
            this._DataTable = dataTable;
            this._HeadersMapper = new Dictionary<string, string>();
        }

        public int Inject(Helpers.ILogger logger) {
            logger.Info($"Verificando encabezado ...{this._DataTable.TableName}");
            FixDataTable();

            CheckHeaders();
            logger.Info($"Inyectando contenidos de {this._DataTable.TableName}...");

            var injected = ChangeHeaderNames();
            logger.Info($"Se inyectaron {injected} registros en {this._DataTable.TableName}");

            return 0;
        }

        public int ChangeHeaderNames() {
            var inserted = 0;
            for (int i = 0; i < _DataTable.Columns.Count; i++) {
                _DataTable.Columns[i].ColumnName = _HeadersMapper[_DataTable.Columns[i].ColumnName];
            }
            _DataTable.AcceptChanges();
            Fill();
            return inserted;
        }

        protected abstract void CheckHeaders();

        protected abstract void Fill();

        protected bool ArrayCompare(string[] firstArray, string[] secondArray) {
            if (firstArray.Length != secondArray.Length)
                return false;

            for (int i = 0; i < firstArray.Length; i++) {
                if (firstArray[i].ToLower() != secondArray[i].ToLower()) {
                    Console.WriteLine($"Diferencia en array 1 {firstArray[i]} posición {i} con array 2 {secondArray[i]}");
                    return false;
                }
            }

            return true;
        }

        protected void FixDataTable() {
            for (int i = 0; i < _SkipRows; i++) {
                _DataTable.Rows[i].Delete();
            }
            var headers = _DataTable.Rows[_SkipRows].ItemArray;
            for (int i = 0; i < headers.Length; i++) {
                if (headers[i].ToString() != "")
                    _DataTable.Columns[i].ColumnName = headers[i].ToString();
            }
            _DataTable.Rows[_SkipRows].Delete();
            _DataTable.AcceptChanges();
            this.DeleteBlankColumns();
        }

        protected void DeleteBlankColumns() {
            // eliminar columnas que no tienen encabezados correctos
            var columnNames = _DataTable.Columns
                .Cast<DataColumn>()
                .Select(column => column.ColumnName)
                .Where(column => column.ToLower().StartsWith("column"))
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
