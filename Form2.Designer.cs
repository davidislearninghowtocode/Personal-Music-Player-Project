using System.Windows.Forms;

namespace Ampli_Music_Player
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.picAlbumArt = new System.Windows.Forms.PictureBox();
            this.lblSongTitle = new System.Windows.Forms.Label();
            this.lblArtist = new System.Windows.Forms.Label();
            this.trackProgress = new System.Windows.Forms.TrackBar();
            this.btnPlayPause = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.lblCurrentTime = new System.Windows.Forms.Label();
            this.lblTotalTime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.picAlbumArt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackProgress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // picAlbumArt
            // 
            this.picAlbumArt.Location = new System.Drawing.Point(20, 20);
            this.picAlbumArt.Size = new System.Drawing.Size(150, 150);
            this.picAlbumArt.SizeMode = PictureBoxSizeMode.StretchImage;
            // 
            // lblSongTitle
            // 
            this.lblSongTitle.Location = new System.Drawing.Point(180, 20);
            this.lblSongTitle.Size = new System.Drawing.Size(200, 30);
            this.lblSongTitle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblSongTitle.ForeColor = System.Drawing.Color.Black;
            // 
            // lblArtist
            // 
            this.lblArtist.Location = new System.Drawing.Point(180, 60);
            this.lblArtist.Size = new System.Drawing.Size(200, 20);
            this.lblArtist.ForeColor = System.Drawing.Color.Gray;
            // 
            // trackProgress
            // 
            this.trackProgress.Location = new System.Drawing.Point(20, 180);
            this.trackProgress.Size = new System.Drawing.Size(360, 45);
            this.trackProgress.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackProgress.Scroll += new System.EventHandler(this.trackProgress_Scroll);
            // 
            // btnPlayPause
            // 
            this.btnPlayPause.Location = new System.Drawing.Point(150, 230);
            this.btnPlayPause.Size = new System.Drawing.Size(50, 50);
            this.btnPlayPause.Text = "▶";
            this.btnPlayPause.ForeColor = System.Drawing.Color.Black;
            this.btnPlayPause.Click += new System.EventHandler(this.btnPlayPause_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(210, 230);
            this.btnNext.Size = new System.Drawing.Size(50, 50);
            this.btnNext.Text = ">>";
            this.btnNext.ForeColor = System.Drawing.Color.Black;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(90, 230);
            this.btnPrevious.Size = new System.Drawing.Size(50, 50);
            this.btnPrevious.Text = "<<";
            this.btnPrevious.ForeColor = System.Drawing.Color.Black;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // lblCurrentTime
            // 
            this.lblCurrentTime.Location = new System.Drawing.Point(20, 160);
            this.lblCurrentTime.Size = new System.Drawing.Size(50, 20);
            this.lblCurrentTime.Text = "0:00";
            this.lblCurrentTime.ForeColor = System.Drawing.Color.Black;
            // 
            // lblTotalTime
            // 
            this.lblTotalTime.Location = new System.Drawing.Point(330, 160);
            this.lblTotalTime.Size = new System.Drawing.Size(50, 20);
            this.lblTotalTime.Text = "0:00";
            this.lblTotalTime.ForeColor = System.Drawing.Color.Black;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(0, 0);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(10, 10); // Ẩn player
            this.axWindowsMediaPlayer1.TabIndex = 0;
            // 
            // Form2
            // 
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.picAlbumArt);
            this.Controls.Add(this.lblSongTitle);
            this.Controls.Add(this.lblArtist);
            this.Controls.Add(this.trackProgress);
            this.Controls.Add(this.btnPlayPause);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.lblCurrentTime);
            this.Controls.Add(this.lblTotalTime);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form2";
            this.Text = "Ampli Music Player";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picAlbumArt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackProgress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox picAlbumArt;
        private System.Windows.Forms.Label lblSongTitle;
        private System.Windows.Forms.Label lblArtist;
        private System.Windows.Forms.TrackBar trackProgress;
        private System.Windows.Forms.Button btnPlayPause;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Label lblCurrentTime;
        private System.Windows.Forms.Label lblTotalTime;
        private System.Windows.Forms.Timer timer1;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
    }
}