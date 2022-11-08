using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Runtime.Remoting.Contexts;

namespace Lab2
{
    class Students
    {
        public static SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;" + "AttachDbFilename=C:\\Users\\user\\Desktop\\SBDZ\\lab1\\Labs\\Lab1\\Car showroom\\bin\\Students.mdf" + ";Integrated Security=True;Connect Timeout=30" );
        public static DataSet ds = new DataSet();
        public static SqlDataAdapter da = new SqlDataAdapter("", con);
        public static BindingSource bs = new BindingSource();
    }
}
