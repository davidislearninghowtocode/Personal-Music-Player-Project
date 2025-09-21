using System;
using System.IO;
using System.Windows.Forms;

namespace Ampli_Music_Player
{
    public partial class Form2 : Form
    {
        private string[] playlist;
        private int currentIndex = 0;
        private bool isPlaying = false;

        public Form2()
        {
            InitializeComponent();
        }

        public Form2(string[] songs, int startIndex = 0)
        {
            InitializeComponent();
            playlist = songs;
            currentIndex = startIndex;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000; // Cập nhật mỗi giây
            timer1.Start();
            if (playlist != null && playlist.Length > 0)
            {
                PlaySong();
            }
            this.BackColor = System.Drawing.Color.White;
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Button || ctrl is Label || ctrl is TrackBar)
                {
                    ctrl.ForeColor = System.Drawing.Color.Black;
                }
            }
        }

        private void PlaySong()
        {
            if (playlist == null || playlist.Length == 0 || currentIndex >= playlist.Length) return;

            string songPath = playlist[currentIndex];
            if (!File.Exists(songPath))
            {
                MessageBox.Show($"File nhạc không tồn tại: {songPath}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                axWindowsMediaPlayer1.URL = songPath;
                axWindowsMediaPlayer1.Ctlcontrols.play();
                lblSongTitle.Text = Path.GetFileNameWithoutExtension(songPath);
                lblArtist.Text = "Unknown Artist";
                btnPlayPause.Text = "⏸";
                isPlaying = true;
                trackProgress.Maximum = 100; // Cập nhật sau
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi phát nhạc: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPlayPause_Click(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1.currentMedia == null) return;

            if (!isPlaying)
            {
                axWindowsMediaPlayer1.Ctlcontrols.play();
                btnPlayPause.Text = "⏸";
                isPlaying = true;
            }
            else
            {
                axWindowsMediaPlayer1.Ctlcontrols.pause();
                btnPlayPause.Text = "▶";
                isPlaying = false;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (playlist == null || playlist.Length == 0) return;

            currentIndex = (currentIndex + 1) % playlist.Length;
            PlaySong();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (playlist == null || playlist.Length == 0) return;

            currentIndex = (currentIndex - 1 + playlist.Length) % playlist.Length;
            PlaySong();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1.currentMedia != null)
            {
                double current = axWindowsMediaPlayer1.Ctlcontrols.currentPosition;
                double total = axWindowsMediaPlayer1.currentMedia.duration;

                if (total > 0)
                {
                    trackProgress.Maximum = (int)total;
                    trackProgress.Value = (int)current;
                }

                lblCurrentTime.Text = TimeSpan.FromSeconds((int)current).ToString(@"m\:ss");
                lblTotalTime.Text = TimeSpan.FromSeconds((int)total).ToString(@"m\:ss");
            }
        }

        private void trackProgress_Scroll(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1.currentMedia != null)
            {
                axWindowsMediaPlayer1.Ctlcontrols.currentPosition = trackProgress.Value;
            }
        }
    }
}