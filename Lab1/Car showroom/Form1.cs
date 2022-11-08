using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Policy;

namespace Students_Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Students.openConnection();
            
        }


        private void Form1_Closed(object sender, EventArgs e)
        {
            Students.closeConnection();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            UpdateListView();
        }

        public void UpdateListView()
        {

            listView1.Items.Clear();
            string queryString = "SELECT * FROM dbo.Students;";
            Students.cmd.CommandText = queryString;
            SqlDataReader reader = Students.cmd.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem items = new ListViewItem(reader.GetValue(0).ToString());

                for (int i = 1; i < 6; i++)
                    items.SubItems.Add(reader.GetValue(i).ToString());

                listView1.Items.Add(items);



            }
            reader.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" +
            "\"C:\\Users\\user\\Desktop\\SBDZ\\lab1\\Labs\\Lab1\\Car showroom\\bin\\Students.mdf\";" +
            "Integrated Security=True;Connect Timeout=30");

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            string queryString = "INSERT INTO dbo.Students (Id, Full_Name, Group_Code, City, Year, Sex) VALUES('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "')";
            Students.cmd.CommandText = queryString;
            Students.cmd.ExecuteNonQuery();

            UpdateListView();
            con.Close();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            string queryString;
            queryString = "UPDATE dbo.Students SET" +
             " [Full_Name] ='" + textBox2.Text + "'," +
                "[Group_Code] = '" + textBox3.Text + "'," +
                    "[City] = '" + textBox4.Text + "'," +
                     "[Year] = " + textBox5.Text + "," +
                            "[Sex] = " + textBox6.Text +
                                "WHERE  [Id] = " + textBox1.Text + ";";
            Students.cmd.CommandText = queryString;
            Students.cmd.ExecuteNonQuery();
            UpdateListView();

        }



        private void button3_Click(object sender, EventArgs e)
        {
            string queryString = " DELETE FROM dbo.Students WHERE [ID] =  " + listView1.SelectedItems[0].Text + ";";
            Students.cmd.CommandText = queryString;
            Students.cmd.ExecuteNonQuery();
            UpdateListView();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listView1.SelectedItems.Count > 0)
            {
                textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
                textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
                textBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;
                textBox4.Text = listView1.SelectedItems[0].SubItems[3].Text;
                textBox5.Text = listView1.SelectedItems[0].SubItems[4].Text;
                textBox6.Text = listView1.SelectedItems[0].SubItems[5].Text;
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
/*        if (listView1.SelectedItems.Count > 0)
            {
                textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
                textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
                textBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;
                textBox4.Text = listView1.SelectedItems[0].SubItems[3].Text;
                textBox5.Text = listView1.SelectedItems[0].SubItems[4].Text;
                textBox6.Text = listView1.SelectedItems[0].SubItems[5].Text;
            }
*/
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            string queryString = "SELECT * FROM Students WHERE ";
            switch (comboBox1.Text)
            {
                case "Full_Name":
                    {
                        queryString += "Full_Name = '" + textBox7.Text + "';";
                        textBox7_TextChanged(queryString);
                        break;
                    }
                case "Group_Code":
                    {
                        queryString += "Group_Code = '" + textBox7.Text + "';";
                        textBox7_TextChanged(queryString);
                        break;
                    }
                case "City":
                    {
                        queryString += "City = '" + textBox7.Text + "';";
                        textBox7_TextChanged(queryString);
                        break;
                    }
                case "Year":
                    {
                        queryString += " Year = '" + textBox7.Text + "';";
                        textBox7_TextChanged(queryString);
                        break;
                    }
                case "Sex":
                    {
                        queryString += " Sex >= '" + textBox7.Text + "';";
                        textBox7_TextChanged(queryString);
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Неправильно введено параметр пошуку");
                        break;

                    }

            }


        }

        private void textBox7_TextChanged(string queryString)
        {

              Students.cmd.CommandText = queryString;
              SqlDataReader reader = Students.cmd.ExecuteReader();
              while (reader.Read())
              {
                  ListViewItem items = new ListViewItem(reader.GetValue(0).ToString());

                  for (int i = 1; i < 6; i++)
                      items.SubItems.Add(reader.GetValue(i).ToString());

                  listView1.Items.Add(items);

              }
              reader.Close();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
