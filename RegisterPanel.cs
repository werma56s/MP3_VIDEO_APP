using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace PlayerMP3AndVideo
{
    public partial class RegisterPanel : Form
    {
        public RegisterPanel()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
        string plec, wybor;
        MySqlConnection polaczenie = new MySqlConnection("server=localhost; user=root; database=user; port=3306; pooling=false");
        
        private void button1_Click(object sender, EventArgs e)
        {
            int id=0;
            MySqlCommand komenda = polaczenie.CreateCommand();
            try
            {

                if (polaczenie.State == ConnectionState.Closed)
                {
                    polaczenie.Open();
                    //sprawdza radiobutona
                    if (radioButtonMale.Checked == true)
                    {
                        plec = "male";
                    }
                    else if (radioButtonfemale.Checked == true)
                    {
                        plec = "female";
                    }
                    //sprawdza ktory checbox jest znanzacozny
                    if (checkBox1.Checked == true && checkBox2.Checked == true && checkBox3.Checked == true && checkBox4.Checked == true)
                    {
                        wybor = "Rock,Pop,Metal,Other";
                    }
                    else if(checkBox1.Checked == true && checkBox2.Checked == true && checkBox3.Checked == true)
                    {
                        wybor = "Rock,Pop,Metal";
                    }
                    else if (checkBox1.Checked == true && checkBox2.Checked == true)
                    {
                        wybor = "Rock,Pop";
                    }
                    else if (checkBox1.Checked == true && checkBox3.Checked == true)
                    {
                        wybor = "Rock,Metal";
                    }
                    else if (checkBox1.Checked == true && checkBox4.Checked == true)
                    {
                        wybor = "Rock,Other";
                    }
                    else if (checkBox2.Checked == true && checkBox3.Checked == true)
                    {
                        wybor = "Pop,Metal";
                    }
                    else if (checkBox2.Checked == true && checkBox4.Checked == true)
                    {
                        wybor = "Pop,Other";
                    }
                    else if (checkBox3.Checked == true && checkBox4.Checked == true)
                    {
                        wybor = "Metal,Other";
                    }
                    else if (checkBox1.Checked == true)
                    {
                        wybor = "Rock";
                    }
                    else if (checkBox2.Checked == true)
                    {
                        wybor = "Pop";
                    }
                    else if (checkBox3.Checked == true)
                    {
                        wybor = "Metal";
                    }
                    else if (checkBox4.Checked == true)
                    {
                        wybor = "Other";
                    }


                    komenda.CommandText = string.Format("INSERT INTO register(Name,Surname,Email,Password,Music,Sex) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", NameBox.Text, SurnameBox.Text, EmailBox.Text, PasswordBox.Text, wybor, plec);
                    
                    if(komenda.ExecuteNonQuery()== 1){ 
                    MessageBox.Show("Poprawinie się zarejstrowałes", "Informacja", MessageBoxButtons.OK);

                    this.Hide();
                    LogPanel NewLogPanel = new LogPanel();
                    NewLogPanel.Show();
                    }
                }

            }
            catch (Exception ex)
            {
                string byk = string.Format("Problem z polaczniem \n{0}", ex.Message);
                MessageBox.Show(byk, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                if (polaczenie.State == ConnectionState.Open)
                {
                    polaczenie.Close();
                }
            }
    
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
