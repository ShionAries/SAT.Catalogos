using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Jaeger.SAT.Catalogos.Helpers.Mapping {
    public class DataNamesMapper<TEntity> where TEntity : class, new() {
        public TEntity Map(DataRow row) {
            TEntity entity = new TEntity();
            return Map(row, entity);
        }

        public TEntity Map(DataRow row, TEntity entity) {
            var properties = typeof(TEntity).GetProperties()
                                              .Where(x => x.GetCustomAttributes(typeof(DataNamesAttribute), true).Any())
                                              .ToList();
            foreach (var prop in properties) {
                PropertyMapHelper.Map(typeof(TEntity), row, prop, entity);
            }

            return entity;
        }

        public IEnumerable<TEntity> Map(DataTable table) {
            List<TEntity> entities = new List<TEntity>();
            var properties = typeof(TEntity).GetProperties()
                                              .Where(x => x.GetCustomAttributes(typeof(DataNamesAttribute), true).Any())
                                              .ToList();
            foreach (DataRow row in table.Rows) {
                TEntity entity = new TEntity();
                foreach (var prop in properties) {
                    PropertyMapHelper.Map(typeof(TEntity), row, prop, entity);
                }
                entities.Add(entity);
            }

            return entities;
        }
    }
}
