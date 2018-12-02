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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int num;
            bool flag = int.TryParse(textBox1.Text, out num);
            if (!flag)
            {
                MessageBox.Show("请输入正确的行号！");
                textBox1.Text = "";
            }
            else
            {
                int total = Program.form1.richTextBox1.Lines.Length;
                if(num > total)
                {
                    MessageBox.Show("制定行号超过文本总行号！");
                    textBox1.Text = "";
                }
                else
                {
                    Program.form1.richTextBox1.Select(num - 1, 0);
                    this.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
