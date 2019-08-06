namespace SqlFastQuery
{
    partial class Form2
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
        private void InitializeComponent()
        {
            this.tb_server = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_port = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_logid = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_logpass = new System.Windows.Forms.TextBox();
            this.cbb_db = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cbb_provider = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // tb_server
            // 
            this.tb_server.Location = new System.Drawing.Point(96, 64);
            this.tb_server.Name = "tb_server";
            this.tb_server.Size = new System.Drawing.Size(206, 21);
            this.tb_server.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Server";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(309, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port";
            // 
            // tb_port
            // 
            this.tb_port.Location = new System.Drawing.Point(344, 64);
            this.tb_port.Name = "tb_port";
            this.tb_port.Size = new System.Drawing.Size(100, 21);
            this.tb_port.TabIndex = 2;
            this.tb_port.Text = "3306";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "LogID";
            // 
            // tb_logid
            // 
            this.tb_logid.Location = new System.Drawing.Point(96, 106);
            this.tb_logid.Name = "tb_logid";
            this.tb_logid.Size = new System.Drawing.Size(348, 21);
            this.tb_logid.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "LogPass";
            // 
            // tb_logpass
            // 
            this.tb_logpass.Location = new System.Drawing.Point(96, 146);
            this.tb_logpass.Name = "tb_logpass";
            this.tb_logpass.Size = new System.Drawing.Size(348, 21);
            this.tb_logpass.TabIndex = 6;
            // 
            // cbb_db
            // 
            this.cbb_db.FormattingEnabled = true;
            this.cbb_db.Location = new System.Drawing.Point(96, 190);
            this.cbb_db.Name = "cbb_db";
            this.cbb_db.Size = new System.Drawing.Size(348, 20);
            this.cbb_db.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "database";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(288, 233);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(369, 233);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(96, 233);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 12;
            this.button3.Text = "测试连接";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "provider";
            // 
            // cbb_provider
            // 
            this.cbb_provider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_provider.FormattingEnabled = true;
            this.cbb_provider.Items.AddRange(new object[] {
            "MySql.Data.MySqlClient",
            "System.Data.SqlClient",
            "System.Data.OracleClient"});
            this.cbb_provider.Location = new System.Drawing.Point(96, 24);
            this.cbb_provider.Name = "cbb_provider";
            this.cbb_provider.Size = new System.Drawing.Size(348, 20);
            this.cbb_provider.TabIndex = 13;
            this.cbb_provider.SelectedIndexChanged += new System.EventHandler(this.cbb_provider_SelectedIndexChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 281);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbb_provider);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbb_db);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_logpass);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_logid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_port);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_server);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.Text = "连接数据库";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_server;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_port;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_logid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_logpass;
        private System.Windows.Forms.ComboBox cbb_db;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbb_provider;
    }
}