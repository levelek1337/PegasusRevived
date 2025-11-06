using PegasusV2Beta;
using Siticone.Desktop.UI.WinForms;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace Halo_5_ultra_white_emblem
{
    public class Halo5 : Form
    {
        private IContainer components = null;
        private SiticoneButton Layer2;
        private SiticoneButton Layer1;
        private SiticoneButton Layer3;
        private SiticoneButton AllLayers;
        private SiticoneTextBox Gamertag;
        private SiticoneTextBox Token;
        private Button button5;
        private Button minimize;
        private Label label1;
        private const int WM_NCLBUTTONDBLCLK = 0x00A3; // Message for double-click
        private const int WM_NCHITTEST = 0x0084;      // Message for hit test
        private const int HTCLIENT = 0x1;             // Client area
        private const int HTCAPTION = 0x2;            // Caption (title bar)

        public Halo5() => InitializeComponent();

        private void Form1_Load(object sender, EventArgs e)
        {
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

        private void Layer1_Click(object sender, EventArgs e)
        {
            try
            {
                string str1 = "{\"Model\":{\"Gender\":null},\"Emblem\":{\"ColorPrimary\":60,\"ColorSecondary\":null,\"ColorTertiary\":null,\"EmblemId\":null,\"HarmonyGroupIndex\":null,\"HarmonyIndex\":null},\"ModelCustomization\":{\"ColorPrimary\":null,\"ColorSecondary\":null,\"WeaponSkinIds\":null,\"HelmetId\":null,\"VisorId\":null,\"ArmorSuitId\":null,\"DeathFX\":0,\"Assassination\":null,\"StanceRotation\":null,\"StanceZoom\":0,\"VoiceOver\":null},\"StanceId\":null,\"Gamertag\":\"" + this.Gamertag.Text + "\",\"DateFidelity\":2,\"Links\":[],\"LastModifiedUtc\":{\"ISO8601Date\":\"2022-06-21T02:50:37.374Z\"},\"FirstModifiedUtc\":{\"ISO8601Date\":\"2022-06-21T02:45:48.979Z\"},\"StatusCode\":0,\"ServiceTag\":\"null\",\"Company\":null}";
                int length = str1.Length;
                HttpWebRequest httpWebRequest = WebRequest.Create("https://haloplayer.svc.halowaypoint.com/h5/profiles/" + this.Gamertag.Text + "/appearance") as HttpWebRequest;
                httpWebRequest.Method = "PATCH";
                httpWebRequest.Headers.Add("x-343-authorization-spartan", this.Token.Text);
                httpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
                httpWebRequest.Headers.Add("Accept-Language", "en-US");
                httpWebRequest.Headers.Add("343-clearance", "1af109f1-41bd-4d73-8182-02612049dd39");
                httpWebRequest.ContentType = "application/json, text/plain, */*";
                httpWebRequest.Headers.Add("Cache-Control", "no-cache");
                httpWebRequest.ContentLength = length;
                using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(str1);
                    streamWriter.Flush();
                }
            }
            catch (Exception)
            {

            }
        }

        private void Layer2_Click(object sender, EventArgs e)
        {
            try
            {
                string str1 = "{\"Model\":{\"Gender\":null},\"Emblem\":{\"ColorPrimary\":null,\"ColorSecondary\":60,\"ColorTertiary\":null,\"EmblemId\":null,\"HarmonyGroupIndex\":null,\"HarmonyIndex\":null},\"ModelCustomization\":{\"ColorPrimary\":null,\"ColorSecondary\":null,\"WeaponSkinIds\":null,\"HelmetId\":null,\"VisorId\":null,\"ArmorSuitId\":null,\"DeathFX\":0,\"Assassination\":null,\"StanceRotation\":null,\"StanceZoom\":0,\"VoiceOver\":null},\"StanceId\":null,\"Gamertag\":\"" + this.Gamertag.Text + "\",\"DateFidelity\":2,\"Links\":[],\"LastModifiedUtc\":{\"ISO8601Date\":\"2022-06-21T02:50:37.374Z\"},\"FirstModifiedUtc\":{\"ISO8601Date\":\"2022-06-21T02:45:48.979Z\"},\"StatusCode\":0,\"ServiceTag\":\"null\",\"Company\":null}";
                int length = str1.Length;
                HttpWebRequest httpWebRequest = WebRequest.Create("https://haloplayer.svc.halowaypoint.com/h5/profiles/" + this.Gamertag.Text + "/appearance") as HttpWebRequest;
                httpWebRequest.Method = "PATCH";
                httpWebRequest.Headers.Add("x-343-authorization-spartan", this.Token.Text);
                httpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
                httpWebRequest.Headers.Add("Accept-Language", "en-US");
                httpWebRequest.Headers.Add("343-clearance", "1af109f1-41bd-4d73-8182-02612049dd39");
                httpWebRequest.ContentType = "application/json, text/plain, */*";
                httpWebRequest.Headers.Add("Cache-Control", "no-cache");
                httpWebRequest.ContentLength = length;
                using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(str1);
                    streamWriter.Flush();
                }
            }
            catch (Exception)
            {

            }
        }

        private void Layer3_Click(object sender, EventArgs e)
        {
            try
            {
                string str1 = "{\"Model\":{\"Gender\":null},\"Emblem\":{\"ColorPrimary\":null,\"ColorSecondary\":null,\"ColorTertiary\":60,\"EmblemId\":null,\"HarmonyGroupIndex\":null,\"HarmonyIndex\":null},\"ModelCustomization\":{\"ColorPrimary\":null,\"ColorSecondary\":null,\"WeaponSkinIds\":null,\"HelmetId\":null,\"VisorId\":null,\"ArmorSuitId\":null,\"DeathFX\":0,\"Assassination\":null,\"StanceRotation\":null,\"StanceZoom\":0,\"VoiceOver\":null},\"StanceId\":null,\"Gamertag\":\"" + this.Gamertag.Text + "\",\"DateFidelity\":2,\"Links\":[],\"LastModifiedUtc\":{\"ISO8601Date\":\"2022-06-21T02:50:37.374Z\"},\"FirstModifiedUtc\":{\"ISO8601Date\":\"2022-06-21T02:45:48.979Z\"},\"StatusCode\":0,\"ServiceTag\":\"null\",\"Company\":null}";
                int length = str1.Length;
                HttpWebRequest httpWebRequest = WebRequest.Create("https://haloplayer.svc.halowaypoint.com/h5/profiles/" + this.Gamertag.Text + "/appearance") as HttpWebRequest;
                httpWebRequest.Method = "PATCH";
                httpWebRequest.Headers.Add("x-343-authorization-spartan", this.Token.Text);
                httpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
                httpWebRequest.Headers.Add("Accept-Language", "en-US");
                httpWebRequest.Headers.Add("343-clearance", "1af109f1-41bd-4d73-8182-02612049dd39");
                httpWebRequest.ContentType = "application/json, text/plain, */*";
                httpWebRequest.Headers.Add("Cache-Control", "no-cache");
                httpWebRequest.ContentLength = length;
                using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(str1);
                    streamWriter.Flush();
                }
            }
            catch (Exception)
            {

            }
        }

        private void AllLayers_Click(object sender, EventArgs e)
        {
            try
            {
                string str1 = "{\"Model\":{\"Gender\":null},\"Emblem\":{\"ColorPrimary\":60,\"ColorSecondary\":60,\"ColorTertiary\":60,\"EmblemId\":null,\"HarmonyGroupIndex\":null,\"HarmonyIndex\":null},\"ModelCustomization\":{\"ColorPrimary\":null,\"ColorSecondary\":null,\"WeaponSkinIds\":null,\"HelmetId\":null,\"VisorId\":null,\"ArmorSuitId\":null,\"DeathFX\":0,\"Assassination\":null,\"StanceRotation\":null,\"StanceZoom\":0,\"VoiceOver\":null},\"StanceId\":null,\"Gamertag\":\"" + this.Gamertag.Text + "\",\"DateFidelity\":2,\"Links\":[],\"LastModifiedUtc\":{\"ISO8601Date\":\"2022-06-21T02:50:37.374Z\"},\"FirstModifiedUtc\":{\"ISO8601Date\":\"2022-06-21T02:45:48.979Z\"},\"StatusCode\":0,\"ServiceTag\":\"null\",\"Company\":null}";
                int length = str1.Length;
                HttpWebRequest httpWebRequest = WebRequest.Create("https://haloplayer.svc.halowaypoint.com/h5/profiles/" + this.Gamertag.Text + "/appearance") as HttpWebRequest;
                httpWebRequest.Method = "PATCH";
                httpWebRequest.Headers.Add("x-343-authorization-spartan", this.Token.Text);
                httpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
                httpWebRequest.Headers.Add("Accept-Language", "en-US");
                httpWebRequest.Headers.Add("343-clearance", "1af109f1-41bd-4d73-8182-02612049dd39");
                httpWebRequest.ContentType = "application/json, text/plain, */*";
                httpWebRequest.Headers.Add("Cache-Control", "no-cache");
                httpWebRequest.ContentLength = length;
                using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(str1);
                    streamWriter.Flush();
                }
            }
            catch (Exception)
            {

            }
        }

        private void button5_Click(object sender, EventArgs e)
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

        private void minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Layer2 = new SiticoneButton();
            this.Layer1 = new SiticoneButton();
            this.Layer3 = new SiticoneButton();
            this.AllLayers = new SiticoneButton();
            this.Gamertag = new SiticoneTextBox();
            this.Token = new SiticoneTextBox();
            this.button5 = new Button();
            this.minimize = new Button();
            this.label1 = new Label();
            this.SuspendLayout();

            // Layer2
            this.Layer2.BorderColor = Color.White;
            this.Layer2.BorderRadius = 23;
            this.Layer2.Margin = new System.Windows.Forms.Padding(2);
            this.Layer2.FillColor = Color.FromArgb(25, 27, 33);
            this.Layer2.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Italic, GraphicsUnit.Point, 0);
            this.Layer2.ForeColor = Color.White;
            this.Layer2.Location = new Point(351, 149);
            this.Layer2.Name = "Layer2";
            this.Layer2.Size = new Size(150, 45);
            this.Layer2.TabIndex = 199;
            this.Layer2.Text = "Layer 2";
            this.Layer2.Click += new EventHandler(this.Layer2_Click);

            // Layer1
            this.Layer1.BorderColor = Color.White;
            this.Layer1.BorderRadius = 23;
            this.Layer1.Margin = new System.Windows.Forms.Padding(2);
            this.Layer1.FillColor = Color.FromArgb(25, 27, 33);
            this.Layer1.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Italic, GraphicsUnit.Point, 0);
            this.Layer1.ForeColor = Color.White;
            this.Layer1.Location = new Point(179, 149);
            this.Layer1.Name = "Layer1";
            this.Layer1.Size = new Size(150, 45);
            this.Layer1.TabIndex = 200;
            this.Layer1.Text = "Layer 1";
            this.Layer1.Click += new EventHandler(this.Layer1_Click);

            // Layer3
            this.Layer3.BorderColor = Color.White;
            this.Layer3.BorderRadius = 23;
            this.Layer3.Margin = new System.Windows.Forms.Padding(2);
            this.Layer3.FillColor = Color.FromArgb(25, 27, 33);
            this.Layer3.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Italic, GraphicsUnit.Point, 0);
            this.Layer3.ForeColor = Color.White;
            this.Layer3.Location = new Point(529, 149);
            this.Layer3.Name = "Layer3";
            this.Layer3.Size = new Size(150, 45);
            this.Layer3.TabIndex = 201;
            this.Layer3.Text = "Layer 3";
            this.Layer3.Click += new EventHandler(this.Layer3_Click);

            // AllLayers
            this.AllLayers.BorderColor = Color.White;
            this.AllLayers.BorderRadius = 23;
            this.AllLayers.Margin = new System.Windows.Forms.Padding(2);
            this.AllLayers.FillColor = Color.FromArgb(25, 27, 33);
            this.AllLayers.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Italic, GraphicsUnit.Point, 0);
            this.AllLayers.ForeColor = Color.White;
            this.AllLayers.Location = new Point(351, 221);
            this.AllLayers.Name = "AllLayers";
            this.AllLayers.Size = new Size(150, 45);
            this.AllLayers.TabIndex = 202;
            this.AllLayers.Text = "All Layers";
            this.AllLayers.Click += new EventHandler(this.AllLayers_Click);

            // Gamertag
            this.Gamertag.Location = new Point(12, 26);
            this.Gamertag.Name = "Gamertag";
            this.Gamertag.PlaceholderText = "Gamertag";
            this.Gamertag.PlaceholderForeColor = System.Drawing.Color.Lime;
            this.Gamertag.Size = new Size(100, 20);
            this.Gamertag.TabIndex = 203;
            this.Gamertag.FillColor = System.Drawing.Color.Black;

            // Token
            this.Token.Location = new Point(12, 67);
            this.Token.Name = "Token";
            this.Token.Size = new Size(100, 20);
            this.Token.TabIndex = 205;
            this.Token.PlaceholderText = "Token V4";
            this.Token.PlaceholderForeColor = System.Drawing.Color.Lime;
            this.Token.FillColor = System.Drawing.Color.Black;

            // Close button
            this.button5.BackColor = Color.Transparent;
            this.button5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ForeColor = Color.Black;
            this.button5.Location = new Point(770, 0);
            this.button5.Name = "button5";
            this.button5.Size = new Size(30, 30);
            this.button5.TabIndex = 53;
            this.button5.Text = "×";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new EventHandler(this.button5_Click);

            // minimize
            this.minimize.BackColor = System.Drawing.Color.Transparent;
            this.minimize.FlatAppearance.BorderSize = 0;
            this.minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimize.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.minimize.ForeColor = System.Drawing.Color.Black;
            this.minimize.Location = new Point(740, 0);
            this.minimize.Name = "minimize";
            this.minimize.Size = new Size(30, 30);
            this.minimize.TabIndex = 53;
            this.minimize.Text = "–";
            this.minimize.UseVisualStyleBackColor = false;
            this.minimize.Click += new EventHandler(this.minimize_Click);

            // Label
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label1.Location = new Point(255, 25);
            this.label1.Name = "label1";
            this.label1.Size = new Size(354, 20);
            this.label1.TabIndex = 260;
            this.label1.Text = "Halo 5 Ultra White Emblem Color By SpriTe";

            // Form settings
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 319);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.minimize);
            this.Controls.Add(this.Token);
            this.Controls.Add(this.Gamertag);
            this.Controls.Add(this.AllLayers);
            this.Controls.Add(this.Layer3);
            this.Controls.Add(this.Layer1);
            this.Controls.Add(this.Layer2);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Name = nameof(Halo5);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = nameof(Halo5);
            this.Icon = PegasusRevived.Properties.Resources.Icon;
            this.Load += new EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}