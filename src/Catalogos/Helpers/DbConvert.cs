using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

namespace Jaeger.SAT.Catalogos.Helpers {
    public class DbConvert {
        public DbConvert() { }

        public static bool ConvertBool(object boolValue) {
            if (boolValue != DBNull.Value) {
                if (boolValue != null) {
                    if (boolValue.ToString().Trim() != (object)string.Empty) {
                        return Convert.ToBoolean(boolValue);
                    }
                }
            }
            return false;
        }

        public static DateTime ConvertDateTime(object dtValue) {
            if (dtValue != DBNull.Value) {
                if (dtValue != null) {
                    if (dtValue.ToString().Trim() != (object)string.Empty) {
                        return Convert.ToDateTime(dtValue);
                    }
                }
            }
            return DateTime.MinValue;
        }

        public static double ConvertDouble(object dbValue) {
            if (dbValue == DBNull.Value | dbValue == null | dbValue.ToString().Trim() == (object)string.Empty | dbValue.ToString() == "") {
                return 0;
            }
            return Convert.ToDouble(dbValue);
        }

        public static decimal ConvertDecimal(object dbValue) {
            if (dbValue == DBNull.Value | dbValue == null | dbValue.ToString().Trim() == (object)string.Empty | dbValue.ToString() == "") {
                return 0;
            }
            return Convert.ToDecimal(dbValue);
        }

        public static short ConvertInt16(object intValue) {
            if (intValue != DBNull.Value) {
                if (intValue != null) {
                    if (intValue.ToString().Trim() != (object)string.Empty) {
                        return Convert.ToInt16(intValue);
                    }
                }
            }
            return 0;
        }

        public static int ConvertInt32(object intValue) {
            if (intValue != DBNull.Value) {
                if (intValue != null) {
                    if (intValue.ToString().Trim() != (object)string.Empty) {
                        return Convert.ToInt32(intValue);
                    }
                }
            }
            return 0;
        }

        public static string ConvertString(object strValue) {
            if (strValue != DBNull.Value) {
                if (strValue != null) {
                    if (strValue.ToString().Trim() != (object)string.Empty) {
                        return strValue.ToString();
                    }
                }
            }
            return "";
        }

        /// <summary>
        /// convertir lista de objetos en DataTable
        /// </summary>
        public static DataTable ConvertToDataTable<T>(IList<T> data) {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data) {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }
    }
}