using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace Work7
{
    public partial class Form1 : Form
    {
        private string filename = "";   //文件名

        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //新建文件
        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            filename = "";
            this.Text = "无标题";
        }

        //打开文件
        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "文本文件 | *.txt";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.InitialDirectory = "C:\\user\\文档";
            //如果点击确定按钮，载入文件
            if(openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filename = openFileDialog1.FileName;
                richTextBox1.LoadFile(filename, RichTextBoxStreamType.PlainText);
                this.Text = filename;
            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //原来已有此文件，直接保存
            if(filename.Length > 0)
            {
                richTextBox1.SaveFile(filename, RichTextBoxStreamType.PlainText);
            }
            else
            {
                //新建文件
                另存为ToolStripMenuItem_Click(sender, e);
            }
        }

        //另存为
        private void 另存为ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "文本文件 | *.txt";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.InitialDirectory = "";
            //如果点击确定按钮，保存文件
            if(saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filename = saveFileDialog1.FileName;
                richTextBox1.SaveFile(filename, RichTextBoxStreamType.PlainText);
                int index = filename.LastIndexOf("\\");
                string name = filename.Substring(index + 1);
                this.Text = name;
            }
        }

        private void 页面设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.Document = printDocument1;
            pageSetupDialog1.ShowDialog();
        }

        private void 打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("是否将更改保存","舞文 1.0.0",  MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                保存ToolStripMenuItem_Click(sender, e);
            }
            else if (result == DialogResult.No)
            {
                //不保存就什么都不用做了
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 撤销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(richTextBox1.CanUndo == true)
            {
                richTextBox1.Undo();
                richTextBox1.ClearUndo();
            }
        }

        private void 剪切ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(richTextBox1.SelectionLength != 0)
            {
                richTextBox1.Cut();
            }
        }

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(richTextBox1.SelectionLength != 0)
            {
                richTextBox1.Copy();
            }
        }

        private void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Clipboard.GetText().ToString() != "")
            {
                richTextBox1.Paste();
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(richTextBox1.SelectedText != string.Empty)
            {
                richTextBox1.SelectedText = string.Empty;
            }
        }

        private void 查找ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 find = new Form2();
            find.Owner = this;
            find.Show();
        }

        private void 转到ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void 全选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(richTextBox1.Text != string.Empty)
            {
                richTextBox1.SelectAll();
            }
        }

        private void 时间日期ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = richTextBox1.Text + DateTime.Now.ToString();
        }

        private void 自动换行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (自动换行ToolStripMenuItem.Checked == true)
            {
                richTextBox1.WordWrap = true;   //文本自动换行
            }
            else
            {
                richTextBox1.WordWrap = false;
            }
            (sender as ToolStripMenuItem).Checked = !(sender as ToolStripMenuItem).Checked;
        }

        private void 字体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.fontDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionFont = fontDialog1.Font;
                richTextBox1.SelectionColor = fontDialog1.Color;
            }
        }

        private void 关于记事本ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Laj的记事本，如有不当，寻找伯乐~");
        }

        private void 查看帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("具体使用方法，请参照微软记事本！");
        }

        private void 状态栏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (sender as ToolStripMenuItem).Checked = !(sender as ToolStripMenuItem).Checked;
            if (状态栏ToolStripMenuItem.Checked)
            {
                int row = richTextBox1.GetLineFromCharIndex(richTextBox1.SelectionStart) + 1;
                int start = richTextBox1.GetFirstCharIndexOfCurrentLine();
                string s = richTextBox1.Text.Substring(start, richTextBox1.SelectionStart - start);
                int col = s.Length + 1;
                toolStripStatusLabel1.Text = "第" + row + "行，第" + col + "列";
            }
            else
            {
                toolStripStatusLabel1.Text = "";
            }

        }

        private void 编辑EToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 编辑EToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            if (richTextBox1.CanUndo)
            {
                撤销ToolStripMenuItem.Enabled = true;
            }
            else
            {
                撤销ToolStripMenuItem.Enabled = false;
            }
            if(richTextBox1.SelectionLength != 0)
            {
                剪切ToolStripMenuItem.Enabled = true;
                复制ToolStripMenuItem.Enabled = true;
                删除ToolStripMenuItem.Enabled = true;
            }
            else
            {
                剪切ToolStripMenuItem.Enabled = false;
                复制ToolStripMenuItem.Enabled = false;
                删除ToolStripMenuItem.Enabled = false;
            }
            if (Clipboard.GetText().ToString() != "")
            {
                粘贴ToolStripMenuItem.Enabled = true;
            }
            else
            {
                粘贴ToolStripMenuItem.Enabled = false;
            }
            if(richTextBox1.Text.Length != 0)
            {
                全选ToolStripMenuItem.Enabled = true;
            }
            else
            {
                全选ToolStripMenuItem.Enabled = false;
            }

        }

        private void 替换ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
