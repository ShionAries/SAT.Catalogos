using System;
using Newtonsoft.Json;

namespace Jaeger.SAT.Catalogos.Repository.Abstracts {
    public abstract class RepositoryBase {
        protected static readonly DateTime MinValidDate = new DateTime(1900, 1, 1);

        protected readonly JsonSerializerSettings _jsonSettings = new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore,
            DateFormatString = "dd/MM/yyyy"
        };

        #region Métodos Protegidos Estáticos

        protected static DateTime? NormalizeDate(DateTime? date) {
            return (date.HasValue && date.Value >= MinValidDate) ? date : null;
        }

        #endregion
    }
}