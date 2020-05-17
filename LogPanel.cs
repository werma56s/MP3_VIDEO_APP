using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        void Polacznie()
        {
            //Polacznie z lokalna baza danych
            MySqlConnection polaczenie = new MySqlConnection("server=localhost; user=root; database=user");
           //Stworznie komedy wyszykujacej email i haslo uzytkownika
            MySqlDataAdapter komenda = new MySqlDataAdapter("SELECT count(*) FROM user1 where Email='"+ EmailBox.Text + "'and Password='"+ PasswodBox.Text + "'",polaczenie);
            //Stworzenie nowego obiektu DataTable
            DataTable dt = new DataTable();
            //metody Fill pozwala załadować dane (z komedy) do obiektów DataTable
            komenda.Fill(dt);
            //if sprawdza czy zwraca dokladnie 1
            if(dt.Rows[0][0].ToString() == "1")
            {
                //komunkiat o poprawnym zajeztreowniu uzytkownika
                MessageBox.Show("Login Succes", "Congrates", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //przejscie do panelu uzytkownika
                this.Hide();
                MainPanel NewPanel = new MainPanel();
                NewPanel.Show();
            }
            else
            {
                //Error gdy wpiszemy zle email lub haslo
                MessageBox.Show("Either your email or password is incorrect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //czysci pola tesktowe
                EmailBox.Clear();
                PasswodBox.Clear();
            }

            //jesli polaczenie jest otwarte, to zamnknij
            if (polaczenie.State == ConnectionState.Open)
            {
                polaczenie.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if ktory sprawdza czy pola(email, haslo) sa puste lib wartosic domyslne,
            if (EmailBox.Text.Equals(" ") || EmailBox.Text.Equals("Email") || PasswodBox.Text.Equals(" ") || PasswodBox.Text.Equals("Password"))
            {
                MessageBox.Show("Login or password is empty, or are the defaults", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                Polacznie();
            }
            
        }

        private void EmailBox_Enter(object sender, EventArgs e)
        {
            //jesli najdziemy na EmailBox --- bedzie puste pole
            if (EmailBox.Text.Equals("Email"))
            {
                EmailBox.Text = "";
            }
        }

        private void EmailBox_Leave(object sender, EventArgs e)
        {
            //jesli opuscimy EmailBox --- bedzie napis Name
            if (EmailBox.Text.Equals(""))
            {
                EmailBox.Text = "Email";
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
