using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
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
        private static SqlDatabase Database = new SqlDatabase();
        /// <summary>
        /// 
        /// </summary>
        private static readonly List<Type> NumericTypes = new List<Type>() { typeof(int), typeof(long), typeof(Int16), typeof(Int32), typeof(Int64) };
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

            var objectSchemaFields = Schema.DataFields.Where(field => field.TableField != null).ToList<DataField>();

            foreach (var field in objectSchemaFields)
            {
                if (field.TableField.IsIDField && field.TableField.AllowIDInsert) continue;
                var dataObjectAttr = dataObject.GetType().GetProperty(field.Name);
                if (dataObjectAttr==null) continue;

                if (!field.TableField.AllowNull)
                {
                    var dataObjectAttrValue = dataObjectAttr.GetValue(dataObject, null);
                    if (dataObjectAttrValue != null)
                    {
                        if (NumericTypes.Contains(field.TableField.FieldType))
                        {
                            // Future Imlementation
                            var value = Convert.ChangeType(dataObjectAttrValue, field.TableField.FieldType);
                        }
                        columnsValues.Add(field.TableField.ColumnName, Convert.ChangeType(dataObjectAttrValue, field.TableField.FieldType));
                    }
                    else{
                        throw new Exception("The Property " + field.TableField.ColumnName + " in the " + dataObject.GetType().Name + " Table is not allowed with [IsAllowNull]");
                    }
                }
                else
                {
                    var dataObjectAttrValue = dataObjectAttr.GetValue(dataObject, null);
                    if (dataObjectAttrValue == null) continue;

                    if ( NumericTypes.Contains(field.TableField.FieldType)){
                        var value = Convert.ChangeType(dataObjectAttrValue, field.TableField.FieldType);

                        if (Convert.ToInt64(value) <= 0 && field.TableField.IsKey)
                            continue;
                    }

                    columnsValues.Add(field.TableField.ColumnName, Convert.ChangeType(dataObjectAttrValue, field.TableField.FieldType));
                }
            }

            var rowID = 0;

            try
            {
                rowID = Database.INSERT(Schema.DataSourceName, columnsValues, Schema.IDFieldName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return rowID;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataObject"></param>
        /// <returns></returns>
        public virtual bool Update(T dataObject)
        {
            var columnsValues = new Dictionary<string, object>();

            var objectSchemaFields = Schema.DataFields.Where(field => field.TableField != null).ToList<DataField>();

            foreach (var field in objectSchemaFields)
            {
                if (field.TableField.IsIDField && field.TableField.AllowIDInsert) continue;
                var dataObjectAttr = dataObject.GetType().GetProperty(field.Name);
                if (dataObjectAttr == null) continue;

                if (!field.TableField.AllowNull)
                {
                    var dataObjectAttrValue = dataObjectAttr.GetValue(dataObject, null);
                    if (dataObjectAttrValue != null)
                    {
                        if (NumericTypes.Contains(field.TableField.FieldType))
                        {
                            // Future Imlementation
                            var value = Convert.ChangeType(dataObjectAttrValue, field.TableField.FieldType);
                        }

                        columnsValues.Add(field.TableField.ColumnName,
                            Convert.ChangeType(dataObjectAttrValue, field.TableField.FieldType));
                    }
                    else
                        throw new Exception("The Property " + field.TableField.ColumnName + " in the " +
                                            dataObject.GetType().Name + " Table is not allowed with [IsAllowNull]");
                }
                else
                {
                    var dataObjectAttrValue = dataObjectAttr.GetValue(dataObject, null);
                    if (dataObjectAttrValue == null) continue;

                    if (NumericTypes.Contains(field.TableField.FieldType))
                    {
                        var value = Convert.ChangeType(dataObjectAttrValue, field.TableField.FieldType);

                        if (Convert.ToInt64(value) <= 0 && field.TableField.IsKey)
                            continue;
                    }

                    columnsValues.Add(field.TableField.ColumnName,
                        Convert.ChangeType(dataObjectAttrValue, field.TableField.FieldType));
                }
            }

            try
            {
                var ID = 0;

                foreach (var prop in dataObject.GetType().GetProperties())
                {
                    var attribute = prop.GetCustomAttribute<IsIDFieldAttribute>();
                    if (attribute == null) continue;
                    if (int.TryParse(prop.GetValue(dataObject).ToString(), out ID))
                        ID = Convert.ToInt32(prop.GetValue(dataObject).ToString());
                    
                }
                return ID != 0 && Database.UPDATE(Schema.DataSourceName, columnsValues, Schema.IDFieldName, ID);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
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
