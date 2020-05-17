using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices; //for ddl
using System.IO;
using WMPLib;
//Zdjęcie autorstwa Vova Krasilnikov z Pexels

namespace PlayerMP3AndVideo
{
    public partial class MusicPage : UserControl
    {
        
        public MusicPage()
        {
            InitializeComponent();
            trackBar1.Maximum = 100;
            trackBar1.Minimum = 0;
        }
        string[] files, path; 
        void music()
        {
            var myPlayList = axWindowsMediaPlayer1.playlistCollection.newPlaylist("MyPlayList");
            OpenFileDialog open = new OpenFileDialog();
            open.Multiselect = true;
            open.Filter = "All Files|*.*";

            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                files = open.SafeFileNames; //nazwa pliku

                path = open.FileNames; //cala sciezka

                foreach (string file in open.FileNames)
                {
                    ListVideo.Items.Add(file);
                    var mediaItem = axWindowsMediaPlayer1.newMedia(file);
                    myPlayList.appendItem(mediaItem);
                }
            }

            axWindowsMediaPlayer1.currentPlaylist = myPlayList;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            music();
        }
        
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
        }

        private void ListVideo_SelectedIndexChanged(object sender, EventArgs e)
        {
          axWindowsMediaPlayer1.URL = path[ListVideo.SelectedIndex]; 
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.next();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.previous();  
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.volume = trackBar1.Value;
        }

    }
}
