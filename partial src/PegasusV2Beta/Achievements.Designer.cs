using System.Windows.Forms;
using PegasusRevived.Properties;

namespace PegasusV2Beta
{
    partial class Achievements
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Achievements));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.discord = new System.Windows.Forms.Label();
            this.GameName = new System.Windows.Forms.Label();
            this.SpoofLabel = new System.Windows.Forms.Label();
            this.Panel = new Siticone.Desktop.UI.WinForms.SiticonePanel();
            this.refresh = new System.Windows.Forms.PictureBox();
            this.pfp = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Gamertag = new System.Windows.Forms.Label();
            this.Gamerscore = new System.Windows.Forms.Label();
            this.Xuid = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.LBL_Status = new System.Windows.Forms.Label();
            this.SpoofPanel = new Siticone.Desktop.UI.WinForms.SiticonePanel();
            this.ClosePanel = new System.Windows.Forms.Button();
            this.SBelse = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.AsMe = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.TextL = new System.Windows.Forms.Label();
            this.XUIDPanel = new Siticone.Desktop.UI.WinForms.SiticonePanel();
            this.XUIDe = new Siticone.Desktop.UI.WinForms.SiticoneTextBox();
            this.XUIDaccept = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.ClosePanel2 = new System.Windows.Forms.Button();
            this.TextL2 = new System.Windows.Forms.Label();
            this.TimePanel = new Siticone.Desktop.UI.WinForms.SiticonePanel();
            this.ClosePanel3 = new System.Windows.Forms.Button();
            this.TextL3 = new System.Windows.Forms.Label();
            this.Timeaccept = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.Time = new Siticone.Desktop.UI.WinForms.SiticoneTextBox();
            this.SpoofSwitch = new Siticone.Desktop.UI.WinForms.SiticoneToggleSwitch();
            this.Minimize = new System.Windows.Forms.Button();
            this.Close = new System.Windows.Forms.Button();
            this.Search = new Siticone.Desktop.UI.WinForms.SiticoneTextBox();
            this.ERROR = new System.Windows.Forms.TextBox();
            this.Token = new System.Windows.Forms.TextBox();
            this.G1 = new Siticone.Desktop.UI.WinForms.SiticoneGradientPanel();
            this.T1 = new System.Windows.Forms.Label();
            this.Select1 = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.D1 = new System.Windows.Forms.Label();
            this.BIG1 = new System.Windows.Forms.Label();
            this.N1 = new System.Windows.Forms.Label();
            this.P1 = new System.Windows.Forms.PictureBox();
            this.G2 = new Siticone.Desktop.UI.WinForms.SiticoneGradientPanel();
            this.T2 = new System.Windows.Forms.Label();
            this.Select2 = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.D2 = new System.Windows.Forms.Label();
            this.BIG2 = new System.Windows.Forms.Label();
            this.N2 = new System.Windows.Forms.Label();
            this.P2 = new System.Windows.Forms.PictureBox();
            this.G3 = new Siticone.Desktop.UI.WinForms.SiticoneGradientPanel();
            this.T3 = new System.Windows.Forms.Label();
            this.Select3 = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.D3 = new System.Windows.Forms.Label();
            this.BIG3 = new System.Windows.Forms.Label();
            this.N3 = new System.Windows.Forms.Label();
            this.P3 = new System.Windows.Forms.PictureBox();
            this.G4 = new Siticone.Desktop.UI.WinForms.SiticoneGradientPanel();
            this.T4 = new System.Windows.Forms.Label();
            this.Select4 = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.D4 = new System.Windows.Forms.Label();
            this.BIG4 = new System.Windows.Forms.Label();
            this.N4 = new System.Windows.Forms.Label();
            this.P4 = new System.Windows.Forms.PictureBox();
            this.G5 = new Siticone.Desktop.UI.WinForms.SiticoneGradientPanel();
            this.T5 = new System.Windows.Forms.Label();
            this.Select5 = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.D5 = new System.Windows.Forms.Label();
            this.BIG5 = new System.Windows.Forms.Label();
            this.N5 = new System.Windows.Forms.Label();
            this.P5 = new System.Windows.Forms.PictureBox();
            this.TitleId = new System.Windows.Forms.Label();
            this.Scid = new System.Windows.Forms.Label();
            this.AchievementList = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.AchievementsGrid = new Siticone.Desktop.UI.WinForms.SiticoneDataGridView();
            this.LoadTitleID = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.ReLoad = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.UnlockAll = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.StatsList = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.SetStats = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.CopyTitleId = new System.Windows.Forms.PictureBox();
            this.StatsGrid = new Siticone.Desktop.UI.WinForms.SiticoneDataGridView();
            this.SpoofTitleIdTextBox = new Siticone.Desktop.UI.WinForms.SiticoneTextBox();
            this.Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.refresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pfp)).BeginInit();
            this.SpoofPanel.SuspendLayout();
            this.XUIDPanel.SuspendLayout();
            this.TimePanel.SuspendLayout();
            this.G1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.P1)).BeginInit();
            this.G2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.P2)).BeginInit();
            this.G3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.P3)).BeginInit();
            this.G4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.P4)).BeginInit();
            this.G5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.P5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AchievementsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CopyTitleId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // discord
            // 
            this.discord.AutoSize = true;
            this.discord.BackColor = System.Drawing.Color.Transparent;
            this.discord.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.discord.ForeColor = System.Drawing.Color.White;
            this.discord.Location = new System.Drawing.Point(570, 404);
            this.discord.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.discord.Name = "discord";
            this.discord.Size = new System.Drawing.Size(184, 21);
            this.discord.TabIndex = 51;
            this.discord.Text = "discord.gg/S8QAJjJkxz";
            // 
            // GameName
            // 
            this.GameName.AutoSize = true;
            this.GameName.BackColor = System.Drawing.Color.Transparent;
            this.GameName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.GameName.ForeColor = System.Drawing.Color.White;
            this.GameName.Location = new System.Drawing.Point(80, 404);
            this.GameName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.GameName.Name = "GameName";
            this.GameName.Size = new System.Drawing.Size(100, 21);
            this.GameName.TabIndex = 51;
            this.GameName.Text = "GameName";
            this.GameName.Visible = false;
            // 
            // SpoofLabel
            // 
            this.SpoofLabel.AutoSize = true;
            this.SpoofLabel.BackColor = System.Drawing.Color.Transparent;
            this.SpoofLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.SpoofLabel.ForeColor = System.Drawing.Color.White;
            this.SpoofLabel.Location = new System.Drawing.Point(11, 201);
            this.SpoofLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SpoofLabel.Name = "SpoofLabel";
            this.SpoofLabel.Size = new System.Drawing.Size(88, 15);
            this.SpoofLabel.TabIndex = 51;
            this.SpoofLabel.Text = "Game Spoofer";
            // 
            // Panel
            // 
            this.Panel.AutoRoundedCorners = true;
            this.Panel.BackColor = System.Drawing.Color.Transparent;
            this.Panel.BorderRadius = 49;
            this.Panel.Controls.Add(this.refresh);
            this.Panel.Controls.Add(this.pfp);
            this.Panel.Controls.Add(this.label9);
            this.Panel.Controls.Add(this.Gamertag);
            this.Panel.Controls.Add(this.Gamerscore);
            this.Panel.Controls.Add(this.Xuid);
            this.Panel.Controls.Add(this.label10);
            this.Panel.Controls.Add(this.label8);
            this.Panel.Controls.Add(this.LBL_Status);
            this.Panel.Location = new System.Drawing.Point(0, 0);
            this.Panel.Margin = new System.Windows.Forms.Padding(2);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(597, 100);
            this.Panel.TabIndex = 51;
            // 
            // refresh
            // 
            this.refresh.BackColor = System.Drawing.Color.Transparent;
            this.refresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.refresh.Image = global::PegasusRevived.Properties.Resources.refresh;
            this.refresh.Location = new System.Drawing.Point(104, 78);
            this.refresh.Margin = new System.Windows.Forms.Padding(2);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(19, 20);
            this.refresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.refresh.TabIndex = 57;
            this.refresh.TabStop = false;
            this.refresh.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // pfp
            // 
            this.pfp.BackColor = System.Drawing.Color.Transparent;
            this.pfp.Location = new System.Drawing.Point(0, 0);
            this.pfp.Margin = new System.Windows.Forms.Padding(2);
            this.pfp.Name = "pfp";
            this.pfp.Size = new System.Drawing.Size(100, 100);
            this.pfp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pfp.TabIndex = 47;
            this.pfp.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(127, 11);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 42;
            this.label9.Text = "Gamertag:";
            // 
            // Gamertag
            // 
            this.Gamertag.AutoSize = true;
            this.Gamertag.BackColor = System.Drawing.Color.Transparent;
            this.Gamertag.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gamertag.ForeColor = System.Drawing.Color.White;
            this.Gamertag.Location = new System.Drawing.Point(194, 11);
            this.Gamertag.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Gamertag.Name = "Gamertag";
            this.Gamertag.Size = new System.Drawing.Size(52, 13);
            this.Gamertag.TabIndex = 40;
            this.Gamertag.Text = "Loading";
            // 
            // Gamerscore
            // 
            this.Gamerscore.AutoSize = true;
            this.Gamerscore.BackColor = System.Drawing.Color.Transparent;
            this.Gamerscore.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gamerscore.ForeColor = System.Drawing.Color.White;
            this.Gamerscore.Location = new System.Drawing.Point(210, 62);
            this.Gamerscore.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Gamerscore.Name = "Gamerscore";
            this.Gamerscore.Size = new System.Drawing.Size(52, 13);
            this.Gamerscore.TabIndex = 39;
            this.Gamerscore.Text = "Loading";
            // 
            // Xuid
            // 
            this.Xuid.AutoSize = true;
            this.Xuid.BackColor = System.Drawing.Color.Transparent;
            this.Xuid.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Xuid.ForeColor = System.Drawing.Color.White;
            this.Xuid.Location = new System.Drawing.Point(181, 40);
            this.Xuid.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Xuid.Name = "Xuid";
            this.Xuid.Size = new System.Drawing.Size(52, 13);
            this.Xuid.TabIndex = 38;
            this.Xuid.Text = "Loading";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(127, 62);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 13);
            this.label10.TabIndex = 43;
            this.label10.Text = "GamerScore:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(127, 40);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 41;
            this.label8.Text = "XUID:";
            // 
            // LBL_Status
            // 
            this.LBL_Status.AutoSize = true;
            this.LBL_Status.BackColor = System.Drawing.Color.Transparent;
            this.LBL_Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Status.ForeColor = System.Drawing.Color.White;
            this.LBL_Status.Location = new System.Drawing.Point(127, 78);
            this.LBL_Status.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LBL_Status.Name = "LBL_Status";
            this.LBL_Status.Size = new System.Drawing.Size(52, 13);
            this.LBL_Status.TabIndex = 50;
            this.LBL_Status.Text = "Loading";
            // 
            // SpoofPanel
            // 
            this.SpoofPanel.BackColor = System.Drawing.Color.Transparent;
            this.SpoofPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SpoofPanel.Controls.Add(this.ClosePanel);
            this.SpoofPanel.Controls.Add(this.SBelse);
            this.SpoofPanel.Controls.Add(this.AsMe);
            this.SpoofPanel.Controls.Add(this.TextL);
            this.SpoofPanel.Location = new System.Drawing.Point(270, 190);
            this.SpoofPanel.Margin = new System.Windows.Forms.Padding(2);
            this.SpoofPanel.Name = "SpoofPanel";
            this.SpoofPanel.Size = new System.Drawing.Size(259, 188);
            this.SpoofPanel.TabIndex = 555;
            this.SpoofPanel.Visible = false;
            // 
            // ClosePanel
            // 
            this.ClosePanel.BackColor = System.Drawing.Color.Transparent;
            this.ClosePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClosePanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.ClosePanel.FlatAppearance.BorderSize = 0;
            this.ClosePanel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ClosePanel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.ClosePanel.ForeColor = System.Drawing.Color.White;
            this.ClosePanel.Location = new System.Drawing.Point(233, 0);
            this.ClosePanel.Margin = new System.Windows.Forms.Padding(2);
            this.ClosePanel.Name = "ClosePanel";
            this.ClosePanel.Size = new System.Drawing.Size(26, 27);
            this.ClosePanel.TabIndex = 556;
            this.ClosePanel.Text = "×";
            this.ClosePanel.UseVisualStyleBackColor = false;
            this.ClosePanel.Click += new System.EventHandler(this.ClosePanel_Click);
            // 
            // SBelse
            // 
            this.SBelse.BackColor = System.Drawing.Color.Transparent;
            this.SBelse.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.SBelse.BorderRadius = 10;
            this.SBelse.BorderThickness = 3;
            this.SBelse.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.SBelse.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.SBelse.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.SBelse.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.SBelse.FillColor = System.Drawing.Color.Black;
            this.SBelse.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.SBelse.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.SBelse.Location = new System.Drawing.Point(50, 116);
            this.SBelse.Margin = new System.Windows.Forms.Padding(2);
            this.SBelse.Name = "SBelse";
            this.SBelse.Size = new System.Drawing.Size(81, 25);
            this.SBelse.TabIndex = 46;
            this.SBelse.Text = "Someone";
            this.SBelse.Click += new System.EventHandler(this.SBelse_Click);
            // 
            // AsMe
            // 
            this.AsMe.BackColor = System.Drawing.Color.Transparent;
            this.AsMe.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.AsMe.BorderRadius = 10;
            this.AsMe.BorderThickness = 3;
            this.AsMe.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.AsMe.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.AsMe.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.AsMe.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.AsMe.FillColor = System.Drawing.Color.Black;
            this.AsMe.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.AsMe.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.AsMe.Location = new System.Drawing.Point(135, 116);
            this.AsMe.Margin = new System.Windows.Forms.Padding(2);
            this.AsMe.Name = "AsMe";
            this.AsMe.Size = new System.Drawing.Size(81, 25);
            this.AsMe.TabIndex = 47;
            this.AsMe.Text = "As Me";
            this.AsMe.Click += new System.EventHandler(this.AsMe_Click);
            // 
            // TextL
            // 
            this.TextL.AutoSize = true;
            this.TextL.BackColor = System.Drawing.Color.Transparent;
            this.TextL.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextL.ForeColor = System.Drawing.Color.White;
            this.TextL.Location = new System.Drawing.Point(57, 57);
            this.TextL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TextL.Name = "TextL";
            this.TextL.Size = new System.Drawing.Size(151, 34);
            this.TextL.TabIndex = 0;
            this.TextL.Text = "Do you wanna spoof it \r\nas you or someone else?";
            // 
            // XUIDPanel
            // 
            this.XUIDPanel.BackColor = System.Drawing.Color.Transparent;
            this.XUIDPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.XUIDPanel.Controls.Add(this.XUIDe);
            this.XUIDPanel.Controls.Add(this.XUIDaccept);
            this.XUIDPanel.Controls.Add(this.ClosePanel2);
            this.XUIDPanel.Controls.Add(this.TextL2);
            this.XUIDPanel.Location = new System.Drawing.Point(270, 190);
            this.XUIDPanel.Margin = new System.Windows.Forms.Padding(2);
            this.XUIDPanel.Name = "XUIDPanel";
            this.XUIDPanel.Size = new System.Drawing.Size(259, 188);
            this.XUIDPanel.TabIndex = 556;
            this.XUIDPanel.Visible = false;
            // 
            // XUIDe
            // 
            this.XUIDe.BackColor = System.Drawing.Color.Black;
            this.XUIDe.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.XUIDe.BorderRadius = 3;
            this.XUIDe.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.XUIDe.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.XUIDe.DefaultText = "";
            this.XUIDe.FillColor = System.Drawing.Color.Black;
            this.XUIDe.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.XUIDe.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.XUIDe.Location = new System.Drawing.Point(37, 95);
            this.XUIDe.Margin = new System.Windows.Forms.Padding(2);
            this.XUIDe.Name = "XUIDe";
            this.XUIDe.PasswordChar = '\0';
            this.XUIDe.PlaceholderForeColor = System.Drawing.Color.DeepSkyBlue;
            this.XUIDe.PlaceholderText = "Enter XUID...";
            this.XUIDe.SelectedText = "";
            this.XUIDe.Size = new System.Drawing.Size(183, 20);
            this.XUIDe.TabIndex = 76;
            // 
            // XUIDaccept
            // 
            this.XUIDaccept.BackColor = System.Drawing.Color.Transparent;
            this.XUIDaccept.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.XUIDaccept.BorderRadius = 10;
            this.XUIDaccept.BorderThickness = 3;
            this.XUIDaccept.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.XUIDaccept.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.XUIDaccept.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.XUIDaccept.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.XUIDaccept.FillColor = System.Drawing.Color.Black;
            this.XUIDaccept.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.XUIDaccept.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.XUIDaccept.Location = new System.Drawing.Point(150, 127);
            this.XUIDaccept.Margin = new System.Windows.Forms.Padding(2);
            this.XUIDaccept.Name = "XUIDaccept";
            this.XUIDaccept.Size = new System.Drawing.Size(81, 25);
            this.XUIDaccept.TabIndex = 77;
            this.XUIDaccept.Text = "Accept";
            this.XUIDaccept.Click += new System.EventHandler(this.XUIDaccept_Click);
            // 
            // ClosePanel2
            // 
            this.ClosePanel2.BackColor = System.Drawing.Color.Transparent;
            this.ClosePanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClosePanel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.ClosePanel2.FlatAppearance.BorderSize = 0;
            this.ClosePanel2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ClosePanel2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.ClosePanel2.ForeColor = System.Drawing.Color.White;
            this.ClosePanel2.Location = new System.Drawing.Point(233, 0);
            this.ClosePanel2.Margin = new System.Windows.Forms.Padding(2);
            this.ClosePanel2.Name = "ClosePanel2";
            this.ClosePanel2.Size = new System.Drawing.Size(26, 27);
            this.ClosePanel2.TabIndex = 48;
            this.ClosePanel2.Text = "×";
            this.ClosePanel2.UseVisualStyleBackColor = false;
            this.ClosePanel2.Click += new System.EventHandler(this.ClosePanel2_Click);
            // 
            // TextL2
            // 
            this.TextL2.AutoSize = true;
            this.TextL2.BackColor = System.Drawing.Color.Transparent;
            this.TextL2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextL2.ForeColor = System.Drawing.Color.White;
            this.TextL2.Location = new System.Drawing.Point(57, 57);
            this.TextL2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TextL2.Name = "TextL2";
            this.TextL2.Size = new System.Drawing.Size(146, 34);
            this.TextL2.TabIndex = 0;
            this.TextL2.Text = "Enter XUID Of Account\r\nYou Wanna Spoof As";
            // 
            // TimePanel
            // 
            this.TimePanel.BackColor = System.Drawing.Color.Transparent;
            this.TimePanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TimePanel.BackgroundImage")));
            this.TimePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.TimePanel.Controls.Add(this.ClosePanel3);
            this.TimePanel.Controls.Add(this.TextL3);
            this.TimePanel.Controls.Add(this.Timeaccept);
            this.TimePanel.Controls.Add(this.Time);
            this.TimePanel.Location = new System.Drawing.Point(270, 190);
            this.TimePanel.Margin = new System.Windows.Forms.Padding(2);
            this.TimePanel.Name = "TimePanel";
            this.TimePanel.Size = new System.Drawing.Size(259, 188);
            this.TimePanel.TabIndex = 551;
            this.TimePanel.Visible = false;
            // 
            // ClosePanel3
            // 
            this.ClosePanel3.BackColor = System.Drawing.Color.Transparent;
            this.ClosePanel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClosePanel3.Cursor = System.Windows.Forms.Cursors.Default;
            this.ClosePanel3.FlatAppearance.BorderSize = 0;
            this.ClosePanel3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ClosePanel3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.ClosePanel3.ForeColor = System.Drawing.Color.White;
            this.ClosePanel3.Location = new System.Drawing.Point(233, 0);
            this.ClosePanel3.Margin = new System.Windows.Forms.Padding(2);
            this.ClosePanel3.Name = "ClosePanel3";
            this.ClosePanel3.Size = new System.Drawing.Size(26, 27);
            this.ClosePanel3.TabIndex = 48;
            this.ClosePanel3.Text = "×";
            this.ClosePanel3.UseVisualStyleBackColor = false;
            this.ClosePanel3.Click += new System.EventHandler(this.ClosePanel3_Click);
            // 
            // TextL3
            // 
            this.TextL3.AutoSize = true;
            this.TextL3.BackColor = System.Drawing.Color.Transparent;
            this.TextL3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextL3.ForeColor = System.Drawing.Color.White;
            this.TextL3.Location = new System.Drawing.Point(50, 57);
            this.TextL3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TextL3.Name = "TextL3";
            this.TextL3.Size = new System.Drawing.Size(162, 17);
            this.TextL3.TabIndex = 0;
            this.TextL3.Text = "Change Time If You Want";
            // 
            // Timeaccept
            // 
            this.Timeaccept.BackColor = System.Drawing.Color.Transparent;
            this.Timeaccept.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.Timeaccept.BorderRadius = 10;
            this.Timeaccept.BorderThickness = 3;
            this.Timeaccept.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Timeaccept.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Timeaccept.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Timeaccept.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Timeaccept.FillColor = System.Drawing.Color.Black;
            this.Timeaccept.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Timeaccept.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.Timeaccept.Location = new System.Drawing.Point(150, 127);
            this.Timeaccept.Margin = new System.Windows.Forms.Padding(2);
            this.Timeaccept.Name = "Timeaccept";
            this.Timeaccept.Size = new System.Drawing.Size(81, 25);
            this.Timeaccept.TabIndex = 77;
            this.Timeaccept.Text = "Accept";
            this.Timeaccept.Click += new System.EventHandler(this.TimeAccept_Click);
            // 
            // Time
            // 
            this.Time.BackColor = System.Drawing.Color.Black;
            this.Time.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.Time.BorderRadius = 3;
            this.Time.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.Time.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Time.DefaultText = "";
            this.Time.FillColor = System.Drawing.Color.Black;
            this.Time.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Time.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.Time.Location = new System.Drawing.Point(37, 95);
            this.Time.Margin = new System.Windows.Forms.Padding(2);
            this.Time.Name = "Time";
            this.Time.PasswordChar = '\0';
            this.Time.PlaceholderForeColor = System.Drawing.Color.DeepSkyBlue;
            this.Time.PlaceholderText = "Enter Time...";
            this.Time.SelectedText = "";
            this.Time.Size = new System.Drawing.Size(183, 20);
            this.Time.TabIndex = 76;
            // 
            // SpoofSwitch
            // 
            this.SpoofSwitch.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.SpoofSwitch.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.SpoofSwitch.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.SpoofSwitch.CheckedState.InnerColor = System.Drawing.Color.White;
            this.SpoofSwitch.Location = new System.Drawing.Point(33, 163);
            this.SpoofSwitch.Name = "SpoofSwitch";
            this.SpoofSwitch.Size = new System.Drawing.Size(45, 25);
            this.SpoofSwitch.TabIndex = 69;
            this.SpoofSwitch.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.SpoofSwitch.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.SpoofSwitch.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.SpoofSwitch.UncheckedState.InnerColor = System.Drawing.Color.White;
            // 
            // Minimize
            // 
            this.Minimize.BackColor = System.Drawing.Color.Transparent;
            this.Minimize.FlatAppearance.BorderSize = 0;
            this.Minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Minimize.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.Minimize.ForeColor = System.Drawing.Color.White;
            this.Minimize.Location = new System.Drawing.Point(783, 0);
            this.Minimize.Margin = new System.Windows.Forms.Padding(2);
            this.Minimize.Name = "Minimize";
            this.Minimize.Size = new System.Drawing.Size(30, 32);
            this.Minimize.TabIndex = 74;
            this.Minimize.Text = "–";
            this.Minimize.UseVisualStyleBackColor = false;
            this.Minimize.Click += new System.EventHandler(this.buttonMinimize_Click);
            // 
            // Close
            // 
            this.Close.BackColor = System.Drawing.Color.Transparent;
            this.Close.FlatAppearance.BorderSize = 0;
            this.Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Close.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.Close.ForeColor = System.Drawing.Color.White;
            this.Close.Location = new System.Drawing.Point(817, 0);
            this.Close.Margin = new System.Windows.Forms.Padding(2);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(30, 32);
            this.Close.TabIndex = 73;
            this.Close.Text = "×";
            this.Close.UseVisualStyleBackColor = false;
            this.Close.Click += new System.EventHandler(this.button1_Click);
            // 
            // Search
            // 
            this.Search.AutoRoundedCorners = true;
            this.Search.BackColor = System.Drawing.Color.Transparent;
            this.Search.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.Search.BorderRadius = 13;
            this.Search.BorderThickness = 2;
            this.Search.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Search.DefaultText = "";
            this.Search.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Search.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Search.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Search.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Search.FillColor = System.Drawing.Color.Black;
            this.Search.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Search.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Search.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.Search.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Search.Location = new System.Drawing.Point(277, 121);
            this.Search.Margin = new System.Windows.Forms.Padding(2);
            this.Search.Name = "Search";
            this.Search.PasswordChar = '\0';
            this.Search.PlaceholderForeColor = System.Drawing.Color.DeepSkyBlue;
            this.Search.PlaceholderText = "Search Game...";
            this.Search.SelectedText = "";
            this.Search.Size = new System.Drawing.Size(246, 29);
            this.Search.TabIndex = 52;
            this.Search.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Search.TextChanged += new System.EventHandler(this.Search_TextChanged);
            // 
            // ERROR
            // 
            this.ERROR.Location = new System.Drawing.Point(737, 241);
            this.ERROR.Margin = new System.Windows.Forms.Padding(2);
            this.ERROR.Name = "ERROR";
            this.ERROR.Size = new System.Drawing.Size(76, 20);
            this.ERROR.TabIndex = 54;
            this.ERROR.Visible = false;
            // 
            // Token
            // 
            this.Token.Location = new System.Drawing.Point(752, 121);
            this.Token.Margin = new System.Windows.Forms.Padding(2);
            this.Token.Name = "Token";
            this.Token.Size = new System.Drawing.Size(76, 20);
            this.Token.TabIndex = 53;
            this.Token.Visible = false;
            // 
            // G1
            // 
            this.G1.AutoRoundedCorners = true;
            this.G1.BackColor = System.Drawing.Color.White;
            this.G1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("GPanels.Background")));
            this.G1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.G1.BorderRadius = 44;
            this.G1.Controls.Add(this.T1);
            this.G1.Controls.Add(this.Select1);
            this.G1.Controls.Add(this.D1);
            this.G1.Controls.Add(this.BIG1);
            this.G1.Controls.Add(this.N1);
            this.G1.Controls.Add(this.P1);
            this.G1.Location = new System.Drawing.Point(277, 154);
            this.G1.Margin = new System.Windows.Forms.Padding(2);
            this.G1.Name = "G1";
            this.G1.Size = new System.Drawing.Size(246, 91);
            this.G1.TabIndex = 58;
            this.G1.Visible = false;
            // 
            // T1
            // 
            this.T1.AutoSize = true;
            this.T1.BackColor = System.Drawing.Color.Transparent;
            this.T1.ForeColor = System.Drawing.Color.White;
            this.T1.Location = new System.Drawing.Point(204, 52);
            this.T1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.T1.Name = "T1";
            this.T1.Size = new System.Drawing.Size(35, 13);
            this.T1.TabIndex = 48;
            this.T1.Text = "label1";
            this.T1.Visible = false;
            // 
            // Select1
            // 
            this.Select1.BackColor = System.Drawing.Color.Transparent;
            this.Select1.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.Select1.BorderRadius = 10;
            this.Select1.BorderThickness = 2;
            this.Select1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Select1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Select1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Select1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Select1.FillColor = System.Drawing.Color.Black;
            this.Select1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Select1.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.Select1.Location = new System.Drawing.Point(64, 55);
            this.Select1.Margin = new System.Windows.Forms.Padding(2);
            this.Select1.Name = "Select1";
            this.Select1.Size = new System.Drawing.Size(75, 25);
            this.Select1.TabIndex = 47;
            this.Select1.Text = "Select";
            // 
            // D1
            // 
            this.D1.AutoSize = true;
            this.D1.BackColor = System.Drawing.Color.Transparent;
            this.D1.ForeColor = System.Drawing.Color.White;
            this.D1.Location = new System.Drawing.Point(65, 40);
            this.D1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.D1.Name = "D1";
            this.D1.Size = new System.Drawing.Size(45, 13);
            this.D1.TabIndex = 3;
            this.D1.Text = "Loading";
            // 
            // BIG1
            // 
            this.BIG1.AutoSize = true;
            this.BIG1.BackColor = System.Drawing.Color.Transparent;
            this.BIG1.ForeColor = System.Drawing.Color.White;
            this.BIG1.Location = new System.Drawing.Point(204, 67);
            this.BIG1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BIG1.Name = "BIG1";
            this.BIG1.Size = new System.Drawing.Size(35, 13);
            this.BIG1.TabIndex = 2;
            this.BIG1.Text = "label2";
            this.BIG1.Visible = false;
            // 
            // N1
            // 
            this.N1.AutoSize = true;
            this.N1.BackColor = System.Drawing.Color.Transparent;
            this.N1.ForeColor = System.Drawing.Color.White;
            this.N1.Location = new System.Drawing.Point(65, 18);
            this.N1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.N1.Name = "N1";
            this.N1.Size = new System.Drawing.Size(45, 13);
            this.N1.TabIndex = 1;
            this.N1.Text = "Loading";
            // 
            // P1
            // 
            this.P1.BackColor = System.Drawing.Color.DimGray;
            this.P1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.P1.Location = new System.Drawing.Point(0, 0);
            this.P1.Margin = new System.Windows.Forms.Padding(2);
            this.P1.Name = "P1";
            this.P1.Size = new System.Drawing.Size(60, 60);
            this.P1.TabIndex = 0;
            this.P1.TabStop = false;
            // 
            // G2
            // 
            this.G2.AutoRoundedCorners = true;
            this.G2.BackColor = System.Drawing.Color.DimGray;
            this.G2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("GPanels.Background")));
            this.G2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.G2.BorderRadius = 44;
            this.G2.Controls.Add(this.T2);
            this.G2.Controls.Add(this.Select2);
            this.G2.Controls.Add(this.D2);
            this.G2.Controls.Add(this.BIG2);
            this.G2.Controls.Add(this.N2);
            this.G2.Controls.Add(this.P2);
            this.G2.Location = new System.Drawing.Point(277, 250);
            this.G2.Margin = new System.Windows.Forms.Padding(2);
            this.G2.Name = "G2";
            this.G2.Size = new System.Drawing.Size(246, 91);
            this.G2.TabIndex = 59;
            this.G2.Visible = false;
            // 
            // T2
            // 
            this.T2.AutoSize = true;
            this.T2.BackColor = System.Drawing.Color.Transparent;
            this.T2.ForeColor = System.Drawing.Color.White;
            this.T2.Location = new System.Drawing.Point(204, 52);
            this.T2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.T2.Name = "T2";
            this.T2.Size = new System.Drawing.Size(35, 13);
            this.T2.TabIndex = 49;
            this.T2.Text = "label1";
            this.T2.Visible = false;
            // 
            // Select2
            // 
            this.Select2.BackColor = System.Drawing.Color.Transparent;
            this.Select2.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.Select2.BorderRadius = 10;
            this.Select2.BorderThickness = 2;
            this.Select2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Select2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Select2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Select2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Select2.FillColor = System.Drawing.Color.Black;
            this.Select2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Select2.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.Select2.Location = new System.Drawing.Point(64, 55);
            this.Select2.Margin = new System.Windows.Forms.Padding(2);
            this.Select2.Name = "Select2";
            this.Select2.Size = new System.Drawing.Size(75, 25);
            this.Select2.TabIndex = 47;
            this.Select2.Text = "Select";
            // 
            // D2
            // 
            this.D2.AutoSize = true;
            this.D2.BackColor = System.Drawing.Color.Transparent;
            this.D2.ForeColor = System.Drawing.Color.White;
            this.D2.Location = new System.Drawing.Point(65, 40);
            this.D2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.D2.Name = "D2";
            this.D2.Size = new System.Drawing.Size(45, 13);
            this.D2.TabIndex = 3;
            this.D2.Text = "Loading";
            // 
            // BIG2
            // 
            this.BIG2.AutoSize = true;
            this.BIG2.BackColor = System.Drawing.Color.Transparent;
            this.BIG2.ForeColor = System.Drawing.Color.White;
            this.BIG2.Location = new System.Drawing.Point(204, 67);
            this.BIG2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BIG2.Name = "BIG2";
            this.BIG2.Size = new System.Drawing.Size(35, 13);
            this.BIG2.TabIndex = 2;
            this.BIG2.Text = "label2";
            this.BIG2.Visible = false;
            // 
            // N2
            // 
            this.N2.AutoSize = true;
            this.N2.BackColor = System.Drawing.Color.Transparent;
            this.N2.ForeColor = System.Drawing.Color.White;
            this.N2.Location = new System.Drawing.Point(65, 17);
            this.N2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.N2.Name = "N2";
            this.N2.Size = new System.Drawing.Size(45, 13);
            this.N2.TabIndex = 1;
            this.N2.Text = "Loading";
            // 
            // P2
            // 
            this.P2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.P2.Location = new System.Drawing.Point(0, 0);
            this.P2.Margin = new System.Windows.Forms.Padding(2);
            this.P2.Name = "P2";
            this.P2.Size = new System.Drawing.Size(60, 60);
            this.P2.TabIndex = 0;
            this.P2.TabStop = false;
            // 
            // G3
            // 
            this.G3.AutoRoundedCorners = true;
            this.G3.BackColor = System.Drawing.Color.Transparent;
            this.G3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("GPanels.Background")));
            this.G3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.G3.BorderRadius = 44;
            this.G3.Controls.Add(this.T3);
            this.G3.Controls.Add(this.Select3);
            this.G3.Controls.Add(this.D3);
            this.G3.Controls.Add(this.BIG3);
            this.G3.Controls.Add(this.N3);
            this.G3.Controls.Add(this.P3);
            this.G3.Location = new System.Drawing.Point(277, 346);
            this.G3.Margin = new System.Windows.Forms.Padding(2);
            this.G3.Name = "G3";
            this.G3.Size = new System.Drawing.Size(246, 91);
            this.G3.TabIndex = 60;
            this.G3.Visible = false;
            // 
            // T3
            // 
            this.T3.AutoSize = true;
            this.T3.BackColor = System.Drawing.Color.Transparent;
            this.T3.ForeColor = System.Drawing.Color.White;
            this.T3.Location = new System.Drawing.Point(204, 52);
            this.T3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.T3.Name = "T3";
            this.T3.Size = new System.Drawing.Size(35, 13);
            this.T3.TabIndex = 50;
            this.T3.Text = "label2";
            this.T3.Visible = false;
            // 
            // Select3
            // 
            this.Select3.BackColor = System.Drawing.Color.Transparent;
            this.Select3.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.Select3.BorderRadius = 10;
            this.Select3.BorderThickness = 2;
            this.Select3.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Select3.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Select3.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Select3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Select3.FillColor = System.Drawing.Color.Black;
            this.Select3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Select3.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.Select3.Location = new System.Drawing.Point(64, 54);
            this.Select3.Margin = new System.Windows.Forms.Padding(2);
            this.Select3.Name = "Select3";
            this.Select3.Size = new System.Drawing.Size(75, 25);
            this.Select3.TabIndex = 47;
            this.Select3.Text = "Select";
            // 
            // D3
            // 
            this.D3.AutoSize = true;
            this.D3.BackColor = System.Drawing.Color.Transparent;
            this.D3.ForeColor = System.Drawing.Color.White;
            this.D3.Location = new System.Drawing.Point(65, 39);
            this.D3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.D3.Name = "D3";
            this.D3.Size = new System.Drawing.Size(45, 13);
            this.D3.TabIndex = 3;
            this.D3.Text = "Loading";
            // 
            // BIG3
            // 
            this.BIG3.AutoSize = true;
            this.BIG3.BackColor = System.Drawing.Color.Transparent;
            this.BIG3.ForeColor = System.Drawing.Color.White;
            this.BIG3.Location = new System.Drawing.Point(204, 67);
            this.BIG3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BIG3.Name = "BIG3";
            this.BIG3.Size = new System.Drawing.Size(35, 13);
            this.BIG3.TabIndex = 2;
            this.BIG3.Text = "label5";
            this.BIG3.Visible = false;
            // 
            // N3
            // 
            this.N3.AutoSize = true;
            this.N3.BackColor = System.Drawing.Color.Transparent;
            this.N3.ForeColor = System.Drawing.Color.White;
            this.N3.Location = new System.Drawing.Point(65, 15);
            this.N3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.N3.Name = "N3";
            this.N3.Size = new System.Drawing.Size(45, 13);
            this.N3.TabIndex = 1;
            this.N3.Text = "Loading";
            // 
            // P3
            // 
            this.P3.BackColor = System.Drawing.Color.DimGray;
            this.P3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.P3.Location = new System.Drawing.Point(0, 0);
            this.P3.Margin = new System.Windows.Forms.Padding(2);
            this.P3.Name = "P3";
            this.P3.Size = new System.Drawing.Size(60, 60);
            this.P3.TabIndex = 0;
            this.P3.TabStop = false;
            // 
            // G4
            // 
            this.G4.AutoRoundedCorners = true;
            this.G4.BackColor = System.Drawing.Color.DimGray;
            this.G4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("GPanels.Background")));
            this.G4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.G4.BorderRadius = 44;
            this.G4.Controls.Add(this.T4);
            this.G4.Controls.Add(this.Select4);
            this.G4.Controls.Add(this.D4);
            this.G4.Controls.Add(this.BIG4);
            this.G4.Controls.Add(this.N4);
            this.G4.Controls.Add(this.P4);
            this.G4.Location = new System.Drawing.Point(277, 442);
            this.G4.Margin = new System.Windows.Forms.Padding(2);
            this.G4.Name = "G4";
            this.G4.Size = new System.Drawing.Size(246, 91);
            this.G4.TabIndex = 61;
            this.G4.Visible = false;
            // 
            // T4
            // 
            this.T4.AutoSize = true;
            this.T4.BackColor = System.Drawing.Color.Transparent;
            this.T4.ForeColor = System.Drawing.Color.White;
            this.T4.Location = new System.Drawing.Point(204, 52);
            this.T4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.T4.Name = "T4";
            this.T4.Size = new System.Drawing.Size(35, 13);
            this.T4.TabIndex = 50;
            this.T4.Text = "label3";
            this.T4.Visible = false;
            // 
            // Select4
            // 
            this.Select4.BackColor = System.Drawing.Color.Transparent;
            this.Select4.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.Select4.BorderRadius = 10;
            this.Select4.BorderThickness = 2;
            this.Select4.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Select4.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Select4.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Select4.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Select4.FillColor = System.Drawing.Color.Black;
            this.Select4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Select4.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.Select4.Location = new System.Drawing.Point(64, 54);
            this.Select4.Margin = new System.Windows.Forms.Padding(2);
            this.Select4.Name = "Select4";
            this.Select4.Size = new System.Drawing.Size(75, 25);
            this.Select4.TabIndex = 47;
            this.Select4.Text = "Select";
            // 
            // D4
            // 
            this.D4.AutoSize = true;
            this.D4.BackColor = System.Drawing.Color.Transparent;
            this.D4.ForeColor = System.Drawing.Color.White;
            this.D4.Location = new System.Drawing.Point(64, 40);
            this.D4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.D4.Name = "D4";
            this.D4.Size = new System.Drawing.Size(45, 13);
            this.D4.TabIndex = 3;
            this.D4.Text = "Loading";
            // 
            // BIG4
            // 
            this.BIG4.AutoSize = true;
            this.BIG4.BackColor = System.Drawing.Color.Transparent;
            this.BIG4.ForeColor = System.Drawing.Color.White;
            this.BIG4.Location = new System.Drawing.Point(204, 67);
            this.BIG4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BIG4.Name = "BIG4";
            this.BIG4.Size = new System.Drawing.Size(41, 13);
            this.BIG4.TabIndex = 2;
            this.BIG4.Text = "label11";
            this.BIG4.Visible = false;
            // 
            // N4
            // 
            this.N4.AutoSize = true;
            this.N4.BackColor = System.Drawing.Color.Transparent;
            this.N4.ForeColor = System.Drawing.Color.White;
            this.N4.Location = new System.Drawing.Point(65, 15);
            this.N4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.N4.Name = "N4";
            this.N4.Size = new System.Drawing.Size(45, 13);
            this.N4.TabIndex = 1;
            this.N4.Text = "Loading";
            // 
            // P4
            // 
            this.P4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.P4.Location = new System.Drawing.Point(0, 0);
            this.P4.Margin = new System.Windows.Forms.Padding(2);
            this.P4.Name = "P4";
            this.P4.Size = new System.Drawing.Size(60, 60);
            this.P4.TabIndex = 0;
            this.P4.TabStop = false;
            // 
            // G5
            // 
            this.G5.AutoRoundedCorners = true;
            this.G5.BackColor = System.Drawing.Color.DimGray;
            this.G5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("GPanels.Background")));
            this.G5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.G5.BorderRadius = 44;
            this.G5.Controls.Add(this.T5);
            this.G5.Controls.Add(this.Select5);
            this.G5.Controls.Add(this.D5);
            this.G5.Controls.Add(this.BIG5);
            this.G5.Controls.Add(this.N5);
            this.G5.Controls.Add(this.P5);
            this.G5.Location = new System.Drawing.Point(277, 538);
            this.G5.Margin = new System.Windows.Forms.Padding(2);
            this.G5.Name = "G5";
            this.G5.Size = new System.Drawing.Size(246, 91);
            this.G5.TabIndex = 62;
            this.G5.Visible = false;
            // 
            // T5
            // 
            this.T5.AutoSize = true;
            this.T5.BackColor = System.Drawing.Color.Transparent;
            this.T5.ForeColor = System.Drawing.Color.White;
            this.T5.Location = new System.Drawing.Point(204, 52);
            this.T5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.T5.Name = "T5";
            this.T5.Size = new System.Drawing.Size(35, 13);
            this.T5.TabIndex = 50;
            this.T5.Text = "label4";
            this.T5.Visible = false;
            // 
            // Select5
            // 
            this.Select5.BackColor = System.Drawing.Color.Transparent;
            this.Select5.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.Select5.BorderRadius = 10;
            this.Select5.BorderThickness = 2;
            this.Select5.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Select5.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Select5.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Select5.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Select5.FillColor = System.Drawing.Color.Black;
            this.Select5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Select5.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.Select5.Location = new System.Drawing.Point(64, 54);
            this.Select5.Margin = new System.Windows.Forms.Padding(2);
            this.Select5.Name = "Select5";
            this.Select5.Size = new System.Drawing.Size(75, 25);
            this.Select5.TabIndex = 47;
            this.Select5.Text = "Select";
            // 
            // D5
            // 
            this.D5.AutoSize = true;
            this.D5.BackColor = System.Drawing.Color.Transparent;
            this.D5.ForeColor = System.Drawing.Color.White;
            this.D5.Location = new System.Drawing.Point(64, 40);
            this.D5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.D5.Name = "D5";
            this.D5.Size = new System.Drawing.Size(45, 13);
            this.D5.TabIndex = 3;
            this.D5.Text = "Loading";
            // 
            // BIG5
            // 
            this.BIG5.AutoSize = true;
            this.BIG5.BackColor = System.Drawing.Color.Transparent;
            this.BIG5.ForeColor = System.Drawing.Color.White;
            this.BIG5.Location = new System.Drawing.Point(204, 67);
            this.BIG5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BIG5.Name = "BIG5";
            this.BIG5.Size = new System.Drawing.Size(41, 13);
            this.BIG5.TabIndex = 2;
            this.BIG5.Text = "label14";
            this.BIG5.Visible = false;
            // 
            // N5
            // 
            this.N5.AutoSize = true;
            this.N5.BackColor = System.Drawing.Color.Transparent;
            this.N5.ForeColor = System.Drawing.Color.White;
            this.N5.Location = new System.Drawing.Point(65, 15);
            this.N5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.N5.Name = "N5";
            this.N5.Size = new System.Drawing.Size(45, 13);
            this.N5.TabIndex = 1;
            this.N5.Text = "Loading";
            // 
            // P5
            // 
            this.P5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.P5.Location = new System.Drawing.Point(0, 0);
            this.P5.Margin = new System.Windows.Forms.Padding(2);
            this.P5.Name = "P5";
            this.P5.Size = new System.Drawing.Size(60, 60);
            this.P5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.P5.TabIndex = 0;
            this.P5.TabStop = false;
            // 
            // TitleId
            // 
            this.TitleId.AutoSize = true;
            this.TitleId.BackColor = System.Drawing.Color.Transparent;
            this.TitleId.ForeColor = System.Drawing.Color.White;
            this.TitleId.Location = new System.Drawing.Point(11, 121);
            this.TitleId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TitleId.Name = "TitleId";
            this.TitleId.Size = new System.Drawing.Size(0, 13);
            this.TitleId.TabIndex = 63;
            // 
            // Scid
            // 
            this.Scid.AutoSize = true;
            this.Scid.ForeColor = System.Drawing.Color.White;
            this.Scid.Location = new System.Drawing.Point(550, 121);
            this.Scid.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Scid.Name = "Scid";
            this.Scid.Size = new System.Drawing.Size(10, 13);
            this.Scid.TabIndex = 64;
            this.Scid.Text = " ";
            this.Scid.Visible = false;
            // 
            // AchievementList
            // 
            this.AchievementList.BackColor = System.Drawing.Color.Transparent;
            this.AchievementList.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.AchievementList.BorderThickness = 3;
            this.AchievementList.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.AchievementList.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.AchievementList.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.AchievementList.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.AchievementList.FillColor = System.Drawing.Color.Black;
            this.AchievementList.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.AchievementList.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.AchievementList.Location = new System.Drawing.Point(543, 172);
            this.AchievementList.Margin = new System.Windows.Forms.Padding(2);
            this.AchievementList.Name = "AchievementList";
            this.AchievementList.Size = new System.Drawing.Size(190, 47);
            this.AchievementList.TabIndex = 66;
            this.AchievementList.Text = "Achievements";
            this.AchievementList.Click += new System.EventHandler(this.siticoneButton2_Click);
            // 
            // AchievementsGrid
            // 
            this.AchievementsGrid.AllowUserToAddRows = false;
            this.AchievementsGrid.AllowUserToDeleteRows = false;
            this.AchievementsGrid.AllowUserToResizeColumns = false;
            this.AchievementsGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            this.AchievementsGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.AchievementsGrid.BackgroundColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AchievementsGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.AchievementsGrid.ColumnHeadersHeight = 4;
            this.AchievementsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.AchievementsGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.AchievementsGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.AchievementsGrid.Location = new System.Drawing.Point(84, 435);
            this.AchievementsGrid.Margin = new System.Windows.Forms.Padding(2);
            this.AchievementsGrid.Name = "AchievementsGrid";
            this.AchievementsGrid.ReadOnly = true;
            this.AchievementsGrid.RowHeadersVisible = false;
            this.AchievementsGrid.RowHeadersWidth = 51;
            this.AchievementsGrid.RowTemplate.Height = 24;
            this.AchievementsGrid.Size = new System.Drawing.Size(670, 258);
            this.AchievementsGrid.TabIndex = 67;
            this.AchievementsGrid.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.Black;
            this.AchievementsGrid.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.AchievementsGrid.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.AchievementsGrid.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Black;
            this.AchievementsGrid.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.DeepSkyBlue;
            this.AchievementsGrid.ThemeStyle.BackColor = System.Drawing.Color.Black;
            this.AchievementsGrid.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.AchievementsGrid.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.AchievementsGrid.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.AchievementsGrid.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AchievementsGrid.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.AchievementsGrid.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.AchievementsGrid.ThemeStyle.HeaderStyle.Height = 4;
            this.AchievementsGrid.ThemeStyle.ReadOnly = true;
            this.AchievementsGrid.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.Black;
            this.AchievementsGrid.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.AchievementsGrid.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AchievementsGrid.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.AchievementsGrid.ThemeStyle.RowsStyle.Height = 24;
            this.AchievementsGrid.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.Black;
            this.AchievementsGrid.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.DeepSkyBlue;
            this.AchievementsGrid.Visible = false;
            this.AchievementsGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AchievementsGrid_CellContentClick);
            // 
            // LoadTitleID
            // 
            this.LoadTitleID.AutoRoundedCorners = true;
            this.LoadTitleID.BackColor = System.Drawing.Color.Transparent;
            this.LoadTitleID.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.LoadTitleID.BorderRadius = 9;
            this.LoadTitleID.BorderThickness = 1;
            this.LoadTitleID.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.LoadTitleID.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.LoadTitleID.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.LoadTitleID.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.LoadTitleID.FillColor = System.Drawing.Color.Black;
            this.LoadTitleID.Font = new System.Drawing.Font("Noto Sans", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadTitleID.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.LoadTitleID.Location = new System.Drawing.Point(105, 138);
            this.LoadTitleID.Margin = new System.Windows.Forms.Padding(2);
            this.LoadTitleID.Name = "LoadTitleID";
            this.LoadTitleID.Size = new System.Drawing.Size(30, 20);
            this.LoadTitleID.TabIndex = 66;
            this.LoadTitleID.Text = "➤";
            this.LoadTitleID.Click += new System.EventHandler(this.LoadTitleID_Click);
            // 
            // ReLoad
            // 
            this.ReLoad.BackColor = System.Drawing.Color.Transparent;
            this.ReLoad.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ReLoad.BorderRadius = 10;
            this.ReLoad.BorderThickness = 4;
            this.ReLoad.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ReLoad.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ReLoad.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ReLoad.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ReLoad.FillColor = System.Drawing.SystemColors.ControlDark;
            this.ReLoad.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ReLoad.ForeColor = System.Drawing.Color.Black;
            this.ReLoad.Location = new System.Drawing.Point(752, 143);
            this.ReLoad.Margin = new System.Windows.Forms.Padding(2);
            this.ReLoad.Name = "ReLoad";
            this.ReLoad.Size = new System.Drawing.Size(75, 25);
            this.ReLoad.TabIndex = 48;
            this.ReLoad.Visible = false;
            this.ReLoad.Click += new System.EventHandler(this.Load_Click);
            // 
            // UnlockAll
            // 
            this.UnlockAll.BackColor = System.Drawing.Color.Transparent;
            this.UnlockAll.BorderColor = System.Drawing.Color.Red;
            this.UnlockAll.BorderRadius = 10;
            this.UnlockAll.BorderThickness = 2;
            this.UnlockAll.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.UnlockAll.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.UnlockAll.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.UnlockAll.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.UnlockAll.FillColor = System.Drawing.Color.Black;
            this.UnlockAll.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.UnlockAll.ForeColor = System.Drawing.Color.Red;
            this.UnlockAll.Location = new System.Drawing.Point(665, 320);
            this.UnlockAll.Margin = new System.Windows.Forms.Padding(2);
            this.UnlockAll.Name = "UnlockAll";
            this.UnlockAll.Size = new System.Drawing.Size(102, 25);
            this.UnlockAll.TabIndex = 68;
            this.UnlockAll.Text = "Unlock All";
            this.UnlockAll.Visible = false;
            this.UnlockAll.Click += new System.EventHandler(this.Unlock_Click);
            // 
            // StatsList
            // 
            this.StatsList.BackColor = System.Drawing.Color.Transparent;
            this.StatsList.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.StatsList.BorderThickness = 3;
            this.StatsList.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.StatsList.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.StatsList.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.StatsList.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.StatsList.FillColor = System.Drawing.Color.Black;
            this.StatsList.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.StatsList.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.StatsList.Location = new System.Drawing.Point(543, 223);
            this.StatsList.Margin = new System.Windows.Forms.Padding(2);
            this.StatsList.Name = "StatsList";
            this.StatsList.Size = new System.Drawing.Size(190, 47);
            this.StatsList.TabIndex = 70;
            this.StatsList.Text = "Stats";
            this.StatsList.Click += new System.EventHandler(this.siticoneButton1_Click);
            // 
            // SetStats
            // 
            this.SetStats.BackColor = System.Drawing.Color.Transparent;
            this.SetStats.BorderColor = System.Drawing.Color.Red;
            this.SetStats.BorderRadius = 10;
            this.SetStats.BorderThickness = 2;
            this.SetStats.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.SetStats.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.SetStats.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.SetStats.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.SetStats.FillColor = System.Drawing.Color.Black;
            this.SetStats.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.SetStats.ForeColor = System.Drawing.Color.Red;
            this.SetStats.Location = new System.Drawing.Point(665, 320);
            this.SetStats.Margin = new System.Windows.Forms.Padding(2);
            this.SetStats.Name = "SetStats";
            this.SetStats.Size = new System.Drawing.Size(102, 25);
            this.SetStats.TabIndex = 72;
            this.SetStats.Text = "Set Stats";
            this.SetStats.Visible = false;
            this.SetStats.Click += new System.EventHandler(this.Stats_Click);
            // 
            // CopyTitleId
            // 
            this.CopyTitleId.BackColor = System.Drawing.Color.Transparent;
            this.CopyTitleId.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CopyTitleId.Image = ((System.Drawing.Image)(resources.GetObject("CopyTitleId.Image")));
            this.CopyTitleId.Location = new System.Drawing.Point(84, 114);
            this.CopyTitleId.Margin = new System.Windows.Forms.Padding(2);
            this.CopyTitleId.Name = "CopyTitleId";
            this.CopyTitleId.Size = new System.Drawing.Size(16, 20);
            this.CopyTitleId.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CopyTitleId.TabIndex = 73;
            this.CopyTitleId.TabStop = false;
            this.CopyTitleId.Visible = false;
            this.CopyTitleId.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // StatsGrid
            // 
            this.StatsGrid.AllowUserToResizeColumns = false;
            this.StatsGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Black;
            this.StatsGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.StatsGrid.BackgroundColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.StatsGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.StatsGrid.ColumnHeadersHeight = 4;
            this.StatsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.StatsGrid.DefaultCellStyle = dataGridViewCellStyle6;
            this.StatsGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.StatsGrid.Location = new System.Drawing.Point(69, 435);
            this.StatsGrid.Margin = new System.Windows.Forms.Padding(2);
            this.StatsGrid.Name = "StatsGrid";
            this.StatsGrid.RowHeadersVisible = false;
            this.StatsGrid.RowHeadersWidth = 51;
            this.StatsGrid.RowTemplate.Height = 24;
            this.StatsGrid.Size = new System.Drawing.Size(670, 258);
            this.StatsGrid.TabIndex = 75;
            this.StatsGrid.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.Black;
            this.StatsGrid.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.StatsGrid.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.StatsGrid.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Black;
            this.StatsGrid.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.DeepSkyBlue;
            this.StatsGrid.ThemeStyle.BackColor = System.Drawing.Color.Black;
            this.StatsGrid.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.StatsGrid.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.StatsGrid.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.StatsGrid.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatsGrid.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.StatsGrid.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.StatsGrid.ThemeStyle.HeaderStyle.Height = 4;
            this.StatsGrid.ThemeStyle.ReadOnly = false;
            this.StatsGrid.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.Black;
            this.StatsGrid.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.StatsGrid.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatsGrid.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.StatsGrid.ThemeStyle.RowsStyle.Height = 24;
            this.StatsGrid.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.Black;
            this.StatsGrid.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.DeepSkyBlue;
            this.StatsGrid.Visible = false;
            this.StatsGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellContentClick);
            // 
            // SpoofTitleIdTextBox
            // 
            this.SpoofTitleIdTextBox.BackColor = System.Drawing.Color.Black;
            this.SpoofTitleIdTextBox.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.SpoofTitleIdTextBox.BorderRadius = 3;
            this.SpoofTitleIdTextBox.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.SpoofTitleIdTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.SpoofTitleIdTextBox.DefaultText = "";
            this.SpoofTitleIdTextBox.FillColor = System.Drawing.Color.Black;
            this.SpoofTitleIdTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.SpoofTitleIdTextBox.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.SpoofTitleIdTextBox.Location = new System.Drawing.Point(11, 138);
            this.SpoofTitleIdTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.SpoofTitleIdTextBox.Name = "SpoofTitleIdTextBox";
            this.SpoofTitleIdTextBox.PasswordChar = '\0';
            this.SpoofTitleIdTextBox.PlaceholderForeColor = System.Drawing.Color.DeepSkyBlue;
            this.SpoofTitleIdTextBox.PlaceholderText = "Title ID...";
            this.SpoofTitleIdTextBox.SelectedText = "";
            this.SpoofTitleIdTextBox.Size = new System.Drawing.Size(90, 20);
            this.SpoofTitleIdTextBox.TabIndex = 76;
            // 
            // Achievements
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(848, 695);
            this.Controls.Add(this.TimePanel);
            this.Controls.Add(this.XUIDPanel);
            this.Controls.Add(this.SpoofPanel);
            this.Controls.Add(this.SpoofTitleIdTextBox);
            this.Controls.Add(this.SpoofSwitch);
            this.Controls.Add(this.StatsGrid);
            this.Controls.Add(this.Minimize);
            this.Controls.Add(this.CopyTitleId);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.SetStats);
            this.Controls.Add(this.StatsList);
            this.Controls.Add(this.UnlockAll);
            this.Controls.Add(this.ReLoad);
            this.Controls.Add(this.AchievementsGrid);
            this.Controls.Add(this.AchievementList);
            this.Controls.Add(this.LoadTitleID);
            this.Controls.Add(this.Scid);
            this.Controls.Add(this.TitleId);
            this.Controls.Add(this.G5);
            this.Controls.Add(this.G4);
            this.Controls.Add(this.G3);
            this.Controls.Add(this.G2);
            this.Controls.Add(this.G1);
            this.Controls.Add(this.ERROR);
            this.Controls.Add(this.Token);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.Panel);
            this.Controls.Add(this.discord);
            this.Controls.Add(this.GameName);
            this.Controls.Add(this.SpoofLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = global::PegasusRevived.Properties.Resources.Icon;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Achievements";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manual Unlocker";
            this.Load += new System.EventHandler(this.Achievements_Load);
            this.Panel.ResumeLayout(false);
            this.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.refresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pfp)).EndInit();
            this.SpoofPanel.ResumeLayout(false);
            this.SpoofPanel.PerformLayout();
            this.XUIDPanel.ResumeLayout(false);
            this.XUIDPanel.PerformLayout();
            this.TimePanel.ResumeLayout(false);
            this.TimePanel.PerformLayout();
            this.G1.ResumeLayout(false);
            this.G1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.P1)).EndInit();
            this.G2.ResumeLayout(false);
            this.G2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.P2)).EndInit();
            this.G3.ResumeLayout(false);
            this.G3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.P3)).EndInit();
            this.G4.ResumeLayout(false);
            this.G4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.P4)).EndInit();
            this.G5.ResumeLayout(false);
            this.G5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.P5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AchievementsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CopyTitleId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Label discord;
        private Label GameName;
        private Label SpoofLabel;

        #endregion

        private Siticone.Desktop.UI.WinForms.SiticonePanel Panel;
        private Siticone.Desktop.UI.WinForms.SiticonePanel SpoofPanel;
        private Siticone.Desktop.UI.WinForms.SiticoneButton AsMe;
        private Siticone.Desktop.UI.WinForms.SiticoneButton SBelse;
        private System.Windows.Forms.Button ClosePanel;
        private System.Windows.Forms.Label TextL;
        private Siticone.Desktop.UI.WinForms.SiticonePanel XUIDPanel;
        private System.Windows.Forms.Button ClosePanel2;
        private System.Windows.Forms.Label TextL2;
        private Siticone.Desktop.UI.WinForms.SiticoneTextBox XUIDe;
        private Siticone.Desktop.UI.WinForms.SiticoneButton XUIDaccept;
        private Siticone.Desktop.UI.WinForms.SiticonePanel TimePanel;
        private System.Windows.Forms.Button ClosePanel3;
        private System.Windows.Forms.Label TextL3;
        private Siticone.Desktop.UI.WinForms.SiticoneTextBox Time;
        private Siticone.Desktop.UI.WinForms.SiticoneButton Timeaccept;
        private Siticone.Desktop.UI.WinForms.SiticoneToggleSwitch SpoofSwitch;
        private System.Windows.Forms.PictureBox refresh;
        private System.Windows.Forms.PictureBox pfp;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label Gamertag;
        private System.Windows.Forms.Label Gamerscore;
        private System.Windows.Forms.Label Xuid;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label LBL_Status;
        private Siticone.Desktop.UI.WinForms.SiticoneTextBox Search;
        private System.Windows.Forms.TextBox ERROR;
        private System.Windows.Forms.TextBox Token;
        private Siticone.Desktop.UI.WinForms.SiticoneGradientPanel G1;
        private Siticone.Desktop.UI.WinForms.SiticoneButton Select1;
        private System.Windows.Forms.Label BIG1;
        private System.Windows.Forms.Label N1;
        private System.Windows.Forms.PictureBox P1;
        private Siticone.Desktop.UI.WinForms.SiticoneGradientPanel G2;
        private Siticone.Desktop.UI.WinForms.SiticoneButton Select2;
        private System.Windows.Forms.Label BIG2;
        private System.Windows.Forms.Label N2;
        private System.Windows.Forms.PictureBox P2;
        private Siticone.Desktop.UI.WinForms.SiticoneGradientPanel G3;
        private Siticone.Desktop.UI.WinForms.SiticoneButton Select3;
        private System.Windows.Forms.Label BIG3;
        private System.Windows.Forms.Label N3;
        private System.Windows.Forms.PictureBox P3;
        private Siticone.Desktop.UI.WinForms.SiticoneGradientPanel G4;
        private Siticone.Desktop.UI.WinForms.SiticoneButton Select4;
        private System.Windows.Forms.Label BIG4;
        private System.Windows.Forms.Label N4;
        private System.Windows.Forms.PictureBox P4;
        private Siticone.Desktop.UI.WinForms.SiticoneGradientPanel G5;
        private Siticone.Desktop.UI.WinForms.SiticoneButton Select5;
        private System.Windows.Forms.Label BIG5;
        private System.Windows.Forms.Label N5;
        private System.Windows.Forms.PictureBox P5;
        private System.Windows.Forms.Label D1;
        private System.Windows.Forms.Label D2;
        private System.Windows.Forms.Label D3;
        private System.Windows.Forms.Label D4;
        private System.Windows.Forms.Label D5;
        private System.Windows.Forms.Label TitleId;
        private System.Windows.Forms.Label Scid;
        private Siticone.Desktop.UI.WinForms.SiticoneButton AchievementList;
        private Siticone.Desktop.UI.WinForms.SiticoneButton LoadTitleID;
        private Siticone.Desktop.UI.WinForms.SiticoneButton ReLoad;
        private Siticone.Desktop.UI.WinForms.SiticoneButton UnlockAll;
        private Siticone.Desktop.UI.WinForms.SiticoneButton StatsList;
        private Siticone.Desktop.UI.WinForms.SiticoneButton SetStats;
        private System.Windows.Forms.Label T1;
        private System.Windows.Forms.Label T2;
        private System.Windows.Forms.Label T3;
        private System.Windows.Forms.Label T4;
        private System.Windows.Forms.Label T5;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.Button Minimize;
        private System.Windows.Forms.PictureBox CopyTitleId;
        public Siticone.Desktop.UI.WinForms.SiticoneDataGridView AchievementsGrid;
        public Siticone.Desktop.UI.WinForms.SiticoneDataGridView StatsGrid;
        private Siticone.Desktop.UI.WinForms.SiticoneTextBox SpoofTitleIdTextBox;
    }
}