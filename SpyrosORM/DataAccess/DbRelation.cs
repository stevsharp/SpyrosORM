using System;

namespace SpyrosORM.DataAccess
{
    public class DbRelation
    {
        public string DataField { get; set; }

        public string RelationName { get; set; }

        public Type WithDataModel { get; set; }

        public string OnDataModelKey { get; set; }

        public string ThisKey { get; set; }

        public DbRelation RelationType { get; set; }
    }
}