using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarInfo
{
    public class SQLHelper
    {
        static string location = System.Reflection.Assembly.GetExecutingAssembly().Location;
        static string path = System.IO.Path.GetDirectoryName(location);
        public static SqlConnection GetConn()
        {
            SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;" +
                "AttachDbFilename=" + path + "\\Car_directory.mdf;Integrated Security=True;" +
                "Connect Timeout=30");
            return conn;
        }

        public static void Reseed(string table, int index)
        {
            SqlConnection con = GetConn();
            string query = "DBCC CHECKIDENT ('" + table + "', RESEED, " + index + ")";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.CommandText = query;
                con.Open();
                cmd.ExecuteNonQuery();
            }
            con.Close();
        }

        public static void UpdateTable(string table, string changes, string selector, 
            params SqlParameter[] parameters)
        {
            SqlConnection con = GetConn();
            string query = "UPDATE " + table + " SET " + changes + " WHERE " + selector;
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.CommandText = query;
                cmd.Parameters.AddRange(parameters);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            con.Close ();
        }

        public static SqlDataReader ExecuteReader(string col, string table, string selector,
            SqlParameter parameter)
        {
            SqlConnection con = GetConn();
            string query = "SELECT " + col + " FROM " + table + " WHERE " + selector + " = @" + selector;
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.CommandText = query;
                cmd.Parameters.Add(parameter);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                
                return reader;
            }
        }
        
        public static SqlDataReader ExecuteReaderFrom(string col, string table, string selector, 
            SqlParameter parameter)
        {
            SqlConnection con = GetConn();
            string query = "SELECT " + col + " FROM " + table + " WHERE " + selector + " = @" + selector;
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.CommandText = query;
                cmd.Parameters.Add(parameter);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                con.Close();
                return reader;
            }
        }

        public static string[] Items(string col, string table)
        {
            List<string> list = new List<string>();
            string[] itms;
            SqlConnection con = GetConn();
            string query = "SELECT " + col + " FROM " + table;
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.CommandText = query;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(reader.GetString(0));
                }
                itms = list.ToArray();
            }
            return itms;
        }

        /*public static string[] Items(string query, params SqlParameter[] parameters)
        {
            List<string> list = new List<string>();
            string[] itms;
            SqlConnection con = GetConn();
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.CommandText = query;
                cmd.Parameters.AddRange(parameters);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(reader.GetString(0));
                }
                itms = list.ToArray();
            }
            return itms;
        }*/
        
        public static DataSet LoadData(string table)
        {
            SqlConnection con = GetConn();
            con.Open();
            string query = "SELECT * FROM " + table;
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, table);
            adapter.Dispose();
            con.Close();
            return ds;
        }

        public static DataSet UpdateData(string table, DataSet ds)
        {
            SqlConnection con = GetConn();
            con.Open();
            string query = "SELECT * FROM " + table;
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter);
            adapter.Update(ds, table);
            ds.Clear();
            adapter.Fill(ds, table);
            con.Close();
            return ds;
        }

        public static void GenVINS(string id)
        {
            SqlConnection con = GetConn();
            string[] yearMas = {"A", "B", "C", "D", "E", "F", "G", "H", "J", "K", "L", "M", "N", "P",
            "R", "S", "T", "V", "W", "X", "Y", "1", "2", "3", "4", "5", "6", "7", "8", "9"};
            using (SqlDataReader reader = ExecuteReader("*", "Car_catalog",
                "Id = @Id", new SqlParameter("@Id", id)))
            {
                string WMI = ExecuteReader("WMI", "Brand_name", "Name = @Name",
                    new SqlParameter("@Name", reader.GetString(3))).GetString(0) + "9";
                string VDS = reader.GetString(4).Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)[0] + ExecuteReader("Id", "Body_type",
                    "Name = @Name", new SqlParameter("@Name", reader.GetString(4))).GetString(0) + 1 +
                    ExecuteReader("Id", "Engine_type", "Name = @Name", new SqlParameter("@Name",
                    reader.GetString(6))).GetString(0) + "00";
                int year = Convert.ToInt32(reader.GetDateTime(14).Year);
                string VIS = yearMas[year - (year % 30) * 30] +
                    "0" + WMI + "1";
                string VIN = WMI + VDS + VIS;
                string query = "INSERT INTO Cars_VINs (VIN) VALUES ";
                for (int i = 0; i < 40; i++)
                {
                    if (i % 1000 >= 0) VIN += i;
                    else if (i % 100 >= 0) VIN += "0" + i;
                    else if (i % 10 >= 0) VIN +="00" + i;
                    else VIN += "000" + i;
                    query += VIN;
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandText = query;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }

        }
    }
}
