using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
        }

        static public Form2 form2 = null;

        private void Form1_Load(object sender, EventArgs e)
        {
             
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != "") && (textBox2.Text != ""))
            {
                try
                {
                    Students.con.Open();
                    Students.cmd.CommandText = "SELECT * FROM dbo.Users WHERE [User_Name] = '" + textBox1.Text + "' AND [Password] = '" + textBox2.Text + "' ;";
                    SqlDataReader reader = Students.cmd.ExecuteReader();

                    int level = 1;
                    int i = 0;
                    while (reader.Read())
                    {
                        i++;
                        level = reader.GetInt32(2);

                    }
                    reader.Close();
                    if (i == 1)
                    {
                        textBox1.Text = "";
                        textBox2.Text = "";

                        if (form2 == null)
                            form2 = new Form2(level);
                        
                        this.Visible = false;
                        form2.Show();
                        form2.Activate();

                    }
                    else
                    {
                        MessageBox.Show("Error in [User Name] or [Password]");
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString());
                }
                finally
                {
                    Students.con.Close();
                }
            }
            else
            {
                MessageBox.Show("Enter your [User Name] and [Password]");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != "") && (textBox2.Text != ""))
            {
                try
                {
                    Students.con.Open();
                    Students.cmd.CommandText = "SELECT * FROM dbo.Users WHERE [User_Name] = '" + textBox1.Text + "' ;";
                    SqlDataReader reader = Students.cmd.ExecuteReader();
                    string check_user_name = "";
                    int i = 0;
                    while (reader.Read())
                    {
                        i++;
                        check_user_name = reader.GetValue(0).ToString();
                    }
                    reader.Close();

                    if (i==0)
                    {
                        Students.cmd.CommandText = "Insert into dbo.Users([User_Name], [Password],[Level])" +
                        " Values('" + textBox1.Text + "','" + textBox2.Text + "',1);";
                        Students.cmd.ExecuteNonQuery();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        MessageBox.Show($"Success");
                    }
                    else
                    {
                        MessageBox.Show($"This User Name '{textBox1.Text}' is already in use");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString());
                }
                finally
                {
                    Students.con.Close();
                }
                

               
            }
            else
            {
                MessageBox.Show("Enter your [User Name] and [Password]");
            }
;
           


        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
