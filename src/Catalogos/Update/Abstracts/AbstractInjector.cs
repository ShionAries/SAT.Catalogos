using System;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using Jaeger.SAT.Catalogos.Repository.Interfaces;

namespace Jaeger.SAT.Catalogos.Update.Abstracts {
    public abstract class AbstractInjector : IInjector {
        #region declaraciones
        protected DataTable _DataTable;
        protected Dictionary<string, string> _HeadersMapper;
        protected IRepositoryGeneric _Repository;
        protected DateTime? _LastVersion;
        #endregion

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="dataTable">datatable de datos</param>
        public AbstractInjector(DataTable dataTable) {
            _DataTable = dataTable;
            _HeadersMapper = new Dictionary<string, string>();
        }

        protected int SkipRows {  get; set; }

        public Scraping.Interfaces.IOrigin Origin { get; set; }

        /// <summary>
        /// obtener o establecer fecha de ultima actualizacion del catalogo
        /// </summary>
        public DateTime? LastVersion {
            get {
                if (_LastVersion >= new DateTime(1900, 1, 1))
                    return _LastVersion;
                return _LastVersion;
            }
            set { _LastVersion = value; }
        }

        /// <summary>
        /// proceso de inyeccion de datos
        /// </summary>
        /// <returns>siempre es 0</returns>
        public int Inject() {
            //Arreglando tabla 
            FixDataTable();

            //Verificando encabezado
            CheckHeaders();

            ///Cambiado columnas para mapeo de datos
            ChangeHeadersMapper();
            // si es actualizable
            if (IsUpdateable()) {
                // crear repositorio
                CreateRepository();
                // guardar
                Save();
            }

            return 0;
        }

        /// <summary>
        /// cambiar los nombres de las columnas por las palabras clave para el mapeo de datos
        /// </summary>
        public void ChangeHeadersMapper() {
            for (int i = 0; i < _DataTable.Columns.Count; i++) {
                _DataTable.Columns[i].ColumnName = _HeadersMapper[_DataTable.Columns[i].ColumnName];
            }
            _DataTable.AcceptChanges();
        }

        /// <summary>
        /// verificar encabezados
        /// </summary>
        protected abstract void CheckHeaders();

        /// <summary>
        /// llenar repositorio
        /// </summary>
        protected abstract void CreateRepository();

        protected virtual bool IsUpdateable() {
            return _DataTable.Rows.Count > 0;
        }

        /// <summary>
        /// utilizar el metodo comun para importar y almacenar el repositorio
        /// </summary>
        protected virtual void Save() {
            var counter = _Repository.Import(_DataTable);
            _Repository.Save();
            Console.WriteLine($"Se inyectaron {counter} registros en {_DataTable.TableName}");
        }

        /// <summary>
        /// realizar arreglos para obtener los encabezados 
        /// </summary>
        protected virtual void FixDataTable() {
            for (int i = 0; i < SkipRows; i++) {
                _DataTable.Rows.RemoveAt(0);
            }
            // obetener informacion de la fila donde estan los nombres de las columnas
            RenameColumns();
            // eliminamos todas las columnas que tienen como nombre de columan 'Column??'
            RemoveColumnsName();
        }

        /// <summary>
        /// obtener encabezados de encabezados
        /// </summary>
        /// <returns>retorna lista de enbabezados de datatable</returns>
        protected List<string> GetHeaders() {
            List<string> columnNames = _DataTable.Columns
                .Cast<DataColumn>()
                .Select(column => column.ColumnName)
                .ToList();
            return columnNames;
        }

        /// <summary>
        /// funcion de comparacion de dos arrays
        /// </summary>
        /// <param name="firstArray">primer array</param>
        /// <param name="secondArray">segundo array</param>
        /// <returns>verdadero si ambas matrizes coinciden</returns>
        protected bool ArrayCompare(string[] firstArray, string[] secondArray) {
            // logitud
            if (firstArray.Length != secondArray.Length) {
                Console.WriteLine($"ArrayCompare las matrizes son diferentes en longitud");
                return false;
            }

            // verificar 
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
            foreach (var column in _DataTable.Columns.Cast<DataColumn>().ToArray()) {
                if (_DataTable.AsEnumerable().All(dr => dr.IsNull(column)))
                    _DataTable.Columns.Remove(column);
            }
        }

        /// <summary>
        /// remover columnas con nombres que comienzan 'Column'
        /// </summary>
        protected void RemoveColumnsName() {
            // eliminar columnas que no tienen encabezados correctos
            var columnNames = _DataTable.Columns
                .Cast<DataColumn>()
                .Select(column => column.ColumnName)
                .Where(column => column.ToLower().StartsWith("column"))
                .ToList();

            foreach (var item in columnNames) {
                _DataTable.Columns.Remove(item);
            }
            _DataTable.AcceptChanges();
        }

        /// <summary>
        /// eliminar filas vacias
        /// </summary>
        protected void RemoveEmptyRows() {
            // eliminar filas vacias
            _DataTable = _DataTable.Rows.Cast<DataRow>().Where(row => !row.ItemArray.All(field => field == DBNull.Value | field.Equals(""))).CopyToDataTable();
        }

        /// <summary>
        /// renombres de columnas del datatable
        /// </summary>
        /// <param name="rowIndex">indica la fila donde se encuentran los encabezados</param>
        protected void RenameColumns(int rowIndex = 0) {
            var headers = _DataTable.Rows[rowIndex].ItemArray;
            for (int i = 0; i < headers.Length; i++) {
                if (headers[i].ToString() != "" || headers[i].ToString().ToLower().StartsWith("column")) {
                    // en caso de repetir el nombre de la columna
                    if (_DataTable.Columns.Contains(headers[i].ToString())) {
                        _DataTable.Columns[i].ColumnName = headers[i].ToString() + "_" + i;
                        Console.WriteLine($"Renombrar con posicion: {_DataTable.Columns[i].ColumnName = headers[i].ToString().TrimEnd() + "_" + i}");
                    } else {
                        _DataTable.Columns[i].ColumnName = headers[i].ToString().TrimEnd().Replace("\r\n", "").Replace("\n", "");
                    }
                }
            }
            _DataTable.Rows.RemoveAt(0);
            var fila = _DataTable.Rows[0].ItemArray;
            if (fila[0].ToString() == "") {
                RenameColumns();
            }
        }
    }
}
