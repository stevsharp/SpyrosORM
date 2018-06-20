using System;

namespace SpyrosORM.DataAccess
{
    public class DbTableField
    {
        /// <summary>
        /// 
        /// </summary>
        public string ColumnName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsIDField { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool AllowNull { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool AllowIDInsert { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Type FieldType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public object Value { get; set; }

    }
}