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
using System.Security.Cryptography;

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
        /// <summary>
        /// Głowna funkcja zabezpieczająca hasło użytkownika.
        /// </summary>
        /// <param name="md5Hash"> Przekazujemy wcześniej utworzony MD5.</param>
        /// <param name="input"> Przekazujemy "input" czyli wartość wprowadzona przez użytkownika jako hasło.</param>
        /// <returns>
        /// Funkcja GetMd5Hash() odpowiada za konwersje danych wejściowych na bity i zwrócenie jako ciąg szesnastkowy.
        /// </returns>
        /// <example>
        /// <code>
        /// MD5 md5Hash = MD5.Create();
        /// string input = "Hello World!";
        /// string result = GetMd5Hash(md5Hash, input);
        /// </code>
        /// </example>
        public static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Konwertuje input (string) na tablice bitów i oblicz hash
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Stworz nowy StringBuilder
            StringBuilder sBuilder = new StringBuilder();

            // Petla przez każdy bajt danych mieszaj i sformatujkazda jako ciag szesnastkowy.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            //Zwraca ciąg szesnastkowy.
            return sBuilder.ToString();
        }
        
        string plec, wybor;

        /// <summary>
        /// Głowna funkcja rejestrująca użytkownika.
        /// </summary>
        /// <returns>
        /// Funkcja Rejestracja() odpowiada za połączenie z bazą danych, zabezpieczenie hasła wprowadzonego przez użytkownika,
        /// a także przesłania danych do bazy danych.
        /// </returns>
        void Rejestracja()
        {
            //Połączenie z lokalną bazą danych.
            MySqlConnection polaczenie = new MySqlConnection("server=localhost; user=root; database=user; port=3306; pooling=false");
            MySqlCommand komenda = polaczenie.CreateCommand();
            MySqlCommand komenda1 = polaczenie.CreateCommand();
            try
            {

                if (polaczenie.State == ConnectionState.Closed)
                {
                    polaczenie.Open();
                    //Sprawdza radiobutona, aby moc wprowadzić płeć użytkownika.
                    if (radioButtonMale.Checked == true)
                    {
                        plec = "male";
                    }
                    else if (radioButtonfemale.Checked == true)
                    {
                        plec = "female";
                    }
                    //Sprawdza które checboxy sa zaznaczone.
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
                    string haslo = PasswordBox.Text;
                    //hashowanie hasel.
                    using (MD5 hash = MD5.Create())
                    {
                        haslo = GetMd5Hash(hash, haslo);
                    }

                    komenda1.CommandText = string.Format("SELECT count(id) FROM user1 where Login='" + LoginBox.Text + "'");
                    int wartosc = Convert.ToInt32(komenda1.ExecuteScalar());
                    if(wartosc == 1)
                    {
                        MessageBox.Show(String.Format("Login: {0}, already exists.",LoginBox.Text), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } else
                    {
                        //komeda wstawiaajca dane z pol tekstowych.
                        komenda.CommandText = string.Format("INSERT INTO user1(Name,Surname,Login,Password,Music,Sex) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", NameBox.Text, SurnameBox.Text, LoginBox.Text, haslo, wybor, plec);
                        //if sprawdzajacy czy komeda sie wykonala poprawnie --- czy zwrocila ilosc rzedow.
                        if (komenda.ExecuteNonQuery() == 1)
                        {
                            //komunkiat o poprawnym zajestestrowaniu uzytkownika.
                            MessageBox.Show("You have logged successfuly.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //przejscie do panelu logownia
                            this.Hide();
                            LogPanel NewLogPanel = new LogPanel();
                            NewLogPanel.Show();
                        } else {
                            MessageBox.Show("Login Error.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    NameBox.Clear(); SurnameBox.Clear();LoginBox.Clear();PasswordBox.Clear();NameBox.Focus();
                    
                }

            }
            catch (Exception ex)
            {
                string byk = string.Format("Problem registering user: \n{0}.", ex.Message);
                MessageBox.Show(byk, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                //jesli polaczenie jest otwarte, to zamnknij.
                if (polaczenie.State == ConnectionState.Open)
                {
                    polaczenie.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if ktory sprawdza czy pola (email,pass,surname,name) sa puste, sprawdza tez czy uzytkownik podal plec, jesli wszsytko jest prawidlowe uruchamia funkcje Rejestracja().
            if (LoginBox.Text.Equals("") || LoginBox.Text.Equals("Login") || PasswordBox.Text.Equals("")  || PasswordBox.Text.Equals("Password") || SurnameBox.Text.Equals("") || SurnameBox.Text.Equals("Surname") || NameBox.Text.Equals("") || NameBox.Text.Equals("Name"))
            {
                MessageBox.Show("Yours data are empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (radioButtonfemale.Checked == false && radioButtonMale.Checked == false)
            {
                MessageBox.Show("Select gender.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(LoginBox.TextLength < 5)
            {
                MessageBox.Show("Login must be at least 5 characters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (PasswordBox.TextLength < 5)
            {
                MessageBox.Show("Password must be at least 5 characters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Rejestracja();
            }
        }

        private void NameBox_Enter(object sender, EventArgs e)
        {
            //jesli najdziemy na NameBox --- bedzie puste pole.
            if (NameBox.Text.Equals("Name"))
            {
                NameBox.Text = "";
            }
        }

        private void NameBox_Leave(object sender, EventArgs e)
        {
            //jesli opuscimy NameBox --- bedzie napis Name.
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
            if (LoginBox.Text.Equals("Login"))
            {
                LoginBox.Text = "";
            }
        }

        private void EmailBox_Leave(object sender, EventArgs e)
        {
            if (LoginBox.Text.Equals(""))
            {
                LoginBox.Text = "Login";
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
