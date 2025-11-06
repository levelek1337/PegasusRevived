namespace PegasusV2Beta
{
    partial class Info
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Info));
            this.close = new System.Windows.Forms.Button();
            this.minimize = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.credits = new System.Windows.Forms.Label();
            this.quote = new System.Windows.Forms.Label();
            this.support = new System.Windows.Forms.Label();
            this.link = new System.Windows.Forms.Label();
            this.version = new System.Windows.Forms.Label();
            this.picture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            this.SuspendLayout();
            // 
            // close
            // 
            this.close.BackColor = System.Drawing.Color.Transparent;
            this.close.FlatAppearance.BorderSize = 0;
            this.close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.close.ForeColor = System.Drawing.Color.White;
            this.close.Location = new System.Drawing.Point(814, 0);
            this.close.Margin = new System.Windows.Forms.Padding(2);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(30, 32);
            this.close.TabIndex = 53;
            this.close.Text = "×";
            this.close.UseVisualStyleBackColor = false;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // minimize
            // 
            this.minimize.BackColor = System.Drawing.Color.Transparent;
            this.minimize.FlatAppearance.BorderSize = 0;
            this.minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimize.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.minimize.ForeColor = System.Drawing.Color.White;
            this.minimize.Location = new System.Drawing.Point(780, 0);
            this.minimize.Margin = new System.Windows.Forms.Padding(2);
            this.minimize.Name = "minimize";
            this.minimize.Size = new System.Drawing.Size(30, 32);
            this.minimize.TabIndex = 54;
            this.minimize.Text = "–";
            this.minimize.UseVisualStyleBackColor = false;
            this.minimize.Click += new System.EventHandler(this.minimize_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Sitka Display", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(213, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 30);
            this.label1.TabIndex = 240;
            this.label1.Text = "Hall Of Fame";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // credits
            // 
            this.credits.AutoSize = true;
            this.credits.BackColor = System.Drawing.Color.Transparent;
            this.credits.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.credits.ForeColor = System.Drawing.Color.White;
            this.credits.Location = new System.Drawing.Point(113, 88);
            this.credits.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.credits.Name = "credits";
            this.credits.Size = new System.Drawing.Size(322, 175);
            this.credits.TabIndex = 240;
            this.credits.Text = "SpriTe - Original Pegasus Project\r\n\r\nlevelek1337 - Revived Project\r\n\r\nSteve Modz " +
    "- Token Grabber\r\n\r\nFusion Company - Party Tool";
            this.credits.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // quote
            // 
            this.quote.AutoSize = true;
            this.quote.BackColor = System.Drawing.Color.Transparent;
            this.quote.Font = new System.Drawing.Font("Sitka Display", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quote.ForeColor = System.Drawing.Color.White;
            this.quote.Location = new System.Drawing.Point(11, 473);
            this.quote.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.quote.Name = "quote";
            this.quote.Size = new System.Drawing.Size(572, 30);
            this.quote.TabIndex = 240;
            this.quote.Text = "\'\'United States is illegitmate country, just like Israel\'\' - Bobby Fischer";
            // 
            // support
            // 
            this.support.AutoSize = true;
            this.support.BackColor = System.Drawing.Color.Transparent;
            this.support.Font = new System.Drawing.Font("Sitka Display", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.support.ForeColor = System.Drawing.Color.White;
            this.support.Location = new System.Drawing.Point(81, 344);
            this.support.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.support.Name = "support";
            this.support.Size = new System.Drawing.Size(382, 30);
            this.support.TabIndex = 240;
            this.support.Text = "If you like Pegasus, consider supporting me :";
            // 
            // link
            // 
            this.link.AutoSize = true;
            this.link.BackColor = System.Drawing.Color.Transparent;
            this.link.Font = new System.Drawing.Font("NSimSun", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.link.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.link.Location = new System.Drawing.Point(139, 406);
            this.link.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.link.Name = "link";
            this.link.Size = new System.Drawing.Size(262, 21);
            this.link.TabIndex = 240;
            this.link.Text = "paypal.me/levelek1337";
            this.link.Click += new System.EventHandler(this.link_Click);
            // 
            // version
            // 
            this.version.AutoSize = true;
            this.version.BackColor = System.Drawing.Color.Transparent;
            this.version.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.version.ForeColor = System.Drawing.Color.White;
            this.version.Location = new System.Drawing.Point(638, 476);
            this.version.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(197, 27);
            this.version.TabIndex = 240;
            this.version.Text = "version : partial src";
            // 
            // picture
            // 
            this.picture.BackColor = System.Drawing.Color.Transparent;
            this.picture.ErrorImage = null;
            this.picture.Image = ((System.Drawing.Image)(resources.GetObject("picture.Image")));
            this.picture.Location = new System.Drawing.Point(542, 88);
            this.picture.Margin = new System.Windows.Forms.Padding(2);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(252, 327);
            this.picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture.TabIndex = 241;
            this.picture.TabStop = false;
            // 
            // Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(846, 512);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.credits);
            this.Controls.Add(this.quote);
            this.Controls.Add(this.support);
            this.Controls.Add(this.link);
            this.Controls.Add(this.version);
            this.Controls.Add(this.picture);
            this.Controls.Add(this.close);
            this.Controls.Add(this.minimize);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = global::PegasusRevived.Properties.Resources.Icon;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Info";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Info";
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Button minimize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label credits;
        private System.Windows.Forms.Label quote;
        private System.Windows.Forms.Label support;
        private System.Windows.Forms.Label link;
        private System.Windows.Forms.Label version;
        private System.Windows.Forms.PictureBox picture;
    }
}