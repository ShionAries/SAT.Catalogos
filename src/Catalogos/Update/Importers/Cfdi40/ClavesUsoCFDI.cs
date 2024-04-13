using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository;
using Jaeger.SAT.Catalogos.Repository.Entities;

namespace Jaeger.SAT.Catalogos.Update.Importers.Cfdi40 {
    public class ClavesUsoCFDI : AbstractInjector, IInjector {
        public ClavesUsoCFDI(DataTable dataTable) : base(dataTable) {
            _SkipRows = 3;
        }

        protected override void CheckHeaders() {
            _HeadersMapper = new Dictionary<string, string> {
                { "c_UsoCFDI", "Clave" },
                { "Descripción", "Descripcion" },
                { "Física", "Fisica" },
                { "Moral", "Moral" },
                { "Fecha inicio de vigencia", "VigenciaIni" },
                { "Fecha fin de vigencia", "VigenciaFin" },
                { "Régimen Fiscal Receptor", "RegimenFiscalReceptor" }
            };

            var headers = GetHeaders().ToArray();
            if (!ArrayCompare(_HeadersMapper.Select(it => it.Key).ToArray(), headers)) {
                throw new Exception($"The headers did not match on {this.GetType().Name}");
            }
            
        }

        protected override void Fill() {
            var mapper = new Helpers.Mapping.DataNamesMapper<ClaveUsoCFDI>();
            var resultado = mapper.Map(_DataTable).ToList();
            if (resultado != null) {
                if (resultado.Count() > 0) {
                    _Catalogo = new UsoCFDIRepository {
                        Items = resultado.ToList()
                    };
                }
            }
        }

        //protected override void FixDataTable() {
        //    // eliminar columnas vacias
        //    foreach (var column in _DataTable.Columns.Cast<DataColumn>().ToArray()) {
        //        if (_DataTable.AsEnumerable().All(dr => dr.IsNull(column)))
        //            _DataTable.Columns.Remove(column);
        //    }
        //    // eliminar filas vacias
        //    _DataTable = _DataTable.Rows.Cast<DataRow>().Where(row => !row.ItemArray.All(field => field == DBNull.Value | field.Equals(""))).CopyToDataTable();
        //    _DataTable.AcceptChanges();
        //    // buscar valor de la celda en la columna 0
        //    var row1 = this._DataTable.Select().Where(it => (string)it.ItemArray[0].ToString() == "c_UsoCFDI").FirstOrDefault();
        //    var position = this._DataTable.Rows.IndexOf(row1);
        //    var headers = _DataTable.Rows[position].ItemArray;
        //    for (int i = 0; i < headers.Length; i++) {
        //        if (headers[i].ToString() != "")
        //            _DataTable.Columns[i].ColumnName = headers[i].ToString();
        //    }
        //    _DataTable.Rows[position].Delete();
        //    _DataTable.AcceptChanges();
        //    var result = this._DataTable.AsEnumerable()
        //          .Where((row, index) => index >= position)
        //          .CopyToDataTable();
        //    this._DataTable = result;

        //    var fisica = this._DataTable.Select().Where(it => (string)it.ItemArray[0].ToString() == "Física").FirstOrDefault();
            
        //    //this.DeleteBlankColumns();
        //}

        protected override void FixDataTable() {
            this.RemoveEmptyRows();
            this.RemoveEmptyColumns();
            var search = this._DataTable.Select().Where(it => (string)it.ItemArray[0].ToString() == "c_UsoCFDI").FirstOrDefault();
            var position = this._DataTable.Rows.IndexOf(search);
            
            this._DataTable = this._DataTable.AsEnumerable()
                  .Where((row, index) => index >= position)
                  .CopyToDataTable();
            this.RenameColumns(0);
            this.RenameColumns();
        }

        private void RemoveEmptyColumns() {
            // eliminar columnas vacias
            foreach (var column in _DataTable.Columns.Cast<DataColumn>().ToArray()) {
                if (_DataTable.AsEnumerable().All(dr => dr.IsNull(column)))
                    _DataTable.Columns.Remove(column);
            }
        }

        private void RemoveEmptyRows() {
            // eliminar filas vacias
            _DataTable = _DataTable.Rows.Cast<DataRow>().Where(row => !row.ItemArray.All(field => field == DBNull.Value | field.Equals(""))).CopyToDataTable();
        }

        private void RenameColumns(int rowIndex = 0) {
            var headers = _DataTable.Rows[rowIndex].ItemArray;
            for (int i = 0; i < headers.Length; i++) {
                if (headers[i].ToString() != "" || headers[i].ToString().ToLower().StartsWith("column"))
                    _DataTable.Columns[i].ColumnName = headers[i].ToString();
            }
            _DataTable.Rows[rowIndex].Delete();
            this._DataTable.AcceptChanges();
        }
    }
}
