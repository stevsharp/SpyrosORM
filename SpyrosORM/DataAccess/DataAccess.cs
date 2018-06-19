using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SpyrosORM.DataAttributes;

namespace SpyrosORM.DataAccess
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DataAccess<T> : IDataAccess<T> where T : DataModel, new()
    {
        /// <summary>
        /// 
        /// </summary>
        public DataSourceSchema<T> Schema { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataObject"></param>
        /// <returns></returns>
        public virtual int Insert(T dataObject)
        {
            var columnsValues = new Dictionary<string, object>();

            string finalDataSourceName = Schema.DataSourceName;

            var objectSchemaFields = Schema.DataFields
                .Where(field => field.TableField != null)
                .ToList<DataField>();

            return 1;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="dataSourceName"></param>
        /// <returns></returns>
        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> predicate, string dataSourceName = null)
        {
            var ev = new CustomExpressionVisitor();

            var whereClause = ev.Translate(predicate);

            return new List<T>();
        }

        public virtual IEnumerable<T> Get(Dictionary<string, object> whereConditions, string dataSourceName = null)
        {
            //var ev = new CustomExpressionVisitor();

            //var whereClause = ev.Translate(predicate);

            return new List<T>();
        }
    }
}
