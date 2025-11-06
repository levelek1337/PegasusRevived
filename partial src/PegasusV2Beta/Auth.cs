using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SteveMem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PegasusV2Beta
{
    public partial class Auth : Form
    {
        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;
        private const int WM_NCLBUTTONDBLCLK = 0x00A3;
        private const string TOKEN_FILE_PATH = @"C:\Pegasus Revived\Token.JSON";
        private const int SYNC_INCREMENT = 12004;

        private static readonly HttpClientHandler handler = new HttpClientHandler
        {
            AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
            Proxy = new WebProxy(),
            PreAuthenticate = true,
            AllowAutoRedirect = false,
            DefaultProxyCredentials = null
        };
        private static readonly HttpClient client = new HttpClient(handler);

        public SteveMem.Mem m = new SteveMem.Mem();
        bool attached = false;
        private bool isBackgroundWorkerCancelled = false;

        public Auth()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            backgroundWorker1.WorkerSupportsCancellation = true;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_NCLBUTTONDBLCLK)
            {
                return; // prevent double click full screen
            }

            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST && (int)m.Result == HTCLIENT)
            {
                m.Result = (IntPtr)HTCAPTION; // whole window as bar to drag
            }
        }

        private async void grabXauthButton_Click(object sender, EventArgs e)
        {
            if (m.OpenProcess("XboxPcAppFT"))
            {
                long XauthStartAddress = (await (m.AoBScan("41 75 74 68 6F 72 69 7A 61 74 69 6F 6E 3A 20 58 42 4C 33 2E 30 20 78 3D", true, true))).FirstOrDefault();
                string XauthStartAddressHex = (XauthStartAddress + 15).ToString("X");
                IEnumerable<long> XauthEndScanList = await m.AoBScan("0D 0A 43 6F 6E 74 65 6E 74 2D 4C 65 6E 67 74 68 3A 20", true, true);
                long XauthEndAddress = 0;
                long XauthLength = 0;

                foreach (var endaddr in XauthEndScanList.ToArray())
                {
                    if (endaddr > XauthStartAddress)
                    {
                        XauthEndAddress = endaddr;
                        XauthLength = (XauthEndAddress - XauthStartAddress - 15);
                        break;
                    }
                }

                try
                {
                    string xauthtoken = Encoding.ASCII.GetString(m.ReadBytes(XauthStartAddressHex, XauthLength));
                    Token.Text = "";
                    Token.Text = xauthtoken;
                    GrabToken.ForeColor = Color.LimeGreen;
                    GrabToken.Text = "Token Grabbed!";
					await Task.Delay(3000);
					GrabToken.ForeColor = Color.White;
                    GrabToken.Text = "Grab My Token";
					
                }
                catch (Exception ex)
                {
                    int one = 0;
                    if (ex.Message.Contains("Array dimensions exceeded supported range.") && one == 0)
                    {
                        GrabToken.ForeColor = Color.Red;
                        GrabToken.Text = "Error!";
                        await Task.Delay(1500);
                        GrabToken.ForeColor = Color.White;
                        GrabToken.Text = "Grab My Token";
                        MessageBox.Show("Can't find any xbox profile's signed in. Has the app loaded fully?", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        one += 1;
                        return;
                    }
                    else if (ex.Message.Contains("Array cannot be null"))
                    {
                        MessageBox.Show("No Token Found", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (ex.Message.Contains("Value cannot be null"))
                    {
                        MessageBox.Show("Token is null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    GrabToken.ForeColor = Color.Red;
                    GrabToken.Text = "Error!";
                    await Task.Delay(1500);
                    GrabToken.ForeColor = Color.White;
                    GrabToken.Text = "Grab My Token";
                    return;
                }
            }
            else
            {
                MessageBox.Show("Xbox App is not running or not detected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GrabToken.ForeColor = Color.Red;
                GrabToken.Text = "Error!";
                await Task.Delay(1500);
                GrabToken.ForeColor = Color.White;
                GrabToken.Text = "Grab My Token";
            }
        }

        private async void siticoneButton5_Click(object sender, EventArgs e)
        {
            Connect.Visible = false;
            label7.Text = "Loading...";
            label7.Visible = true;
            Token.Visible = false;

            try
            {
                if (string.IsNullOrWhiteSpace(Token.Text))
                {
                    throw new Exception("Token is empty or invalid.");
                }

                // check if sync exist
                int existingSync = GetExistingSync();
                bool skipSync = existingSync > 0;

                // Zapisz token
                SaveToken(Token.Text, existingSync);

                // Pobierz profil użytkownika
                var profileData = await GetUserProfile(Token.Text);
                Xuid.Text = profileData.xuid;
                Gamertag.Text = profileData.gamertag;

                int finalSync = existingSync;

                // if there is no sync do stats shit
                if (!skipSync)
                {
                    finalSync = await SyncAchievementStats(Token.Text, Xuid.Text, SYNC_INCREMENT);
                    SaveSync(finalSync);
                }

                // go to main window
                label7.Text = "Connected to Pegasus";
                await Task.Delay(2000);
                label7.Visible = false;

                isBackgroundWorkerCancelled = true;
                backgroundWorker1.CancelAsync(); // cancel scanning for xbox process
                main formMain = new main();
                formMain.Show();
                formMain.Closed += (o, y) => Application.Exit();
                this.Hide();
            }
            catch (Exception ex)
            {
                label7.Text = "Failed to Connect :(";
                await Task.Delay(2000);
                label7.Visible = false;
                Token.Visible = true;
                Connect.Visible = true;

                if (ex.Message.Contains("The format of value") || ex.Message.Contains("401"))
                {
                    MessageBox.Show("Token Expired or is invalid, Grab New Token.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private int GetExistingSync()
        {
            if (File.Exists(TOKEN_FILE_PATH))
            {
                var lines = File.ReadAllLines(TOKEN_FILE_PATH).ToList();
                if (lines.Count >= 2 && !string.IsNullOrWhiteSpace(lines[1]))
                {
                    int sync;
                    if (int.TryParse(lines[1], out sync) && sync > 0)
                    {
                        return sync;
                    }
                }
            }
            return 0;
        }

        private void SaveToken(string token, int existingSync)
        {
            string directoryPath = Path.GetDirectoryName(TOKEN_FILE_PATH);

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            string syncValue = existingSync > 0 ? existingSync.ToString() : "0";
            File.WriteAllLines(TOKEN_FILE_PATH, new[] { token, syncValue });
        }

        private void SaveSync(int sync)
        {
            if (File.Exists(TOKEN_FILE_PATH))
            {
                var lines = File.ReadAllLines(TOKEN_FILE_PATH).ToList();
                if (lines.Count >= 2)
                {
                    lines[1] = sync.ToString();
                }
                else
                {
                    lines.Add(sync.ToString());
                }
                File.WriteAllLines(TOKEN_FILE_PATH, lines);
            }
        }

        private async Task<(string xuid, string gamertag)> GetUserProfile(string token)
        {
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("x-xbl-contract-version", "2");
            client.DefaultRequestHeaders.Add("Accept-Language", "en-AU");
            client.DefaultRequestHeaders.Add("Authorization", token);

            var response = await client.GetAsync("https://profile.xboxlive.com/users/me/profile/settings?settings=Gamertag,Gamerscore");
            response.EnsureSuccessStatusCode();

            string jsonResponse = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<JObject>(jsonResponse);

            if (responseObject["profileUsers"] == null || responseObject["profileUsers"].Count() == 0)
            {
                throw new Exception("No profile data received.");
            }

            var hostId = responseObject["profileUsers"][0]["hostId"].ToString();
            var settings = responseObject["profileUsers"][0]["settings"];

            string gamertag = "";
            foreach (var setting in settings)
            {
                if (setting["id"].ToString() == "Gamertag")
                {
                    gamertag = setting["value"].ToString();
                    break;
                }
            }

            return (hostId, gamertag);
        }

        private async Task<string> GetStats(string token, string xuid)
        {
            string jsonRequest = "{\"arrangebyfield\":\"xuid\",\"xuids\":[\"" + xuid + "\"],\"groups\":[{\"name\":\"Hero\",\"titleId\":\"1790482525\"}]}";

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("x-xbl-contract-version", "2");
            client.DefaultRequestHeaders.Add("Accept-Language", "en-US");
            client.DefaultRequestHeaders.Add("Authorization", token);
            client.DefaultRequestHeaders.Add("Cache-Control", "no-cache");

            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://userstats.xboxlive.com/batch", content);
            response.EnsureSuccessStatusCode();

            string jsonResponse = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<JObject>(jsonResponse);

            var groups = responseObject["groups"] as JArray;
            if (groups != null && groups.Count > 0)
            {
                var statlistscollection = groups[0]["statlistscollection"] as JArray;
                if (statlistscollection != null && statlistscollection.Count > 0)
                {
                    var stats = statlistscollection[0]["stats"] as JArray;
                    if (stats != null)
                    {
                        var achievement = stats.FirstOrDefault(s => s["name"].ToString() == "ACHIEVEMENTS-UNLOCKED-MP");
                        if (achievement != null)
                        {
                            return achievement["value"]?.ToString() ?? "0";
                        }
                    }
                }
            }

            throw new Exception("Stat status not found in response.");
        }

        private async Task UpdateStat(string token, string xuid, int sync, string achievementValue)
        {
            string jsonPayload = "{\"$schema\":\"http://stats.xboxlive.com/2017-1/schema#\",\"previousRevision\":55,\"revision\":" + sync + ",\"stats\":{\"title\":{\"ACHIEVEMENTS-UNLOCKED-MP\":{\"value\":\"" + achievementValue + "\"},\"ACHIEVEMENTS-UNLOCKED-CP\":{\"value\":\"0\"},\"ACHIEVEMENTS-UNLOCKED-ZM\":{\"value\":\"0\"}}},\"timestamp\":\"2024-06-01T13:33:20.501081Z\"}";

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("x-xbl-contract-version", "2");
            client.DefaultRequestHeaders.Add("Accept-Language", "en-US");
            client.DefaultRequestHeaders.Add("Authorization", token);
            client.DefaultRequestHeaders.Add("Cache-Control", "no-cache");

            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://statswrite.xboxlive.com/stats/users/" + xuid + "/scids/00000000-0000-0000-0000-00006ab8985d", content);
            response.EnsureSuccessStatusCode();
        }

        private async Task<int> SyncAchievementStats(string token, string xuid, int sync)
        {
            const int MAX_ITERATIONS = 10;
            int iterations = 0;

            while (iterations < MAX_ITERATIONS)
            {
                iterations++;

                string achievementStatus = await GetStats(token, xuid);

                if (achievementStatus == "-1")
                {
                    // Już zsynchronizowane
                    return sync;
                }
                else if (achievementStatus == "-2")
                {
                    // Ustaw na 0 i zakończ
                    await UpdateStat(token, xuid, sync, "0");
                    return sync;
                }
                else
                {
                    // Ustaw na -2 i zwiększ sync
                    await UpdateStat(token, xuid, sync, "-2");
                    sync += SYNC_INCREMENT;

                    // Poczekaj przed następną iteracją
                    await Task.Delay(1000);
                }
            }

            throw new Exception("Max iterations reached during sync.");
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (attached)
            {
                LBL_Attached.Text = "Attached to Xbox App! 😄";
                LBL_Attached.ForeColor = Color.LimeGreen;
            }
            else
            {
                LBL_Attached.Text = "Not attached to Xbox App";
                LBL_Attached.ForeColor = Color.Red;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (backgroundWorker1.CancellationPending)
            {
                e.Cancel = true; // Oznacz jako anulowane
                return;
            }

            if (m.OpenProcess("XboxPcAppFT"))
            {
                attached = true;
            }
            else
            {
                attached = false;
            }
            backgroundWorker1.ReportProgress(0);
            Thread.Sleep(5000);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Uruchamiaj ponownie tylko, jeśli nie anulowano
            if (!isBackgroundWorkerCancelled && !e.Cancelled)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void Auth_Load(object sender, EventArgs e)
        {
            if (File.Exists(TOKEN_FILE_PATH))
            {
                var lines = File.ReadAllLines(TOKEN_FILE_PATH).ToList();
                if (lines.Count >= 1)
                {
                    Token.Text = lines[0];
                }
            }

            Token.Visible = true;
            backgroundWorker1.RunWorkerAsync();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}