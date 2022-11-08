using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Runtime.Remoting.Contexts;


namespace Lab3
{
    class Students
    {

        public static SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + "\"C:\\Users\\user\\Desktop\\SBDZ\\lab1\\Labs\\Lab1\\Car showroom\\bin\\Students.mdf\";" + "Integrated Security=True;Connect Timeout=30");
        public static SqlCommand cmd = new SqlCommand("", con);
        //public static DataSet ds;
        //public static SqlDataAdapter da;
        //public static BindingSource bs;
        //public static string sql;

        public static void openConnection()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    // MessageBox.Show("The connection is: " + con.State.ToString());

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Open connection Failed: " + ex.Message);
            }
        }

        public static void closeConnection()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Close();
                    // MessageBox.Show("The connection is: " + con.State.ToString());

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Close connection error: " + ex.Message);
            }
        }



    }
}

