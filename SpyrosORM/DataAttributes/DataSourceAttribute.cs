using System.ComponentModel;

namespace SpyrosORM.DataAttributes
{
    public enum DatabaseType
    {
        [Description("Database table.")]
        [DefaultValue("DBTable")]
        DBTable = 1,

        [Description("Database View")]
        [DefaultValue("View")]
        DBView = 2
    }

    [System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Struct)]
    public class DataSourceAttribute : System.Attribute
    {
        public string Name { get; set; }

        public DatabaseType Type { get; set; }
    }
}