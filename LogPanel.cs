using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;



namespace PlayerMP3AndVideo
{
    
    public partial class LogPanel : Form
    {
        public LogPanel()
        {
            InitializeComponent();    
        }

        public static string Set_Name="";
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

        //Sprawdza skrót względem łańcucha.
        public static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash wejściowy.
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Utwórz StringComparer i porównaj skróty.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterPanel NewRegister = new RegisterPanel();
            NewRegister.Show();


        }
        void Polacznie1()
        {
            //Polacznie z lokalna baza danych.
            MySqlConnection polaczenie = new MySqlConnection("server=localhost; user=root; database=user; port=3306; pooling=false");
            //Stworznie komedy wyszykujacej email i haslo uzytkownika
            MySqlDataAdapter komenda = new MySqlDataAdapter("SELECT count(id) FROM user1 where Login='" + LoginBox.Text + "'", polaczenie);
            try
            {
                //Stworzenie nowego obiektu DataTable
                DataTable dt = new DataTable();
                //metody Fill pozwala załadować dane (z komedy) do obiektów DataTable
                komenda.Fill(dt);
                //if sprawdza czy zwraca dokladnie 1
                if (dt.Rows[0][0].ToString() == "1")
                {
                    //hasla
                    MD5 hashMd5 = MD5.Create();
                    string haslo = GetMd5Hash(hashMd5,PasswodBox.Text);

                    MySqlDataAdapter komenda1 = new MySqlDataAdapter("SELECT Password FROM user1 where Login='" + LoginBox.Text + "'", polaczenie);
                    DataTable dt1 = new DataTable();            
                    komenda1.Fill(dt1);
                    
                    string haslozBazy = dt1.Rows[0][0].ToString(); 

                    if (VerifyMd5Hash(hashMd5, PasswodBox.Text, haslozBazy))
                    {
                        //przypisz dane so wartosi Set_Name dzieki, ktorej przkazujemy wartosc do wyswietlenia w kolejnym panelu
                        Set_Name = LoginBox.Text;
                        //komunkiat o poprawnym zajeztreowniu uzytkownika
                        MessageBox.Show("Login Succes.", "Congrates", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //przejscie do panelu uzytkownika
                        this.Hide();
                        MainPanel NewPanel = new MainPanel();
                        NewPanel.Show();
                    }else
                    {
                        //Error gdy wpiszemy zle email lub haslo
                        MessageBox.Show("Either your Login is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //czysci pola tesktowe
                        LoginBox.Clear();
                        PasswodBox.Clear();
                    }
                    
                }
                else
                {
                    //Error gdy wpiszemy zle email lub haslo
                    MessageBox.Show("nie ma takie Loginu.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //czysci pola tesktowe
                    LoginBox.Clear();
                    PasswodBox.Clear();
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
        void Polacznie()
        {
            //Polacznie z lokalna baza danych.
            MySqlConnection polaczenie = new MySqlConnection("server=localhost; user=root; database=user; port=3306; pooling=false");
            //Stworznie komedy wyszykujacej email i haslo uzytkownika
            MySqlDataAdapter komenda = new MySqlDataAdapter("SELECT count(*) FROM user1 where Email='" + LoginBox.Text + "'and Password='" + PasswodBox.Text + "'", polaczenie);
            try
            {
                //Stworzenie nowego obiektu DataTable
                DataTable dt = new DataTable();
                //metody Fill pozwala załadować dane (z komedy) do obiektów DataTable
                komenda.Fill(dt);
                //if sprawdza czy zwraca dokladnie 1
                if (dt.Rows[0][0].ToString() == "1")
                {
                    //komunkiat o poprawnym zajeztreowniu uzytkownika
                    MessageBox.Show("Login Succes.", "Congrates", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //przejscie do panelu uzytkownika
                    this.Hide();
                    MainPanel NewPanel = new MainPanel();
                    NewPanel.Show();
                }
                else
                {
                    //Error gdy wpiszemy zle email lub haslo
                    MessageBox.Show("Either your Login or password is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //czysci pola tesktowe
                    LoginBox.Clear();
                    PasswodBox.Clear();
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
            //if ktory sprawdza czy pola(email, haslo) sa puste lib wartosic domyslne.
            if (LoginBox.Text.Equals(" ") || LoginBox.Text.Equals("Email") || PasswodBox.Text.Equals(" ") || PasswodBox.Text.Equals("Password"))
            {
                MessageBox.Show("Login or password is empty, or are the defaults.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                Polacznie1();
            }
            
        }

        private void EmailBox_Enter(object sender, EventArgs e)
        {
            //jesli najdziemy na EmailBox --- bedzie puste pole.
            if (LoginBox.Text.Equals("Login"))
            {
                LoginBox.Text = "";
            }
        }

        private void EmailBox_Leave(object sender, EventArgs e)
        {
            //jesli opuscimy EmailBox --- bedzie napis Name.
            if (LoginBox.Text.Equals(""))
            {
                LoginBox.Text = "Login";
            }
        }

        private void PasswodBox_Enter(object sender, EventArgs e)
        {
            if (PasswodBox.Text.Equals("Password"))
            {
                PasswodBox.Text = "";
            }
        }

        private void PasswodBox_Leave(object sender, EventArgs e)
        {
            if (PasswodBox.Text.Equals(""))
            {
                PasswodBox.Text = "Password";
            }
        }
    }
}
