using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;    // local DB
using System.Data;              // ConnectionState, DataTable
using System.Reflection;

namespace InventoryTracker
{
    public static class ClsDB
    {
        public static SqlConnection Get_DB_Connection()
        {
            // gets the path to the database
            string cn_String = Properties.Settings.Default.Connection_String;

            // Instantiates a connection to the database with the path string
            SqlConnection cn_connection = new SqlConnection(cn_String);

            // if its not open, then it opens it
            if (cn_connection.State != ConnectionState.Open)
                cn_connection.Open();
            
            // returns the connection
            return cn_connection;

        }

        public static DataTable Get_DataTable(string SQL_Text)
        {
            // opens a connection to the database
            SqlConnection cn_connection = Get_DB_Connection();

            // instantiates a table object
            DataTable table = new DataTable();

            // instatiates an adapter object 
            SqlDataAdapter adapter = new SqlDataAdapter(SQL_Text, cn_connection);

            // fills the table with the adapter
            adapter.Fill(table);

            // returns the full table
            return table;
        }


        public static void Execute_SQL(string SQL_Text)
        {

            SqlConnection cn_connection = Get_DB_Connection();

            SqlCommand cmd_Command = new SqlCommand(SQL_Text, cn_connection);

            cmd_Command.ExecuteNonQuery();

        }

        public static void Close_DB_Connection()
        {

            string cn_String = Properties.Settings.Default.Connection_String;

            SqlConnection cn_connection = new SqlConnection(cn_String);

            if (cn_connection.State != ConnectionState.Closed)
                cn_connection.Close();

        }

    }
}
