using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SpyrosORM.DataAttributes;

namespace SpyrosORM.DataAccess
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DataSourceSchema<T> where T : DataModel, new()
    {
        /// <summary>
        /// 
        /// </summary>
        public string DataSourceName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<DataField> DataFields { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DatabaseType DataSourceType { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public DataSourceSchema()
        {
            TryReadDataSourceAttributeValue();
            TryReadClassDataFields();
        }
        /// <summary>
        /// 
        /// </summary>
        private void TryReadDataSourceAttributeValue()
        {
            if (!(typeof(T).GetCustomAttributes(typeof(DataSourceAttribute), false).FirstOrDefault() is
                DataSourceAttribute dataSourceAttributes)) return;

            DataSourceType = dataSourceAttributes.Type;
            DataSourceName = dataSourceAttributes.Name;
        }
        /// <summary>
        /// 
        /// </summary>
        private void TryReadClassDataFields()
        {
            this.DataFields = new List<DataField>();

            var tableFields = typeof(T)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(x => x.GetCustomAttributes<DbColumnAttribute>() != null)
                .ToList();

            var relationFields = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(x=>x.GetCustomAttributes<DataRelationAttribute>() != null).ToList();
            var allClassFields = relationFields.Concat(relationFields).ToList();

            foreach (var field in allClassFields)
            {
                var newDataField = new DataField {Name = field.Name};
                if (field.GetCustomAttributes<DbColumnAttribute>() != null)
                {
                    newDataField.TableField = new DbTableField(){
                        ColumnName = field.GetCustomAttribute<DbColumnAttribute>().Name,
                        IsIDField = field.GetCustomAttribute<IsIDFieldAttribute>() != null ? field.GetCustomAttribute<IsIDFieldAttribute>().Status : false,
                        AllowNull = field.GetCustomAttribute<AllowNullAttribute>() != null ? field.GetCustomAttribute<AllowNullAttribute>().Status : false,
                        AllowIDInsert = field.GetCustomAttribute<AllowIDInsertAttribute>() != null ? field.GetCustomAttribute<AllowIDInsertAttribute>().Status : false,
                        IsKey = field.GetCustomAttribute<IsKeyAttribute>() != null ? field.GetCustomAttribute<IsKeyAttribute>().Status : false,
                        FieldType = field.PropertyType
                    };
                }

                if (field.GetCustomAttribute<DataRelationAttribute>() == null) continue;

                var dataRelationAttribute = field.GetCustomAttribute<DataRelationAttribute>();

                newDataField.Relation = new DbRelation()
                {
                    DataField = field.Name,
                    RelationName = dataRelationAttribute.Name
                    //WithDataModel = dataRelationAttribute.WithDataModel,
                    //OnDataModelKey = dataRelationAttribute.OnDataModelKey,
                    //ThisKey = dataRelationAttribute.ThisKey,
                    //RelationType = dataRelationAttribute.RelationType
                };
            }

        }
    }
}