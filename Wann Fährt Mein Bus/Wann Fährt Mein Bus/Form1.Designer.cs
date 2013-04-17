namespace Wann_Fährt_Mein_Bus
{
    partial class WFMB_Form
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuBar = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fix_label_stopID = new System.Windows.Forms.Label();
            this.txt_stopID = new System.Windows.Forms.TextBox();
            this.fix_label_stopname = new System.Windows.Forms.Label();
            this.lbl_stopname = new System.Windows.Forms.Label();
            this.fix_label_route = new System.Windows.Forms.Label();
            this.lbl_route = new System.Windows.Forms.Label();
            this.fix_label_fahrtrichtung = new System.Windows.Forms.Label();
            this.lbl_fahrtrichtung = new System.Windows.Forms.Label();
            this.btn_getInfo = new System.Windows.Forms.Button();
            this.txt_ausgabe = new System.Windows.Forms.TextBox();
            this.lbl_currentTime = new System.Windows.Forms.Label();
            this.fix_label_cuurentTime = new System.Windows.Forms.Label();
            this.menuBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuBar
            // 
            this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem});
            this.menuBar.Location = new System.Drawing.Point(0, 0);
            this.menuBar.Name = "menuBar";
            this.menuBar.Size = new System.Drawing.Size(693, 24);
            this.menuBar.TabIndex = 0;
            this.menuBar.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.dateiToolStripMenuItem.Text = "Info";
            // 
            // fix_label_stopID
            // 
            this.fix_label_stopID.AutoSize = true;
            this.fix_label_stopID.Location = new System.Drawing.Point(9, 31);
            this.fix_label_stopID.Name = "fix_label_stopID";
            this.fix_label_stopID.Size = new System.Drawing.Size(46, 13);
            this.fix_label_stopID.TabIndex = 1;
            this.fix_label_stopID.Text = "Stop ID:";
            // 
            // txt_stopID
            // 
            this.txt_stopID.Location = new System.Drawing.Point(65, 28);
            this.txt_stopID.Name = "txt_stopID";
            this.txt_stopID.Size = new System.Drawing.Size(100, 20);
            this.txt_stopID.TabIndex = 2;
            this.txt_stopID.TextChanged += new System.EventHandler(this.txt_stopID_TextChanged);
            // 
            // fix_label_stopname
            // 
            this.fix_label_stopname.AutoSize = true;
            this.fix_label_stopname.Location = new System.Drawing.Point(12, 61);
            this.fix_label_stopname.Name = "fix_label_stopname";
            this.fix_label_stopname.Size = new System.Drawing.Size(58, 13);
            this.fix_label_stopname.TabIndex = 3;
            this.fix_label_stopname.Text = "Stopname:";
            // 
            // lbl_stopname
            // 
            this.lbl_stopname.AutoSize = true;
            this.lbl_stopname.Location = new System.Drawing.Point(76, 61);
            this.lbl_stopname.Name = "lbl_stopname";
            this.lbl_stopname.Size = new System.Drawing.Size(0, 13);
            this.lbl_stopname.TabIndex = 4;
            // 
            // fix_label_route
            // 
            this.fix_label_route.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fix_label_route.AutoSize = true;
            this.fix_label_route.Location = new System.Drawing.Point(418, 31);
            this.fix_label_route.Name = "fix_label_route";
            this.fix_label_route.Size = new System.Drawing.Size(39, 13);
            this.fix_label_route.TabIndex = 5;
            this.fix_label_route.Text = "Route:";
            // 
            // lbl_route
            // 
            this.lbl_route.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_route.AutoSize = true;
            this.lbl_route.Location = new System.Drawing.Point(463, 31);
            this.lbl_route.Name = "lbl_route";
            this.lbl_route.Size = new System.Drawing.Size(0, 13);
            this.lbl_route.TabIndex = 6;
            // 
            // fix_label_fahrtrichtung
            // 
            this.fix_label_fahrtrichtung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fix_label_fahrtrichtung.AutoSize = true;
            this.fix_label_fahrtrichtung.Location = new System.Drawing.Point(418, 61);
            this.fix_label_fahrtrichtung.Name = "fix_label_fahrtrichtung";
            this.fix_label_fahrtrichtung.Size = new System.Drawing.Size(72, 13);
            this.fix_label_fahrtrichtung.TabIndex = 7;
            this.fix_label_fahrtrichtung.Text = "Fahrtrichtung:";
            // 
            // lbl_fahrtrichtung
            // 
            this.lbl_fahrtrichtung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_fahrtrichtung.AutoSize = true;
            this.lbl_fahrtrichtung.Location = new System.Drawing.Point(496, 61);
            this.lbl_fahrtrichtung.Name = "lbl_fahrtrichtung";
            this.lbl_fahrtrichtung.Size = new System.Drawing.Size(0, 13);
            this.lbl_fahrtrichtung.TabIndex = 8;
            // 
            // btn_getInfo
            // 
            this.btn_getInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_getInfo.Enabled = false;
            this.btn_getInfo.Location = new System.Drawing.Point(12, 78);
            this.btn_getInfo.Name = "btn_getInfo";
            this.btn_getInfo.Size = new System.Drawing.Size(669, 23);
            this.btn_getInfo.TabIndex = 9;
            this.btn_getInfo.Text = "Wann fährt mein Bus?";
            this.btn_getInfo.UseVisualStyleBackColor = true;
            this.btn_getInfo.Click += new System.EventHandler(this.btn_getInfo_Click);
            // 
            // txt_ausgabe
            // 
            this.txt_ausgabe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_ausgabe.BackColor = System.Drawing.SystemColors.Window;
            this.txt_ausgabe.Location = new System.Drawing.Point(12, 108);
            this.txt_ausgabe.Multiline = true;
            this.txt_ausgabe.Name = "txt_ausgabe";
            this.txt_ausgabe.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_ausgabe.Size = new System.Drawing.Size(669, 164);
            this.txt_ausgabe.TabIndex = 10;
            // 
            // lbl_currentTime
            // 
            this.lbl_currentTime.AutoSize = true;
            this.lbl_currentTime.Location = new System.Drawing.Point(282, 31);
            this.lbl_currentTime.Name = "lbl_currentTime";
            this.lbl_currentTime.Size = new System.Drawing.Size(0, 13);
            this.lbl_currentTime.TabIndex = 11;
            // 
            // fix_label_cuurentTime
            // 
            this.fix_label_cuurentTime.AutoSize = true;
            this.fix_label_cuurentTime.Location = new System.Drawing.Point(171, 31);
            this.fix_label_cuurentTime.Name = "fix_label_cuurentTime";
            this.fix_label_cuurentTime.Size = new System.Drawing.Size(105, 13);
            this.fix_label_cuurentTime.TabIndex = 12;
            this.fix_label_cuurentTime.Text = "Datum / Zeit vor Ort:";
            // 
            // WFMB_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 284);
            this.Controls.Add(this.fix_label_cuurentTime);
            this.Controls.Add(this.lbl_currentTime);
            this.Controls.Add(this.txt_ausgabe);
            this.Controls.Add(this.btn_getInfo);
            this.Controls.Add(this.lbl_fahrtrichtung);
            this.Controls.Add(this.fix_label_fahrtrichtung);
            this.Controls.Add(this.lbl_route);
            this.Controls.Add(this.fix_label_route);
            this.Controls.Add(this.lbl_stopname);
            this.Controls.Add(this.fix_label_stopname);
            this.Controls.Add(this.txt_stopID);
            this.Controls.Add(this.fix_label_stopID);
            this.Controls.Add(this.menuBar);
            this.MainMenuStrip = this.menuBar;
            this.MinimumSize = new System.Drawing.Size(709, 320);
            this.Name = "WFMB_Form";
            this.Text = "Wann fährt mein Bus?";
            this.Load += new System.EventHandler(this.WFMB_Form_Load);
            this.menuBar.ResumeLayout(false);
            this.menuBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuBar;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.Label fix_label_stopID;
        private System.Windows.Forms.TextBox txt_stopID;
        private System.Windows.Forms.Label fix_label_stopname;
        private System.Windows.Forms.Label lbl_stopname;
        private System.Windows.Forms.Label fix_label_route;
        private System.Windows.Forms.Label lbl_route;
        private System.Windows.Forms.Label fix_label_fahrtrichtung;
        private System.Windows.Forms.Label lbl_fahrtrichtung;
        private System.Windows.Forms.Button btn_getInfo;
        private System.Windows.Forms.TextBox txt_ausgabe;
        private System.Windows.Forms.Label lbl_currentTime;
        private System.Windows.Forms.Label fix_label_cuurentTime;
    }
}

