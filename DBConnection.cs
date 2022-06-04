using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace HelloApp
{
    internal class DBConnection
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False";
        SqlConnection connection = new SqlConnection(connectionString);
        public void Open_connetion()
        {
            if(connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

        }
        public void Close_connetion()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }

        }
        public SqlConnection Get_connection()
        {
            return connection;
        }
    }   
}
