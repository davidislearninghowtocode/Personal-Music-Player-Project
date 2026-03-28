using System.Windows.Forms;
using System.Drawing;

namespace Ampli_Music_Player
{
    partial class Form2
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.picAlbumArt = new System.Windows.Forms.PictureBox();
            this.lblSongTitle = new System.Windows.Forms.Label();
            this.lblArtist = new System.Windows.Forms.Label();
            this.lblAlbum = new System.Windows.Forms.Label();
            this.trackProgress = new System.Windows.Forms.TrackBar();
            this.btnPlayPause = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.lblCurrentTime = new System.Windows.Forms.Label();
            this.lblTotalTime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picAlbumArt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackProgress)).BeginInit();
            this.SuspendLayout();
            // 
            // picAlbumArt
            // 
            this.picAlbumArt.Location = new System.Drawing.Point(20, 20);
            this.picAlbumArt.Name = "picAlbumArt";
            this.picAlbumArt.Size = new System.Drawing.Size(150, 150);
            this.picAlbumArt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAlbumArt.TabIndex = 0;
            this.picAlbumArt.TabStop = false;
            // 
            // lblSongTitle
            // 
            this.lblSongTitle.Location = new System.Drawing.Point(180, 20);
            this.lblSongTitle.Name = "lblSongTitle";
            this.lblSongTitle.Size = new System.Drawing.Size(200, 30);
            this.lblSongTitle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblSongTitle.ForeColor = System.Drawing.Color.White;
            this.lblSongTitle.TabIndex = 1;
            // 
            // lblArtist
            // 
            this.lblArtist.Location = new System.Drawing.Point(180, 55);
            this.lblArtist.Name = "lblArtist";
            this.lblArtist.Size = new System.Drawing.Size(200, 20);
            this.lblArtist.ForeColor = System.Drawing.Color.Silver;
            this.lblArtist.TabIndex = 2;
            // 
            // lblAlbum
            // 
            this.lblAlbum.Location = new System.Drawing.Point(180, 80);
            this.lblAlbum.Name = "lblAlbum";
            this.lblAlbum.Size = new System.Drawing.Size(200, 20);
            this.lblAlbum.ForeColor = System.Drawing.Color.Gray;
            this.lblAlbum.TabIndex = 10;
            // 
            // trackProgress
            // 
            this.trackProgress.Location = new System.Drawing.Point(20, 180);
            this.trackProgress.Name = "trackProgress";
            this.trackProgress.Size = new System.Drawing.Size(360, 45);
            this.trackProgress.TabIndex = 3;
            this.trackProgress.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackProgress.Scroll += new System.EventHandler(this.trackProgress_Scroll);
            // 
            // btnPlayPause
            // 
            this.btnPlayPause.Location = new System.Drawing.Point(170, 230);
            this.btnPlayPause.Name = "btnPlayPause";
            this.btnPlayPause.Size = new System.Drawing.Size(60, 60);
            this.btnPlayPause.TabIndex = 4;
            this.btnPlayPause.Text = "▶";
            this.btnPlayPause.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.btnPlayPause.UseVisualStyleBackColor = false;
            this.btnPlayPause.BackColor = Color.FromArgb(29, 185, 84); // Spotify green
            this.btnPlayPause.ForeColor = Color.White;
            this.btnPlayPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayPause.FlatAppearance.BorderSize = 0;
            this.btnPlayPause.Click += new System.EventHandler(this.btnPlayPause_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(240, 240);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(60, 50);
            this.btnNext.TabIndex = 5;
            this.btnNext.Text = ">>";
            this.btnNext.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.BackColor = Color.Black;
            this.btnNext.ForeColor = Color.White;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(100, 240);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(60, 50);
            this.btnPrevious.TabIndex = 6;
            this.btnPrevious.Text = "<<";
            this.btnPrevious.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.btnPrevious.UseVisualStyleBackColor = false;
            this.btnPrevious.BackColor = Color.Black;
            this.btnPrevious.ForeColor = Color.White;
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevious.FlatAppearance.BorderSize = 0;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // lblCurrentTime
            // 
            this.lblCurrentTime.Location = new System.Drawing.Point(20, 160);
            this.lblCurrentTime.Name = "lblCurrentTime";
            this.lblCurrentTime.Size = new System.Drawing.Size(50, 20);
            this.lblCurrentTime.TabIndex = 7;
            this.lblCurrentTime.Text = "0:00";
            this.lblCurrentTime.ForeColor = System.Drawing.Color.White;
            // 
            // lblTotalTime
            // 
            this.lblTotalTime.Location = new System.Drawing.Point(330, 160);
            this.lblTotalTime.Name = "lblTotalTime";
            this.lblTotalTime.Size = new System.Drawing.Size(50, 20);
            this.lblTotalTime.TabIndex = 8;
            this.lblTotalTime.Text = "0:00";
            this.lblTotalTime.ForeColor = System.Drawing.Color.White;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form2
            // 
            this.ClientSize = new System.Drawing.Size(400, 320);
            this.Controls.Add(this.picAlbumArt);
            this.Controls.Add(this.lblSongTitle);
            this.Controls.Add(this.lblArtist);
            this.Controls.Add(this.lblAlbum);
            this.Controls.Add(this.trackProgress);
            this.Controls.Add(this.btnPlayPause);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.lblCurrentTime);
            this.Controls.Add(this.lblTotalTime);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form2";
            this.Text = "Ampli Music Player";
            this.BackColor = Color.FromArgb(18, 18, 18); // Spotify dark background
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picAlbumArt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackProgress)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox picAlbumArt;
        private System.Windows.Forms.Label lblSongTitle;
        private System.Windows.Forms.Label lblArtist;
        private System.Windows.Forms.Label lblAlbum;
        private System.Windows.Forms.TrackBar trackProgress;
        private System.Windows.Forms.Button btnPlayPause;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Label lblCurrentTime;
        private System.Windows.Forms.Label lblTotalTime;
        private System.Windows.Forms.Timer timer1;
    }
}
