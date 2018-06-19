using System;

namespace SpyrosORM.DataAccess
{
    public class DbTableField
    {
      
        public string ColumnName { get; set; }

        public bool IsIDField { get; set; }

        public bool AllowNull { get; set; }

        public bool AllowIDInsert { get; set; }

        public bool IsKey { get; set; }

        public Type FieldType { get; set; }

    }
}