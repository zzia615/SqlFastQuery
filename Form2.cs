using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace SqlFastQuery
{
    public partial class Form2 : Form
    {
        public DbConStrInfo ConStr { get; set; }
        public Form2()
        {
            InitializeComponent();
        }
        string GetConStr()
        {
            string conStr = string.Format("server={0};port={1};userid={2};password={3};database={4}",tb_server.Text,tb_port.Text,tb_logid.Text,tb_logpass.Text,cbb_db.Text);
            return conStr;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ConStr = new DbConStrInfo
            {
                Server = tb_server.Text,
                Port = tb_port.Text,
                LogId = tb_logid.Text,
                LogPass = tb_logpass.Text,
                Database = cbb_db.Text,
                Provider = cbb_provider.Text
            };
            if (!AppFunc.TestConnect(ConStr))
            {
                ConStr = null;
                return;
            }
            SaveXml("db_config.xml");
            this.DialogResult = DialogResult.OK;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ConStr = new DbConStrInfo
            {
                Server = tb_server.Text,
                Port = tb_port.Text,
                LogId = tb_logid.Text,
                LogPass = tb_logpass.Text,
                Database = cbb_db.Text,
                Provider = cbb_provider.Text
            };
            if (AppFunc.TestConnect(ConStr))
            {
                MessageBox.Show("连接数据库成功！","提示信息");
            }
            ConStr = null;
        }

        void SaveXml(string xmlFile)
        {
            StringBuilder sb_xml = new StringBuilder();
            sb_xml.Append("<root>");
            sb_xml.Append("<dbconfig>");
            sb_xml.AppendFormat("<server>{0}</server>", tb_server.Text);
            sb_xml.AppendFormat("<port>{0}</port>", tb_port.Text);
            sb_xml.AppendFormat("<logid>{0}</logid>", tb_logid.Text);
            sb_xml.AppendFormat("<logpass>{0}</logpass>", tb_logpass.Text);
            sb_xml.AppendFormat("<database>{0}</database>", cbb_db.Text);
            sb_xml.AppendFormat("<provider>{0}</provider>", cbb_provider.Text);
            sb_xml.Append("</dbconfig>");
            sb_xml.Append("</root>");

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(sb_xml.ToString());
            doc.Save(xmlFile);
        }
        void LoadXml(string xmlFile)
        {
            if (!System.IO.File.Exists(xmlFile))
            {
                System.IO.File.Create(xmlFile);
            }
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(xmlFile);
                tb_server.Text = doc.SelectSingleNode("/root/dbconfig/server").InnerText;
                tb_port.Text = doc.SelectSingleNode("/root/dbconfig/port").InnerText;
                tb_logid.Text = doc.SelectSingleNode("/root/dbconfig/logid").InnerText;
                tb_logpass.Text = doc.SelectSingleNode("/root/dbconfig/logpass").InnerText;
                cbb_db.Text = doc.SelectSingleNode("/root/dbconfig/database").InnerText;
                cbb_provider.Text = doc.SelectSingleNode("/root/dbconfig/provider").InnerText;
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LoadXml("db_config.xml");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConStr = null;
            this.DialogResult = DialogResult.Cancel;
        }

        private void cbb_provider_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_provider.SelectedIndex == 0)
            {
                tb_port.Text = "3306";
            }
            if (cbb_provider.SelectedIndex == 1)
            {
                tb_port.Text = "1433";
            }
            if (cbb_provider.SelectedIndex == 2)
            {
                tb_port.Text = "5821";
            }


            if (cbb_provider.SelectedIndex == 2)
            {
                label2.Visible = false;
                label5.Visible = false;
                tb_port.Visible = false;
                cbb_db.Visible = false;
            }
            else
            {
                label2.Visible = true;
                label5.Visible = true;
                tb_port.Visible = true;
                cbb_db.Visible = true;

            }
        }
    }
}
