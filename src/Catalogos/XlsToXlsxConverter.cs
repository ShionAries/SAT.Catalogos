using System;
using System.IO;
using System.Linq;
using System.Text;
using MiniExcelLibs;
using Jaeger.SAT.Catalogos.Importers.Articulo69B;
using ExcelDataReader;

namespace Jaeger.SAT.Catalogos {
    public class XlsToXlsxConverter {
        public void Testing() {
            //var filePath = @"C:\Jaeger\Jaeger.Temporal\Listado_Completo_69-B.csv";
            var filePath = @"C:\Jaeger\Jaeger.Temporal\cfdi_40.xls";
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
{
                // Auto-detect format, supports:
                //  - Binary Excel files (2.0-2003 format; *.xls)
                //  - OpenXml Excel files (2007 format; *.xlsx, *.xlsb)
                using (var reader = ExcelReaderFactory.CreateReader(stream)) {
                    // Choose one of either 1 or 2:

                    // 1. Use the reader methods
                    do {
                        while (reader.Read()) {
                            // reader.GetDouble(0);
                        }
                    } while (reader.NextResult());

                    // 2. Use the AsDataSet extension method
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration() {
                        UseColumnDataType = true,
                        ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration() {
                            UseHeaderRow = true,
                            ReadHeaderRow = (rowHeader) => { rowHeader.Read(); }, 
                        }  
                    });

                    // The result of each spreadsheet is in result.Tables
                }
            }
        }
        public void Testing1() {
            var path = @"C:\Jaeger\Jaeger.Temporal\Listado_Completo_69-B.csv";
            var config = new MiniExcelLibs.Csv.CsvConfiguration() {
                Seperator = ',',
                StreamReaderFunc = (stream) => new StreamReader(stream, encoding: Encoding.Default)
            };
            var rows = MiniExcel.Query<ListadoCompleto>(path, configuration: config, excelType: ExcelType.CSV, startCell:"A3").ToList();
            Console.WriteLine(rows[0]);
        }
    }
}
