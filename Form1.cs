using Ampli_Music_Player;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Windows.Forms;

namespace Ampli_Music_Player
{
    public partial class Form1 : Form
    {
        private List<SongInfo> songs = new List<SongInfo>();
        private SpotifyService spotifyService = new SpotifyService();

        public Form1()
        {
            InitializeComponent();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(keyword) || keyword == "Enter song name...")
            {
                MessageBox.Show("Please enter a song name to search.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            listBoxResults.Items.Clear();
            songs.Clear();

            string accessToken = await spotifyService.GetAccessTokenAsync();
            if (!string.IsNullOrEmpty(accessToken))
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");
                    string url = $"https://api.spotify.com/v1/search?q={Uri.EscapeDataString(keyword)}&type=track&limit=10";
                    var response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        JObject data = JObject.Parse(json);
                        foreach (var track in data["tracks"]["items"])
                        {
                            SongInfo song = new SongInfo
                            {
                                Title = track["name"]?.ToString(),
                                Artist = track["artists"]?[0]?["name"]?.ToString(),
                                Album = track["album"]?["name"]?.ToString(),
                                PreviewUrl = track["preview_url"]?.ToString(),
                                ImageUrl = track["album"]?["images"]?[0]?["url"]?.ToString()
                            };
                            songs.Add(song);
                            listBoxResults.Items.Add($"{song.Title} - {song.Artist} ({song.Album})");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Spotify API request failed.", "Error");
                    }
                }
            }
            else
            {
                MessageBox.Show("Failed to get Spotify access token.", "Error");
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                SongInfo song = new SongInfo
                {
                    Title = Path.GetFileNameWithoutExtension(filePath),
                    Artist = "Local File",
                    FilePath = filePath,
                    Album = "Unknown Album"
                };
                songs.Add(song);
                listBoxResults.Items.Add(song.ToString() + " (Uploaded)");

                // 🚀 mở Form2 luôn sau khi upload
                int index = songs.Count - 1;
                Form2 playerForm = new Form2(songs, index);
                playerForm.Show();
            }
        }

        private void listBoxResults_DoubleClick(object sender, EventArgs e)
        {
            int index = listBoxResults.SelectedIndex;
            if (index >= 0 && index < songs.Count)
            {
                // 🚀 mở Form2 với danh sách + index
                Form2 playerForm = new Form2(songs, index);
                playerForm.Show();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtSearch.GotFocus += (s, args) =>
            {
                if (txtSearch.Text == "Enter song name...")
                    txtSearch.Text = "";
            };
            txtSearch.LostFocus += (s, args) =>
            {
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                    txtSearch.Text = "Enter song name...";
            };
        }
    }
}
