using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace WindowsFormsApp1
{
    class KinoClass
    {
        SqlConnection conn = new SqlConnection("Data Source=45.76.93.137;Initial Catalog=KINO_seanse;Persist Security Info=True;User ID=SA;Password=Projektkino1");
        SqlCommand comm;
        SqlDataAdapter adapter;

        public bool query_command(string query)
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
                comm = new SqlCommand(query, conn);
                comm.ExecuteNonQuery();
                conn.Close();
                return true;
            }

            conn.Close();
            return false;

        }

        public DataTable table_get_data(string query)
        {
            DataTable tab = new DataTable();
            if (conn.State == ConnectionState.Closed)
            {
                
                conn.Open();
                adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(tab);
                conn.Close();
                return tab;                
           
            }

            conn.Close();
            return null;

        }
    }
}
