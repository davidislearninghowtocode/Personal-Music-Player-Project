using Ampli_Music_Player;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Windows.Forms;

public partial class Form1 : Form
{
    private List<string> mockSongs = new List<string>();
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
                        string title = track["name"].ToString();
                        string artist = track["artists"][0]["name"].ToString();
                        string album = track["album"]["name"].ToString();
                        string imageUrl = track["album"]["images"][0]["url"].ToString();
                        listBoxResults.Items.Add($"{title} - {artist} (Album: {album})");
                        // Lưu thông tin tạm (sau này tải hình ảnh)
                    }
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
            mockSongs.Add(filePath);
            listBoxResults.Items.Add(Path.GetFileNameWithoutExtension(filePath) + " (Uploaded)");
        }
    }

    private void listBoxResults_DoubleClick(object sender, EventArgs e)
    {
        if (listBoxResults.SelectedIndex >= 0 && mockSongs.Count > 0)
        {
            string[] songsArray = mockSongs.ToArray();
            int startIndex = listBoxResults.SelectedIndex % mockSongs.Count;
            Form2 playerForm = new Form2(songsArray, startIndex);
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