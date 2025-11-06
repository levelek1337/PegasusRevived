using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Siticone.Desktop.UI.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PegasusV2Beta
{
    public partial class Achievements : Form
    {
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        private System.Windows.Forms.ToolTip toolTip;
        private int typingDelay = 2000;
        private DateTime lastTypingTime;
        private string selectedXuid = "";
        private string selectedTime = "";
        private string currentAchievementId = "";
        private const int WM_NCLBUTTONDBLCLK = 0x00A3; // Message for double-click
        private const int WM_NCHITTEST = 0x0084;      // Message for hit test
        private const int HTCLIENT = 0x1;             // Client area
        private const int HTCAPTION = 0x2;            // Caption (title bar)

        private static readonly HttpClientHandler handler = new HttpClientHandler
        {
            AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
            Proxy = new WebProxy(),
            PreAuthenticate = true,
            AllowAutoRedirect = false,
            DefaultProxyCredentials = null
        };
        private static readonly HttpClient client = new HttpClient(handler);
        private System.Windows.Forms.Timer spoofTimer;
        private bool isSpoofing;

        public Achievements()
        {
            InitializeComponent();
            InitializeSelectButtonHandlers();
            toolTip = new System.Windows.Forms.ToolTip();
            Panel.MouseDown += new MouseEventHandler(Panel_MouseDown);
            Panel.MouseMove += new MouseEventHandler(Panel_MouseMove);
            Panel.MouseUp += new MouseEventHandler(Panel_MouseUp);

            // timer
            spoofTimer = new System.Windows.Forms.Timer();
            spoofTimer.Interval = 5 * 60 * 1000; // 5 minutes
            spoofTimer.Tick += new EventHandler(SpoofTimer_Tick);

            SpoofSwitch.CheckedChanged += new EventHandler(SpoofSwitch_CheckedChanged);

            if (SpoofTitleIdTextBox != null)
            {
                SpoofTitleIdTextBox.Enabled = true;
            }

            LoadTitleID.MouseEnter += LoadTitleID_MouseEnter;
            LoadTitleID.MouseLeave += LoadTitleID_MouseLeave;
            toolTip.SetToolTip(LoadTitleID, "Load game by ID");

            StatsList.Visible = false;
            AchievementList.Visible = false;
            AchievementsGrid.CellFormatting += new DataGridViewCellFormattingEventHandler(AchievementsGrid_CellFormatting);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_NCLBUTTONDBLCLK)
            {
                return; // Prevent double-click full screen
            }

            if (m.Msg == WM_NCHITTEST)
            {
                base.WndProc(ref m);
                if ((int)m.Result == HTCLIENT)
                {
                    m.Result = (IntPtr)HTCAPTION; // Whole window as bar to drag
                }
                return;
            }
            base.WndProc(ref m);
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
       
        private async Task LoadProfile()
        {
            string gamertag = "";
            string xuid = "";

            try
            {
                // Define the directory and file path
                string directoryPath = @"C:\Pegasus Revived";
                string filePath = Path.Combine(directoryPath, "Token.JSON");

                // Read the first line of the file and use it for Token.Text
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
                xuid = jsonResponse["profileUsers"]?[0]?["hostId"]?.ToString();

                //online status and profile picture
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

                // Load profile picture
                if (!string.IsNullOrEmpty(profileGamerPic))
                {
                    pfp.ImageLocation = profileGamerPic;
                    pfp.Show();
                }
                Gamertag.Show();
                Gamerscore.Show();
                Xuid.Show();
                label8.Show();
                label9.Show();
                label10.Show();
                LBL_Status.Show();
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

        private void LoadTitleID_MouseEnter(object sender, EventArgs e)
        {
            toolTip.Show("Load game by ID", LoadTitleID);
        }

        private void LoadTitleID_MouseLeave(object sender, EventArgs e)
        {
            toolTip.Hide(LoadTitleID);
        }

        private async void LoadTitleID_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SpoofTitleIdTextBox.Text))
            {
                MessageBox.Show("Please enter a valid Title ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // if not only digits - error
            if (!SpoofTitleIdTextBox.Text.All(char.IsDigit))
            {
                MessageBox.Show("Title ID must contain only numbers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                TitleId.Text = SpoofTitleIdTextBox.Text; 
                XUIDPanel.Visible = false;
                TimePanel.Visible = false;
                SpoofPanel.Visible = false;
                StatsList.Visible = true;
                AchievementList.Visible = true;
                CopyTitleId.Visible = true;
                UnlockAll.Visible = false;
                SetStats.Visible = false;
                StatsGrid.Visible = false;
                G1.Visible = false;
                G2.Visible = false;
                G3.Visible = false;
                G4.Visible = false;
                G5.Visible = false;

                await LoadAchievements();

            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Title ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void SpoofSwitch_CheckedChanged(object sender, EventArgs e)
        {
            if (SpoofSwitch.Checked && SpoofTitleIdTextBox != null && !string.IsNullOrEmpty(SpoofTitleIdTextBox.Text))
            {
                isSpoofing = true;
                SpoofTitleIdTextBox.Enabled = false;
                await SendSpoofRequest(SpoofTitleIdTextBox.Text);
                spoofTimer.Start();
            }
            else
            {
                isSpoofing = false;
                if (SpoofTitleIdTextBox != null)
                {
                    SpoofTitleIdTextBox.Enabled = true;
                }
                spoofTimer.Stop();
                // Display error message and turn off switch if TitleId is empty
                if (SpoofSwitch.Checked && string.IsNullOrEmpty(SpoofTitleIdTextBox?.Text))
                {
                    SpoofSwitch.Checked = false;
                    MessageBox.Show("Please enter a valid Title ID before enabling spoofing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void SpoofTimer_Tick(object sender, EventArgs e)
        {
            if (isSpoofing && SpoofSwitch.Checked && SpoofTitleIdTextBox != null && !string.IsNullOrEmpty(SpoofTitleIdTextBox.Text))
            {
                await SendSpoofRequest(SpoofTitleIdTextBox.Text);
            }
        }

        private Task SendSpoofRequest(string titleId)
        {
            return Task.Run(() =>
            {
                try
                {
                    string jsonRequest = "{\"titles\":[{\"expiration\":600,\"id\":" + titleId + ",\"state\":\"active\",\"sandbox\":\"RETAIL\"}]}";
                    string url = $"https://presence-heartbeat.xboxlive.com/users/xuid({Xuid.Text})/devices/current";

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = "POST";
                    request.ContentType = "application/json";
                    request.Accept = "application/json";
                    request.Headers.Add("x-xbl-contract-version", "2");
                    request.Headers.Add("Authorization", Token.Text);
                    request.Headers.Add("Accept-Encoding", "gzip, deflate");
                    // xbl contect that pegasus uses client.DefaultRequestHeaders.Add("Signature", "example");
                    request.Headers.Add("accept-language", "en-US");
                    // signature that pegasus uses client.DefaultRequestHeaders.Add("Signature", "example");
                    request.Headers.Add("Cache-Control", "no-cache");

                    byte[] jsonBytes = Encoding.UTF8.GetBytes(jsonRequest);
                    request.ContentLength = jsonBytes.Length;

                    using (Stream requestStream = request.GetRequestStream())
                    {
                        requestStream.Write(jsonBytes, 0, jsonBytes.Length);
                    }

                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            Console.WriteLine($"Spoof request sent for TitleId: {titleId} at: {DateTime.Now}");
                        }
                        else
                        {
                            throw new Exception($"Unexpected response status: {response.StatusCode}");
                        }
                    }
                }
                catch (WebException ex)
                {
                    string errorMessage = $"Spoofing failed for TitleId: {titleId}, Error: {ex.Message} at: {DateTime.Now}";

                    this.Invoke((Action)(() =>
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SpoofSwitch.Checked = false;
                        spoofTimer.Stop();
                        isSpoofing = false;
                        if (SpoofTitleIdTextBox != null)
                        {
                            SpoofTitleIdTextBox.Enabled = true;
                        }
                    }));
                }
                catch (Exception ex)
                {
                    string errorMessage = $"Spoofing failed for TitleId: {titleId}, Error: {ex.Message} at: {DateTime.Now}";

                    this.Invoke((Action)(() =>
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SpoofSwitch.Checked = false;
                        spoofTimer.Stop();
                        isSpoofing = false;
                        if (SpoofTitleIdTextBox != null)
                        {
                            SpoofTitleIdTextBox.Enabled = true;
                        }
                    }));
                }
            });
        }

        private void InitializeSelectButtonHandlers()
        {
            Select1.Click += (sender, e) => SendRequest(BIG1.Text);
            Select2.Click += (sender, e) => SendRequest(BIG2.Text);
            Select3.Click += (sender, e) => SendRequest(BIG3.Text);
            Select4.Click += (sender, e) => SendRequest(BIG4.Text);
            Select5.Click += (sender, e) => SendRequest(BIG5.Text);
        }

        private async void SendRequest(string productId)
        {
            try
            {
                string jsonRequest = "{\"Products\":[\"" + productId + "\"]}";

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate");
                client.DefaultRequestHeaders.Add("accept-language", "en-US");
                client.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
                client.DefaultRequestHeaders.Add("accept", "application/json");

                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("https://catalog.gamepass.com/products?market=US&language=en-US&hydration=PCLowAmber0", content);
                response.EnsureSuccessStatusCode();

                string jsonResponse = await response.Content.ReadAsStringAsync();
                var responseObject = JObject.Parse(jsonResponse);

                if (responseObject["Products"] != null)
                {
                    var product = responseObject["Products"].First as JProperty;
                    var xBoxTitleId = product.Value["alternateIds"]
                        .FirstOrDefault(x => x["idType"].ToString() == "XBOXTITLEID")?["id"].ToString();

                    TitleId.Text = xBoxTitleId;

                    // g
                    StatsList.Visible = true;
                    AchievementList.Visible = true;
                    CopyTitleId.Visible = true;
                    SetStats.Visible = false;
                    UnlockAll.Visible = true;
                    // hide shit from spoof 
                    XUIDPanel.Visible = false;
                    TimePanel.Visible = false;
                    SpoofPanel.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            AchievementList.PerformClick();
            G1.Visible = false;
            G2.Visible = false;
            G3.Visible = false;
            G4.Visible = false;
            G5.Visible = false;
        }

        private async void Search_TextChanged(object sender, EventArgs e)
        {
            lastTypingTime = DateTime.Now;
            // Only trigger search if the search field is not empty
            if (!string.IsNullOrEmpty(Search.Text))
            {
                await CheckTypingPause();
            }
        }

        private async Task CheckTypingPause()
        {
            await Task.Delay(typingDelay);
            if ((DateTime.Now - lastTypingTime).TotalMilliseconds >= typingDelay)
            {
                await SendRequestAsync();
            }
        }

        private async Task SendRequestAsync()
        {
            try
            {
                // Hide previously loaded game elements when starting a new search
                TitleId.Text = "";
                GameName.Visible = false;
                StatsList.Visible = false;
                AchievementList.Visible = false;
                CopyTitleId.Visible = false;
                UnlockAll.Visible = false;
                SetStats.Visible = false;
                AchievementsGrid.Visible = false;
                StatsGrid.Visible = false;

                // hide shit from spoof 
                XUIDPanel.Visible = false;
                TimePanel.Visible = false;
                SpoofPanel.Visible = false;
                
                // show search games
                G1.Visible = true;
                G2.Visible = true;
                G3.Visible = true;
                G4.Visible = true;
                G5.Visible = true;
                await Task.Delay(500);

                string query = Uri.EscapeDataString(Search.Text);
                string requestUrl = $"https://www.microsoft.com/msstoreapiprod/api/autosuggest?market=en-us&clientId=7F27B536-CF6B-4C65-8638-A0F8CBDFCA65&sources=Microsoft-Terms%2CIris-Products%2CxSearch-Products&%2BClientType%3AStoreWeb&counts=5%2C1%2C5&query={query}";

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br, zstd");
                client.DefaultRequestHeaders.Add("accept-language", "en-US");
                client.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/125.0.0.0 Safari/537.36");

                HttpResponseMessage response = await client.GetAsync(requestUrl);
                response.EnsureSuccessStatusCode();

                string jsonResponse = await response.Content.ReadAsStringAsync();
                JObject json = JObject.Parse(jsonResponse);

                var resultSet = json["ResultSets"]?.FirstOrDefault(rs => rs["Source"]?.ToString() == "xsearch-products");
                if (resultSet == null)
                {
                    MessageBox.Show("We could not find that game", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                JArray suggests = (JArray)resultSet["Suggests"];
                int maxResults = Math.Min(suggests.Count, 5);

                // if not found show loading
                for (int i = 1; i <= 5; i++)
                {
                    Label label = this.Controls.Find("D" + i, true).FirstOrDefault() as Label;
                    if (label != null)
                    {
                        label.Text = "Loading";
                    }
                }

                for (int i = 0; i < maxResults; i++)
                {
                    JObject suggest = (JObject)suggests[i];
                    string title = suggest["Title"]?.ToString();
                    string imageUrl = suggest["ImageUrl"]?.ToString();
                    string bigCatalogId = suggest["Metas"]?.FirstOrDefault(m => m["Key"]?.ToString() == "BigCatalogId")?["Value"]?.ToString();

                    if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(imageUrl) || string.IsNullOrEmpty(bigCatalogId))
                    {
                        Console.WriteLine($"Invalid data for suggestion {i + 1}: Title={title}, ImageUrl={imageUrl}, BigCatalogId={bigCatalogId}");
                        continue;
                    }

                    imageUrl = "https:" + imageUrl;

                    Label nameLabel = this.Controls.Find("N" + (i + 1), true).FirstOrDefault() as Label;
                    Label bigLabel = this.Controls.Find("BIG" + (i + 1), true).FirstOrDefault() as Label;
                    PictureBox pictureBox = this.Controls.Find("P" + (i + 1), true).FirstOrDefault() as PictureBox;

                    if (nameLabel != null)
                        nameLabel.Text = title;
                    else
                        Console.WriteLine("Label N" + (i + 1) + " not found.");

                    if (bigLabel != null)
                        bigLabel.Text = bigCatalogId;
                    else
                        Console.WriteLine("Label BIG" + (i + 1) + " not found.");

                    if (pictureBox != null)
                    {
                        pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox.Load(imageUrl);
                    }
                    else
                        Console.WriteLine("PictureBox P" + (i + 1) + " not found.");
                }

                List<string> bigCatalogIds = new List<string>();
                for (int i = 1; i <= 5; i++)
                {
                    Label bigLabel = this.Controls.Find("BIG" + i, true).FirstOrDefault() as Label;
                    if (bigLabel != null && !string.IsNullOrEmpty(bigLabel.Text))
                        bigCatalogIds.Add(bigLabel.Text);
                }

                if (bigCatalogIds.Any())
                {
                    string jsonRequest = "{\"Products\":[\"" + BIG1.Text + "\",\"" + BIG2.Text + "\",\"" + BIG3.Text + "\",\"" + BIG4.Text + "\",\"" + BIG5.Text + "\"]}";
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate");
                    client.DefaultRequestHeaders.Add("accept-language", "en-US");
                    client.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
                    client.DefaultRequestHeaders.Add("accept", "application/json");

                    var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                    var response2 = await client.PostAsync("https://catalog.gamepass.com/products?market=US&language=en-US&hydration=PCLowAmber0", content);
                    response2.EnsureSuccessStatusCode();

                    string jsonResponse2 = await response2.Content.ReadAsStringAsync();
                    var responseObject = JObject.Parse(jsonResponse2);

                    List<string> titleIds = new List<string>();
                    Dictionary<string, string> titleIdMapping = new Dictionary<string, string>();

                    if (responseObject["Products"] != null)
                    {
                        int i = 1;
                        foreach (var product in responseObject["Products"])
                        {
                            var xBoxTitleId = product.First["alternateIds"]
                                .FirstOrDefault(x => x["idType"].ToString() == "XBOXTITLEID")?["id"].ToString();

                            if (xBoxTitleId != null)
                            {
                                switch (i)
                                {
                                    case 1:
                                        T1.Text = xBoxTitleId;
                                        titleIdMapping[xBoxTitleId] = "D1";
                                        break;
                                    case 2:
                                        T2.Text = xBoxTitleId;
                                        titleIdMapping[xBoxTitleId] = "D2";
                                        break;
                                    case 3:
                                        T3.Text = xBoxTitleId;
                                        titleIdMapping[xBoxTitleId] = "D3";
                                        break;
                                    case 4:
                                        T4.Text = xBoxTitleId;
                                        titleIdMapping[xBoxTitleId] = "D4";
                                        break;
                                    case 5:
                                        T5.Text = xBoxTitleId;
                                        titleIdMapping[xBoxTitleId] = "D5";
                                        break;
                                }
                                titleIds.Add(xBoxTitleId);
                                i++;
                            }
                        }
                    }

                    string titleHubRequestJson = JsonConvert.SerializeObject(new { pfns = (object)null, titleIds = titleIds });
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Add("x-xbl-contract-version", "2");
                    client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate");
                    // signature that pegasus uses client.DefaultRequestHeaders.Add("Signature", "example");
                    client.DefaultRequestHeaders.Add("accept-language", "en-US");
                    client.DefaultRequestHeaders.Add("authorization", Token.Text);
                    client.DefaultRequestHeaders.Add("accept", "application/json");

                    var titleHubContent = new StringContent(titleHubRequestJson, Encoding.UTF8, "application/json");
                    var titleHubResponse = await client.PostAsync($"https://titlehub.xboxlive.com/users/xuid({Xuid.Text})/titles/batch/decoration/Achievement", titleHubContent);
                    titleHubResponse.EnsureSuccessStatusCode();

                    string titleHubResponseJson = await titleHubResponse.Content.ReadAsStringAsync();
                    var titleHubResponseObject = JObject.Parse(titleHubResponseJson);

                    // Store achievement status for each titleId
                    Dictionary<string, string> titleAchievementStatus = new Dictionary<string, string>();

                    if (titleHubResponseObject["titles"] != null)
                    {
                        foreach (var title in titleHubResponseObject["titles"])
                        {
                            var titleId = title["titleId"]?.ToString();
                            var currentGamerscore = title["achievement"]?["currentGamerscore"]?.ToString() ?? "0";
                            var totalGamerscore = title["achievement"]?["totalGamerscore"]?.ToString() ?? "0";
                            string gamerscoreText = $"{currentGamerscore}/{totalGamerscore}";

                            if (titleId != null)
                            {
                                titleAchievementStatus[titleId] = gamerscoreText;
                            }
                        }

                        // Update all labels corresponding to the same titleId
                        for (int i = 1; i <= 5; i++)
                        {
                            Label titleLabel = this.Controls.Find("T" + i, true).FirstOrDefault() as Label;
                            if (titleLabel != null && !string.IsNullOrEmpty(titleLabel.Text) && titleAchievementStatus.ContainsKey(titleLabel.Text))
                            {
                                Label achievementLabel = this.Controls.Find("D" + i, true).FirstOrDefault() as Label;
                                if (achievementLabel != null)
                                {
                                    achievementLabel.Text = titleAchievementStatus[titleLabel.Text];
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private async void siticoneButton2_Click(object sender, EventArgs e)
        {
            // hide stats etc load achiev
            CopyTitleId.Visible = true;
            UnlockAll.Visible = false;
            SetStats.Visible = false;
            StatsGrid.Visible = false;

            // hide shit from spoof 
            XUIDPanel.Visible = false;
            TimePanel.Visible = false;
            SpoofPanel.Visible = false;

            await LoadAchievements();
        }

        private async Task LoadAchievements()
        {
            try
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("x-xbl-contract-version", "4");
                client.DefaultRequestHeaders.Add("Authorization", Token.Text);
                client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate");
                client.DefaultRequestHeaders.Add("accept-language", "en-US");
                client.DefaultRequestHeaders.Add("accept", "application/json");
                // signature that pegasus uses client.DefaultRequestHeaders.Add("Signature", "example");

                var response = await client.GetAsync($"https://achievements.xboxlive.com/users/xuid({Xuid.Text})/achievements?titleId={TitleId.Text}&maxItems=10000");
                response.EnsureSuccessStatusCode();

                string jsonResponse = await response.Content.ReadAsStringAsync();
                var responseObject = JObject.Parse(jsonResponse);

                if (responseObject["achievements"] != null && responseObject["achievements"].Count() > 0)
                {
                    string gameName = "Unknown";
                    if (responseObject["achievements"][0]["titleAssociations"] != null &&
                        responseObject["achievements"][0]["titleAssociations"].Count() > 0 &&
                        responseObject["achievements"][0]["titleAssociations"][0]["name"] != null)
                    {
                        gameName = responseObject["achievements"][0]["titleAssociations"][0]["name"].ToString();
                    }

                    GameName.Text = gameName;
                    GameName.Visible = true;

                    DataTable dt = new DataTable();
                    dt.Columns.Add("ID");
                    dt.Columns.Add("Name");
                    dt.Columns.Add("Description");
                    dt.Columns.Add("ProgressState");
                    dt.Columns.Add("Value");
                    dt.Columns.Add("UnlockButton");
                    dt.Columns.Add("Spoof");

                    foreach (var achievement in responseObject["achievements"])
                    {
                        string achievementId = achievement["id"].ToString();
                        string achievementName = achievement["name"].ToString();
                        string achievementDescription = achievement["description"].ToString();
                        string progressState = achievement["progressState"].ToString();
                        string achievementScid = achievement["serviceConfigId"].ToString();
                        string achievementValue = "0";

                        if (achievement["rewards"] != null && achievement["rewards"].Count() > 0)
                        {
                            foreach (var reward in achievement["rewards"])
                            {
                                if (reward["type"].ToString() == "Gamerscore")
                                {
                                    achievementValue = reward["value"].ToString();
                                    break;
                                }
                            }
                        }
                        Scid.Text = achievementScid;

                        string unlockButtonText = progressState != "Achieved" ? "Press to unlock" : "Already Unlocked";
                        dt.Rows.Add(achievementId, achievementName, achievementDescription, progressState, achievementValue, unlockButtonText, "Spoof");
                    }

                    AchievementsGrid.DataSource = null;
                    AchievementsGrid.DataSource = dt;

                    if (!AchievementsGrid.Columns.Contains("Spoof"))
                    {
                        DataGridViewButtonColumn spoofColumn = new DataGridViewButtonColumn
                        {
                            Name = "Spoof",
                            HeaderText = "Spoof",
                            Text = "Spoof",
                            UseColumnTextForButtonValue = true
                        };
                        AchievementsGrid.Columns.Add(spoofColumn);
                    }

                    AchievementsGrid.Visible = true;
                    //Show Unlock button if achievements exist
                    UnlockAll.Visible = true;
                }
                else
                {
                    //Hide Unlock and stats button if no achievements exist
                    UnlockAll.Visible = false;
                    AchievementsGrid.Visible = false;
                    SetStats.Visible = false;
                }
            }
            catch (Exception ex)
            {
                UnlockAll.Visible = false;
                AchievementsGrid.Visible = false;
                GameName.Visible = false;
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AchievementsGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == AchievementsGrid.Columns["UnlockButton"]?.Index && e.Value != null)
            {
                string cellValue = e.Value.ToString();
                if (cellValue == "Already Unlocked")
                {
                    e.CellStyle.ForeColor = Color.Red;
                    e.CellStyle.SelectionForeColor = Color.Red;
                }
                else if (cellValue == "Press to unlock")
                {
                    e.CellStyle.ForeColor = Color.Lime;
                    e.CellStyle.SelectionForeColor = Color.Lime;
                }
            }
            if (e.ColumnIndex == AchievementsGrid.Columns["Spoof"]?.Index && e.Value != null)
            {
                string cellValue = e.Value.ToString();
                if (cellValue == "Spoof")
                {
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.SelectionForeColor = Color.White;
                }
            }
        }

        private async void AchievementsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == AchievementsGrid.Columns["UnlockButton"].Index)
            {
                string progressState = AchievementsGrid.Rows[e.RowIndex].Cells["ProgressState"].Value.ToString();
                if (progressState != "Achieved")
                {
                    string achievementId = AchievementsGrid.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                    try
                    {
                        string jsonRequest = "{\"achievements\":[{\"id\":\"" + achievementId + "\",\"percentComplete\":100}],\"action\":\"progressUpdate\",\"serviceConfigId\":\"" + Scid.Text + "\",\"titleId\":" + TitleId.Text + ",\"userId\":\"" + Xuid.Text + "\"}";

                        client.DefaultRequestHeaders.Clear();
                        client.DefaultRequestHeaders.Add("x-xbl-contract-version", "2");
                        client.DefaultRequestHeaders.Add("Authorization", Token.Text);
                        client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate");
                        // xbl content restrictions that pegasus uses client.DefaultRequestHeaders.Add("Signature", "example");
                        client.DefaultRequestHeaders.Add("accept-language", "en-US");
                        client.DefaultRequestHeaders.Add("accept", "application/json");
                        // signature that pegasus uses client.DefaultRequestHeaders.Add("Signature", "example");
                        client.DefaultRequestHeaders.Add("Cache-Control", "no-cache");

                        var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                        var response = await client.PostAsync($"https://achievements.xboxlive.com/users/xuid({Xuid.Text})/achievements/{Scid.Text}/update", content);

                        if (response.StatusCode == HttpStatusCode.BadRequest)
                        {
                            MessageBox.Show("Achievements for this game cannot be unlocked.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show($"Unlocked ID: {achievementId}", "Achievement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (WebException)
                    {
                        MessageBox.Show("Failed to Unlock Achivement", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    ReLoad.PerformClick();
                }
                else if (progressState == "Achieved")
                {
                    string achievementId = AchievementsGrid.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                    MessageBox.Show($"You have already unlocked achievement ID: {achievementId}", "Achievement Already Unlocked", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (e.ColumnIndex == AchievementsGrid.Columns["Spoof"].Index)
            {
                currentAchievementId = AchievementsGrid.Rows[e.RowIndex].Cells["ID"].Value.ToString();

                XUIDPanel.Visible = false;
                TimePanel.Visible = false;
                SpoofPanel.Visible = true;
                SpoofPanel.BringToFront();
            }
        }

        private void AsMe_Click(object sender, EventArgs e)
        {
            selectedXuid = Xuid.Text;
            SpoofPanel.Visible = false;

            ShowTimePanel();
        }

        private void SBelse_Click(object sender, EventArgs e)
        {
            SpoofPanel.Visible = false;

            XUIDPanel.Visible = true;
            XUIDPanel.BringToFront();
            XUIDe.Focus();
        }

        private void XUIDaccept_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(XUIDe.Text))
            {
                MessageBox.Show("Enter a XUID or spoof as you, wtf u trying to do?", "Nigga", MessageBoxButtons.OK);
                return;
            }

            selectedXuid = XUIDe.Text;
            XUIDPanel.Visible = false;

            ShowTimePanel();
        }

        private void ShowTimePanel()
        {
            // set time right now in format ISO 8601
            Time.Text = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffffffZ");

            TimePanel.Visible = true;
            TimePanel.BringToFront();
            Time.Focus();
        }

        private async void TimeAccept_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Time.Text))
            {
                MessageBox.Show("nigga why u deleted time?", "lmao", MessageBoxButtons.OK);
				Time.Text = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffffffZ");
                return;
            }

            selectedTime = Time.Text;
            TimePanel.Visible = false;

            try
            {
                // spoof request (deleted from public src)

                MessageBox.Show("Spoofed! Check Your Social Tab", "levelek1337", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                // silent
            }
        }

        private async void Load_Click(object sender, EventArgs e)
        {
            int horizontalScrollPosition = AchievementsGrid.HorizontalScrollingOffset;
            int verticalScrollPosition = AchievementsGrid.FirstDisplayedScrollingRowIndex;

            await LoadAchievements();

            AchievementsGrid.Invoke((Action)(() =>
            {
                AchievementsGrid.HorizontalScrollingOffset = horizontalScrollPosition;
                if (verticalScrollPosition >= 0 && verticalScrollPosition < AchievementsGrid.Rows.Count)
                {
                    AchievementsGrid.FirstDisplayedScrollingRowIndex = verticalScrollPosition;
                }
            }));
        }

        private async void siticoneButton1_Click(object sender, EventArgs e)
        {
            // Hide Achievement Grid and Unlock button when switching to stats
            AchievementsGrid.Visible = false;
            UnlockAll.Visible = false;
            // hide shit from spoof 
            XUIDPanel.Visible = false;
            TimePanel.Visible = false;
            SpoofPanel.Visible = false;

            try
            {
                string jsonRequest = "{\"arrangebyfield\":\"xuid\",\"xuids\":[\"" + Xuid.Text + "\"],\"groups\":[{\"name\":\"Hero\",\"titleId\":\"" + TitleId.Text + "\"}]}";

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate");
                client.DefaultRequestHeaders.Add("x-xbl-contract-version", "2");
                // signature that pegasus uses client.DefaultRequestHeaders.Add("Signature", "example");
                client.DefaultRequestHeaders.Add("authorization", Token.Text);
                client.DefaultRequestHeaders.Add("accept-language", "en-US");
                client.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
                client.DefaultRequestHeaders.Add("accept", "application/json");

                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("https://userstats.xboxlive.com/batch", content);
                response.EnsureSuccessStatusCode();

                string jsonResponse = await response.Content.ReadAsStringAsync();
                var responseObject = JObject.Parse(jsonResponse);

                this.Invoke((Action)(() =>
                {
                    StatsGrid.Rows.Clear();
                    StatsGrid.Columns.Clear();

                    StatsGrid.Columns.Add("Ordinal", "Ordinal");
                    StatsGrid.Columns.Add("Name", "Name");
                    StatsGrid.Columns.Add("DisplayName", "Display Name");

                    DataGridViewTextBoxColumn valueColumn = new DataGridViewTextBoxColumn();
                    valueColumn.HeaderText = "Value";
                    valueColumn.Name = "Value";
                    valueColumn.ReadOnly = false;
                    StatsGrid.Columns.Add(valueColumn);

                    if (responseObject["groups"] != null && responseObject["groups"].Count() > 0)
                    {
                        var stats = responseObject["groups"][0]["statlistscollection"][0]["stats"];

                        foreach (var stat in stats)
                        {
                            string ordinal = stat["groupproperties"]["Ordinal"].ToString();
                            string name = stat["name"].ToString();
                            string displayName = stat["properties"]["DisplayName"].ToString();
                            string statValue = stat["value"]?.ToString() ?? "N/A";

                            StatsGrid.Rows.Add(ordinal, name, displayName, statValue);
                        }
                    }

                    StatsGrid.Visible = true;
                    StatsGrid.Show();
                    StatsGrid.Refresh();
                    SetStats.Visible = true;
                }));
            }
            catch (Exception)
            {
                SetStats.Visible = false;
                MessageBox.Show("This Game Does Not Have Statistics", "Did you know?", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void Stats_Click(object sender, EventArgs e)
        {
            try
            {
                // Récupérer le chemin du fichier JSON
                string directoryPath = @"C:\Pegasus Revived";
                string filePath = Path.Combine(directoryPath, "Token.JSON");

                // Vérifier si le fichier existe
                if (File.Exists(filePath))
                {
                    // Lire toutes les lignes du fichier JSON
                    var lines = File.ReadAllLines(filePath);

                    // Vérifier si le fichier a au moins deux lignes (ligne 1 pour le token et ligne 2 pour la valeur sync)
                    if (lines.Length >= 2)
                    {
                        // Récupérer la valeur actuelle de sync à partir de la ligne 2
                        if (int.TryParse(lines[1], out int sync))
                        {
                            // Incrémenter la valeur de sync de 1
                            sync++;

                            // Construire et envoyer le JSON avec la nouvelle valeur de sync
                            JObject statsObject = new JObject();
                            JObject titleObject = new JObject();

                            foreach (DataGridViewRow row in StatsGrid.Rows)
                            {
                                if (row.Cells["Name"].Value != null && row.Cells["Value"].Value != null)
                                {
                                    string name = row.Cells["Name"].Value.ToString();
                                    string value = row.Cells["Value"].Value.ToString();

                                    titleObject[name] = new JObject { { "value", value } };
                                }
                            }

                            statsObject["title"] = titleObject;
                            JObject rootObject = new JObject
                    {
                        { "$schema", "http://stats.xboxlive.com/2017-1/schema#" },
                        { "previousRevision", 55 },
                        { "revision", sync },
                        { "stats", statsObject },
                        { "timestamp", DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.ffffffZ") }
                    };

                            string jsonString = rootObject.ToString();

                            client.DefaultRequestHeaders.Clear();
                            client.DefaultRequestHeaders.Add("x-xbl-contract-version", "2");
                            client.DefaultRequestHeaders.Add("Authorization", Token.Text);
                            client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate");
                            client.DefaultRequestHeaders.Add("x-xbl-contentrestrictions", "AAAAAQHWz5NlGHSiGhEEoMhfRFSXomRyncvTZ/dwjSwRdWj5PAYDZ3aYuXCFbMii5hU0gjdefTSj67IjB0AbaxFBUgBg48qk9Z7hHIQ==");
                            client.DefaultRequestHeaders.Add("Accept-Language", "en-US");
                            // signature that pegasus uses client.DefaultRequestHeaders.Add("Signature", "example");
                            client.DefaultRequestHeaders.Add("Cache-Control", "no-cache");

                            var postContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
                            var postResponse = await client.PostAsync("https://statswrite.xboxlive.com/stats/users/" + Xuid.Text + "/scids/" + Scid.Text, postContent);
                            postResponse.EnsureSuccessStatusCode();

                            string response = await postResponse.Content.ReadAsStringAsync();

                            // read sync from line 2 Token.JSON
                            lines[1] = sync.ToString();
                            File.WriteAllLines(filePath, lines);

                            // reload stats
                            string jsonRequest = "{\"arrangebyfield\":\"xuid\",\"xuids\":[\"" + Xuid.Text + "\"],\"groups\":[{\"name\":\"Hero\",\"titleId\":\"" + TitleId.Text + "\"}]}";

                            client.DefaultRequestHeaders.Clear();
                            client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate");
                            client.DefaultRequestHeaders.Add("x-xbl-contract-version", "2");
                            // signature that pegasus uses client.DefaultRequestHeaders.Add("Signature", "example");
                            client.DefaultRequestHeaders.Add("authorization", Token.Text);
                            client.DefaultRequestHeaders.Add("accept-language", "en-US");
                            client.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
                            client.DefaultRequestHeaders.Add("accept", "application/json");

                            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                            var statsResponse = await client.PostAsync("https://userstats.xboxlive.com/batch", content);
                            statsResponse.EnsureSuccessStatusCode();

                            string statsJsonResponse = await statsResponse.Content.ReadAsStringAsync();
                            var statsResponseObject = JObject.Parse(statsJsonResponse);

                            this.Invoke((Action)(() =>
                            {
                                AchievementsGrid.Visible = false;
                                UnlockAll.Visible = false;
                                SetStats.Visible = true;

                                StatsGrid.Rows.Clear();
                                StatsGrid.Columns.Clear();

                                StatsGrid.Columns.Add("Ordinal", "Ordinal");
                                StatsGrid.Columns.Add("Name", "Name");
                                StatsGrid.Columns.Add("DisplayName", "Display Name");

                                DataGridViewTextBoxColumn valueColumn = new DataGridViewTextBoxColumn();
                                valueColumn.HeaderText = "Value";
                                valueColumn.Name = "Value";
                                valueColumn.ReadOnly = false;
                                StatsGrid.Columns.Add(valueColumn);

                                if (statsResponseObject["groups"] != null && statsResponseObject["groups"].Count() > 0)
                                {
                                    var stats = statsResponseObject["groups"][0]["statlistscollection"][0]["stats"];

                                    foreach (var stat in stats)
                                    {
                                        string ordinal = stat["groupproperties"]["Ordinal"].ToString();
                                        string name = stat["name"].ToString();
                                        string displayName = stat["properties"]["DisplayName"].ToString();
                                        string statValue = stat["value"]?.ToString() ?? "N/A";

                                        StatsGrid.Rows.Add(ordinal, name, displayName, statValue);
                                    }
                                }
                                MessageBox.Show("Successfully changed stats!", "Maybe?", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                StatsGrid.Visible = true;
                                StatsGrid.Show();
                                StatsGrid.Refresh();
                            }));
                        }
                        else
                        {
                            MessageBox.Show("The value of sync is not a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("JSON file does not contain enough lines.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("JSON file does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Invoke((Action)(() =>
                {
                    AchievementsGrid.Visible = false;
                    UnlockAll.Visible = false;
                    SetStats.Visible = true;
                    StatsGrid.Visible = true;
                }));
            }
        }

        private async void Unlock_Click(object sender, EventArgs e)
        {
            // hide shit from spoof 
            XUIDPanel.Visible = false;
            TimePanel.Visible = false;
            SpoofPanel.Visible = false;
            DialogResult result = MessageBox.Show("Do you wanna be banned?", "Nigga", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
            {
                return;
            }

            try
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("x-xbl-contract-version", "4");
                client.DefaultRequestHeaders.Add("Authorization", Token.Text);
                client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate");
                client.DefaultRequestHeaders.Add("accept-language", "en-US");
                client.DefaultRequestHeaders.Add("accept", "application/json");
                // signature that pegasus uses client.DefaultRequestHeaders.Add("Signature", "example");

                var response = await client.GetAsync($"https://achievements.xboxlive.com/users/xuid({Xuid.Text})/achievements?titleId={TitleId.Text}&maxItems=10000");
                response.EnsureSuccessStatusCode();

                string jsonResponse = await response.Content.ReadAsStringAsync();
                var responseObject = JObject.Parse(jsonResponse);

                // Sprawdź, czy istnieją osiągnięcia
                if (responseObject["achievements"] != null && responseObject["achievements"].Count() > 0)
                {
                    // Filtruj osiągnięcia z progressState nie jest Achieved
                    var achievementsToUnlock = responseObject["achievements"]
                        .Where(a => a["progressState"]?.ToString() != "Achieved")
                        .ToList();

                    if (!achievementsToUnlock.Any())
                    {
                        MessageBox.Show("You already unlocked all achievements", "You trying to test me?", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadAchievements();
                        return;
                    }

                    foreach (var achievement in achievementsToUnlock)
                    {
                        string achievementId = achievement["id"]?.ToString();
                        string achievementScid = achievement["serviceConfigId"]?.ToString();

                        if (string.IsNullOrEmpty(achievementId) || string.IsNullOrEmpty(achievementScid))
                        {
                            MessageBox.Show("Achievements for this game cannot be unlocked : there is no ID or SCID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            await LoadAchievements();
                            return;
                        }
                    }
                    // hide while unlocking
                    AchievementsGrid.Visible = false;
                    UnlockAll.Visible = false;
                    SetStats.Visible = false;
                    StatsGrid.Visible = false;

                    int unlockedCount = 0;
                    bool firstRequestSent = false;

                    foreach (var achievement in achievementsToUnlock)
                    {
                        string achievementId = achievement["id"]?.ToString();
                        string achievementScid = achievement["serviceConfigId"]?.ToString();

                        string jsonRequest = $"{{\"achievements\":[{{\"id\":\"{achievementId}\",\"percentComplete\":100}}],\"action\":\"progressUpdate\",\"serviceConfigId\":\"{achievementScid}\",\"titleId\":{TitleId.Text},\"userId\":\"{Xuid.Text}\"}}";

                        client.DefaultRequestHeaders.Clear();
                        client.DefaultRequestHeaders.Add("x-xbl-contract-version", "2");
                        client.DefaultRequestHeaders.Add("Authorization", Token.Text);
                        client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate");
                        // x xbl content restrictions that pegasus uses client.DefaultRequestHeaders.Add("x-xbl-contentrestrictions", "example");
                        client.DefaultRequestHeaders.Add("accept-language", "en-US");
                        client.DefaultRequestHeaders.Add("accept", "application/json");
                        // signature that pegasus uses client.DefaultRequestHeaders.Add("Signature", "example");
                        client.DefaultRequestHeaders.Add("Cache-Control", "no-cache");

                        var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                        var unlockResponse = await client.PostAsync($"https://achievements.xboxlive.com/users/xuid({Xuid.Text})/achievements/{achievementScid}/update", content);

                        // Sprawdź tylko pierwszy request
                        if (!firstRequestSent)
                        {
                            if (unlockResponse.StatusCode == HttpStatusCode.BadRequest)
                            {
                                MessageBox.Show("Achievements for this game cannot be unlocked.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                await LoadAchievements();
                                return;
                            }

                            unlockResponse.EnsureSuccessStatusCode();
                            Task.Run(() => MessageBox.Show("Started Unlocking, Please Wait...", "levelek1337", MessageBoxButtons.OK, MessageBoxIcon.Information));
                            firstRequestSent = true;
                        }

                        unlockedCount++;
                        await Task.Delay(777);
                    }

                    // if unlocked show message
                    if (unlockedCount > 0)
                    {
                        MessageBox.Show("Successfully unlocked all", "Yooooooo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    // Odśwież listę osiągnięć
                    await LoadAchievements();
                }
                else
                {
                    MessageBox.Show("This game does not have achievements.", "???", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UnlockAll.Visible = false;
                    AchievementsGrid.Visible = false;
                    SetStats.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UnlockAll.Visible = false;
                AchievementsGrid.Visible = false;
                SetStats.Visible = false;
            }
        }

        private async void Achievements_Load(object sender, EventArgs e)
        {
            await LoadProfile();
        }

        private async void pictureBox4_Click(object sender, EventArgs e)
        {
            await LoadProfile();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Stop the spoofing timer to prevent it from running in the background
            isSpoofing = false;
            spoofTimer.Stop();
            if (SpoofTitleIdTextBox != null)
            {
                SpoofTitleIdTextBox.Enabled = true;
            }
            SpoofSwitch.Checked = false;

            // Check if the main window is already open
            main formMain = Application.OpenForms.OfType<main>().FirstOrDefault();
            formMain.FormClosed += (s, args) => this.Close();

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

            // Show the main window (if new instance)
            if (formMain != null && Application.OpenForms.OfType<main>().Contains(formMain))
            {
                formMain.Show();
            }
        }

        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(TitleId.Text);
            toolTip.Show("Copied", CopyTitleId, 0, -20, 2000);
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        
		private void ClosePanel_Click(object sender, EventArgs e)
        {
            SpoofPanel.Visible = false;
        }

        private void ClosePanel2_Click(object sender, EventArgs e)
        {
            XUIDPanel.Visible = false;
        }
        private void ClosePanel3_Click(object sender, EventArgs e)
        {
            TimePanel.Visible = false;
        }
    }
}