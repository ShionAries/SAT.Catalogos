using System;
using ExcelDataReader;
using Jaeger.SAT.Catalogos.Helpers;

namespace Jaeger.SAT.Catalogos.Update.Converts {
    public class CsvFileReader : ExcelReader, IExcelFileReader {
        public CsvFileReader(string filename) {
            if (string.IsNullOrEmpty(filename)) {
                throw new ArgumentException("The filename cannot be empty", "filename");
            }

            if (DirectoryService.IsDirectory(filename)) {
                throw new ArgumentException("The filename is a directory", "filename");
            }

            FileName = filename;
        }

        public override void GetDataSet(string tableName = "") {
            IExcelDataReader reader = ExcelReaderFactory.CreateCsvReader(
                FileService.ReadFileStrem(FileName), new ExcelReaderConfiguration() {
                });

            var config = new ExcelDataSetConfiguration {
                // utilizar tipo de dato
                UseColumnDataType = true
            };

            // en caso de obtener solo una tabla, con esta funcion creamos el filtro
            if (tableName != "") {
                config.FilterSheet = (tableReader, sheetIndex) => { return tableReader.Name == tableName; };
            }

            config.ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration() {
                UseHeaderRow = true,
                ReadHeaderRow = (rowReader) => {
                    // saltamos las filas hasta los encabezados segun el valor de SkipRows
                    for (int i = 0; i < SkipRows; i++) {
                        rowReader.Read();
                    }
                }
            };

            DataSet = reader.AsDataSet(config);
        }
    }
}
