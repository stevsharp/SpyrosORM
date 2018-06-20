using SpyrosORM.DataAttributes;

namespace SpyrosORM.DataModel
{
    [DataSource(Name = "Region" , Type = DatabaseType.DBTable)]
    public class RegionModel : DataAccess.DataModel
    {
        /// <summary>
        /// /
        /// </summary>
        [IsIDField]
        [DbColumn("RegionID")]
        public int RegionID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DbColumn("RegionDescription")]
        public string RegionDescripton { get; set; }
    }
}
