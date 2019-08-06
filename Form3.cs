using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SqlFastQuery
{
    public partial class Form3 : Form
    {
        string table; DbConStrInfo conStr;
        public Form3(string table,DbConStrInfo conStr )
        {
            InitializeComponent();
            this.table = table;
            this.conStr = conStr;

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.Text = string.Format(Tag.ToString(), table);
            string s_sql = AppFunc.GetSql(conStr, 3, table);
            dataGridView1.DataSource=  AppFunc.GetData(conStr, s_sql);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
