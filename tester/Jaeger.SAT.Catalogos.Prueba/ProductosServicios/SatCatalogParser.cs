using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.IO;

namespace Jaeger.SAT.Catalogos.Prueba.ProductosServicios {
    public sealed class SatCatalogParser {
        public IReadOnlyList<SatProductoServicio> Parse(
            string filePath) {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException(
                    "Debe especificar el archivo.",
                    nameof(filePath));

            if (!File.Exists(filePath))
                throw new FileNotFoundException(
                    "No se encontró el catálogo.",
                    filePath);

            try {
                List<SatProductoServicio> result =
                    new List<SatProductoServicio>();

                using (FileStream stream =
                    File.Open(
                        filePath,
                        FileMode.Open,
                        FileAccess.Read,
                        FileShare.Read))
                using (IExcelDataReader reader =
                    ExcelReaderFactory.CreateReader(stream)) {
                    bool isFirstRow = true;

                    while (reader.Read()) {
                        if (isFirstRow) {
                            isFirstRow = false;
                            continue;
                        }

                        string clave =
                            GetString(reader, 0);

                        if (string.IsNullOrWhiteSpace(clave))
                            continue;

                        result.Add(
                            new SatProductoServicio {
                                ClaveProdServ = clave,
                                Descripcion =
                                    GetString(reader, 1),
                                IncluirIvaTrasladado =
                                    GetString(reader, 2),
                                IncluirIepsTrasladado =
                                    GetString(reader, 3),
                                Complemento =
                                    GetString(reader, 4)
                            });
                    }
                }

                return result;
            } catch (InvalidDataException ex) {
                throw new InvalidOperationException(
                    "El archivo descargado no tiene un formato Excel válido.",
                    ex);
            } catch (IOException ex) {
                throw new InvalidOperationException(
                    "No fue posible leer el archivo del catálogo.",
                    ex);
            }
        }

        private static string GetString(
            IExcelDataReader reader,
            int index) {
            if (index >= reader.FieldCount)
                return string.Empty;

            object value = reader.GetValue(index);

            return value == null
                ? string.Empty
                : Convert.ToString(value).Trim();
        }
    }
}