using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpyrosORM.DataAccess;
using SpyrosORM.DataModel;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var db = new DataAccess<RegionModel>();

            var condition = new Dictionary<string, object> { { "RegionID", 1 } };

            var id = 1;
            var list = db.Get(x => x.RegionID == id);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var dataSourceSchema = new DataSourceSchema<RegionModel>();
            var db = new DataAccess<RegionModel> {Schema = dataSourceSchema};
            var id = db.Insert(new RegionModel()
            {
                RegionID = 5,
                RegionDescripton = "Test"
            });

            Assert.IsTrue(id > 0);

        }
    }
}
