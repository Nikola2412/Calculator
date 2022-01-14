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
        string r = null;
        string[] o = { "+", "-", "*", "/" };
        int[] numbs = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
        string oper = null;
        private void button1_Click(object sender, EventArgs e)
        {
            var t = ((Button)sender).Text;

            textBox1.Text += t;

            Test(textBox1.Text);
        }
        private void Test(string s)
        {
            int n = s.Length;

            if (n != 0 && o.Any(p => p == s[n - 1].ToString()) && s!="=")
            {
                if (first == null && second == null)
                {
                    oper = s[n - 1].ToString();
                    first = double.Parse(s.Remove(n - 1));
                    textBox1.Clear();
                    label1.Text = $"{first}";
                }
                else if (first != null && second == null)
                {
                    oper = s[n - 1].ToString();
                    second = double.Parse(s.Remove(n - 1));
                    r = Calculate();
                    label1.Text = $"{r}";
                    textBox1.Clear();
                    first = double.Parse(r);
                    second = null;
                }
            }

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
            r = null;
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
            Test(s);
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
    }
}
