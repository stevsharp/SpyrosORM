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
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Insert()
        {
            var dataSourceSchema = new DataSourceSchema<RegionModel>();
            var db = new DataAccess<RegionModel> {Schema = dataSourceSchema};
            var id = db.Insert(new RegionModel()
            {
                RegionID = 6,
                RegionDescripton = "Test"
            });

            Assert.IsTrue(id > 0);
        }
        /// <summary>
        /// /
        /// </summary>
        [TestMethod]
        public void Update()
        {
            var dataSourceSchema = new DataSourceSchema<RegionModel>();
            var db = new DataAccess<RegionModel> { Schema = dataSourceSchema };
            var  isTrUpdate= db.Update(new RegionModel()
            {
                RegionID = 6,
                RegionDescripton = "Test11"
            });

            Assert.IsTrue(isTrUpdate);
        }
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Delete()
        {
            var dataSourceSchema = new DataSourceSchema<RegionModel>();
            var db = new DataAccess<RegionModel> { Schema = dataSourceSchema };
            var isDelete = db.Delete(new RegionModel()
            {
                RegionID = 6,
                RegionDescripton = "Test11"
            });

            Assert.IsTrue(isDelete);
        }
    }
}
