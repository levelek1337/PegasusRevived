using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Siticone.Desktop.UI.WinForms;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using Application = System.Windows.Forms.Application;

namespace PegasusV2Beta
{
    public partial class Profile : Form
    {
        private Point startPoint = new Point(0, 0);
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;
        private const int WM_NCLBUTTONDBLCLK = 0x00A3;

        private static readonly HttpClientHandler handler = new HttpClientHandler
        {
            AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
            Proxy = new WebProxy(),
            PreAuthenticate = true,
            AllowAutoRedirect = false,
            DefaultProxyCredentials = null
        };
        private static readonly HttpClient client = new HttpClient(handler);

        public Profile()
        {
            InitializeComponent();
            siticonePanel2.MouseDown += new MouseEventHandler(Panel_MouseDown);
            siticonePanel2.MouseMove += new MouseEventHandler(Panel_MouseMove);
            siticonePanel2.MouseUp += new MouseEventHandler(Panel_MouseUp);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_NCLBUTTONDBLCLK)
            {
                return;
            }

            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST && (int)m.Result == HTCLIENT)
            {
                m.Result = (IntPtr)HTCAPTION;
            }
        }

        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Panel_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private async void ProfilMisc_Load(object sender, EventArgs e)
        {
            await LoadProfile();
        }

        private async void refresh_Click(object sender, EventArgs e)
        {
            await LoadProfile();
        }

        private async Task LoadProfile()
        {
            string gamertag = "";
            string xuid = "";

            try
            {
                string directoryPath = @"C:\Pegasus Revived";
                string filePath = Path.Combine(directoryPath, "Token.JSON");

                if (File.Exists(filePath))
                {
                    var lines = File.ReadLines(filePath).ToList();
                    if (lines.Count > 0)
                    {
                        Token.Text = lines[0];
                    }
                }

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("x-xbl-contract-version", "2");
                client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate");
                client.DefaultRequestHeaders.Add("accept", "application/json");
                client.DefaultRequestHeaders.Add("accept-language", "en-US");
                client.DefaultRequestHeaders.Add("Authorization", Token.Text);
                client.DefaultRequestHeaders.Add("Host", "profile.xboxlive.com");
                client.DefaultRequestHeaders.Add("Connection", "Keep-Alive");

                var responseString = await client.GetStringAsync("https://profile.xboxlive.com/users/me/profile/settings?settings=Gamertag,Gamerscore");
                var jsonResponse = JObject.Parse(responseString);
                xuid = jsonResponse["profileUsers"]?[0]?["id"]?.ToString();

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("x-xbl-contract-version", "5");
                client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate");
                client.DefaultRequestHeaders.Add("accept", "application/json");
                client.DefaultRequestHeaders.Add("accept-language", "en-US");
                client.DefaultRequestHeaders.Add("Authorization", Token.Text);
                client.DefaultRequestHeaders.Add("Host", "peoplehub.xboxlive.com");
                client.DefaultRequestHeaders.Add("Connection", "Keep-Alive");

                responseString = await client.GetStringAsync($"https://peoplehub.xboxlive.com/users/me/people/xuids({xuid})/decoration/detail,preferredColor,presenceDetail,multiplayerSummary");
                jsonResponse = JObject.Parse(responseString);

                var pic = jsonResponse["people"]?[0]?["displayPicRaw"]?.ToString();
                string profileGamerPic = pic?.Contains("&mode=Padding") == true ? pic.Replace("&mode=Padding", "") : pic;
                gamertag = jsonResponse["people"]?[0]?["displayName"]?.ToString();
                var gamerscore = jsonResponse["people"]?[0]?["gamerScore"]?.ToString();
                string status = jsonResponse["people"]?[0]?["presenceState"]?.ToString();
                string presence = jsonResponse["people"]?[0]?["presenceText"]?.ToString();

                Gamertag.Text = gamertag ?? "Unknown";
                Gamerscore.Text = gamerscore ?? "0";
                Xuid.Text = xuid ?? "Unknown";
                LBL_Status.Text = presence ?? "Unknown";
                label9.Text = "Gamertag:";
                label10.Text = "GamerScore:";
                label8.Text = "XUID:";

                if (status == "Online" && presence == "Online")
                {
                    LBL_Status.Text = "Online";
                }
                else if (status == "Online")
                {
                    LBL_Status.Text = $"Online - {presence}";
                }
                else if (status == "Offline" && presence == "Offline")
                {
                    LBL_Status.Text = "Offline";
                }
                else if (status == "Offline")
                {
                    LBL_Status.Text = $"Offline - {presence}";
                }
                else
                {
                    LBL_Status.Text = "Status: Unknown";
                }

                if (!string.IsNullOrEmpty(profileGamerPic))
                {
                    pictureBox7.ImageLocation = profileGamerPic;
                    pictureBox7.Show();
                }
                Gamertag.Show();
                Gamerscore.Show();
                Xuid.Show();
                LBL_Status.Show();
                label8.Show();
                label9.Show();
                label10.Show();
            }
            catch (HttpRequestException ex)
            {
                if (ex.Message.Contains("The format of value") || ex.Message.Contains("401"))
                {
                    MessageBox.Show("Token Expired, Close Pegasus fully and Grab New Token.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else if (ex.Message.Contains("429"))
                {
                    MessageBox.Show("You've been rate limited by Xbox servers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task SendHttpClientRequest(string url, object requestBody)
        {
            try
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("x-xbl-contract-version", "2");
                client.DefaultRequestHeaders.Add("Authorization", Token.Text);
                client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate");
                // xbl content restrictions that pegasus uses client.DefaultRequestHeaders.Add("Signature", "example");
                client.DefaultRequestHeaders.Add("Accept-Language", "en-US");
                // signature that pegasus uses client.DefaultRequestHeaders.Add("Signature", "example");
                client.DefaultRequestHeaders.Add("Cache-Control", "no-cache");

                string jsonBody = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Changed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Error.Text = "";
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    Error.Text = "Error: XAuth is not correct.";
                    MessageBox.Show(Error.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (response.StatusCode == (HttpStatusCode)429)
                {
                    Error.Text = "Error: You've been rate limited by Xbox servers.";
                    MessageBox.Show(Error.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Error.Text = $"Error: {response.StatusCode}";
                    MessageBox.Show(Error.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (HttpRequestException ex)
            {
                if (ex.Message.Contains("401"))
                {
                    Error.Text = "Error: XAuth is not correct.";
                }
                else if (ex.Message.Contains("429"))
                {
                    Error.Text = "Error: You've been rate limited by Xbox servers.";
                }
                else
                {
                    Error.Text = $"Error: {ex.Message}";
                }
                MessageBox.Show(Error.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Error.Text = $"Error: {ex.Message}";
                MessageBox.Show(Error.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void pictureBox1_Click(object sender, EventArgs e)
        {
            var requestBody = new
            {
                userSetting = new
                {
                    id = "PublicGamerpic",
                    value = "https://dlassets-ssl.xboxlive.com/public/content/ppl/gamerpics/00035-00000-md.png"
                }
            };
            await SendHttpClientRequest("https://profile.xboxlive.com/users/me/profile/settings/PublicGamerpic", requestBody);
        }

        private async void pictureBox2_Click(object sender, EventArgs e)
        {
            var requestBody = new
            {
                userSetting = new
                {
                    id = "PublicGamerpic",
                    value = "https://dlassets-ssl.xboxlive.com/public/content/ppl/gamerpics/00035-00001-md.png"
                }
            };
            await SendHttpClientRequest("https://profile.xboxlive.com/users/me/profile/settings/PublicGamerpic", requestBody);
        }

        private async void pictureBox3_Click(object sender, EventArgs e)
        {
            var requestBody = new
            {
                userSetting = new
                {
                    id = "PublicGamerpic",
                    value = "https://dlassets-ssl.xboxlive.com/public/content/ppl/gamerpics/00033-00000-md.png"
                }
            };
            await SendHttpClientRequest("https://profile.xboxlive.com/users/me/profile/settings/PublicGamerpic", requestBody);
        }

        private async void pictureBox4_Click(object sender, EventArgs e)
        {
            var requestBody = new
            {
                userSetting = new
                {
                    id = "PublicGamerpic",
                    value = ""
                }
            };
            await SendHttpClientRequest("https://profile.xboxlive.com/users/me/profile/settings/PublicGamerpic", requestBody);
        }

        private async void siticoneButton1_Click(object sender, EventArgs e)
        {
            var requestBody = new
            {
                userSetting = new
                {
                    id = "Bio",
                    value = Bio.Text
                }
            };

            await SendHttpClientRequest("https://profile.xboxlive.com/users/me/profile/settings/Bio", requestBody);
        }

        private async void siticoneButton2_Click(object sender, EventArgs e)
        {
            var requestBody = new
            {
                userSetting = new
                {
                    id = "Location",
                    value = Bio.Text
                }
            };

            await SendHttpClientRequest("https://profile.xboxlive.com/users/me/profile/settings/Location", requestBody);
        }

        private async void Offline_Click(object sender, EventArgs e)
        {
            try
            {
                string jsonRequest = "{\"state\":\"Cloaked\"}";
                string url = $"https://userpresence.xboxlive.com/users/xuid({Xuid.Text})/state";
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("authorization", Token.Text);
                client.DefaultRequestHeaders.Add("x-xbl-contract-version", "3");
                client.DefaultRequestHeaders.Add("accept", "application/json");
                client.DefaultRequestHeaders.Add("accept-language", "en-US");
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Changed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Error.Text = "";
                }
            }
            catch (Exception ex)
            {
                Error.Text = $"Error: {ex.Message}";
                MessageBox.Show(Error.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void Online_Click(object sender, EventArgs e)
        {
            try
            {
                string jsonRequest = "{\"state\":\"Active\"}";
                string url = $"https://userpresence.xboxlive.com/users/xuid({Xuid.Text})/state";
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("authorization", Token.Text);
                client.DefaultRequestHeaders.Add("x-xbl-contract-version", "3");
                client.DefaultRequestHeaders.Add("accept", "application/json");
                client.DefaultRequestHeaders.Add("accept-language", "en-US");
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Changed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Error.Text = "";
                }
            }
            catch (Exception ex)
            {
                Error.Text = $"Error: {ex.Message}";
                MessageBox.Show(Error.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ach_Click(object sender, EventArgs e)
        {
           // spoof rarest achievements (deleted from public src)
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Check if the main window is already open
            main formMain = Application.OpenForms.OfType<main>().FirstOrDefault();

            if (formMain == null)
            {
                // If it doesn't exist, create new form
                formMain = new main();
                formMain.FormClosed += (s, args) => this.Close();
            }
            else
            {
                // If it exists, show it again
                if (formMain.WindowState == FormWindowState.Minimized)
                {
                    formMain.WindowState = FormWindowState.Normal;
                }
                formMain.Activate();
            }

            // Hide the current window
            this.Hide();

            // Show the main window
            formMain.Show();
        }

        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void siticonePanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}