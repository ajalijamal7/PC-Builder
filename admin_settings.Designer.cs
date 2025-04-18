using System;

namespace PC_Builder
{
    partial class frm_settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
    
        private void panel1_Click(object sender, EventArgs e)
        {

        }
        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }
        private void bunifuCards1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_settings));
            this.crd_dark = new Bunifu.Framework.UI.BunifuCards();
            this.pnl_Dark = new System.Windows.Forms.Panel();
            this.lbl_Dark = new Bunifu.UI.WinForms.BunifuLabel();
            this.pnl_Light = new System.Windows.Forms.Panel();
            this.lbl_light = new Bunifu.UI.WinForms.BunifuLabel();
            this.crd_Light = new Bunifu.Framework.UI.BunifuCards();
            this.crd_dark.SuspendLayout();
            this.pnl_Dark.SuspendLayout();
            this.pnl_Light.SuspendLayout();
            this.crd_Light.SuspendLayout();
            this.SuspendLayout();
            // 
            // crd_dark
            // 
            this.crd_dark.BackColor = System.Drawing.Color.WhiteSmoke;
            this.crd_dark.BorderRadius = 55;
            this.crd_dark.BottomSahddow = true;
            this.crd_dark.color = System.Drawing.Color.White;
            this.crd_dark.Controls.Add(this.pnl_Dark);
            this.crd_dark.ForeColor = System.Drawing.SystemColors.ControlText;
            this.crd_dark.LeftSahddow = false;
            this.crd_dark.Location = new System.Drawing.Point(517, 51);
            this.crd_dark.Name = "crd_dark";
            this.crd_dark.RightSahddow = true;
            this.crd_dark.ShadowDepth = 20;
            this.crd_dark.Size = new System.Drawing.Size(230, 215);
            this.crd_dark.TabIndex = 1;
            this.crd_dark.Click += new System.EventHandler(this.crd_dark_Click);
            // 
            // pnl_Dark
            // 
            this.pnl_Dark.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnl_Dark.Controls.Add(this.lbl_Dark);
            this.pnl_Dark.Location = new System.Drawing.Point(67, 42);
            this.pnl_Dark.Name = "pnl_Dark";
            this.pnl_Dark.Size = new System.Drawing.Size(163, 170);
            this.pnl_Dark.TabIndex = 1;
            this.pnl_Dark.Click += new System.EventHandler(this.pnl_Dark_Click);
            // 
            // lbl_Dark
            // 
            this.lbl_Dark.AllowParentOverrides = false;
            this.lbl_Dark.AutoEllipsis = false;
            this.lbl_Dark.CursorType = null;
            this.lbl_Dark.Font = new System.Drawing.Font("Segoe UI", 16.2F);
            this.lbl_Dark.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbl_Dark.Location = new System.Drawing.Point(3, 3);
            this.lbl_Dark.Name = "lbl_Dark";
            this.lbl_Dark.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_Dark.Size = new System.Drawing.Size(31, 37);
            this.lbl_Dark.TabIndex = 1;
            this.lbl_Dark.Text = "Aa";
            this.lbl_Dark.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lbl_Dark.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            this.lbl_Dark.Click += new System.EventHandler(this.lbl_Dark_Click);
            // 
            // pnl_Light
            // 
            this.pnl_Light.BackColor = System.Drawing.Color.White;
            this.pnl_Light.Controls.Add(this.lbl_light);
            this.pnl_Light.Location = new System.Drawing.Point(64, 42);
            this.pnl_Light.Name = "pnl_Light";
            this.pnl_Light.Size = new System.Drawing.Size(152, 170);
            this.pnl_Light.TabIndex = 1;
            this.pnl_Light.Click += new System.EventHandler(this.pnl_Light_Click);
            // 
            // lbl_light
            // 
            this.lbl_light.AllowParentOverrides = false;
            this.lbl_light.AutoEllipsis = false;
            this.lbl_light.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbl_light.CursorType = System.Windows.Forms.Cursors.Default;
            this.lbl_light.Font = new System.Drawing.Font("Segoe UI", 16.2F);
            this.lbl_light.Location = new System.Drawing.Point(3, 3);
            this.lbl_light.Name = "lbl_light";
            this.lbl_light.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_light.Size = new System.Drawing.Size(31, 37);
            this.lbl_light.TabIndex = 1;
            this.lbl_light.Text = "Aa";
            this.lbl_light.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lbl_light.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            this.lbl_light.Click += new System.EventHandler(this.lbl_light_Click);
            // 
            // crd_Light
            // 
            this.crd_Light.BackColor = System.Drawing.Color.WhiteSmoke;
            this.crd_Light.BorderRadius = 55;
            this.crd_Light.BottomSahddow = true;
            this.crd_Light.color = System.Drawing.Color.White;
            this.crd_Light.Controls.Add(this.pnl_Light);
            this.crd_Light.ForeColor = System.Drawing.SystemColors.ControlText;
            this.crd_Light.LeftSahddow = false;
            this.crd_Light.Location = new System.Drawing.Point(120, 51);
            this.crd_Light.Name = "crd_Light";
            this.crd_Light.RightSahddow = true;
            this.crd_Light.ShadowDepth = 20;
            this.crd_Light.Size = new System.Drawing.Size(219, 215);
            this.crd_Light.TabIndex = 0;
            this.crd_Light.Click += new System.EventHandler(this.crd_Light_Click);
            this.crd_Light.Paint += new System.Windows.Forms.PaintEventHandler(this.crd_Light_Paint);
            // 
            // frm_settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.crd_dark);
            this.Controls.Add(this.crd_Light);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_settings";
            this.Text = "c";
            this.Load += new System.EventHandler(this.pnl_settings_Load);
            this.crd_dark.ResumeLayout(false);
            this.pnl_Dark.ResumeLayout(false);
            this.pnl_Dark.PerformLayout();
            this.pnl_Light.ResumeLayout(false);
            this.pnl_Light.PerformLayout();
            this.crd_Light.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Bunifu.Framework.UI.BunifuCards crd_dark;
        private System.Windows.Forms.Panel pnl_Dark;
        private Bunifu.UI.WinForms.BunifuLabel lbl_Dark;
        private System.Windows.Forms.Panel pnl_Light;
        private Bunifu.UI.WinForms.BunifuLabel lbl_light;
        private Bunifu.Framework.UI.BunifuCards crd_Light;
    }
}