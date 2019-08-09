using OfficeOpenXml;
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

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "Excel文件(*.xls)|*.xls";
            if (saveFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            System.IO.FileInfo file = new System.IO.FileInfo(saveFileDialog1.FileName);
            using (ExcelPackage ep = new ExcelPackage(file))
            {
                try
                {
                    var sheet = ep.Workbook.Worksheets.Add("sheet1");
                    var data = dataGridView1.DataSource as DataTable;
                    if (data != null)
                    {
                        sheet.Cells["A1"].LoadFromDataTable(data, true);
                        ep.Save();


                        MessageBox.Show("已导出文件" + file.FullName, "导出成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "导出失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
