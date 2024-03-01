using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "" || 
                (!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked && !radioButton4.Checked && !radioButton5.Checked))
            {
                label7.Visible = true;
                return;
            }
            label7.Visible = false;

            label5.Visible = true;
            label6.Visible = true;

            double n1 = Convert.ToDouble(textBox1.Text);
            double n2 = Convert.ToDouble(textBox2.Text);

            string op = "";
            if(radioButton1.Checked)
            {
                op = radioButton1.Text;
            }
            else if(radioButton2.Checked)
            {
                op = radioButton2.Text;
            }
            else if(radioButton3.Checked)
            {
                op = radioButton3.Text;
            }
            else if(radioButton4.Checked)
            {
                op = radioButton4.Text;
            }
            else if(radioButton5.Checked)
            {
                op = radioButton5.Text;
            }

            double result;
            switch (op)
            {
                case "+":
                    result = n1 + n2;
                    label6.Text = result.ToString();
                    break;
                case "-":
                    result = n1 - n2;
                    label6.Text = result.ToString();
                    break;
                case "*":
                    result = n1 * n2;
                    label6.Text = result.ToString();
                    break;
                case "/":
                    result = n1 / n2;
                    label6.Text = result.ToString();
                    break;
                case "%":
                    result = n1 % n2;
                    label6.Text = result.ToString();
                    break;
            }
        }
    }
}
