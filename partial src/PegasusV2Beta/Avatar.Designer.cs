namespace PegasusV2Beta
{
    partial class Avatar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Avatar));
            this.Token = new System.Windows.Forms.TextBox();
            this.Error = new System.Windows.Forms.TextBox();
            this.siticonePanel2 = new Siticone.Desktop.UI.WinForms.SiticonePanel();
            this.LBL_Status = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.refresh = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Gamertag = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Gamerscore = new System.Windows.Forms.Label();
            this.Xuid = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Close = new System.Windows.Forms.Button();
            this.minimize = new System.Windows.Forms.Button();
            this.search = new Siticone.Desktop.UI.WinForms.SiticoneTextBox();
            this.avatarp = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Steal = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.label2 = new System.Windows.Forms.Label();
            this.Backup = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.Restore = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.label14 = new System.Windows.Forms.Label();
            this.colorB = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.siticonePanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.refresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.avatarp)).BeginInit();
            this.SuspendLayout();
            // 
            // Token
            // 
            this.Token.Location = new System.Drawing.Point(639, 386);
            this.Token.Margin = new System.Windows.Forms.Padding(2);
            this.Token.Name = "Token";
            this.Token.Size = new System.Drawing.Size(150, 20);
            this.Token.TabIndex = 0;
            this.Token.Visible = false;
            // 
            // Error
            // 
            this.Error.Location = new System.Drawing.Point(713, 419);
            this.Error.Margin = new System.Windows.Forms.Padding(2);
            this.Error.Name = "Error";
            this.Error.ReadOnly = true;
            this.Error.Size = new System.Drawing.Size(76, 20);
            this.Error.TabIndex = 3;
            this.Error.Visible = false;
            // 
            // siticonePanel2
            // 
            this.siticonePanel2.BackColor = System.Drawing.Color.Transparent;
            this.siticonePanel2.Controls.Add(this.LBL_Status);
            this.siticonePanel2.Controls.Add(this.label11);
            this.siticonePanel2.Controls.Add(this.refresh);
            this.siticonePanel2.Controls.Add(this.label9);
            this.siticonePanel2.Controls.Add(this.Gamertag);
            this.siticonePanel2.Controls.Add(this.pictureBox1);
            this.siticonePanel2.Controls.Add(this.Gamerscore);
            this.siticonePanel2.Controls.Add(this.Xuid);
            this.siticonePanel2.Controls.Add(this.label10);
            this.siticonePanel2.Controls.Add(this.label8);
            this.siticonePanel2.Location = new System.Drawing.Point(0, 0);
            this.siticonePanel2.Name = "siticonePanel2";
            this.siticonePanel2.Size = new System.Drawing.Size(514, 100);
            this.siticonePanel2.TabIndex = 50;
            // 
            // LBL_Status
            // 
            this.LBL_Status.AutoSize = true;
            this.LBL_Status.BackColor = System.Drawing.Color.Transparent;
            this.LBL_Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Status.ForeColor = System.Drawing.Color.White;
            this.LBL_Status.Location = new System.Drawing.Point(127, 83);
            this.LBL_Status.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LBL_Status.Name = "LBL_Status";
            this.LBL_Status.Size = new System.Drawing.Size(52, 13);
            this.LBL_Status.TabIndex = 243;
            this.LBL_Status.Text = "Loading";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(104, 83);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(0, 13);
            this.label11.TabIndex = 244;
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
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 47;
            this.pictureBox1.TabStop = false;
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
            // Close
            // 
            this.Close.BackColor = System.Drawing.Color.Transparent;
            this.Close.FlatAppearance.BorderSize = 0;
            this.Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Close.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.Close.ForeColor = System.Drawing.Color.Black;
            this.Close.Location = new System.Drawing.Point(766, 0);
            this.Close.Margin = new System.Windows.Forms.Padding(2);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(30, 32);
            this.Close.TabIndex = 241;
            this.Close.Text = "×";
            this.Close.UseVisualStyleBackColor = false;
            this.Close.Click += new System.EventHandler(this.button2_Click);
            // 
            // minimize
            // 
            this.minimize.BackColor = System.Drawing.Color.Transparent;
            this.minimize.FlatAppearance.BorderSize = 0;
            this.minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimize.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.minimize.ForeColor = System.Drawing.Color.Black;
            this.minimize.Location = new System.Drawing.Point(736, 0);
            this.minimize.Margin = new System.Windows.Forms.Padding(2);
            this.minimize.Name = "minimize";
            this.minimize.Size = new System.Drawing.Size(30, 32);
            this.minimize.TabIndex = 242;
            this.minimize.Text = "–";
            this.minimize.UseVisualStyleBackColor = false;
            this.minimize.Click += new System.EventHandler(this.buttonMinimize_Click);
            // 
            // search
            // 
            this.search.BackColor = System.Drawing.Color.Transparent;
            this.search.BorderColor = System.Drawing.Color.Crimson;
            this.search.BorderRadius = 10;
            this.search.BorderThickness = 2;
            this.search.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.search.DefaultText = "";
            this.search.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.search.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.search.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.search.FillColor = System.Drawing.Color.LightGray;
            this.search.FocusedState.BorderColor = System.Drawing.Color.Crimson;
            this.search.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.search.ForeColor = System.Drawing.Color.OrangeRed;
            this.search.Location = new System.Drawing.Point(344, 134);
            this.search.Margin = new System.Windows.Forms.Padding(2);
            this.search.Name = "search";
            this.search.PasswordChar = '\0';
            this.search.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.search.PlaceholderText = "Enter Gamertag...";
            this.search.SelectedText = "";
            this.search.Size = new System.Drawing.Size(115, 24);
            this.search.TabIndex = 51;
            this.search.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // avatarp
            // 
            this.avatarp.BackColor = System.Drawing.Color.Transparent;
            this.avatarp.Location = new System.Drawing.Point(344, 162);
            this.avatarp.Margin = new System.Windows.Forms.Padding(2);
            this.avatarp.Name = "avatarp";
            this.avatarp.Size = new System.Drawing.Size(115, 200);
            this.avatarp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.avatarp.TabIndex = 52;
            this.avatarp.TabStop = false;
            this.avatarp.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(11, 175);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 237;
            this.label1.Text = "XUID";
            this.label1.Visible = false;
            // 
            // Steal
            // 
            this.Steal.BackColor = System.Drawing.Color.Transparent;
            this.Steal.BorderColor = System.Drawing.Color.Crimson;
            this.Steal.BorderRadius = 10;
            this.Steal.BorderThickness = 2;
            this.Steal.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Steal.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Steal.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Steal.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Steal.FillColor = System.Drawing.Color.LightGray;
            this.Steal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Steal.ForeColor = System.Drawing.Color.Black;
            this.Steal.Location = new System.Drawing.Point(353, 366);
            this.Steal.Margin = new System.Windows.Forms.Padding(2);
            this.Steal.Name = "Steal";
            this.Steal.Size = new System.Drawing.Size(95, 24);
            this.Steal.TabIndex = 238;
            this.Steal.Text = "Steal Avatar";
            this.Steal.Visible = false;
            this.Steal.Click += new System.EventHandler(this.siticoneButton4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 205);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 239;
            this.label2.Text = "Wait Connect";
            this.label2.Visible = false;
            // 
            // Backup
            // 
            this.Backup.BackColor = System.Drawing.Color.Transparent;
            this.Backup.BorderColor = System.Drawing.Color.Crimson;
            this.Backup.BorderRadius = 10;
            this.Backup.BorderThickness = 2;
            this.Backup.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Backup.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Backup.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Backup.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Backup.FillColor = System.Drawing.Color.LightGray;
            this.Backup.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Backup.ForeColor = System.Drawing.Color.Black;
            this.Backup.Location = new System.Drawing.Point(618, 164);
            this.Backup.Margin = new System.Windows.Forms.Padding(2);
            this.Backup.Name = "Backup";
            this.Backup.Size = new System.Drawing.Size(95, 24);
            this.Backup.TabIndex = 245;
            this.Backup.Text = "Backup";
            this.Backup.Click += new System.EventHandler(this.siticoneButton5_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(11, 235);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 13);
            this.label12.TabIndex = 246;
            this.label12.Text = "Wait Connect";
            this.label12.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(608, 146);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(114, 16);
            this.label13.TabIndex = 247;
            this.label13.Text = "Backup Your Avatar";
            // 
            // Restore
            // 
            this.Restore.BackColor = System.Drawing.Color.Transparent;
            this.Restore.BorderColor = System.Drawing.Color.Crimson;
            this.Restore.BorderRadius = 10;
            this.Restore.BorderThickness = 2;
            this.Restore.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Restore.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Restore.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Restore.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Restore.FillColor = System.Drawing.Color.LightGray;
            this.Restore.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Restore.ForeColor = System.Drawing.Color.Black;
            this.Restore.Location = new System.Drawing.Point(618, 224);
            this.Restore.Margin = new System.Windows.Forms.Padding(2);
            this.Restore.Name = "Restore";
            this.Restore.Size = new System.Drawing.Size(95, 24);
            this.Restore.TabIndex = 248;
            this.Restore.Text = "Restore";
            this.Restore.Click += new System.EventHandler(this.siticoneButton6_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(618, 205);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(93, 16);
            this.label14.TabIndex = 249;
            this.label14.Text = "Restore Backup";
            // 
            // colorB
            // 
            this.colorB.BackColor = System.Drawing.Color.Transparent;
            this.colorB.BorderColor = System.Drawing.Color.Crimson;
            this.colorB.BorderRadius = 10;
            this.colorB.BorderThickness = 2;
            this.colorB.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.colorB.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.colorB.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.colorB.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.colorB.FillColor = System.Drawing.Color.LightGray;
            this.colorB.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.colorB.ForeColor = System.Drawing.Color.Black;
            this.colorB.Location = new System.Drawing.Point(152, 366);
            this.colorB.Margin = new System.Windows.Forms.Padding(2);
            this.colorB.Name = "colorB";
            this.colorB.Size = new System.Drawing.Size(110, 24);
            this.colorB.TabIndex = 250;
            this.colorB.Text = "change color";
            // 
            // Avatar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(28)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.colorB);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.Restore);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.minimize);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.Backup);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Steal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.avatarp);
            this.Controls.Add(this.search);
            this.Controls.Add(this.siticonePanel2);
            this.Controls.Add(this.Error);
            this.Controls.Add(this.Token);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = global::PegasusRevived.Properties.Resources.Icon;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Avatar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Avatar";
            this.Load += new System.EventHandler(this.Avatar_Load);
            this.siticonePanel2.ResumeLayout(false);
            this.siticonePanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.refresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.avatarp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.TextBox Token;
        private System.Windows.Forms.TextBox Error;
        private Siticone.Desktop.UI.WinForms.SiticonePanel siticonePanel2;
        private System.Windows.Forms.PictureBox refresh;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label Gamertag;
        private System.Windows.Forms.Label Gamerscore;
        private System.Windows.Forms.Label Xuid;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private Siticone.Desktop.UI.WinForms.SiticoneTextBox search;
        private System.Windows.Forms.PictureBox avatarp;
        private System.Windows.Forms.Label label1;
        private Siticone.Desktop.UI.WinForms.SiticoneButton Steal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.Button minimize;
        private System.Windows.Forms.Label LBL_Status;
        private System.Windows.Forms.Label label11;
        private Siticone.Desktop.UI.WinForms.SiticoneButton Backup;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private Siticone.Desktop.UI.WinForms.SiticoneButton Restore;
        private System.Windows.Forms.Label label14;
        private Siticone.Desktop.UI.WinForms.SiticoneButton colorB;
    }
}