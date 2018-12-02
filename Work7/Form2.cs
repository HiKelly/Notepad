using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Work7
{
    public partial class Form2 : Form
    {
        int start = 0;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                if (start >= Program.form1.richTextBox1.Text.Length - 1) 
                {
                    MessageBox.Show("没有找到！");
                    start = 0;
                    return;
                }
                string str1 = textBox1.Text;    //获取要查找的文本
                start = Program.form1.richTextBox1.Find(str1, start, Program.form1.richTextBox1.Text.Length, RichTextBoxFinds.MatchCase);
                if (start == -1)
                {
                    MessageBox.Show("没有找到！");
                }
                else
                {
                    start = start + str1.Length;
                    Program.form1.richTextBox1.Focus();
                }
            }
            else
            {
                MessageBox.Show(start + " " + textBox1.Text);
                if (start < 0)
                {
                    MessageBox.Show("没有找到！");
                    start = Program.form1.richTextBox1.Text.Length - 1;
                    return;
                }
                string str1 = textBox1.Text;    //获取要查找的文本
                start = Program.form1.richTextBox1.Find(str1, 0, start, RichTextBoxFinds.Reverse);
                if (start == -1)
                {
                    MessageBox.Show("没有找到！");
                }
                else
                {
                    start = start - str1.Length;
                    Program.form1.richTextBox1.Focus();
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Program.form1.richTextBox1.Focus();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Program.form1.richTextBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
