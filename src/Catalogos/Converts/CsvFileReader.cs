using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using ExcelDataReader;

namespace Jaeger.SAT.Catalogos.Helpers {
    public class CsvFileReader : IExcelFileReader {
        public CsvFileReader(string filename) {
            if (string.IsNullOrEmpty(filename)) {
                throw new ArgumentException("The filename cannot be empty", "filename");
            }

            if (DirectoryService.IsDirectory(filename)) {
                throw new ArgumentException("The filename is a directory", "filename");
            }

            FileName = filename;
        }

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

        public void GetDataSet(string tableName = "") {
            IExcelDataReader reader = ExcelReaderFactory.CreateReader(
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

            this.DataSet = reader.AsDataSet(config);
        }

        public DataTable GetDataTable(string tableName) {
            if (this.DataSet == null) {
                this.GetDataTable(tableName);
            }
            return this.DataSet.Tables[tableName];
        }
    }
}
