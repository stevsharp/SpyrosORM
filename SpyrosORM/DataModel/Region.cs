using SpyrosORM.DataAttributes;

namespace SpyrosORM.DataModel
{
    [DataSource(Name = "Region" , Type = DatabaseType.DBTable)]
    public class RegionModel : DataAccess.DataModel
    {
        [IsIDField]
        [DbColumn("RegionID")]
        public int RegionID { get; set; }

        [DbColumn("RegionDescription")]
        public int RegionDescripton { get; set; }
    }
}
