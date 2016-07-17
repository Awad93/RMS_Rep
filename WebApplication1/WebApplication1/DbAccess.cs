using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Collections.Generic;

namespace App_Code
{
    public class DbAccess
    {
        //static string connectionString = ConfigurationManager.ConnectionStrings["connectionString_RMS_DB"].ConnectionString;
        static string connectionString = "server = DELLDSR;" +
                "Trusted_Connection=yes;" +
                "database = RMS_DB;" +
                "connection timeout=30;";

        public static void ExecuteNonQuery(string commandText, CommandType commandType, params SqlParameter[] commandParameters)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(commandText, connection))
                {
                    command.CommandType = commandType;
                    command.Parameters.AddRange(commandParameters);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public static DataTable ExecuteQuery(string commandText, CommandType commandType, SqlParameter parameter)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(commandText, connection))
                {
                    DataTable dt = new DataTable();
                    command.CommandType = commandType;
                    command.Parameters.Add(parameter);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dt);
                    connection.Close();
                    return dt;
                }
            }
        }

        public static DataTable ExecuteQuery(string commandText, CommandType commandType, List<SqlParameter> parameters)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(commandText, connection))
                {
                    DataTable dt = new DataTable();
                    command.CommandType = commandType;
                    command.Parameters.AddRange(parameters.ToArray());
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dt);
                    connection.Close();
                    return dt;
                }
            }
        }

        public static DataTable ExecuteQuery(string commandText, CommandType commandType)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(commandText, connection))
                {
                    DataTable dt = new DataTable();
                    command.CommandType = commandType;
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dt);
                    connection.Close();
                    return dt;
                }
            }
        }
    }
}

//public static class Connection
//{
//    public static SqlConnection Connect()
//    {
//        string strSqlServerName = "macdr";
//        string strSqlDatabase = "RMS_DB";

//        return Connect(strSqlServerName, strSqlDatabase);

//    }

//    public static DataTable StoredProcedure(string sp_name, List<string> parameters, List<string> values)
//    {
//        SqlConnection connection = Connect();
//        SqlDataAdapter adapter = new SqlDataAdapter(sp_name, connection);

//        adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
//        for (int i = 0; i < parameters.Count; i++)
//        {
//            adapter.SelectCommand.Parameters.Add(parameters[i], SqlDbType.Char).Value = values[i];
//        }

//        DataTable dt = new DataTable();
//        adapter.Fill(dt);
//        return dt;
//    }

//    public static DataTable Query(string query)
//    {
//        using (SqlConnection connection = Connect())
//        {
//            SqlCommand cmd = new SqlCommand(query, connection);
//            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

//            DataTable dt = new DataTable();
//            adapter.Fill(dt);
//            return dt;
//        }


//    }

//    public static SqlConnection Connect(string server_name, string db_name)
//    {
//        SqlConnection connection = new SqlConnection("server = " + server_name + ";" +
//            "Trusted_Connection=yes;" +
//            "database = " + db_name + ";" +
//            "connection timeout=30;");
//        return connection;
//    }
//}