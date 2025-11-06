using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static PegasusV2Beta.XUIDS;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Application = System.Windows.Forms.Application;

namespace PegasusV2Beta
{
    public partial class XUIDS : Form
    {
        private System.Windows.Forms.ToolTip toolTip;
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

        private List<string> titleIds = new List<string>();
        private string selectedFilePath = string.Empty;
        private int typingDelay = 1500;
        private DateTime lastTypingTime;

        public XUIDS()
        {
            InitializeComponent();

            siticonePanel2.MouseDown += new MouseEventHandler(Panel_MouseDown);
            siticonePanel2.MouseMove += new MouseEventHandler(Panel_MouseMove);
            siticonePanel2.MouseUp += new MouseEventHandler(Panel_MouseUp);
            toolTip = new System.Windows.Forms.ToolTip();
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
                    pfp.ImageLocation = profileGamerPic;
                    pfp.Show();
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

        private async void Form_Load(object sender, EventArgs e)
        {
            await LoadProfile();
        }


        private async void Store_TextChanged(object sender, EventArgs e)
        {
            if (Store.Text == Store.PlaceholderText)
                return;

            lastTypingTime = DateTime.Now;

            await Task.Delay(typingDelay);

            if ((DateTime.Now - lastTypingTime).TotalMilliseconds >= typingDelay)
            {
                if (!string.IsNullOrEmpty(Store.Text))
                {
                    try
                    {
                        string jsonRequest = "{\"Products\":[\"" + Store.Text + "\"]}";
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

                        if (responseObject["InvalidIds"] != null && responseObject["InvalidIds"].HasValues)
                        {
                            TitleID.Visible = false;
                            Copy2.Visible = false;
                            gamepic.Visible = false;
                            Dev.Visible = false;
                            MessageBox.Show("Game not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        if (responseObject["Products"] != null)
                        {
                            TitleID.Visible = true;
                            Copy2.Visible = true;

                            foreach (var product in responseObject["Products"])
                            {
                                var xBoxTitleId = product.First["alternateIds"]
                                    .FirstOrDefault(x => x["idType"].ToString() == "XBOXTITLEID")?["id"].ToString();

                                if (xBoxTitleId != null)
                                {
                                    TitleID.Text = xBoxTitleId;
                                    titleIdMapping[xBoxTitleId] = "TitleID";

                                    // Pobieranie logo gry
                                    var artwork = product.First["artwork"];
                                    var logoArtwork = artwork?.FirstOrDefault(x => x["purpose"]?.ToString() == "BOXART");
                                    string logoUri = logoArtwork?["uri"]?.ToString();

                                    if (!string.IsNullOrEmpty(logoUri))
                                    {
                                        gamepic.ImageLocation = logoUri;
                                        gamepic.Visible = true;
                                    }
                                    else
                                    {
                                        gamepic.Visible = false;
                                    }

                                    var developer = product.First["developer"]?.ToString();
                                    if (!string.IsNullOrEmpty(developer))
                                    {
                                        Dev.Text = "Dev: " + developer;
                                        Dev.Visible = true;
                                    }
                                    else
                                    {
                                        Dev.Visible = false;
                                    }

                                    var release = product.First["releaseDate"]?.ToString();
                                    if (!string.IsNullOrEmpty(release))
                                    {
                                        rd.Text = "Release Date : " + release;
                                        rd.Visible = true;
                                    }
                                    else
                                    {
                                        rd.Visible = false;
                                    }

                                    titleIds.Add(xBoxTitleId);
                                    break;
                                }
                            }
                        }
                    }
                    catch (HttpRequestException ex)
                    {
                        TitleID.Visible = false;
                        Copy2.Visible = false;
                        gamepic.Visible = false;
                        Dev.Visible = false;
                        if (ex.Message.Contains("401"))
                        {
                            MessageBox.Show("Token Expired, Close Pegasus fully and Grab New Token.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (ex.Message.Contains("429"))
                        {
                            MessageBox.Show("You've been rate limited by Xbox servers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (ex.Message.Contains("InvalidIds"))
                        {
                            MessageBox.Show("Game not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                else
                {
                    TitleID.Visible = false;
                    Copy2.Visible = false;
                    gamepic.Visible = false;
                    Dev.Visible = false;
                }
            }
        }

        private void Copy2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(TitleID.Text);
            toolTip.Show("Copied", Copy2, 0, -20, 2000);
        }

        private async void Search_TextChanged(object sender, EventArgs e)
        {
            if (search.Text == search.PlaceholderText)
                return;

            lastTypingTime = DateTime.Now;

            await Task.Delay(typingDelay);

            if ((DateTime.Now - lastTypingTime).TotalMilliseconds >= typingDelay)
            {
                string searchText = search.Text;
                if (!string.IsNullOrEmpty(searchText))
                {
                    pfpp.Image = null;
                    pfpp.Visible = false;
                    XUIDp.Text = "";
                    XUIDp.Visible = false;
                    GamerScorep.Text = "";
                    GamerScorep.Visible = false;
                    Steal.Visible = false;
                    Copy.Visible = false;
                    More.Visible = false;

                    try
                    {
                        // Sprawdź czy wyszukiwanie zaczyna się od cyfry
                        bool isXuid = char.IsDigit(searchText[0]);

                        if (isXuid)
                        {
                            // Bezpośrednie wyszukiwanie po XUID
                            client.DefaultRequestHeaders.Clear();
                            client.DefaultRequestHeaders.Add("x-xbl-contract-version", "5");
                            client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate");
                            client.DefaultRequestHeaders.Add("accept", "application/json");
                            client.DefaultRequestHeaders.Add("accept-language", "en-US");
                            client.DefaultRequestHeaders.Add("Authorization", Token.Text);
                            client.DefaultRequestHeaders.Add("Host", "peoplehub.xboxlive.com");
                            client.DefaultRequestHeaders.Add("Connection", "Keep-Alive");

                            // Pobierz pełną odpowiedź
                            var response = await client.GetAsync($"https://peoplehub.xboxlive.com/users/me/people/xuids({searchText})/decoration/detail,preferredColor,presenceDetail,multiplayerSummary");

                            if (!response.IsSuccessStatusCode)
                            {
                                HandleHttpError(response.StatusCode);
                                return;
                            }

                            var responseContent = await response.Content.ReadAsStringAsync();

                            // Sformatuj odpowiedź do czytelnej formy
                            string formattedResponse = FormatJsonResponse(responseContent);
                            Bio.Text = formattedResponse;

                            var peopleJson = JObject.Parse(responseContent);

                            var uniqueModernGamertag = peopleJson["people"]?[0]?["uniqueModernGamertag"]?.ToString();
                            var gamerscore = peopleJson["people"]?[0]?["gamerScore"]?.ToString();
                            var pic = peopleJson["people"]?[0]?["displayPicRaw"]?.ToString();
                            string profileGamerPic = pic?.Contains("&mode=Padding") == true ? pic.Replace("&mode=Padding", "") : pic;

                            if (!string.IsNullOrEmpty(uniqueModernGamertag))
                            {
                                XUIDp.Text = uniqueModernGamertag;
                                XUIDp.Visible = true;
                                Steal.Visible = true;
                                Copy.Visible = true;
                                More.Visible = true;
                            }

                            if (!string.IsNullOrEmpty(gamerscore))
                            {
                                GamerScorep.Text = "Gamerscore: " + gamerscore;
                                GamerScorep.Visible = true;
                            }

                            if (!string.IsNullOrEmpty(profileGamerPic))
                            {
                                pfpp.ImageLocation = profileGamerPic;
                                pfpp.Visible = true;
                            }
                        }
                        else
                        {
                            //wyszukaj po gamertagu
                            string gamertag = searchText;

                            client.DefaultRequestHeaders.Clear();
                            client.DefaultRequestHeaders.Add("x-xbl-contract-version", "2");
                            client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate");
                            client.DefaultRequestHeaders.Add("accept", "application/json");
                            client.DefaultRequestHeaders.Add("accept-language", "en-US");
                            client.DefaultRequestHeaders.Add("Authorization", Token.Text);
                            client.DefaultRequestHeaders.Add("Host", "profile.xboxlive.com");

                            string url = $"https://profile.xboxlive.com/users/gt({gamertag})/profile/settings?settings=Gamerscore,Gamertag";

                            // Pobierz pełną odpowiedź
                            var response = await client.GetAsync(url);

                            if (!response.IsSuccessStatusCode)
                            {
                                HandleHttpError(response.StatusCode);
                                return;
                            }

                            var responseContent = await response.Content.ReadAsStringAsync();

                            var jsonResponse = JObject.Parse(responseContent);

                            // Sprawdź czy znaleziono użytkownika
                            if (jsonResponse["profileUsers"] == null || !jsonResponse["profileUsers"].Any())
                            {
                                MessageBox.Show("Gamertag not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }

                            string xuid = jsonResponse["profileUsers"]?[0]?["id"]?.ToString();
                            var settings = jsonResponse["profileUsers"]?[0]?["settings"] as JArray;

                            string gamerscore = "";

                            if (settings != null)
                            {
                                foreach (var setting in settings)
                                {
                                    string settingId = setting["id"]?.ToString();
                                    if (settingId == "Gamerscore")
                                    {
                                        gamerscore = setting["value"]?.ToString();
                                        break;
                                    }
                                }
                            }

                            if (!string.IsNullOrEmpty(xuid))
                            {
                                XUIDp.Text = xuid;
                                XUIDp.Visible = true;
                                Steal.Visible = true;
                                Copy.Visible = true;
                            }

                            if (!string.IsNullOrEmpty(gamerscore))
                            {
                                GamerScorep.Text = "Gamerscore: " + gamerscore;
                                GamerScorep.Visible = true;
                            }

                            // profile picture
                            if (!string.IsNullOrEmpty(xuid))
                            {
                                client.DefaultRequestHeaders.Clear();
                                client.DefaultRequestHeaders.Add("x-xbl-contract-version", "5");
                                client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate");
                                client.DefaultRequestHeaders.Add("accept", "application/json");
                                client.DefaultRequestHeaders.Add("accept-language", "en-US");
                                client.DefaultRequestHeaders.Add("Authorization", Token.Text);
                                client.DefaultRequestHeaders.Add("Host", "peoplehub.xboxlive.com");
                                client.DefaultRequestHeaders.Add("Connection", "Keep-Alive");

                                // Pobierz pełną odpowiedź dla zdjęcia profilowego
                                var peopleResponse = await client.GetAsync($"https://peoplehub.xboxlive.com/users/me/people/xuids({xuid})/decoration/detail,preferredColor,presenceDetail,multiplayerSummary");

                                if (!peopleResponse.IsSuccessStatusCode)
                                {
                                    HandleHttpError(peopleResponse.StatusCode);
                                    return;
                                }

                                var peopleResponseContent = await peopleResponse.Content.ReadAsStringAsync();

                                string peopleFormattedResponse = FormatJsonResponse(peopleResponseContent);
                                Bio.Text = peopleFormattedResponse;

                                var peopleJson = JObject.Parse(peopleResponseContent);

                                var pic = peopleJson["people"]?[0]?["displayPicRaw"]?.ToString();
                                string profileGamerPic = pic?.Contains("&mode=Padding") == true ? pic.Replace("&mode=Padding", "") : pic;

                                More.Visible = true;

                                if (!string.IsNullOrEmpty(profileGamerPic))
                                {
                                    pfpp.ImageLocation = profileGamerPic;
                                    pfpp.Visible = true;
                                }
                            }
                        }
                    }
                    catch (HttpRequestException ex)
                    {
                        if (ex.Message.Contains("401"))
                        {
                            MessageBox.Show("Token Expired, Close Pegasus fully and Grab New Token.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (ex.Message.Contains("429"))
                        {
                            MessageBox.Show("You've been rate limited by Xbox servers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (ex.Message.Contains("404"))
                        {
                            MessageBox.Show("Not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                else
                {
                    pfpp.Image = null;
                    pfpp.Visible = false;
                    XUIDp.Text = "";
                    XUIDp.Visible = false;
                    GamerScorep.Text = "";
                    GamerScorep.Visible = false;
                    Steal.Visible = false;
                    Copy.Visible = false;
                    More.Visible = false;
                }
            }
        }

        // Dodatkowa metoda do obsługi błędów HTTP
        private void HandleHttpError(HttpStatusCode statusCode)
        {
            switch ((int)statusCode)
            {
                case 401: // Unauthorized
                    MessageBox.Show("Token Expired, Close Pegasus fully and Grab New Token.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 429: // TooManyRequests
                    MessageBox.Show("You've been rate limited by Xbox servers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 404: // NotFound
                    MessageBox.Show("Not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                default:
                    MessageBox.Show($"HTTP Error: {(int)statusCode} {statusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private string FormatJsonResponse(string jsonResponse)
        {
            try
            {
                var jsonObject = JToken.Parse(jsonResponse);
                return FormatJToken(jsonObject, 0);
            }
            catch
            {
                // Jeśli nie uda się sparsować JSON, zwróć oryginalny tekst
                return jsonResponse;
            }
        }

        private string FormatJToken(JToken token, int indentLevel)
        {
            var indent = new string(' ', indentLevel * 2);
            var result = new StringBuilder();

            switch (token.Type)
            {
                case JTokenType.Object:
                    var obj = (JObject)token;
                    foreach (var property in obj.Properties())
                    {
                        // Pomijaj puste i null wartości
                        if (property.Value.Type == JTokenType.Null ||
                            (property.Value.Type == JTokenType.String && string.IsNullOrEmpty(property.Value.ToString())))
                            continue;

                        // Pomijaj puste tablice
                        if (property.Value.Type == JTokenType.Array && !property.Value.HasValues)
                            continue;

                        result.AppendLine($"{indent}{property.Name} : {FormatJToken(property.Value, indentLevel + 1)}");
                    }
                    break;

                case JTokenType.Array:
                    var array = (JArray)token;
                    foreach (var item in array)
                    {
                        result.AppendLine($"{indent}- {FormatJToken(item, indentLevel + 1)}");
                    }
                    break;

                case JTokenType.String:
                    var strValue = token.ToString();
                    // Usuń znaki nowej linii z wartości string aby nie psuły formatowania
                    strValue = strValue.Replace("\r", "").Replace("\n", " ");
                    result.Append(strValue);
                    break;

                default:
                    result.Append(token.ToString());
                    break;
            }

            return result.ToString().TrimEnd();
        }

        private void Copy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(XUIDp.Text);
            toolTip.Show("Copied", Copy, 0, -20, 2000);
        }

        private void More_Click(object sender, EventArgs e)
        {
            MorePanel.Visible = true;
            MorePanel.BringToFront();
            Bio.Focus();
        }

        private async void Steal_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(XUIDp.Text))
            {
                MessageBox.Show("No XUID found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Steal.Visible = false;

            try
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("x-xbl-contract-version", "2");
                client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate");
                client.DefaultRequestHeaders.Add("accept", "application/json");
                client.DefaultRequestHeaders.Add("accept-language", "en-US");
                client.DefaultRequestHeaders.Add("Authorization", Token.Text);
                client.DefaultRequestHeaders.Add("Host", "titlehub.xboxlive.com");

                // if first character is leter use search text, if not use XUIDp Text
                string xuidValue = char.IsLetter(XUIDp.Text[0]) ? search.Text : XUIDp.Text;

                string url = $"https://titlehub.xboxlive.com/users/xuid({xuidValue})/titles/titleHistory/decoration/Achievement?maxItems=100000";
                var responseString = await client.GetStringAsync(url);
                var jsonResponse = JObject.Parse(responseString);

                var titles = jsonResponse["titles"] as JArray;

                if (titles == null || titles.Count == 0)
                {
                    Steal.Visible = true;
                    MessageBox.Show("No titles found for this user.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                StringBuilder fileContent = new StringBuilder();

                foreach (var title in titles)
                {
                    string titleId = title["titleId"]?.ToString();
                    string name = title["name"]?.ToString();

                    if (!string.IsNullOrEmpty(titleId) && !string.IsNullOrEmpty(name))
                    {
                        fileContent.AppendLine($"{titleId},{name}");
                    }
                }

                if (fileContent.Length == 0)
                {
                    Steal.Visible = true;
                    MessageBox.Show("No valid titles found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Steal.Visible = true;

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                    saveFileDialog.DefaultExt = "txt";
                    saveFileDialog.FileName = search.Text;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(saveFileDialog.FileName, fileContent.ToString());
                        MessageBox.Show($"Successfully saved {titles.Count} titles to file.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                if (ex.Message.Contains("401"))
                {
                    MessageBox.Show("Token Expired, Close Pegasus fully and Grab New Token.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (ex.Message.Contains("429"))
                {
                    MessageBox.Show("You've been rate limited by Xbox servers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (ex.Message.Contains("404"))
                {
                    MessageBox.Show("is that even possible??", "lol", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private async void DumpL_Click(object sender, EventArgs e)
        {
            try
            {
                DumpL.Visible = false;
                Loading.Visible = true;
                // Pierwszy request - pobieranie listy productId
                string jsonRequest = "{\"Filters\":\"e30=\",\"ReturnFilters\":false,\"ChannelKeyToBeUsedInResponse\":\"BROWSE_CHANNELID=DYNAMICCHANNEL.NEWGAMES_FILTERS=\",\"ChannelId\":\"DynamicChannel.newgames\"}";
                string url = "https://emerald.xboxservices.com/xboxcomfd/browse?locale=en-US";

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("ms-cv", "Om86GY70bGsPYBBTWH5Jka.19");
                client.DefaultRequestHeaders.Add("x-ms-api-version", "1.1");
                client.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/140.0.0.0 Safari/537.36");
                client.DefaultRequestHeaders.Add("accept", "*/*");
                client.DefaultRequestHeaders.Add("accept-language", "en-US");

                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url, content);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                // Parsowanie odpowiedzi i wyciąganie productId
                dynamic jsonResponse = Newtonsoft.Json.JsonConvert.DeserializeObject(responseBody);
                var products = jsonResponse.channels["BROWSE_CHANNELID=DYNAMICCHANNEL.NEWGAMES_FILTERS="].products;

                List<string> productIds = new List<string>();
                foreach (var product in products)
                {
                    productIds.Add((string)product.productId);
                }

                // Usuwanie duplikatów productId
                productIds = productIds.Distinct().ToList();

                // Drugi request - pobieranie szczegółów gier (w partiach po 2)
                List<string> results = new List<string>();
                List<List<string>> failedBatches = new List<List<string>>();
                int batchSize = 2;

                // Pierwsza próba - wszystkie partie
                for (int i = 0; i < productIds.Count; i += batchSize)
                {
                    var batch = productIds.Skip(i).Take(batchSize).ToList();

                    try
                    {
                        await ProcessBatch(batch, results);
                    }
                    catch (HttpRequestException ex) when (ex.Message.Contains("500"))
                    {
                        // Zapisujemy partie z błędem na później
                        failedBatches.Add(batch);
                    }
                    catch
                    {
                        // Inne błędy też zapisujemy
                        failedBatches.Add(batch);
                    }

                    await Task.Delay(10);
                }

                // Druga próba - partie z błędami, próbujemy każdy ID osobno
                foreach (var failedBatch in failedBatches)
                {
                    foreach (var productId in failedBatch)
                    {
                        var singleItemBatch = new List<string> { productId };

                        try
                        {
                            await ProcessBatch(singleItemBatch, results);
                        }
                        catch
                        {
                            // Jeśli nadal error, olej to
                        }

                        await Task.Delay(100);
                    }
                }

                // Usuwanie duplikatów po titleId
                var uniqueResults = results
                    .GroupBy(line => line.Split(',')[0])
                    .Select(group => group.First())
                    .ToList();

                // Zapisywanie do pliku
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.DefaultExt = "txt";
                saveFileDialog.FileName = $"New_Games_{DateTime.Now:yyyyMMdd_HHmmss}.txt";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllLines(saveFileDialog.FileName, uniqueResults);
                    MessageBox.Show($"Saved {uniqueResults.Count} new games!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                DumpL.Visible = true;
                Loading.Visible = false;
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DumpL.Visible = true;
                Loading.Visible = false;
            }
        }

        private async Task ProcessBatch(List<string> batch, List<string> results)
        {
            string productsJson = string.Join(",", batch.Select(id => $"\"{id}\""));
            string jsonRequest2 = $"{{\"Products\":[{productsJson}]}}";

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate");
            client.DefaultRequestHeaders.Add("accept-language", "en-US");
            client.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
            client.DefaultRequestHeaders.Add("accept", "application/json");

            var content2 = new StringContent(jsonRequest2, Encoding.UTF8, "application/json");
            var response2 = await client.PostAsync("https://catalog.gamepass.com/products?market=US&language=en-US&hydration=PCLowAmber0", content2);
            response2.EnsureSuccessStatusCode();

            string responseBody2 = await response2.Content.ReadAsStringAsync();
            dynamic jsonResponse2 = Newtonsoft.Json.JsonConvert.DeserializeObject(responseBody2);

            // Wyciąganie XBOXTITLEID i title
            foreach (var prop in jsonResponse2.Products)
            {
                foreach (var game in prop)
                {
                    string title = game.title;
                    string xboxTitleId = "";

                    foreach (var altId in game.alternateIds)
                    {
                        if (altId.idType == "XBOXTITLEID")
                        {
                            xboxTitleId = altId.id;
                            break;
                        }
                    }

                    if (!string.IsNullOrEmpty(xboxTitleId) && !string.IsNullOrEmpty(title))
                    {
                        results.Add($"{xboxTitleId},{title}");
                    }
                }
            }
        }

        private async void Merge_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Choose couple of Title ID Lists you want to Merge";
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.Multiselect = true;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Słownik do przechowywania unikalnych wpisów (klucz = ID przed przecinkiem)
                        Dictionary<string, string> mergedEntries = new Dictionary<string, string>();

                        // Przetwarzanie każdego wybranego pliku
                        foreach (string filePath in openFileDialog.FileNames)
                        {
                            string[] lines = await Task.Run(() => File.ReadAllLines(filePath));

                            foreach (string line in lines)
                            {
                                if (string.IsNullOrWhiteSpace(line))
                                    continue;

                                // Pobierz ID przed pierwszym przecinkiem (lub całą linię jeśli nie ma przecinka)
                                string titleId = line.Contains(",") ? line.Split(',')[0].Trim() : line.Trim();

                                // Dodaj tylko jeśli nie ma jeszcze takiego ID
                                if (!mergedEntries.ContainsKey(titleId))
                                {
                                    mergedEntries[titleId] = line;
                                }
                            }
                        }

                        // Zapisz połączone dane
                        if (mergedEntries.Count > 0)
                        {
                            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                            {
                                saveFileDialog.Filter = "Text files (*.txt)|*.txt";
                                saveFileDialog.Title = "Save Merged List";
                                saveFileDialog.FileName = "merged_list.txt";

                                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                                {
                                    await Task.Run(() =>
                                        File.WriteAllLines(saveFileDialog.FileName, mergedEntries.Values)
                                    );

                                    MessageBox.Show($"Successfully merged {mergedEntries.Count} unique entries!",
                                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("No valid entries found in selected files.",
                                "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error during merge: {ex.Message}",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private async void ClearShit_Click(object sender, EventArgs e)
        {
            try
            {
                // Wybór pliku
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Text files (*.txt)|*.txt";
                    openFileDialog.Title = "Select .txt file with Title IDs";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        selectedFilePath = openFileDialog.FileName;

                        LoadTitleIdsFromTxt(selectedFilePath);

                        if (titleIds.Count == 0)
                        {
                            MessageBox.Show("No valid Title IDs found in the file.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Załaduj not supported list
                        LoadNotSupportedList();

                        // Usuń not supported titles
                        int originalCount = titleIds.Count;
                        titleIds = titleIds.Where(id => !notSupportedIds.Contains(id)).ToList();
                        int removedCount = originalCount - titleIds.Count;

                        if (titleIds.Count == 0)
                        {
                            MessageBox.Show("All Title IDs are in the not supported list.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Check token
                        if (string.IsNullOrWhiteSpace(Token.Text))
                        {
                            MessageBox.Show("Token is missing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        string message = $"Loaded {originalCount} Title IDs.";
                        if (removedCount > 0)
                        {
                            message += $"\nRemoved {removedCount} not supported IDs.";
                        }
                        message += $"\nProcessing {titleIds.Count} Title IDs...";

                        MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Przetwórz Title IDs
                        await ProcessTitleIds();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<string> notSupportedIds = new List<string>();

        private void LoadNotSupportedList()
        {
            try
            {
                notSupportedIds.Clear();
                string exePath = AppDomain.CurrentDomain.BaseDirectory;
                string notSupportedPath = Path.Combine(exePath, "not supported.txt");

                if (File.Exists(notSupportedPath))
                {
                    foreach (string line in File.ReadLines(notSupportedPath))
                    {
                        // read only line before first "," if exist
                        string titleId = line.Contains(",") ? line.Split(',')[0].Trim() : line.Trim();
                        if (!string.IsNullOrWhiteSpace(titleId))
                        {
                            notSupportedIds.Add(titleId);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load not supported list: {ex.Message}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                notSupportedIds.Clear();
            }
        }

        private void LoadTitleIdsFromTxt(string filePath)
        {
            try
            {
                titleIds.Clear();
                HashSet<string> uniqueTitleIds = new HashSet<string>(StringComparer.OrdinalIgnoreCase); // Ignoruj wielkość liter
                int totalLines = 0; // Licznik wszystkich wczytanych linii
                int invalidLines = 0; // Licznik niepoprawnych linii

                foreach (string line in File.ReadLines(filePath))
                {
                    totalLines++;
                    // Wczytaj tylko linię przed pierwszym przecinkiem, jeśli istnieje
                    string titleId = line.Contains(",") ? line.Split(',')[0].Trim() : line.Trim();

                    if (!string.IsNullOrWhiteSpace(titleId))
                    {
                        uniqueTitleIds.Add(titleId); // HashSet automatycznie usuwa duplikaty
                    }
                    else
                    {
                        invalidLines++; // Zlicz puste lub niepoprawne linie
                    }
                }

                titleIds.AddRange(uniqueTitleIds); // Przekonwertuj HashSet na listę

                // Wyświetl komunikat o wczytaniu i duplikatach
                int duplicatesRemoved = totalLines - invalidLines - uniqueTitleIds.Count;
                string message = $"Loaded {uniqueTitleIds.Count} unique Title IDs from {totalLines} lines.";
                if (duplicatesRemoved > 0)
                {
                    message += $"\nRemoved {duplicatesRemoved} duplicate Title IDs.";
                }
                if (invalidLines > 0)
                {
                    message += $"\nSkipped {invalidLines} invalid or empty lines.";
                }

                if (titleIds.Count == 0)
                {
                    message += "\nNo valid Title IDs found in the file.";
                    MessageBox.Show(message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                titleIds.Clear();
            }
        }

        private async Task ProcessTitleIds()
        {
            try
            {
                List<FilteredTitle> allFilteredTitles = new List<FilteredTitle>();

                // Sprawdź czy trzeba podzielić na części
                if (titleIds.Count > 8000)
                {
                    // Podziel na 3 części
                    var chunks = SplitList(titleIds, 3);

                    for (int i = 0; i < chunks.Count; i++)
                    {
                        MessageBox.Show($"Processing part {i + 1} of 3 ({chunks[i].Count} IDs)...", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        var results = await ProcessTitleIdsBatch(chunks[i]);
                        allFilteredTitles.AddRange(results);
                    }
                }
                else if (titleIds.Count > 4800)
                {
                    // Podziel na 2 części
                    var chunks = SplitList(titleIds, 2);

                    for (int i = 0; i < chunks.Count; i++)
                    {
                        MessageBox.Show($"Processing part {i + 1} of 2 ({chunks[i].Count} IDs)...", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        var results = await ProcessTitleIdsBatch(chunks[i]);
                        allFilteredTitles.AddRange(results);
                    }
                }
                else
                {
                    // Wyślij jednym requestem
                    allFilteredTitles = await ProcessTitleIdsBatch(titleIds);
                }

                // Zapisz wyniki
                await SaveFilteredTitlesToTxt(allFilteredTitles);

                MessageBox.Show($"Processing completed!\n\nOriginal Count: {titleIds.Count}\nFiltered Count: {allFilteredTitles.Count}\n\nFile saved successfully.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing titles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<List<string>> SplitList(List<string> list, int parts)
        {
            var result = new List<List<string>>();
            int chunkSize = (int)Math.Ceiling((double)list.Count / parts);

            for (int i = 0; i < parts; i++)
            {
                var chunk = list.Skip(i * chunkSize).Take(chunkSize).ToList();
                if (chunk.Count > 0)
                {
                    result.Add(chunk);
                }
            }

            return result;
        }

        private async Task<List<FilteredTitle>> ProcessTitleIdsBatch(List<string> batchTitleIds)
        {
            try
            {
                var requestBody = new
                {
                    titleIds = batchTitleIds
                };

                string jsonBody = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("host", "titlehub.xboxlive.com");
                client.DefaultRequestHeaders.Add("authorization", Token.Text);
                client.DefaultRequestHeaders.Add("x-xbl-contract-version", "2");
                client.DefaultRequestHeaders.Add("accept-language", "en-US");

                HttpResponseMessage response = await client.PostAsync(
                    "https://titlehub.xboxlive.com/titles/batch/decoration/Achievement,detail,scid?maxItems=10000",
                    content
                );

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"Request failed with status code {response.StatusCode}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new List<FilteredTitle>();
                }

                string responseContent = await response.Content.ReadAsStringAsync();
                var responseData = JsonConvert.DeserializeObject<TitleHubResponse>(responseContent);

                if (responseData?.Titles == null)
                {
                    return new List<FilteredTitle>();
                }

                return FilterTitles(responseData.Titles);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing batch: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<FilteredTitle>();
            }
        }

        private List<FilteredTitle> FilterTitles(List<Title> titles)
        {
            return titles
                .Where(t => t.Devices != null &&
                           !t.Devices.Contains("Xbox360") &&
                           !t.Devices.Contains("Mobile") &&
                           t.Achievement != null &&
                           t.Achievement.TotalGamerscore >= 1000)
                .Select(t => new FilteredTitle
                {
                    TitleId = t.TitleId,
                    Name = t.Name
                })
                .ToList();
        }

        private async Task SaveFilteredTitlesToTxt(List<FilteredTitle> filteredTitles)
        {
            try
            {
                if (filteredTitles == null || filteredTitles.Count == 0)
                {
                    MessageBox.Show("No titles to save.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string defaultFileName = $"ClearedList_{DateTime.Now:yyyyMMdd_HHmmss}.txt";

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                    saveFileDialog.DefaultExt = "txt";
                    saveFileDialog.FileName = defaultFileName;
                    saveFileDialog.InitialDirectory = @"C:\Pegasus Revived";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        await Task.Run(() =>
                        {
                            using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName, false, Encoding.UTF8))
                            {
                                foreach (var title in filteredTitles)
                                {
                                    writer.WriteLine($"{title.TitleId},{title.Name}");
                                }
                            }
                        });

                        MessageBox.Show($"Successfully saved {filteredTitles.Count} titles to file:\n{saveFileDialog.FileName}",
                            "File Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Save cancelled.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // shit classes lol
        public class TitleHubResponse
        {
            public string Xuid { get; set; }
            public List<Title> Titles { get; set; }
        }

        public class Title
        {
            public string TitleId { get; set; }
            public string Name { get; set; }
            public List<string> Devices { get; set; }
            public Achievement Achievement { get; set; }
        }

        public class Achievement
        {
            public int TotalGamerscore { get; set; }
        }

        public class FilteredTitle
        {
            public string TitleId { get; set; }
            public string Name { get; set; }
        }


        // 
        private void Close_Click(object sender, EventArgs e)
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

        private async void refresh_Click(object sender, EventArgs e)
        {
            await LoadProfile();
        }

        private void Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void ClosePanel_Click(object sender, EventArgs e)
        {
            MorePanel.Visible = false;
        }
    }
}