using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyrosORM.DataAccess
{
    public class SqlDatabase
    {
        /// <summary>
        /// 
        /// </summary>
        public static ConfigurationSetting config = new ConfigurationSetting();
        /// <summary>
        /// 
        /// </summary>
        public static string ConnectionString_Lync = config.DllConfig.ConnectionStrings.ConnectionStrings["LyncConnectionString"].ConnectionString;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        private System.Data.SqlClient.SqlConnection DBInitializeConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }
    }
}
