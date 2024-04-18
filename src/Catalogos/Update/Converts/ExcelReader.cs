using System.Linq;
using System.Collections.Generic;
using System.Data;

namespace Jaeger.SAT.Catalogos.Update.Converts {
    public abstract class ExcelReader {
        /// <summary>
        /// obtener o establecer nombre del archivo EXCEL
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// obtener o establecer la cantidad de filas que debemos saltar hasta los encabezados
        /// </summary>
        public int SkipRows { get; set; }

        public DataTable DataTable { get; set; }

        public DataSet DataSet { get; set; }

        public List<string> GetHeaders() {
            List<string> columnNames = DataTable.Columns
                .Cast<DataColumn>()
                .Select(column => column.ColumnName)
                .ToList();
            return columnNames;
        }

        public abstract void GetDataSet(string tableName = "");

        public DataTable GetDataTable(string tableName) {
            if (DataSet == null) {
                GetDataTable(tableName);
            }
            return DataSet.Tables[tableName];
        }
    }
}
