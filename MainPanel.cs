using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerMP3AndVideo
{
    public partial class MainPanel : Form
    {
        public MainPanel()
        {
            InitializeComponent();
           SidePanel.Height = button1.Height;
           SidePanel.Top = button1.Top;
            musicPage1.BringToFront();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           SidePanel.Height = button1.Height;
           SidePanel.Top = button1.Top;
            musicPage1.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button2.Height;
            SidePanel.Top = button2.Top;
            videoPage1.BringToFront();
        }

       
    }
}
