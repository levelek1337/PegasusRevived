using System;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Siticone.Desktop.UI.WinForms;

namespace PegasusV2Beta
{
    public partial class Avatar : Form
    {
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
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
        private int typingDelay = 1500;
        private DateTime lastTypingTime;

        
        public Avatar()
        {
            InitializeComponent();
            siticonePanel2.MouseDown += new MouseEventHandler(Panel_MouseDown);
            siticonePanel2.MouseMove += new MouseEventHandler(Panel_MouseMove);
            siticonePanel2.MouseUp += new MouseEventHandler(Panel_MouseUp);

            // Create avatars folder if it doesn't exist
            string avatarsPath = Path.Combine(@"C:\Pegasus Revived", "avatars");
            if (!Directory.Exists(avatarsPath))
            {
                Directory.CreateDirectory(avatarsPath);
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

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_NCLBUTTONDBLCLK)
            {
                return;
            }

            if (m.Msg == WM_NCHITTEST)
            {
                base.WndProc(ref m);
                if ((int)m.Result == HTCLIENT)
                {
                    m.Result = (IntPtr)HTCAPTION;
                }
                return;
            }
            base.WndProc(ref m);
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
                    pictureBox1.ImageLocation = profileGamerPic;
                    pictureBox1.Show();
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

        private async void Avatar_Load(object sender, EventArgs e)
        {
            await LoadProfile();
        }

        private async void pictureBox4_Click(object sender, EventArgs e)
        {
            await LoadProfile();
        }

        private async void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (search.Text == search.PlaceholderText)
                return;
            lastTypingTime = DateTime.Now;
            await Task.Delay(typingDelay);
            if ((DateTime.Now - lastTypingTime).TotalMilliseconds >= typingDelay)
            {
                string gamertag = search.Text;
                if (!string.IsNullOrEmpty(gamertag))
                {
                    Steal.Visible = false;
                    avatarp.Image = null;
                    avatarp.Visible = false;
                    try
                    {
                        string url = $"http://avatar.xboxlive.com/avatar/{gamertag}/avatar-body.png";
                        client.DefaultRequestHeaders.Clear();
                        client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate");
                        client.DefaultRequestHeaders.Add("Accept-Language", "en-AU");
                        var response = await client.GetAsync(url);
                        response.EnsureSuccessStatusCode();
                        using (Stream responseStream = await response.Content.ReadAsStreamAsync())
                        {
                            Bitmap avatarImage = new Bitmap(responseStream);
                            avatarp.Image = avatarImage;
                            avatarp.Visible = true;
                        }
                    }
                    catch (HttpRequestException ex)
                    {
                        Error.Text = $"Error loading avatar image: {ex.Message}";
                    }
                    catch (Exception ex)
                    {
                        Error.Text = $"Error loading avatar image: {ex.Message}";
                    }
                    // always get XUID
                    await FetchXuid(gamertag);
                }
                else
                {
                    // if gamertag is empty clear picturebox
                    avatarp.Image = null;
                    avatarp.Visible = false;
                    label1.Text = "";
                    label1.Visible = false;
                    Steal.Visible = false;
                }
            }
        }
        private async Task FetchXuid(string gamertag)
        {
            try
            {
                string url = $"https://peoplehub.xboxlive.com/users/me/people/search/decoration/detail,preferredColor?q={gamertag}&maxItems=25";
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("x-xbl-contract-version", "5");
                client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate");
                // signature that pegasus uses client.DefaultRequestHeaders.Add("Signature", "example");
                client.DefaultRequestHeaders.Add("accept-language", "en-US");
                client.DefaultRequestHeaders.Add("authorization", Token.Text);
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string jsonResponse = await response.Content.ReadAsStringAsync();
                var responseObject = JObject.Parse(jsonResponse);
                if (responseObject["people"] != null && responseObject["people"].Count() > 0)
                {
                    var xuid = responseObject["people"][0]["xuid"].ToString();
                    label1.Text = xuid;
                    Steal.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Error.Text = $"Error: {ex.Message}";
            }
        }

        private async void siticoneButton4_Click(object sender, EventArgs e)
        {
            try
            {
                string xuid = label1.Text;
                string apiUrl = $"https://avatarservices.xboxlive.com/users/xuid({xuid})/avatar/manifest";

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate");
                client.DefaultRequestHeaders.Add("Authorization", Token.Text);

                var response = await client.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                string jsonResponseGet = await response.Content.ReadAsStringAsync();
                var responseObjectGet = JObject.Parse(jsonResponseGet);

                if (responseObjectGet["manifest"] != null)
                {
                    var manifestObjectGet = responseObjectGet["manifest"];

                    if (manifestObjectGet["manifest"] != null)
                    {
                        string manifestValue = manifestObjectGet["manifest"].ToString();
                        await UpdateManifest(xuid, manifestValue);
                    }
                    else
                    {
                        Error.Text = "Error: 'manifest' key not found in response.";
                        MessageBox.Show(Error.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    Error.Text = "Error: 'manifest' key not found in response.";
                    MessageBox.Show(Error.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Error.Text = $"Error retrieving manifest: {ex.Message}";
                MessageBox.Show(Error.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task UpdateManifest(string xuid, string manifest)
        {
            try
            {
                string apiUrl = $"https://avatarservices.xboxlive.com/users/xuid({Xuid.Text})/avatar/manifest";

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("x-xbl-contract-version", "2");
                client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate");
                client.DefaultRequestHeaders.Add("Authorization", Token.Text);

                string jsonBody = "{\"manifest\":\"" + manifest + "\"}";
                var content = new StringContent(jsonBody, System.Text.Encoding.UTF8, "application/json");

                var response = await client.PutAsync(apiUrl, content);
                response.EnsureSuccessStatusCode();

                MessageBox.Show("Avatar changed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Error.Text = $"Error updating manifest: {ex.Message}";
                MessageBox.Show(Error.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void siticoneButton5_Click(object sender, EventArgs e)
        {
            try
            {
                string apiUrl = $"https://avatarservices.xboxlive.com/users/xuid({Xuid.Text})/avatar/manifest";

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate");
                client.DefaultRequestHeaders.Add("Authorization", Token.Text);

                var response = await client.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                string jsonResponseGet = await response.Content.ReadAsStringAsync();
                var responseObjectGet = JObject.Parse(jsonResponseGet);

                if (responseObjectGet["manifest"] != null)
                {
                    var manifestObjectGet = responseObjectGet["manifest"];

                    if (manifestObjectGet["manifest"] != null)
                    {
                        string manifestValue = manifestObjectGet["manifest"].ToString();
                        label12.Text = manifestValue;

                        using (Form prompt = new Form())
                        {
                            prompt.Width = 400;
                            prompt.Height = 150;
                            prompt.Text = "Backup Name";
                            prompt.FormBorderStyle = FormBorderStyle.FixedDialog;
                            prompt.StartPosition = FormStartPosition.CenterParent;
                            prompt.MaximizeBox = false;
                            prompt.MinimizeBox = false;

                            Label textLabel = new Label() { Left = 20, Top = 20, Width = 360, Text = "How you wanna name your backup?" };
                            TextBox textBox = new TextBox() { Left = 20, Top = 50, Width = 340 };
                            Button confirmation = new Button() { Text = "OK", Left = 260, Width = 100, Top = 80 };
                            Button cancel = new Button() { Text = "Cancel", Left = 160, Width = 100, Top = 80 };
                            confirmation.Click += (s, args) => { prompt.DialogResult = DialogResult.OK; prompt.Close(); };
                            cancel.Click += (s, args) => { prompt.DialogResult = DialogResult.Cancel; prompt.Close(); };
                            prompt.Controls.Add(textLabel);
                            prompt.Controls.Add(textBox);
                            prompt.Controls.Add(confirmation);
                            prompt.Controls.Add(cancel);
                            prompt.AcceptButton = confirmation;
                            prompt.CancelButton = cancel;

                            DialogResult result = prompt.ShowDialog();

                            if (result == DialogResult.OK && !string.IsNullOrEmpty(textBox.Text))
                            {
                                string backupName = textBox.Text;
                                string avatarsPath = Path.Combine(@"C:\Pegasus Revived", "avatars");
                                string filePath = Path.Combine(avatarsPath, $"{backupName}.txt");
                                File.WriteAllText(filePath, manifestValue);
                                MessageBox.Show($"Backup saved as {backupName}.txt", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        Error.Text = "Error: 'manifest' key not found in response.";
                        MessageBox.Show(Error.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    Error.Text = "Error: 'manifest' key not found in response.";
                    MessageBox.Show(Error.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Error.Text = $"Error retrieving manifest: {ex.Message}";
                MessageBox.Show(Error.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void siticoneButton6_Click(object sender, EventArgs e)
        {
            try
            {
                string avatarsPath = Path.Combine(@"C:\Pegasus Revived", "avatars");
                string[] files = Directory.GetFiles(avatarsPath, "*.txt");

                if (files.Length == 0)
                {
                    Error.Text = "Error: No backup files found in avatars folder.";
                    MessageBox.Show(Error.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (Form prompt = new Form())
                {
                    prompt.Width = 400;
                    prompt.Height = 150;
                    prompt.Text = "Restore Backup";
                    prompt.FormBorderStyle = FormBorderStyle.FixedDialog;
                    prompt.StartPosition = FormStartPosition.CenterParent;
                    prompt.MaximizeBox = false;
                    prompt.MinimizeBox = false;

                    Label textLabel = new Label() { Left = 20, Top = 20, Width = 360, Text = "Select backup to restore:" };
                    ComboBox comboBox = new ComboBox() { Left = 20, Top = 50, Width = 340, DropDownStyle = ComboBoxStyle.DropDownList };
                    comboBox.Items.AddRange(files.Select(f => Path.GetFileName(f)).ToArray());
                    Button confirmation = new Button() { Text = "OK", Left = 260, Width = 100, Top = 100 };
                    Button cancel = new Button() { Text = "Cancel", Left = 160, Width = 100, Top = 100 };
                    confirmation.Click += (s, args) => { prompt.DialogResult = DialogResult.OK; prompt.Close(); };
                    cancel.Click += (s, args) => { prompt.DialogResult = DialogResult.Cancel; prompt.Close(); };
                    prompt.Controls.Add(textLabel);
                    prompt.Controls.Add(comboBox);
                    prompt.Controls.Add(confirmation);
                    prompt.Controls.Add(cancel);
                    prompt.AcceptButton = confirmation;
                    prompt.CancelButton = cancel;

                    DialogResult result = prompt.ShowDialog();

                    if (result == DialogResult.OK && comboBox.SelectedItem != null)
                    {
                        string selectedFile = Path.Combine(avatarsPath, comboBox.SelectedItem.ToString());
                        string manifestValue = File.ReadAllText(selectedFile);
                        await UpdateManifest(Xuid.Text, manifestValue);
                    }
                    // No error on cancel or close
                }
            }
            catch (Exception ex)
            {
                Error.Text = $"Error restoring backup: {ex.Message}";
                MessageBox.Show(Error.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
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
    }
}