namespace PlayerMP3AndVideo
{
    partial class VideoPage
    {
        /// <summary> 
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod wygenerowany przez Projektanta składników

        /// <summary> 
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować 
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VideoPage));
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.WindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.ListVideo = new System.Windows.Forms.ListBox();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.WindowsMediaPlayer1);
            this.panel3.Controls.Add(this.ListVideo);
            this.panel3.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(592, 512);
            this.panel3.TabIndex = 7;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(150)))), ((int)(((byte)(5)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Tw Cen MT", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(208, 450);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(172, 48);
            this.button1.TabIndex = 5;
            this.button1.Text = "&Open";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // WindowsMediaPlayer1
            // 
            this.WindowsMediaPlayer1.Enabled = true;
            this.WindowsMediaPlayer1.Location = new System.Drawing.Point(14, 14);
            this.WindowsMediaPlayer1.Name = "WindowsMediaPlayer1";
            this.WindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("WindowsMediaPlayer1.OcxState")));
            this.WindowsMediaPlayer1.Size = new System.Drawing.Size(564, 385);
            this.WindowsMediaPlayer1.TabIndex = 4;
            this.WindowsMediaPlayer1.DoubleClickEvent += new AxWMPLib._WMPOCXEvents_DoubleClickEventHandler(this.WindowsMediaPlayer1_DoubleClickEvent);
            // 
            // ListVideo
            // 
            this.ListVideo.BackColor = System.Drawing.SystemColors.Desktop;
            this.ListVideo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListVideo.Font = new System.Drawing.Font("Tw Cen MT", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ListVideo.ForeColor = System.Drawing.Color.White;
            this.ListVideo.FormattingEnabled = true;
            this.ListVideo.ItemHeight = 28;
            this.ListVideo.Location = new System.Drawing.Point(89, 414);
            this.ListVideo.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.ListVideo.Name = "ListVideo";
            this.ListVideo.Size = new System.Drawing.Size(415, 28);
            this.ListVideo.TabIndex = 3;
            this.ListVideo.SelectedIndexChanged += new System.EventHandler(this.ListVideo_SelectedIndexChanged_1);
            // 
            // VideoPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Name = "VideoPage";
            this.Size = new System.Drawing.Size(592, 512);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.WindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button1;
        private AxWMPLib.AxWindowsMediaPlayer WindowsMediaPlayer1;
        private System.Windows.Forms.ListBox ListVideo;
    }
}
