using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using ExcelDataReader;
using Jaeger.SAT.Catalogos.Helpers;
using System.Text.RegularExpressions;

namespace Jaeger.SAT.Catalogos.Update.Converts {
    public class ExcelFileReader : IExcelFileReader {
        public ExcelFileReader(string filename) {
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
            IExcelDataReader reader = ExcelReaderFactory.CreateBinaryReader(
                FileService.ReadFileStrem(FileName), new ExcelReaderConfiguration() {
                });

            var config = new ExcelDataSetConfiguration {
                // utilizar tipo de dato
                UseColumnDataType = false
            };

            // en caso de obtener solo una tabla, con esta funcion creamos el filtro
            if (tableName != "") {
                config.FilterSheet = (tableReader, sheetIndex) => { return tableReader.Name == tableName; };
            }

            config.ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration() {
                UseHeaderRow = false,
                // Gets or sets a callback to determine whether to include the 
                // current row in the DataTable.
                // use ExcelDataTableConfiguration.FilterRow to filter empty rows
                FilterRow = rowReader => {
                    var hasData = false;
                    for (var i = 0; i < rowReader.FieldCount; i++) {
                        if (rowReader[i] == null || string.IsNullOrEmpty(rowReader[i].ToString())) {
                            continue;
                        }

                        hasData = true;
                        break;
                    }

                    return hasData;
                },

                ReadHeaderRow = (rowReader) => {
                    // saltamos las filas hasta los encabezados segun el valor de SkipRows
                    for (int i = 0; i < SkipRows; i++) {
                        rowReader.Read();
                    }
                }
            };

            DataSet = reader.AsDataSet(config);
            for (int i = 0; i < DataSet.Tables.Count; i++) {
                this.RemoveEmptyColumns(DataSet.Tables[i]);
                this.RemoveEmptyRows(DataSet.Tables[i]);
            }
            this.Analize();
        }

        public DataTable GetDataTable(string tableName) {
            if (DataSet == null) {
                GetDataTable(tableName);
            }
            return DataSet.Tables[tableName];
        }

        /// <summary>
        /// analizar todas las tablas y unir las hojas con un nombre similar
        /// </summary>
        private void Analize() {
            string pattern = @"(.+)_([0-9]+)";
            var destino = new Dictionary<string, string>();
            var sheets = this.DataSet.Tables.Cast<DataTable>().Select(it => it.TableName).ToList();
            RegexOptions options = RegexOptions.Multiline;

            // recorrer todas las tablas y buscar patron que coincida
            foreach (var sheet in sheets) {
                var matches = Regex.Matches(sheet, pattern, options);
                if (matches.Count > 0) {
                    Console.WriteLine($"destino {matches[0].Groups[0].Value} {matches[0].Groups[1].Value}");
                    destino.Add(matches[0].Groups[0].Value, matches[0].Groups[1].Value);
                }
            }
            // de todas las tablas coincidentes formamos una sola tabla con los datos
            foreach (var item in destino) {
                if (!this.DataSet.Tables.Contains(item.Value)) {
                    // creamos la tabla comun
                    this.DataSet.Tables.Add(item.Value);
                }
                // si existe analizamos los encabezados
                if (this.DataSet.Tables[item.Value].Rows.Count > 0) {
                    this.Analize(this.DataSet.Tables[item.Value], this.DataSet.Tables[item.Key]);
                }
                // unimos las tablas coindentes
                this.DataSet.Tables[item.Value].Merge(this.DataSet.Tables[item.Key]);
                this.DataSet.Tables.Remove(item.Key);
                Console.WriteLine($"datatable {item.Key} destino {item.Value}");
            }
        }

        private void Analize(DataTable table1, DataTable table2) {
            // solo para los casos donde la utlima fila contiene continua como en el caso de colonias o codigos postales
            if (table1.Rows[table1.Rows.Count - 1].ItemArray[0].ToString().ToLower().Contains("continúa")) {
                table1.Rows.RemoveAt(table1.Rows.Count - 1);
            }

            if (table2.Rows[table2.Rows.Count - 1].ItemArray[0].ToString().ToLower().Contains("continúa")) {
                table2.Rows.RemoveAt(table2.Rows.Count - 1);
            }

            // recorremos las primeras 9 filas que generalmente se repiten y removemos las que coincidan
            for (int i = 0; i < 9; i++) {
                Console.WriteLine($"{table1.Rows[i].ItemArray[0].ToString()} == {table2.Rows[0].ItemArray[0].ToString()}");
                if (table1.Rows[i].ItemArray[0].ToString() == table2.Rows[0].ItemArray[0].ToString()) {
                    table2.Rows.RemoveAt(0);
                } else {
                    break;
                }
            }
            table1.AcceptChanges();
            table2.AcceptChanges();
        }

        private void RemoveEmptyColumns(DataTable _DataTable) {
            // eliminar columnas vacias
            foreach (var column in _DataTable.Columns.Cast<DataColumn>().ToArray()) {
                if (_DataTable.AsEnumerable().All(dr => dr.IsNull(column)))
                    _DataTable.Columns.Remove(column);
            }
        }

        private void RemoveEmptyRows(DataTable _DataTable) {
            // eliminar filas vacias
            _DataTable = _DataTable.Rows.Cast<DataRow>().Where(row => !row.ItemArray.All(field => field == DBNull.Value | field.Equals(""))).CopyToDataTable();
        }
    }
}
