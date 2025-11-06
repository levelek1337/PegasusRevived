using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Halo_5_ultra_white_emblem;
using Newtonsoft.Json.Linq;
using Siticone.Desktop.UI.WinForms;

namespace PegasusV2Beta
{
    public partial class main : Form
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

        public main()
        {
            InitializeComponent();
            siticonePanel2.MouseDown += new MouseEventHandler(Panel_MouseDown);
            siticonePanel2.MouseMove += new MouseEventHandler(Panel_MouseMove);
            siticonePanel2.MouseUp += new MouseEventHandler(Panel_MouseUp);
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
        private async void pictureBox4_Click(object sender, EventArgs e)
        {
            main_Load(sender, e);
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

                // Load profile picture into pictureBox3
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

        private async void main_Load(object sender, EventArgs e)
        {
            await LoadProfile();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            siticonePanel1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            siticonePanel1.Visible = false;
        }

        private void Select2_Click(object sender, EventArgs e)
        {
            // open auto unlocker (deleted from public src)
        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            siticonePanel1.Visible = false;
            // Sprawdź, czy forma Achievements już istnieje
            Achievements formMain = Application.OpenForms.OfType<Achievements>().FirstOrDefault();

            if (formMain == null)
            {
                // Jeśli nie istnieje, utwórz nową instancję
                formMain = new Achievements();
                formMain.FormClosed += (o, y) => Application.Exit();  // Zamknij aplikację po zamknięciu formy
            }
            else
            {
                // Jeśli istnieje, przywróć z minimalizacji (jeśli potrzeba) i aktywuj
                if (formMain.WindowState == FormWindowState.Minimized)
                {
                    formMain.WindowState = FormWindowState.Normal;
                }
                formMain.Activate();
            }

            // Ukryj bieżące okno
            this.Hide();

            // Pokaż formę (jeśli nowa lub istniejąca)
            formMain.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            // pfp lol maybe in future something idk
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            // Sprawdź, czy forma Avatar już istnieje
            Avatar formMain = Application.OpenForms.OfType<Avatar>().FirstOrDefault();

            if (formMain == null)
            {
                // Jeśli nie istnieje, utwórz nową instancję
                formMain = new Avatar();
                formMain.FormClosed += (o, y) => Application.Exit();  // Zamknij aplikację po zamknięciu formy
            }
            else
            {
                // Jeśli istnieje, przywróć z minimalizacji (jeśli potrzeba) i aktywuj
                if (formMain.WindowState == FormWindowState.Minimized)
                {
                    formMain.WindowState = FormWindowState.Normal;
                }
                formMain.Activate();
            }

            // Ukryj bieżące okno
            this.Hide();

            // Pokaż formę (jeśli nowa lub istniejąca)
            formMain.Show();
        }
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            // Sprawdź, czy forma już istnieje
            Halo5 formMain = Application.OpenForms.OfType<Halo5>().FirstOrDefault();

            if (formMain == null)
            {
                // Jeśli nie istnieje, utwórz nową instancję
                formMain = new Halo5();
                formMain.FormClosed += (o, y) => Application.Exit();  // Zamknij aplikację po zamknięciu formy
            }
            else
            {
                // Jeśli istnieje, przywróć z minimalizacji (jeśli potrzeba) i aktywuj
                if (formMain.WindowState == FormWindowState.Minimized)
                {
                    formMain.WindowState = FormWindowState.Normal;
                }
                formMain.Activate();
            }

            // Ukryj bieżące okno
            this.Hide();

            // Pokaż formę (jeśli nowa lub istniejąca)
            formMain.Show();
        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            // open minecraft tool (deleted from public src)
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            // open party tool (deleted from public src)
        }


        private void pictureBox10_Click(object sender, EventArgs e)
        {
            // Sprawdź, czy forma już istnieje
            Profile formMain = Application.OpenForms.OfType<Profile>().FirstOrDefault();

            if (formMain == null)
            {
                // Jeśli nie istnieje, utwórz nową instancję
                formMain = new Profile();
                formMain.FormClosed += (o, y) => Application.Exit();  // Zamknij aplikację po zamknięciu formy
            }
            else
            {
                // Jeśli istnieje, przywróć z minimalizacji (jeśli potrzeba) i aktywuj
                if (formMain.WindowState == FormWindowState.Minimized)
                {
                    formMain.WindowState = FormWindowState.Normal;
                }
                formMain.Activate();
            }

            // Ukryj bieżące okno
            this.Hide();

            // Pokaż formę (jeśli nowa lub istniejąca)
            formMain.Show();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            // Sprawdź, czy forma już istnieje
            Info formMain = Application.OpenForms.OfType<Info>().FirstOrDefault();

            if (formMain == null)
            {
                // Jeśli nie istnieje, utwórz nową instancję
                formMain = new Info();
                formMain.FormClosed += (o, y) => Application.Exit();  // Zamknij aplikację po zamknięciu formy
            }
            else
            {
                // Jeśli istnieje, przywróć z minimalizacji (jeśli potrzeba) i aktywuj
                if (formMain.WindowState == FormWindowState.Minimized)
                {
                    formMain.WindowState = FormWindowState.Normal;
                }
                formMain.Activate();
            }

            // Ukryj bieżące okno
            this.Hide();

            // Pokaż formę (jeśli nowa lub istniejąca)
            formMain.Show();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            // Sprawdź, czy forma już istnieje
            XUIDS formMain = Application.OpenForms.OfType<XUIDS>().FirstOrDefault();

            if (formMain == null)
            {
                // Jeśli nie istnieje, utwórz nową instancję
                formMain = new XUIDS();
                formMain.FormClosed += (o, y) => Application.Exit();  // Zamknij aplikację po zamknięciu formy
            }
            else
            {
                // Jeśli istnieje, przywróć z minimalizacji (jeśli potrzeba) i aktywuj
                if (formMain.WindowState == FormWindowState.Minimized)
                {
                    formMain.WindowState = FormWindowState.Normal;
                }
                formMain.Activate();
            }

            // Ukryj bieżące okno
            this.Hide();

            // Pokaż formę (jeśli nowa lub istniejąca)
            formMain.Show();
        }

        private async void ReLoad_Click(object sender, EventArgs e)
        {
            await LoadProfile();
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}