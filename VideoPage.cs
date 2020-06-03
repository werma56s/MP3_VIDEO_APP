using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PlayerMP3AndVideo
{
    public partial class VideoPage : UserControl
    {
        public VideoPage()
        {
            InitializeComponent();
            WindowsMediaPlayer1.Ctlcontrols.next();
            WindowsMediaPlayer1.Ctlcontrols.pause();
            WindowsMediaPlayer1.Ctlcontrols.fastForward();
            WindowsMediaPlayer1.Ctlcontrols.fastReverse();
            WindowsMediaPlayer1.Ctlcontrols.stop();
        }

        /// <summary>
        /// Głowna funkcja odtwarzajaca film w aplikacji..
        /// </summary>
        /// <returns>
        /// Funkcja Video() otwiera standardowe okno dialogowe, które informuje, aby użytkownik wybrał interesujący go plik.
        /// Tworzy playlistę plików filmowych.
        /// </returns>
        void Video()
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Multiselect = true, ValidateNames = true, Filter = "WMV|*.wmv|WAV|*.wav|MP3|*.mp3|MP4|*.mp4|MKV|*.mkv" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    //Add file to play list
                    List<WindowsMediaPlayer> files = new List<WindowsMediaPlayer>();
                    foreach (string fileName in ofd.FileNames)
                    {
                        FileInfo fi = new FileInfo(fileName);
                        files.Add(new WindowsMediaPlayer() { FileName = Path.GetFileNameWithoutExtension(fi.FullName), Path = fi.FullName });
                    }
                    ListVideo.DataSource = files;
                }
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            Video();      
        }
        private void ListVideo_SelectedIndexChanged_1(object sender, EventArgs e)
          {
              //Open media file
              WindowsMediaPlayer file = ListVideo.SelectedItem as WindowsMediaPlayer;
              if (file != null)
              {
                  WindowsMediaPlayer1.URL = file.Path;
                  WindowsMediaPlayer1.Ctlcontrols.play();
              }
         }
        private void panel3_Paint(object sender, PaintEventArgs e)
        { 
            ListVideo.ValueMember = "Path";
            ListVideo.DisplayMember = "FileName";
            
        }

        private void WindowsMediaPlayer1_DoubleClickEvent(object sender, AxWMPLib._WMPOCXEvents_DoubleClickEvent e)
        {
           if(WindowsMediaPlayer1.fullScreen == true)
           {
               WindowsMediaPlayer1.fullScreen = false;
           }else
           {
               WindowsMediaPlayer1.fullScreen = true;
           }
        }
    }
}
