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
            //wylacznie aplikacji
            System.Windows.Forms.Application.Exit();
        }

        //dodatkowe parametry 
        string plec, wybor;
        void Rejestracja()
        {
            //Polacznie z lokalna baza danych
            MySqlConnection polaczenie = new MySqlConnection("server=localhost; user=root; database=user; port=3306; pooling=false");
            MySqlCommand komenda = polaczenie.CreateCommand();
            try
            {

                if (polaczenie.State == ConnectionState.Closed)
                {
                    polaczenie.Open();
                    //sprawdza radiobutona, aby muc wprowadzic plec uzytkownika
                    if (radioButtonMale.Checked == true)
                    {
                        plec = "male";
                    }
                    else if (radioButtonfemale.Checked == true)
                    {
                        plec = "female";
                    }
                    //sprawdza ktore checboxy sa zaznaczone 
                    if (checkBox1.Checked == true && checkBox2.Checked == true && checkBox3.Checked == true && checkBox4.Checked == true)
                    {
                        wybor = "Rock,Pop,Metal,Other";
                    }
                    else if (checkBox1.Checked == true && checkBox2.Checked == true && checkBox3.Checked == true)
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
                    //komeda wstawiaajca dane z pol tekstowych
                    komenda.CommandText = string.Format("INSERT INTO user1(Name,Surname,Email,Password,Music,Sex) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", NameBox.Text, SurnameBox.Text, EmailBox.Text, PasswordBox.Text, wybor, plec);
                    //if sprawdzajacy czy komeda sie wykonala poprawnie --- czy zwrocila ilosc rzedow
                    if (komenda.ExecuteNonQuery() == 1)
                    {
                        //komunkiat o poprawnym zajeztreowniu uzytkownika
                        MessageBox.Show("You have logged successfuly", "Informacja", MessageBoxButtons.OK);
                        //przejscie do panelu logownia
                        this.Hide();
                        LogPanel NewLogPanel = new LogPanel();
                        NewLogPanel.Show();
                    }
                }

            }
            catch (Exception ex)
            {
                string byk = string.Format("Problem podczas rejestracji uzytkwonika \n{0}", ex.Message);
                MessageBox.Show(byk, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                //jesli polaczenie jest otwarte, to zamnknij
                if (polaczenie.State == ConnectionState.Open)
                {
                    polaczenie.Close();
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //if ktory sprawdza czy pola (email,pass,surname,name) sa puste, sprawdza tez czy uzytkownik podal plec, jesli wszsytko jest prawidlowe uruchamia funkcje Rejestracja()
            if (EmailBox.Text.Equals(" ") || EmailBox.Text.Equals("Email") || PasswordBox.Text.Equals(" ")  || PasswordBox.Text.Equals("Password") || SurnameBox.Text.Equals(" ") || SurnameBox.Text.Equals("Surname") || NameBox.Text.Equals(" ") || NameBox.Text.Equals("Name"))
            {
                MessageBox.Show("Yours data are empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (radioButtonfemale.Checked == false && radioButtonMale.Checked == false)
            {
                MessageBox.Show("Select gender", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Rejestracja();
            }
        }

        private void NameBox_Enter(object sender, EventArgs e)
        {
            //jesli najdziemy na NameBox --- bedzie puste pole
            if (NameBox.Text.Equals("Name"))
            {
                NameBox.Text = "";
            }
        }

        private void NameBox_Leave(object sender, EventArgs e)
        {
            //jesli opuscimy NameBox --- bedzie napis Name
            if (NameBox.Text.Equals(""))
            {
                NameBox.Text = "Name";
            }
        }

        private void SurnameBox_Enter(object sender, EventArgs e)
        {
            if (SurnameBox.Text.Equals("Surname"))
            {
                SurnameBox.Text = "";
            }
        }

        private void SurnameBox_Leave(object sender, EventArgs e)
        {
            if (SurnameBox.Text.Equals(""))
            {
                SurnameBox.Text = "Surname";
            }
        }

        private void EmailBox_Enter(object sender, EventArgs e)
        {
            if (EmailBox.Text.Equals("Email"))
            {
                EmailBox.Text = "";
            }
        }

        private void EmailBox_Leave(object sender, EventArgs e)
        {
            if (EmailBox.Text.Equals(""))
            {
                EmailBox.Text = "Email";
            }
        }

        private void PasswordBox_Enter(object sender, EventArgs e)
        {
            if (PasswordBox.Text.Equals("Password"))
            {
                PasswordBox.Text = "";
            }
        }

        private void PasswordBox_Leave(object sender, EventArgs e)
        {
            if (PasswordBox.Text.Equals(""))
            {
                PasswordBox.Text = "Password";
            }
        }

    }
}
