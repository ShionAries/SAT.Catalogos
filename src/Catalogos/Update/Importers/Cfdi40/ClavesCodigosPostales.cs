using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Jaeger.SAT.Catalogos.Repository.Cfdi40;

namespace Jaeger.SAT.Catalogos.Update.Importers.Cfdi40 {
    /// <summary>
    /// catalogo de codigos postales
    /// </summary>
    public class ClavesCodigosPostales : AbstractInjector, IInjector {
        public ClavesCodigosPostales(DataTable dataTable) : base(dataTable) {
            this._SkipRows = 3;
            _HeadersMapper = new Dictionary<string, string> {
                { "c_CodigoPostal", "Clave" },
                { "c_Estado", "Estado" },
                { "c_Municipio", "Municipio" },
                { "c_Localidad", "Localidad" },
                { "Estímulo Franja Fronteriza", "Estimulo" },
                { "Fecha inicio de vigencia", "VigenciaIni" },
                { "Fecha fin de vigencia", "VigenciaFin" },
                { "Descripción del Huso Horario", "descripcion_del_huso_horario" },
                { "Mes_Inicio_Horario_Verano", "mes_inicio_horario_verano" },
                { "Día_Inicio_Horario_Verano", "dia_inicio_horario_verano" },
                { "Día_Inicio_Horario_Verano_10", "dia_inicio_horario_verano_10" },
                { "Diferencia_Horaria_Verano", "diferencia_horaria_verano2" },
                { "Mes_Inicio_Horario_Invierno", "mes_inicio_horario_invierno" },
                { "Día_Inicio_Horario_Invierno", "dia_inicio_horario_invierno" },
                { "Día_Inicio_Horario_Invierno_14", "día_inicio_horario_invierno_14" },
                { "Diferencia_Horaria_Invierno", "diferencia_horaria_invierno" }
            };
        }

        protected override void CheckHeaders() {
            // obtener los encabezados de la tabla y comparar con las columnas esperadas
            var headers = GetHeaders().ToArray();
            if (!ArrayCompare(_HeadersMapper.Select(it => it.Key).ToArray(), headers)) {
                throw new Exception($"The headers did not match on {this.GetType().Name}");
            }
        }

        protected override void CreateRepository() {
            this._Catalogo = new CodigoPostalRepository();
        }
    }
}
