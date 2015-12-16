using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Demo_01();
            //Demo_02();
            Demo_03();
            //conn.ConnectionString;
            //conn.ConnectionTimeout;
            
            //command
            //SqlCommand command = new SqlCommand();
            //command.CommandText
            //command.CommandType
            //command.ExecuteNonQuery()
            //command.ExecuteReader()
            //command.ExecuteScalar()

            //conn.CreateCommand()
        }

        public static void Demo_01()
        {
            string connStr = "Data source=transdb.qa.fellowshipone.com;Initial catalog=ChmDashboard;persist security info=True;integrated security=True;";
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "SELECT * FROM [ChmDashboard].[dbo].[AuthenticateConsumer]";

            conn.Open();
            SqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("ConsumerID : {0}", dataReader["AuthenticateConsumerID"]);
                sb.AppendFormat("AppID : {0}", dataReader["ConsumerAppID"]);
                sb.AppendFormat("ConsumerName : {0}", dataReader["ConsumerName"]);
                Console.WriteLine(sb.ToString());
            }
            conn.Close();
        }

        public static void Demo_02()
        {
            string connStr = "Data source=transdb.qa.fellowshipone.com;Initial catalog=ChmDashboard;persist security info=True;integrated security=True;";

            using(SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM [ChmDashboard].[dbo].[AuthenticateConsumer];";

                conn.Open();
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendFormat("ConsumerID : {0}", dataReader["AuthenticateConsumerID"]);
                        sb.AppendFormat("AppID : {0}", dataReader["ConsumerAppID"]);
                        sb.AppendFormat("ConsumerName : {0}", dataReader["ConsumerName"]);
                        Console.WriteLine(sb.ToString());
                    }
                    conn.Close();
                }
            }
        }

        public static void Demo_03()
        {
            string connStr = "Data source=transdb.qa.fellowshipone.com;Initial catalog=ChmDashboard;persist security info=True;integrated security=True;";
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "SELECT * FROM [ChmDashboard].[dbo].[AuthenticateConsumer];";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendFormat("ConsumerID : {0}", row["AuthenticateConsumerID"]);
                    sb.AppendFormat("AppID : {0}", row["ConsumerAppID"]);
                    sb.AppendFormat("ConsumerName : {0}", row["ConsumerName"]);
                    Console.WriteLine(sb.ToString());
                }
            }
            
        }
    }
}
