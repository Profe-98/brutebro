using System.Windows.Forms;

namespace bruteBro
{
    partial class MainWindow
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
            this.TBOX_log = new System.Windows.Forms.RichTextBox();
            this.TBOX_ip = new System.Windows.Forms.TextBox();
            this.BTN_start = new System.Windows.Forms.Button();
            this.CHBOX_logonTry = new System.Windows.Forms.CheckBox();
            this.LAB_ip = new System.Windows.Forms.Label();
            this.LAB_port = new System.Windows.Forms.Label();
            this.TBAR_passwordLenght = new System.Windows.Forms.TrackBar();
            this.TBARLAB_pwlength = new System.Windows.Forms.Label();
            this.TBOX_port = new System.Windows.Forms.TextBox();
            this.BTN_rainbowtbls = new System.Windows.Forms.Button();
            this.LB_rainbow_files = new System.Windows.Forms.ListBox();
            this.TC_gui = new System.Windows.Forms.TabControl();
            this.TP_generate = new System.Windows.Forms.TabPage();
            this.TP_rainbow_tbls = new System.Windows.Forms.TabPage();
            this.BTN_Start1 = new System.Windows.Forms.Button();
            this.LAB_ip1 = new System.Windows.Forms.Label();
            this.TB_port1 = new System.Windows.Forms.TextBox();
            this.TB_ip1 = new System.Windows.Forms.TextBox();
            this.LAB_port1 = new System.Windows.Forms.Label();
            this.CHBOX_logonTry1 = new System.Windows.Forms.CheckBox();
            this.TP_docs = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.TBAR_passwordLenght)).BeginInit();
            this.TC_gui.SuspendLayout();
            this.TP_generate.SuspendLayout();
            this.TP_rainbow_tbls.SuspendLayout();
            this.SuspendLayout();
            // 
            // TBOX_log
            // 
            this.TBOX_log.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TBOX_log.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBOX_log.ForeColor = System.Drawing.Color.Chartreuse;
            this.TBOX_log.Location = new System.Drawing.Point(12, 12);
            this.TBOX_log.Name = "TBOX_log";
            this.TBOX_log.ReadOnly = true;
            this.TBOX_log.Size = new System.Drawing.Size(635, 382);
            this.TBOX_log.TabIndex = 0;
            this.TBOX_log.Text = "";
            // 
            // TBOX_ip
            // 
            this.TBOX_ip.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBOX_ip.Location = new System.Drawing.Point(46, 10);
            this.TBOX_ip.Name = "TBOX_ip";
            this.TBOX_ip.Size = new System.Drawing.Size(100, 20);
            this.TBOX_ip.TabIndex = 1;
            // 
            // BTN_start
            // 
            this.BTN_start.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_start.Location = new System.Drawing.Point(6, 97);
            this.BTN_start.Name = "BTN_start";
            this.BTN_start.Size = new System.Drawing.Size(75, 23);
            this.BTN_start.TabIndex = 2;
            this.BTN_start.Text = "Start";
            this.BTN_start.UseVisualStyleBackColor = true;
            this.BTN_start.Click += new System.EventHandler(this.StartBTN_Click);
            // 
            // CHBOX_logonTry
            // 
            this.CHBOX_logonTry.AutoSize = true;
            this.CHBOX_logonTry.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CHBOX_logonTry.Location = new System.Drawing.Point(6, 74);
            this.CHBOX_logonTry.Name = "CHBOX_logonTry";
            this.CHBOX_logonTry.Size = new System.Drawing.Size(146, 17);
            this.CHBOX_logonTry.TabIndex = 3;
            this.CHBOX_logonTry.Text = "CheckMaximumLogonTry";
            this.CHBOX_logonTry.UseVisualStyleBackColor = true;
            this.CHBOX_logonTry.CheckedChanged += new System.EventHandler(this.LogonTryCHBOX_CheckedChanged);
            // 
            // LAB_ip
            // 
            this.LAB_ip.AutoSize = true;
            this.LAB_ip.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LAB_ip.Location = new System.Drawing.Point(3, 13);
            this.LAB_ip.Name = "LAB_ip";
            this.LAB_ip.Size = new System.Drawing.Size(37, 13);
            this.LAB_ip.TabIndex = 4;
            this.LAB_ip.Text = "IPv4:";
            // 
            // LAB_port
            // 
            this.LAB_port.AutoSize = true;
            this.LAB_port.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LAB_port.Location = new System.Drawing.Point(3, 38);
            this.LAB_port.Name = "LAB_port";
            this.LAB_port.Size = new System.Drawing.Size(37, 13);
            this.LAB_port.TabIndex = 5;
            this.LAB_port.Text = "Port:";
            // 
            // TBAR_passwordLenght
            // 
            this.TBAR_passwordLenght.Location = new System.Drawing.Point(164, 10);
            this.TBAR_passwordLenght.Maximum = 32;
            this.TBAR_passwordLenght.Minimum = 1;
            this.TBAR_passwordLenght.Name = "TBAR_passwordLenght";
            this.TBAR_passwordLenght.Size = new System.Drawing.Size(253, 45);
            this.TBAR_passwordLenght.TabIndex = 9;
            this.TBAR_passwordLenght.Value = 1;
            this.TBAR_passwordLenght.Scroll += new System.EventHandler(this.PasswordLenghtTBAR_Scroll);
            this.TBAR_passwordLenght.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PasswordLenghtTBAR_MouseUp);
            // 
            // TBARLAB_pwlength
            // 
            this.TBARLAB_pwlength.AutoSize = true;
            this.TBARLAB_pwlength.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBARLAB_pwlength.Location = new System.Drawing.Point(235, 58);
            this.TBARLAB_pwlength.Name = "TBARLAB_pwlength";
            this.TBARLAB_pwlength.Size = new System.Drawing.Size(115, 13);
            this.TBARLAB_pwlength.TabIndex = 10;
            this.TBARLAB_pwlength.Text = "PasswordLength - 1";
            // 
            // TBOX_port
            // 
            this.TBOX_port.Location = new System.Drawing.Point(46, 36);
            this.TBOX_port.Name = "TBOX_port";
            this.TBOX_port.Size = new System.Drawing.Size(100, 20);
            this.TBOX_port.TabIndex = 12;
            // 
            // BTN_rainbowtbls
            // 
            this.BTN_rainbowtbls.Location = new System.Drawing.Point(152, 65);
            this.BTN_rainbowtbls.Name = "BTN_rainbowtbls";
            this.BTN_rainbowtbls.Size = new System.Drawing.Size(108, 23);
            this.BTN_rainbowtbls.TabIndex = 13;
            this.BTN_rainbowtbls.Text = "Add rainbow tables";
            this.BTN_rainbowtbls.UseVisualStyleBackColor = true;
            this.BTN_rainbowtbls.Click += new System.EventHandler(this.BTN_rainbowtbls_Click);
            // 
            // LB_rainbow_files
            // 
            this.LB_rainbow_files.BackColor = System.Drawing.SystemColors.Window;
            this.LB_rainbow_files.FormattingEnabled = true;
            this.LB_rainbow_files.Location = new System.Drawing.Point(152, 6);
            this.LB_rainbow_files.Name = "LB_rainbow_files";
            this.LB_rainbow_files.Size = new System.Drawing.Size(265, 56);
            this.LB_rainbow_files.TabIndex = 14;
            // 
            // TC_gui
            // 
            this.TC_gui.Controls.Add(this.TP_generate);
            this.TC_gui.Controls.Add(this.TP_rainbow_tbls);
            this.TC_gui.Controls.Add(this.TP_docs);
            this.TC_gui.Location = new System.Drawing.Point(653, 12);
            this.TC_gui.Name = "TC_gui";
            this.TC_gui.SelectedIndex = 0;
            this.TC_gui.Size = new System.Drawing.Size(431, 382);
            this.TC_gui.TabIndex = 16;
            // 
            // TP_generate
            // 
            this.TP_generate.BackColor = System.Drawing.Color.DimGray;
            this.TP_generate.Controls.Add(this.BTN_start);
            this.TP_generate.Controls.Add(this.LAB_ip);
            this.TP_generate.Controls.Add(this.TBOX_ip);
            this.TP_generate.Controls.Add(this.CHBOX_logonTry);
            this.TP_generate.Controls.Add(this.TBAR_passwordLenght);
            this.TP_generate.Controls.Add(this.TBOX_port);
            this.TP_generate.Controls.Add(this.TBARLAB_pwlength);
            this.TP_generate.Controls.Add(this.LAB_port);
            this.TP_generate.Location = new System.Drawing.Point(4, 22);
            this.TP_generate.Name = "TP_generate";
            this.TP_generate.Padding = new System.Windows.Forms.Padding(3);
            this.TP_generate.Size = new System.Drawing.Size(423, 356);
            this.TP_generate.TabIndex = 0;
            this.TP_generate.Text = "Generate";
            // 
            // TP_rainbow_tbls
            // 
            this.TP_rainbow_tbls.BackColor = System.Drawing.Color.DimGray;
            this.TP_rainbow_tbls.Controls.Add(this.BTN_Start1);
            this.TP_rainbow_tbls.Controls.Add(this.BTN_rainbowtbls);
            this.TP_rainbow_tbls.Controls.Add(this.LAB_ip1);
            this.TP_rainbow_tbls.Controls.Add(this.LB_rainbow_files);
            this.TP_rainbow_tbls.Controls.Add(this.TB_port1);
            this.TP_rainbow_tbls.Controls.Add(this.TB_ip1);
            this.TP_rainbow_tbls.Controls.Add(this.LAB_port1);
            this.TP_rainbow_tbls.Controls.Add(this.CHBOX_logonTry1);
            this.TP_rainbow_tbls.Location = new System.Drawing.Point(4, 22);
            this.TP_rainbow_tbls.Name = "TP_rainbow_tbls";
            this.TP_rainbow_tbls.Padding = new System.Windows.Forms.Padding(3);
            this.TP_rainbow_tbls.Size = new System.Drawing.Size(423, 356);
            this.TP_rainbow_tbls.TabIndex = 1;
            this.TP_rainbow_tbls.Text = "Rainbow tables";
            // 
            // BTN_Start1
            // 
            this.BTN_Start1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Start1.Location = new System.Drawing.Point(6, 94);
            this.BTN_Start1.Name = "BTN_Start1";
            this.BTN_Start1.Size = new System.Drawing.Size(75, 23);
            this.BTN_Start1.TabIndex = 14;
            this.BTN_Start1.Text = "Start";
            this.BTN_Start1.UseVisualStyleBackColor = true;
            this.BTN_Start1.Click += new System.EventHandler(this.BTN_Start1_Click);
            // 
            // LAB_ip1
            // 
            this.LAB_ip1.AutoSize = true;
            this.LAB_ip1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LAB_ip1.Location = new System.Drawing.Point(3, 10);
            this.LAB_ip1.Name = "LAB_ip1";
            this.LAB_ip1.Size = new System.Drawing.Size(37, 13);
            this.LAB_ip1.TabIndex = 16;
            this.LAB_ip1.Text = "IPv4:";
            // 
            // TB_port1
            // 
            this.TB_port1.Location = new System.Drawing.Point(46, 33);
            this.TB_port1.Name = "TB_port1";
            this.TB_port1.Size = new System.Drawing.Size(100, 20);
            this.TB_port1.TabIndex = 18;
            // 
            // TB_ip1
            // 
            this.TB_ip1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_ip1.Location = new System.Drawing.Point(46, 7);
            this.TB_ip1.Name = "TB_ip1";
            this.TB_ip1.Size = new System.Drawing.Size(100, 20);
            this.TB_ip1.TabIndex = 13;
            // 
            // LAB_port1
            // 
            this.LAB_port1.AutoSize = true;
            this.LAB_port1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LAB_port1.Location = new System.Drawing.Point(3, 35);
            this.LAB_port1.Name = "LAB_port1";
            this.LAB_port1.Size = new System.Drawing.Size(37, 13);
            this.LAB_port1.TabIndex = 17;
            this.LAB_port1.Text = "Port:";
            // 
            // CHBOX_logonTry1
            // 
            this.CHBOX_logonTry1.AutoSize = true;
            this.CHBOX_logonTry1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CHBOX_logonTry1.Location = new System.Drawing.Point(6, 71);
            this.CHBOX_logonTry1.Name = "CHBOX_logonTry1";
            this.CHBOX_logonTry1.Size = new System.Drawing.Size(146, 17);
            this.CHBOX_logonTry1.TabIndex = 15;
            this.CHBOX_logonTry1.Text = "CheckMaximumLogonTry";
            this.CHBOX_logonTry1.UseVisualStyleBackColor = true;
            // 
            // TP_docs
            // 
            this.TP_docs.BackColor = System.Drawing.Color.DimGray;
            this.TP_docs.Location = new System.Drawing.Point(4, 22);
            this.TP_docs.Name = "TP_docs";
            this.TP_docs.Size = new System.Drawing.Size(423, 356);
            this.TP_docs.TabIndex = 2;
            this.TP_docs.Text = "Documentation";
            this.TP_docs.Visible = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(1096, 412);
            this.Controls.Add(this.TC_gui);
            this.Controls.Add(this.TBOX_log);
            this.Name = "MainWindow";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TBAR_passwordLenght)).EndInit();
            this.TC_gui.ResumeLayout(false);
            this.TP_generate.ResumeLayout(false);
            this.TP_generate.PerformLayout();
            this.TP_rainbow_tbls.ResumeLayout(false);
            this.TP_rainbow_tbls.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox TBOX_log;
        private System.Windows.Forms.TextBox TBOX_ip;
        private System.Windows.Forms.Button BTN_start;
        private System.Windows.Forms.CheckBox CHBOX_logonTry;
        private System.Windows.Forms.Label LAB_ip;
        private System.Windows.Forms.Label LAB_port;
        private System.Windows.Forms.TrackBar TBAR_passwordLenght;
        private System.Windows.Forms.Label TBARLAB_pwlength;
        private System.Windows.Forms.TextBox TBOX_port;
        private System.Windows.Forms.Button BTN_rainbowtbls;
        private System.Windows.Forms.ListBox LB_rainbow_files;
        private System.Windows.Forms.TabControl TC_gui;
        private System.Windows.Forms.TabPage TP_generate;
        private System.Windows.Forms.TabPage TP_rainbow_tbls;
        private System.Windows.Forms.Button BTN_Start1;
        private System.Windows.Forms.Label LAB_ip1;
        private System.Windows.Forms.TextBox TB_port1;
        private System.Windows.Forms.TextBox TB_ip1;
        private System.Windows.Forms.Label LAB_port1;
        private System.Windows.Forms.CheckBox CHBOX_logonTry1;
        private System.Windows.Forms.TabPage TP_docs;
    }
}

