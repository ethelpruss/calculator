using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public partial class Form1 : Form
    {
        string input = ""; //user input 
        string operand1; 
        string operand2; 
        char operation;
        double result = 0.0; //calculated result
        


        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void displayBox_TextChanged(object sender, EventArgs e)
        {

        }


        private void Button0_Click(object sender, EventArgs e)
        {
            displayBox.Text += "0";
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if(displayBox.Text=="0")
            {
                displayBox.Text = "";
            }
            displayBox.Text += "1";
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (displayBox.Text == "0")
            {
                displayBox.Text = "";
            }
            displayBox.Text += "2";
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (displayBox.Text == "0")
            {
                displayBox.Text = "";
            }
            displayBox.Text += "3";
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (displayBox.Text == "0")
            {
                displayBox.Text = "";
            }
            displayBox.Text += "4";
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (displayBox.Text == "0")
            {
                displayBox.Text = "";
            }
            displayBox.Text += "5";
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            if (displayBox.Text == "0")
            {
                displayBox.Text = "";
            }
            displayBox.Text += "6";
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            if (displayBox.Text == "0")
            {
                displayBox.Text = "";
            }
            displayBox.Text += "7";
        }

 
        private void Button8_Click(object sender, EventArgs e)
        {
            if (displayBox.Text == "0")
            {
                displayBox.Text = "";
            }
            displayBox.Text += "8";
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            if (displayBox.Text == "0")
            {
                displayBox.Text = "";
            }
            displayBox.Text += "9";
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            displayBox.Text = "0";
        }

        private void Equals_Click(object sender, EventArgs e)
        {

        }

        private void Plus_Click(object sender, EventArgs e)
        {
           

            if (displayBox.Text == "*-" || displayBox.Text == "*x" || displayBox.Text == "*/")
            {
                displayBox.Text = displayBox.Text.Remove(displayBox.Text.Length - 1, 1) + "+";
            }

            else if (displayBox.Text == "+")
            {
                displayBox.Text = "test";
            }
            else
            {
                displayBox.Text += "+";
            }
        
        }

        private void Minus_Click(object sender, EventArgs e)

        {
            operand1 = displayBox.Text;
            operation = '-';
            displayBox.Text = "";

        }

        private void Multiply_Click(object sender, EventArgs e)
        {
            displayBox.Text += "x";
        }

        private void Divide_Click(object sender, EventArgs e)
        {
            displayBox.Text += "/";
        }
        private void Dot_Click(object sender, EventArgs e)
        {

            displayBox.Text += ".";
        }
    }
}
