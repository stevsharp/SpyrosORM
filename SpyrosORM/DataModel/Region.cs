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
        [AllowIDInsert]
        [DbColumn("RegionID")]
        public int RegionID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DbColumn("RegionDescription")]
        public int RegionDescripton { get; set; }
    }
}
