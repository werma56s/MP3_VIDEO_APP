using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Zdjęcie autorstwa Vova Krasilnikov z Pexels

namespace PlayerMP3AndVideo
{
    public partial class MusicPage : UserControl
    {
        
        public MusicPage()
        {
            InitializeComponent();

        }
        string[] files, path; 
        void music()
        {
            //nowa playlista w windows media player
            var myPlayList = axWindowsMediaPlayer1.playlistCollection.newPlaylist("MyPlayList");
            //nowy OpenFileDialog
            OpenFileDialog open = new OpenFileDialog();
            //mozliwosc wyboru kilku na raz
            open.Multiselect = true;
            //filtr rozszerzen
            open.Filter = "All Files|*.*";

            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                files = open.SafeFileNames; //nazwa pliku

                path = open.FileNames; //cala sciezka
                //nazwy w ListVitefo
                for (int i = 0; i < files.Length; i++)
                {
                    ListMusic.Items.Add(files[i]);
                }
                //dodowanie piosenek do playlisty w windows media player
                foreach (string file in open.FileNames)
                {
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
            //zatrzymaj muzyke
            axWindowsMediaPlayer1.Ctlcontrols.pause();
        }

        private void ListVideo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (ListMusic.SelectedIndex < path.Length)
            {
                axWindowsMediaPlayer1.URL = path[ListMusic.SelectedIndex];
            }
            else
            {
                MessageBox.Show("Clean and Add new songs.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
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

        private void CleanButton_Click(object sender, EventArgs e)
        {
            //czyszczenie tablicy z wykazem piosenek i ListyViedo
            Array.Clear(path,0,path.Length);
            ListMusic.Items.Clear();
        }

        private void MusicPage_Load(object sender, EventArgs e)
        {
            trackBar1.Maximum = 100;
            trackBar1.Minimum = 0;
            //poczatkowa wartosc gloscnosci
            axWindowsMediaPlayer1.settings.volume = 0;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            //uzaleznienie tackBara od glosnosci w windows media player
            axWindowsMediaPlayer1.settings.volume = trackBar1.Value;
        }

    }
}
