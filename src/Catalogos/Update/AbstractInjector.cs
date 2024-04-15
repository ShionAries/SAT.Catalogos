using System.Linq;
using System.Data;
using System.Collections.Generic;
using System;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Update {
    public abstract class AbstractInjector : IInjector {
        protected DataTable _DataTable;
        protected int _SkipRows;
        protected Dictionary<string, string> _HeadersMapper;
        protected IGeneralRepository _Catalogo;

        public AbstractInjector(DataTable dataTable) {
            this._DataTable = dataTable;
            this._HeadersMapper = new Dictionary<string, string>();
        }

        public int Inject(Helpers.ILogger logger) {
            logger.Info($"Arreglando tabla ...{this._DataTable.TableName}");
            this.FixDataTable();
            
            logger.Info($"Verificando encabezado ...{this._DataTable.TableName}");
            this.CheckHeaders();

            logger.Info($"Cambiado columnas para mapeo de datos {this._DataTable.TableName}...");
            this.ChangeHeadersMapper();

            this.Fill();
            logger.Info($"Se inyectaron injected registros en {this._DataTable.TableName}");

            return 0;
        }

        /// <summary>
        /// cambiar los nombres de las columnas por las palabras clave para el mapeo de datos
        /// </summary>
        public void ChangeHeadersMapper() {
            for (int i = 0; i < this._DataTable.Columns.Count; i++) {
                this._DataTable.Columns[i].ColumnName = _HeadersMapper[this._DataTable.Columns[i].ColumnName];
            }
            this._DataTable.AcceptChanges();
        }

        /// <summary>
        /// verificar encabezados
        /// </summary>
        protected abstract void CheckHeaders();

        /// <summary>
        /// llenar repositorio
        /// </summary>
        protected abstract void Fill();

        protected virtual void FixDataTable() {
            for (int i = 0; i < this._SkipRows; i++) {
                this._DataTable.Rows.RemoveAt(0);
            }
            // obetener informacion de la fila donde estan los nombres de las columnas
            this.RenameColumns();
            // eliminamos todas las columnas que tienen como nombre de columan 'Column??'
            this.RemoveColumnsName();
        }

        protected virtual void FixDataTable1() {
            // remover filas
            if (this._SkipRows >= 0) {
                for (int i = 0; i < _SkipRows; i++) {
                    this._DataTable.Rows[i].Delete();
                }
                // obetener informacion de la fila
                var headers = this._DataTable.Rows[_SkipRows].ItemArray;
                // renombrar 
                for (int i = 0; i < headers.Length; i++) {
                    if (headers[i].ToString() != "")
                        this._DataTable.Columns[i].ColumnName = headers[i].ToString();
                }
                this._DataTable.Rows[_SkipRows].Delete();
                this._DataTable.AcceptChanges();
            }
            this.RemoveColumnsName();
        }

        protected List<string> GetHeaders() {
            List<string> columnNames = this._DataTable.Columns
                .Cast<DataColumn>()
                .Select(column => column.ColumnName)
                .ToList();
            return columnNames;
        }

        protected bool ArrayCompare(string[] firstArray, string[] secondArray) {
            if (firstArray.Length != secondArray.Length) {
                Console.WriteLine($"ArrayCompare las matrizes son diferentes en longitud");
                return false;
            }

            for (int i = 0; i < firstArray.Length; i++) {
                if (firstArray[i].ToLower() != secondArray[i].ToLower()) {
                    Console.WriteLine($"Diferencia en array 1 '{firstArray[i]}' posición {i} con array 2 '{secondArray[i]}'");
                    return false;
                }
            }

            return true;
        }
        
        protected void RemoveEmptyColumns() {
            // eliminar columnas vacias
            foreach (var column in this._DataTable.Columns.Cast<DataColumn>().ToArray()) {
                if (this._DataTable.AsEnumerable().All(dr => dr.IsNull(column)))
                    this._DataTable.Columns.Remove(column);
            }
        }

        /// <summary>
        /// remover columnas con nombres que comienzan 'Column'
        /// </summary>
        protected void RemoveColumnsName() {
            // eliminar columnas que no tienen encabezados correctos
            var columnNames = this._DataTable.Columns
                .Cast<DataColumn>()
                .Select(column => column.ColumnName)
                .Where(column => column.ToLower().StartsWith("column"))
                .ToList();

            foreach (var item in columnNames) {
                this._DataTable.Columns.Remove(item);
            }
            this._DataTable.AcceptChanges();
        }

        /// <summary>
        /// eliminar filas vacias
        /// </summary>
        protected void RemoveEmptyRows() {
            // eliminar filas vacias
            _DataTable = this._DataTable.Rows.Cast<DataRow>().Where(row => !row.ItemArray.All(field => field == DBNull.Value | field.Equals(""))).CopyToDataTable();
        }

        protected void RenameColumns(int rowIndex = 0) {
            var headers = this._DataTable.Rows[rowIndex].ItemArray;
            for (int i = 0; i < headers.Length; i++) {
                if (headers[i].ToString() != "" || headers[i].ToString().ToLower().StartsWith("column")) {
                    // en caso de repetir el nombre de la columna
                    if (this._DataTable.Columns.Contains(headers[i].ToString())) {
                        this._DataTable.Columns[i].ColumnName = headers[i].ToString() + "_" + i;
                        Console.WriteLine($"Renombrar con posicion: {this._DataTable.Columns[i].ColumnName = headers[i].ToString().TrimEnd() + "_" + i}");
                    } else {
                        this._DataTable.Columns[i].ColumnName = headers[i].ToString().TrimEnd();
                    }
                }
            }
            this._DataTable.Rows.RemoveAt(0);
            var fila = this._DataTable.Rows[0].ItemArray;
            if (fila[0].ToString() == "") {
                this.RenameColumns();
            }
            //this._DataTable.Rows[rowIndex].Delete();
            //this._DataTable.AcceptChanges();
        }
    }
}
