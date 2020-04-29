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
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Multiselect = true;

            WMPLib.IWMPPlaylist playlist = axWindowsMediaPlayer1.playlistCollection.newPlaylist("myplaylist");

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            { 
                    files = openFileDialog1.SafeFileNames; //file name 
                
                    path = openFileDialog1.FileNames; //all path

                

                for (int i = 0; i < files.Length; i++)
                {

                    ListVideo.Items.Add(files[i]);
                   // axWindowsMediaPlayer1.mediaCollection.add(files[i]);
                    playlist.appendItem(axWindowsMediaPlayer1.newMedia(files[i]));
                }


            }
      
            

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
