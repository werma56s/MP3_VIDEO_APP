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
            
        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection polaczenie = new MySqlConnection("server=localhost; user=root; database=user");
            MySqlCommand komenda = polaczenie.CreateCommand();
            try 
            {

                if (polaczenie.State == ConnectionState.Closed)
                {
                    polaczenie.Open();
                    komenda.CommandText = string.Format("SELECT count(id) FROM register where Email='{0}'and Haslo='{1}'", EmailBox.Text, PasswodBox.Text);
                    MessageBox.Show("Zaloowałeś sie poprawinie", "Informacja", MessageBoxButtons.OK);
                    this.Hide();
                    MainPanel NewPanel = new MainPanel();
                    NewPanel.Show();
                }

            }
            catch(Exception ex)
            {
	            string byk = string.Format("Problem z polaczniem \n{0}", ex.Message);
                MessageBox.Show(byk, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }
            finally
            {
                if(polaczenie.State == ConnectionState.Open)
                {
                    polaczenie.Close();
                }
            }

            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
