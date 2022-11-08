using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    internal class Students
    {
        public static SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\user\\Desktop\\SBDZ\\lab1\\Labs\\Lab1\\Car showroom\\bin\\Students.mdf;Integrated Security=True;Connect Timeout=30");  
        public static SqlCommand cmd = new SqlCommand("", con);

        public static void openConnection()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                 //   MessageBox.Show("The connection is " + con.State.ToString());

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Failed:" + ex.Message);
            }
        }
        public static void closeConnection()
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                    MessageBox.Show("The connection is " + con.State.ToString());

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Close connection error:" + ex.Message);
            }
        }
    }
}
