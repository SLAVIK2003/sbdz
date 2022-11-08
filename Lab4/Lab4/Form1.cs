using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Lab4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        static int Id = -1 ;

        private void Form1_Load(object sender, EventArgs e)
        {
            Students.openConnection();
            Students.cmd.CommandText = "SELECT * FROM [Students];";
            SqlDataReader reader = Students.cmd.ExecuteReader();
            reader.Read();
            Id = Convert.ToInt32(reader.GetValue(0));
            textBox2.Text = reader.GetValue(1).ToString();
            textBox3.Text = reader.GetValue(4).ToString();
            textBox4.Text = reader.GetValue(3).ToString();


            if (reader.GetValue(2) != null)
            {
                byte[] image = (byte[])reader.GetValue(2);


                if (image != null)
                {
                    MemoryStream ms = new MemoryStream(image);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.Image = Image.FromStream(ms);
                }
                else
                {
                    pictureBox1.Image = null;
                }


            }

            reader.Close();


        }






        private void button1_Click(object sender, EventArgs e)
        {

            Students.openConnection();
            Students.cmd.CommandText = "SELECT * FROM [Students] WHERE Id = '" + textBox1.Text + "'";
            SqlDataReader reader = Students.cmd.ExecuteReader();
            reader.Read();
            Id = Convert.ToInt32(reader.GetValue(0));
            textBox2.Text = reader.GetValue(1).ToString();
            textBox3.Text = reader.GetValue(2).ToString();
            textBox4.Text = reader.GetValue(3).ToString();
            textBox5.Text = reader.GetValue(4).ToString();
            textBox6.Text = reader.GetValue(5).ToString();
            // byte[] image = (byte[])reader.GetValue(6);


            if (reader.GetValue(6) != DBNull.Value)
            {
                byte[] image = (byte[])reader.GetValue(6);
                MemoryStream ms = new MemoryStream(image);
                pictureBox1.Image = Image.FromStream(ms);
            }
            else
            {
                pictureBox1.ImageLocation = "https://img.freepik.com/free-photo/front-view-of-male-student-in-dark-t-shirt-yellow-backpack-holding-files-and-books-smiling-on-light-blue-wall_140725-46715.jpg?w=2000";
                
            }
            reader.Close();
        }
        byte[] img;


        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog open_dialog = new OpenFileDialog();
            open_dialog.Filter = "ImageFiles(*.BMP; *.JPG; *.GIF; *.PNG)| *.BMP; *.JPG; *.GIF; *.PNG | All files(*.*) | *.* ";
            if (open_dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    img = GetPhoto(open_dialog.FileName);
                   // button2.BackColor = Color.Chartreuse;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.Image = Image.FromFile(open_dialog.FileName);
                }
                catch (Exception n)
                {
                    DialogResult rezult = MessageBox.Show(n.Message, n.Source,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        public static byte[] GetPhoto(string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Open,
            FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            byte[] photo = br.ReadBytes((int)fs.Length);
            br.Close();
            fs.Close();
            return photo;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Students.openConnection();
            if (textBox1.Text != " " || textBox2.Text != " " || textBox3.Text != " " || textBox4.Text != " " || textBox5.Text != " " || textBox6.Text != " ")
            {
                try
                {

                    Students.cmd.CommandText = "Insert into [Students] (Id, Full_Name, Group_Code, City, Year, Sex, Photo) " +
                        "values(@Id, @full_name, @group_code, @city, @year, @sex, @photo)";
                    Students.cmd.Parameters.Add("@Id", SqlDbType.Int);
                    Students.cmd.Parameters["@Id"].Value = textBox1.Text;
                    Students.cmd.Parameters.Add("@full_name", SqlDbType.NVarChar, 50);
                    Students.cmd.Parameters["@full_name"].Value = textBox2.Text;
                    Students.cmd.Parameters.Add("@group_code", SqlDbType.NVarChar, 50);
                    Students.cmd.Parameters["@group_code"].Value = textBox3.Text;
                    Students.cmd.Parameters.Add("@city", SqlDbType.NVarChar, 50);
                    Students.cmd.Parameters["@city"].Value = textBox4.Text;
                    Students.cmd.Parameters.Add("@year", SqlDbType.Int);
                    Students.cmd.Parameters["@year"].Value = textBox5.Text;
                    Students.cmd.Parameters.Add("@sex", SqlDbType.Int);
                    Students.cmd.Parameters["@sex"].Value = textBox6.Text;

                    Students.cmd.Parameters.Add("@photo", SqlDbType.Image, img.Length);
                    Students.cmd.Parameters["@photo"].Value = img;
                    Students.cmd.ExecuteNonQuery();
                    MessageBox.Show("Базy даних оновлено!");

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    pictureBox1.Image = null;
                    button2.Visible = true;
                    button1.Visible = true;
                    textBox1.Visible = true;


                }
                catch (Exception n)
                {
                    MessageBox.Show(n.Message, n.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Заповніть поля!");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
