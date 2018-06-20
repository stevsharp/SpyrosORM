using System;
using System.Collections.Generic;
using System.Data;
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
        protected IDbConnection _connection;
        /// <summary>
        /// 
        /// </summary>
        protected IDbTransaction _transaction;
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
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="columnsValues"></param>
        /// <param name="idFieldName"></param>
        /// <returns></returns>
        public int INSERT(string tableName, Dictionary<string, object> columnsValues, string idFieldName)
        {
            var fields = new StringBuilder();
            fields.Append("(");
            var values = new StringBuilder();
            values.Append("(");
            var recordID = 0;

            try
            {
                foreach (var pair in columnsValues)
                {
                    switch (pair.Value)
                    {
                        case null:
                            fields.Append("[" + pair.Key + "],");
                            values.Append("NULL" + ",");
                            break;
                        case int _:
                        case double _:
                            fields.Append("[" + pair.Key + "],");
                            values.Append(pair.Value + ",");
                            break;
                        case DateTime _ when (DateTime)pair.Value == DateTime.MinValue:
                            continue;
                        default:
                            fields.Append("[" + pair.Key + "],");
                            values.Append("'" + pair.Value.ToString().Replace("'", "`") + "'" + ",");
                            break;
                    }
                }

                fields.Remove(fields.Length - 1, 1).Append(")");
                values.Remove(values.Length - 1, 1).Append(")");

                using (var cn = new SqlConnection(ConnectionString_Lync))
                {
                    var cmd = cn.CreateCommand();
                    cmd.CommandText = $"INSERT INTO [{tableName}] {fields} VALUES {values}"; 
                    cn.Open();
                    recordID = Convert.ToInt32(cmd.ExecuteNonQuery());
                }
            }
            catch (Exception e){
                throw;
            }

            return recordID;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="columnsValues"></param>
        /// <param name="idFieldName"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool UPDATE(string tableName, Dictionary<string, object> columnsValues, string idFieldName, int ID)
        {
            var fieldsValues = new StringBuilder();

            foreach (var pair in columnsValues)
            {

                var valueType = pair.Value.GetType();

                if (valueType == typeof(int) || valueType == typeof(double))
                    fieldsValues.Append("[" + pair.Key + "]=" + pair.Value + ",");
                else if (valueType == typeof(DateTime) && (DateTime)pair.Value == DateTime.MinValue)
                    continue;
                else
                    fieldsValues.Append("[" + pair.Key + "]=" + "'" + pair.Value + "'" + ",");
            }

            fieldsValues.Remove(fieldsValues.Length - 1, 1);
            var updateQuery = $"UPDATE  [{tableName}] SET {fieldsValues} WHERE [{idFieldName}]={ID}";

            try
            {
                using (var cn = new SqlConnection(ConnectionString_Lync))
                {
                    var cmd = cn.CreateCommand();
                    cmd.CommandText = updateQuery;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}


//foreach (var pair in columnsValues)
//{
//    switch (pair.Value)
//    {
//        case null:
//            fields.Append("[" + pair.Key + "],");
//            values.Append("NULL" + ",");
//            break;
//        case int _:
//        case double _:
//            fields.Append("[" + pair.Key + "],");
//            values.Append(pair.Value + ",");
//            break;
//        case DateTime _ when (DateTime)pair.Value == DateTime.MinValue:
//            continue;
//        default:
//            fields.Append("[" + pair.Key + "],");
//            values.Append("'" + pair.Value.ToString().Replace("'", "`") + "'" + ",");
//            break;
//    }
//}

//fields.Remove(fields.Length - 1, 1).Append(")");
//values.Remove(values.Length - 1, 1).Append(")");

//string insertQuery = string.Format("INSERT INTO [{0}] {1} VALUES {2}", tableName, fields, values);

//var fields = new StringBuilder();
//fields.Append("(");
//var values = new StringBuilder();
//values.Append(")");