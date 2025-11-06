namespace PegasusV2Beta
{
    partial class Auth
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Auth));
            this.Connect = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.Token = new Siticone.Desktop.UI.WinForms.SiticoneTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Gamertag = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Config_stats = new System.Windows.Forms.Label();
            this.Xuid = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.minimizeButton = new System.Windows.Forms.Button();
            this.GrabToken = new System.Windows.Forms.Button();
            this.LBL_Attached = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // Connect
            // 
            this.Connect.BackColor = System.Drawing.Color.Transparent;
            this.Connect.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.Connect.BorderRadius = 10;
            this.Connect.BorderThickness = 2;
            this.Connect.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Connect.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Connect.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Connect.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Connect.FillColor = System.Drawing.Color.Transparent;
            this.Connect.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Connect.ForeColor = System.Drawing.Color.White;
            this.Connect.Location = new System.Drawing.Point(235, 219);
            this.Connect.Margin = new System.Windows.Forms.Padding(2);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(135, 24);
            this.Connect.TabIndex = 45;
            this.Connect.Text = "Connect";
            this.Connect.Click += new System.EventHandler(this.siticoneButton5_Click);
            // 
            // Token
            // 
            this.Token.BackColor = System.Drawing.Color.Transparent;
            this.Token.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.Token.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.Token.BorderThickness = 2;
            this.Token.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Token.DefaultText = "";
            this.Token.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Token.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Token.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Token.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Token.FillColor = System.Drawing.Color.Transparent;
            this.Token.FocusedState.BorderColor = System.Drawing.Color.Blue;
            this.Token.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Token.ForeColor = System.Drawing.SystemColors.Control;
            this.Token.HoverState.BorderColor = System.Drawing.Color.Blue;
            this.Token.Location = new System.Drawing.Point(224, 177);
            this.Token.Margin = new System.Windows.Forms.Padding(2);
            this.Token.Name = "Token";
            this.Token.PasswordChar = '\0';
            this.Token.PlaceholderText = "XBL 3.0 Token...";
            this.Token.SelectedText = "";
            this.Token.Size = new System.Drawing.Size(157, 29);
            this.Token.TabIndex = 47;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Control;
            this.label7.Location = new System.Drawing.Point(243, 208);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 12);
            this.label7.TabIndex = 48;
            this.label7.Text = "Connected to Pegasus";
            this.label7.Visible = false;
            // 
            // Gamertag
            // 
            this.Gamertag.AutoSize = true;
            this.Gamertag.Location = new System.Drawing.Point(22, 145);
            this.Gamertag.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Gamertag.Name = "Gamertag";
            this.Gamertag.Size = new System.Drawing.Size(53, 13);
            this.Gamertag.TabIndex = 49;
            this.Gamertag.Text = "Gamertag";
            this.Gamertag.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(416, 336);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 21);
            this.label1.TabIndex = 51;
            this.label1.Text = "discord.gg/S8QAJjJkxz";
            // 
            // Config_stats
            // 
            this.Config_stats.AutoSize = true;
            this.Config_stats.Location = new System.Drawing.Point(22, 191);
            this.Config_stats.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Config_stats.Name = "Config_stats";
            this.Config_stats.Size = new System.Drawing.Size(61, 13);
            this.Config_stats.TabIndex = 236;
            this.Config_stats.Text = "config stats";
            this.Config_stats.Visible = false;
            // 
            // Xuid
            // 
            this.Xuid.AutoSize = true;
            this.Xuid.Location = new System.Drawing.Point(24, 115);
            this.Xuid.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Xuid.Name = "Xuid";
            this.Xuid.Size = new System.Drawing.Size(33, 13);
            this.Xuid.TabIndex = 237;
            this.Xuid.Text = "XUID";
            this.Xuid.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(234, 8);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 23);
            this.label2.TabIndex = 238;
            this.label2.Text = "Pegasus Revived";
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.Transparent;
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.closeButton.ForeColor = System.Drawing.Color.White;
            this.closeButton.Location = new System.Drawing.Point(578, 8);
            this.closeButton.Margin = new System.Windows.Forms.Padding(2);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(22, 24);
            this.closeButton.TabIndex = 239;
            this.closeButton.Text = "×";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // minimizeButton
            // 
            this.minimizeButton.BackColor = System.Drawing.Color.Transparent;
            this.minimizeButton.FlatAppearance.BorderSize = 0;
            this.minimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.minimizeButton.ForeColor = System.Drawing.Color.White;
            this.minimizeButton.Location = new System.Drawing.Point(551, 8);
            this.minimizeButton.Margin = new System.Windows.Forms.Padding(2);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.Size = new System.Drawing.Size(22, 24);
            this.minimizeButton.TabIndex = 240;
            this.minimizeButton.Text = "–";
            this.minimizeButton.UseVisualStyleBackColor = false;
            this.minimizeButton.Click += new System.EventHandler(this.minimizeButton_Click);
            // 
            // GrabToken
            // 
            this.GrabToken.BackColor = System.Drawing.Color.Transparent;
            this.GrabToken.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GrabToken.ForeColor = System.Drawing.Color.White;
            this.GrabToken.Location = new System.Drawing.Point(235, 143);
            this.GrabToken.Name = "GrabToken";
            this.GrabToken.Size = new System.Drawing.Size(135, 24);
            this.GrabToken.TabIndex = 241;
            this.GrabToken.Text = "Grab My Token";
            this.GrabToken.UseVisualStyleBackColor = false;
            this.GrabToken.Click += new System.EventHandler(this.grabXauthButton_Click);
            // 
            // LBL_Attached
            // 
            this.LBL_Attached.AutoSize = true;
            this.LBL_Attached.BackColor = System.Drawing.Color.Transparent;
            this.LBL_Attached.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.LBL_Attached.ForeColor = System.Drawing.Color.White;
            this.LBL_Attached.Location = new System.Drawing.Point(232, 115);
            this.LBL_Attached.Name = "LBL_Attached";
            this.LBL_Attached.Size = new System.Drawing.Size(145, 15);
            this.LBL_Attached.TabIndex = 242;
            this.LBL_Attached.Text = "Not attached to Xbox App";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // Auth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(611, 366);
            this.Controls.Add(this.LBL_Attached);
            this.Controls.Add(this.GrabToken);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.minimizeButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Xuid);
            this.Controls.Add(this.Config_stats);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Gamertag);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Token);
            this.Controls.Add(this.Connect);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Transparent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = global::PegasusRevived.Properties.Resources.Icon;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Auth";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Auth";
            this.Load += new System.EventHandler(this.Auth_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Siticone.Desktop.UI.WinForms.SiticoneButton Connect;
        private Siticone.Desktop.UI.WinForms.SiticoneTextBox Token;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label Gamertag;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label Config_stats;
        private System.Windows.Forms.Label Xuid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button minimizeButton;
        private System.Windows.Forms.Button GrabToken;
        private System.Windows.Forms.Label LBL_Attached;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}