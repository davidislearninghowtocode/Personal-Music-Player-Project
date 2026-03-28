using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ampli_Music_Player
{
    public class SpotifyService
    {
        private readonly IConfiguration _config;

        public SpotifyService()
        {
            try
            {
                _config = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .Build();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đọc appsettings.json: {ex.Message}");
                _config = new ConfigurationBuilder().Build();
            }
        }

        public async Task<string> GetAccessTokenAsync()
        {
            string clientId = _config["Spotify:ClientId"] ?? "YOUR_CLIENT_ID";
            string clientSecret = _config["Spotify:ClientSecret"] ?? "YOUR_CLIENT_SECRET";
            if (string.IsNullOrEmpty(clientId) || string.IsNullOrEmpty(clientSecret) || clientId == "YOUR_CLIENT_ID")
            {
                MessageBox.Show("Client ID hoặc Client Secret không được cấu hình! Vui lòng cập nhật appsettings.json.");
                return null;
            }

            string auth = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}"));

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Basic {auth}");
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("grant_type", "client_credentials")
                });

                try
                {
                    HttpResponseMessage response = await client.PostAsync("https://accounts.spotify.com/api/token", content);
                    response.EnsureSuccessStatusCode();
                    string json = await response.Content.ReadAsStringAsync();
                    JObject token = JObject.Parse(json);
                    string accessToken = token["access_token"]?.ToString();
                    if (string.IsNullOrEmpty(accessToken))
                    {
                        MessageBox.Show("Không thể lấy Access Token từ phản hồi!");
                        return null;
                    }
                    return accessToken;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi lấy Access Token: {ex.Message}");
                    return null;
                }
            }
        }
    }
}