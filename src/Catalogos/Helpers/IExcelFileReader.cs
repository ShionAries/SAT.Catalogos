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

        /// <summary>
        /// obtener lista de encabezados
        /// </summary>
        List<string> GetHeaders();

        /// <summary>
        /// obtener tabla del dataset
        /// </summary>
        /// <param name="tableName"></param>
        void GetDataSet(string tableName = "");

        /// <summary>
        /// obtener informacion del archivo 
        /// </summary>
        DataTable GetDataTable(string tableName);
    }
}
