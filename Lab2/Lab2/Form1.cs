using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
// using Сar_dealership;
using System.Security.Policy;
using System.Drawing;
using System.Data;

namespace Lab2
{
    public partial class Form1 : Form
    {
        int index;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateListView();
        }

        public void UpdateListView()
        {
            Students.ds.Clear();
            Students.da.SelectCommand = new SqlCommand(" SELECT * FROM dbo.Students;", Students.con);
            Students.da.Fill(Students.ds);
            dataGridView1.DataSource = Students.ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Students.da.DeleteCommand = new SqlCommand(" DELETE FROM dbo.Students WHERE [ID] = @id; ", Students.con);
            Students.da.DeleteCommand.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            Students.con.Open();
            Students.da.DeleteCommand.ExecuteNonQuery();
            Students.con.Close();
            UpdateListView();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Students.ds.Clear();
            string queryString = " SELECT * FROM dbo.Students WHERE [Full_Name] = @br OR [Group_Code] = @mo;";
            Students.da.SelectCommand = new SqlCommand(queryString, Students.con);
            Students.da.SelectCommand.Parameters.Add("@br", System.Data.SqlDbType.NChar).Value = textBox1.Text;
            Students.da.SelectCommand.Parameters.Add("@mo", System.Data.SqlDbType.NChar).Value = textBox1.Text;
           
            Students.da.Fill(Students.ds);
            dataGridView1.DataSource = Students.ds.Tables[0];
        }

        private void button4_Click(object sender, EventArgs e)
        {

            Students.con.Open();
            string queryString = "INSERT INTO dbo.Students (Id, Full_Name, Group_Code, City, Year, Sex) VALUES (@Id, @Full_Name, @Group_Code, @City, @Year, @Sex)";
            Students.da.SelectCommand = new SqlCommand(queryString, Students.con);
            Students.da.SelectCommand.Parameters.Add("@Id", System.Data.SqlDbType.NChar).Value = textBox2.Text;
            Students.da.SelectCommand.Parameters.Add("@Full_Name", System.Data.SqlDbType.NChar).Value = textBox3.Text;
            Students.da.SelectCommand.Parameters.Add("@Group_Code", System.Data.SqlDbType.NChar).Value = textBox4.Text;
            Students.da.SelectCommand.Parameters.Add("@City", System.Data.SqlDbType.NChar).Value = textBox5.Text;
            Students.da.SelectCommand.Parameters.Add("@Year", System.Data.SqlDbType.NChar).Value = textBox6.Text;
            Students.da.SelectCommand.Parameters.Add("@Sex", System.Data.SqlDbType.NChar).Value = textBox7.Text;
            Students.da.SelectCommand.ExecuteNonQuery();
            UpdateListView();
            Students.con.Close();

        }
        private void button5_Click_1(object sender, EventArgs e)
        {

            Students.con.Open();
            string queryString = "UPDATE dbo.Students SET Full_Name = @Full_Name, Group_Code = @Group_Code, City = @City, Year = @Year, Sex = @Sex WHERE Id = @Id";
            Students.da.SelectCommand = new SqlCommand(queryString, Students.con);
            
            Students.da.SelectCommand.Parameters.Add("@Full_Name", System.Data.SqlDbType.NChar).Value = textBox3.Text;
            Students.da.SelectCommand.Parameters.Add("@Group_Code", System.Data.SqlDbType.NChar).Value = textBox4.Text;
            Students.da.SelectCommand.Parameters.Add("@City", System.Data.SqlDbType.NChar).Value = textBox5.Text;
            Students.da.SelectCommand.Parameters.Add("@Year", System.Data.SqlDbType.NChar).Value = textBox6.Text;
            Students.da.SelectCommand.Parameters.Add("@Sex", System.Data.SqlDbType.NChar).Value = textBox7.Text;

            Students.da.SelectCommand.Parameters.Add("@Id", System.Data.SqlDbType.NChar).Value = textBox2.Text;

            Students.da.SelectCommand.ExecuteNonQuery();
            UpdateListView();
            Students.con.Close();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[index];
            textBox2.Text = row.Cells[0].Value.ToString();
            textBox3.Text = row.Cells[1].Value.ToString();
            textBox4.Text = row.Cells[2].Value.ToString();
            textBox5.Text = row.Cells[3].Value.ToString();
            textBox6.Text = row.Cells[4].Value.ToString();
            textBox7.Text = row.Cells[5].Value.ToString();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Students.ds.Clear();
            string queryString = " SELECT * FROM dbo.Students WHERE [Full_Name] LIKE '@br%';";
            Students.da.SelectCommand = new SqlCommand(queryString, Students.con);
            Students.da.SelectCommand.Parameters.Add("@br", System.Data.SqlDbType.NChar).Value = textBox1.Text;
           // Car.da.SelectCommand.Parameters.Add("@mo", System.Data.SqlDbType.NChar).Value = textBox1.Text;

            Students.da.Fill(Students.ds);
            dataGridView1.DataSource = Students.ds.Tables[0];
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
