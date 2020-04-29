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
using System.Data.SqlTypes;
using System.Data.SqlClient;


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
            MySqlConnection polaczenie = new MySqlConnection("server=localhost; user=root; database=user");
           
            MySqlDataAdapter komenda = new MySqlDataAdapter("SELECT count(*) FROM user1 where Email='"+ EmailBox.Text + "'and Password='"+ PasswodBox.Text + "'",polaczenie);
            DataTable dt = new DataTable();
            komenda.Fill(dt);
            if(dt.Rows[0][0].ToString() == "1")
            {
                MessageBox.Show("Login Succes", "Congrates", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
                MainPanel NewPanel = new MainPanel();
                NewPanel.Show();
            }
            else
            {
                MessageBox.Show("Either your email or password is incorrect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Polacznie();
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
