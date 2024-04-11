using System.Collections.Generic;
using System.Data;

namespace Jaeger.SAT.Catalogos.Helpers {
    public interface IExcelFileReader {
        /// <summary>
        /// obtener o establecer nombre del archivo EXCEL
        /// </summary>
        string FileName { get; set; }

        /// <summary>
        /// obtener o establecer la cantidad de filas que debemos saltar hasta los encabezados
        /// </summary>
        int SkipRows { get; set; }

        DataTable DataTable { get; set; }

        DataSet DataSet { get; set; }

        List<string> GetHeaders();

        void GetDataSet(string tableName = "");

        DataTable GetDataTable(string tableName);
    }
}
