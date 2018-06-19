namespace SpyrosORM.DataAccess
{
    public class DataField
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DbTableField TableField { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DbRelation Relation { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DataField()
        {
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="DataFieldName"></param>
        /// <param name="Field"></param>
        public DataField(string DataFieldName , DbTableField Field)
        {
            this.Name = DataFieldName;
            this.TableField = Field;
        }
    }
}