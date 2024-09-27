using System.Data;

namespace Jaeger.SAT.Catalogos.Update.Converts {
    /// <summary>
    /// convertidor Dataset
    /// </summary>
    public class XlsToDataSetConverter {
        /// <summary>
        /// constructor
        /// </summary>
        public XlsToDataSetConverter() { }

        /// <summary>
        /// Dataset
        /// </summary>
        public DataSet DataSet { get; set; }

        /// <summary>
        /// convertir
        /// </summary>
        /// <param name="source">ruta del archivo a comvertir</param>
        public void Convert(string source) {
            IExcelFileReader reader = null;
            if (System.IO.Path.GetExtension(source) == ".xls") {
                reader = new ExcelFileReader(source);
            } else if (System.IO.Path.GetExtension(source) == ".csv") {
                reader = new CsvFileReader(source);
            }
            reader.GetDataSet();
            DataSet = reader.DataSet;
        }
    }
}
