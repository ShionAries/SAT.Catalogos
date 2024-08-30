using System.Data;

namespace Jaeger.SAT.Catalogos.Update.Converts {
    public class XlsToDataSetConverter {
        public XlsToDataSetConverter() { }
        public DataSet DataSet { get; set; }
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
