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
        //string r = null;
        string[] o = { "+", "-", "*", "/" };
        int[] numbs = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
        string oper = null;
        private void button1_Click(object sender, EventArgs e)
        {
            var t = ((Button)sender).Text;
            textBox1.Text += t;
        }
        private void Test(string s)
        {

        }
        private string Calculate()
        {
            double? res = null;
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
            //r = null;
            label1.Text = "";
            textBox1.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                second = double.Parse(textBox1.Text);
                textBox1.Text = Calculate();
            }
            else
            {
                textBox1.Text = first.ToString();
            }
            label1.Text = "";
            first = null;
            second = null;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string s = textBox1.Text;
            int n = s.Length;
            if (n>1 && o.Any(p => p == s[n - 1].ToString()))
            {
                if (first == null)
                {
                    oper = s.Last().ToString();
                    textBox1.Text = s.Remove(n - 1);
                    first = double.Parse(textBox1.Text);
                    label1.Text = textBox1.Text;
                    textBox1.Clear();
                }
                else
                {
                    oper = s.Last().ToString();
                    textBox1.Text = s.Remove(n - 1);
                    second = double.Parse(textBox1.Text);
                    label1.Text = Calculate();
                    first = double.Parse(label1.Text);
                    second = null;
                    textBox1.Clear();
                }
            }
        }


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                if (textBox1.Text != "")
                {
                    second = double.Parse(textBox1.Text);
                    textBox1.Text = Calculate();
                }
                else
                {
                    textBox1.Text = first.ToString();
                }
                label1.Text = "";
                first = null;
                second = null;

            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            oper = ((Button)sender).Text;
            Calculate();
            first = double.Parse(textBox1.Text);
            label1.Text = textBox1.Text;
            textBox1.Clear();
        }
    }
}
