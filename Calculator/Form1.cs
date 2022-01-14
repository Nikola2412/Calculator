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
        int[] numbs = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
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

        private void button11_Click(object sender, EventArgs e)
        {
            second = double.Parse(textBox1.Text);
            label1.Text = "";
            label2.Text = "";
            textBox1.Text = Calculate();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string s = textBox1.Text;
            if (s.Length != 0 && o.Any(p => p == s[s.Length - 1].ToString()))
            {
                if (first!=null && second ==null)
                {
                    string rop = s[s.Length - 1].ToString();
                    second = double.Parse(s.Remove(s.Length - 1));
                    label1.Text = Calculate();
                    oper = rop;
                    rop = null;
                    label2.Text = $"{oper}";
                    textBox1.Clear();
                    first = double.Parse(Calculate());
                    second = null;
                }

                else
                {
                    oper = s[s.Length - 1].ToString();
                    first = double.Parse(s.Remove(s.Length - 1));
                    label1.Text = first.ToString();
                    label2.Text = $"{oper}";
                    textBox1.Clear();
                }
            }
        }


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                second = double.Parse(textBox1.Text);
                label1.Text = "";
                label2.Text = "";
                textBox1.Text = Calculate();
            }
        }
    }
}
