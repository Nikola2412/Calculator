using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double? first = null;
        double? second = null;
        string[] o = { "+", "-", "*", "/" };
        string oper = null;
        private void button1_Click(object sender, EventArgs e)
        {
            string t = ((Button)sender).Text;
            
            if (o.Any(p => p == t))
            {
                first=double.Parse(textBox1.Text);
                label1.Text=textBox1.Text;
                label2.Text = $"{t}";
                textBox1.Clear();
                oper = t;
            }
            else if(t=="=")
            {
                second = double.Parse(textBox1.Text);
                label1.Text = "";
                label2.Text="";
                textBox1.Text = Calculate();
            }
            else
                textBox1.Text += t;
        }
        private string Calculate()
        {
            double? res=null;
            switch (oper)
            {
                case "+":
                    res = first + second;
                    break;
                case "-":
                    res = first - second;
                    break;
                case "/":
                    res = first / second;
                    break;
                case "*":
                    res = first * second;
                    break;
            }
            return res.ToString();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            first = null;
            second = null;
            textBox1.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "";
            label2.Text = "";
        }
    }
}
