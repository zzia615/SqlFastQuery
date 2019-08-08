using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using OfficeOpenXml;
using HWND = System.IntPtr;
namespace SqlFastQuery
{
    public partial class Form1 : Form
    {
        DbConStrInfo conStr;
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.StartPosition = FormStartPosition.CenterScreen;
            if (form2.ShowDialog()!= DialogResult.OK)
            {
                return;
            }
            conStr = form2.ConStr;
            LoadDb();
        }

        void LoadDb()
        {
            treeView1.Nodes.Clear();
            string s_table = AppFunc.GetSql(conStr, 1);
            string s_view = AppFunc.GetSql(conStr, 2);
            DataTable table1 = AppFunc.GetData(conStr, s_table);
            DataTable table2 = AppFunc.GetData(conStr, s_view);
            TreeNode rootNode = new TreeNode(conStr.Database);
            var nodes = treeView1.Nodes.Find(conStr.Database, false);
            if (nodes != null && nodes.Length > 0)
            {
                rootNode = nodes[0];
            }
            else
            {
                treeView1.Nodes.Add(rootNode);
            }
            SetTreeview(1, rootNode, table1);
            SetTreeview(2, rootNode, table2);
        }
        List<TreeNode> TreeNodeList = new List<TreeNode>();
        void SetTreeview(int type,TreeNode rootNode,DataTable table)
        {
            string s_root = "";
            if (type == 1)
            {
                s_root = "tables";
            }
            if (type == 2)
            {
                s_root = "views";
            }


            
            TreeNode treeNode = new TreeNode(s_root);
            var nodes = rootNode.Nodes.Find(s_root, false);
            if (nodes != null && nodes.Length > 0)
            {
                treeNode = nodes[0];
            }
            foreach (DataRow row in table.Rows)
            {
                string s_tableName = row["table_name"] == null ? "" : row["table_name"].ToString();
                treeNode.Nodes.Add(new TreeNode(s_tableName) { Tag="table",ImageIndex = 7,SelectedImageIndex = 7});
            }
            treeNode.ImageIndex = 5;
            treeNode.SelectedImageIndex = 5;
            rootNode.ImageIndex = 1;
            rootNode.SelectedImageIndex = 1;
            rootNode.Nodes.Add(treeNode);
            rootNode.Expand();
        }

        

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (conStr == null)
            {
                toolStripButton1_Click(null, null);
            }
            if (conStr == null)
            {
                return;
            }
            richTextBox2.Text = "";
            string s_sql = richTextBox1.SelectedText.Trim();
            if (string.IsNullOrEmpty(s_sql))
            {
                s_sql = richTextBox1.Text;
            }
            if (s_sql.ToLower().StartsWith("select"))
            {
                dataGridView1.DataSource = null;
                try
                {
                    dataGridView1.DataSource = AppFunc.GetData(conStr,s_sql);
                    tabControl1.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    richTextBox2.Text = ex.ToString();
                    tabControl1.SelectedIndex = 1;
                }
            }
            else
            { 
                dataGridView1.DataSource = null;
                try
                {
                    int ret = AppFunc.ExecuteNonQuery(conStr, s_sql);
                    richTextBox2.Text = string.Format("执行语句成功,影响{0}行", ret);
                    tabControl1.SelectedIndex = 1;
                }
                catch (Exception ex)
                {
                    richTextBox2.Text = ex.ToString();
                    tabControl1.SelectedIndex = 1;
                }
            }
        }

       

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if(e.Button== MouseButtons.Left)
            {
                if(e.Node.Tag!=null&& e.Node.Tag.ToString() == "table")
                {
                    //if (!string.IsNullOrEmpty(richTextBox1.Text))
                    //{
                    //    richTextBox1.Text = richTextBox1.Text + "\r\n";
                    //}
                   // richTextBox1.SelectedText = e.Node.Text;
                    toolStripMenuItem1_Click(null,null);
                    //richTextBox1.Text = richTextBox1.Text + e.Node.Text;
                }
            }
        }
        [DllImport("user32")] private static extern int SendMessage(HWND hwnd, int wMsg, int wParam, IntPtr lParam);
        private const int WM_SETREDRAW = 0xB;
        void SetSqlStyle(RichTextBox rtb)
        {
            int i_pos = richTextBox1.SelectionStart;
            SendMessage(rtb.Handle, WM_SETREDRAW, 0, IntPtr.Zero);
            SetSqlColor(rtb, rtb.Text, Color.Black);
            SetSqlColor(rtb, "select", Color.Blue);
            SetSqlColor(rtb, "from", Color.Blue);
            SetSqlColor(rtb, "create", Color.Blue);
            SetSqlColor(rtb, "drop", Color.Blue);
            SetSqlColor(rtb, "insert", Color.Blue);
            SetSqlColor(rtb, "update", Color.Blue);
            SetSqlColor(rtb, "delete", Color.Blue);
            SetSqlColor(rtb, "into", Color.Blue);
            SetSqlColor(rtb, "set", Color.Blue);
            SetSqlColor(rtb, "where", Color.Blue);
            SetSqlColor(rtb, "table", Color.Blue);
            SetSqlColor(rtb, "alter", Color.Blue);
            SetSqlColor(rtb, "add", Color.Blue);
            SetSqlColor(rtb, "column", Color.Blue);
            SetSqlColor(rtb, "constraint", Color.Blue);
            SetSqlColor(rtb, "primary", Color.Blue);
            SetSqlColor(rtb, "key", Color.Blue);
            rtb.SelectionStart = i_pos;
            rtb.SelectionLength = 0;
            SendMessage(rtb.Handle, WM_SETREDRAW, 1, IntPtr.Zero);
            rtb.Refresh();
        }

        void SetSqlColor(RichTextBox rtb,string findStr,Color color)
        {
            int i_pos = rtb.Text.ToLower().IndexOf(findStr.ToLower());
            while (i_pos >= 0)
            {
                rtb.Select(i_pos, findStr.Length);
                rtb.SelectionColor = color;
                if (i_pos + 1 <= rtb.Text.Length)
                    i_pos = rtb.Text.ToLower().IndexOf(findStr, i_pos + 1);
                else
                    i_pos = -1;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            SetSqlStyle(richTextBox1);
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if(e.Button== MouseButtons.Right)
            {
                treeView1.SelectedNode = e.Node;
                if(e.Node.Tag!=null&& e.Node.Tag.ToString() == "table")
                {
                    treeView1.ContextMenuStrip = contextMenuStrip1;
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string s_table = treeView1.SelectedNode.Text;
            Form3 form3 = new Form3(s_table,conStr);
            form3.StartPosition = FormStartPosition.CenterScreen;
            form3.ShowDialog();
        }

        private void 复制表名ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s_table = treeView1.SelectedNode.Text;
            Clipboard.SetText(s_table);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("软件归Jaylosy所有\r\n请勿用于商业用途\r\n作者:Jiaol", "关于本软件",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "Excel文件(*.xls)|*.xls";
            if(saveFileDialog1.ShowDialog()!= DialogResult.OK)
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


                        MessageBox.Show("已导出文件"+ file.FullName, "导出成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
