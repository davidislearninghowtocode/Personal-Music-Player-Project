using System;
using System.IO;
using System.Windows.Forms;
using NAudio.Wave;
using System.Collections.Generic;

namespace Ampli_Music_Player
{
    public partial class Form2 : Form
    {
        private List<SongInfo> playlist;
        private int currentIndex;
        private bool isPlaying = false;
        private IWavePlayer waveOut;
        private MediaFoundationReader audioFile;

        public Form2(List<SongInfo> songs, int startIndex)
        {
            InitializeComponent();
            playlist = songs;
            currentIndex = startIndex;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Interval = 500; // update every 0.5s
            timer1.Start();
            PlaySong();

            this.BackColor = System.Drawing.Color.Black;
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Button || ctrl is Label || ctrl is TrackBar)
                {
                    ctrl.ForeColor = System.Drawing.Color.White;
                }
            }
        }

        private void PlaySong()
        {
            StopCurrentSong();

            if (playlist == null || playlist.Count == 0) return;

            var currentSong = playlist[currentIndex];

            // cập nhật UI
            lblSongTitle.Text = currentSong.Title ?? "Unknown Title";
            lblArtist.Text = currentSong.Artist ?? "Unknown Artist";
            lblAlbum.Text = string.IsNullOrEmpty(currentSong.Album) ? "Unknown Album" : currentSong.Album;

            if (!string.IsNullOrEmpty(currentSong.ImageUrl))
            {
                try { picAlbumArt.Load(currentSong.ImageUrl); } catch { }
            }
            else
            {
                picAlbumArt.Image = null;
            }

            string source = !string.IsNullOrEmpty(currentSong.FilePath) ? currentSong.FilePath : currentSong.PreviewUrl;

            if (string.IsNullOrEmpty(source))
            {
                btnPlayPause.Enabled = false;
                trackProgress.Enabled = false;
                lblCurrentTime.Text = "N/A";
                lblTotalTime.Text = "N/A";
                return;
            }

            try
            {
                waveOut = new WaveOutEvent();
                audioFile = new MediaFoundationReader(source);
                waveOut.Init(audioFile);

                // đăng ký sự kiện auto-next
                waveOut.PlaybackStopped += WaveOut_PlaybackStopped;

                waveOut.Play();

                btnPlayPause.Text = "⏸";
                isPlaying = true;
                trackProgress.Enabled = true;
                trackProgress.Maximum = (int)audioFile.TotalTime.TotalSeconds;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi phát nhạc: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StopCurrentSong()
        {
            try
            {
                if (waveOut != null)
                {
                    waveOut.PlaybackStopped -= WaveOut_PlaybackStopped;
                    waveOut.Stop();
                }
                audioFile?.Dispose();
                waveOut?.Dispose();
            }
            catch { }
            waveOut = null;
            audioFile = null;
        }

        private void WaveOut_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            // kiểm tra bài kết thúc tự nhiên
            if (audioFile != null && audioFile.CurrentTime >= audioFile.TotalTime)
            {
                Invoke((MethodInvoker)delegate
                {
                    btnNext.PerformClick(); // tự động chuyển bài
                });
            }
        }

        private void btnPlayPause_Click(object sender, EventArgs e)
        {
            if (waveOut == null || audioFile == null) return;

            if (!isPlaying)
            {
                waveOut.Play();
                btnPlayPause.Text = "⏸";
                isPlaying = true;
            }
            else
            {
                waveOut.Pause();
                btnPlayPause.Text = "▶";
                isPlaying = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (audioFile != null)
            {
                double current = audioFile.CurrentTime.TotalSeconds;
                double total = audioFile.TotalTime.TotalSeconds;

                if (total > 0)
                {
                    trackProgress.Maximum = (int)total;
                    trackProgress.Value = Math.Min((int)current, trackProgress.Maximum);
                }

                lblCurrentTime.Text = TimeSpan.FromSeconds((int)current).ToString(@"m\:ss");
                lblTotalTime.Text = TimeSpan.FromSeconds((int)total).ToString(@"m\:ss");
            }
        }

        private void trackProgress_Scroll(object sender, EventArgs e)
        {
            if (audioFile != null)
            {
                audioFile.CurrentTime = TimeSpan.FromSeconds(trackProgress.Value);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (playlist == null || playlist.Count == 0) return;

            currentIndex++;
            if (currentIndex >= playlist.Count)
                currentIndex = 0; // quay về đầu danh sách

            PlaySong();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (playlist == null || playlist.Count == 0) return;

            currentIndex--;
            if (currentIndex < 0)
                currentIndex = playlist.Count - 1; // quay về cuối danh sách

            PlaySong();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            StopCurrentSong();
            base.OnFormClosing(e);
        }
    }
}
