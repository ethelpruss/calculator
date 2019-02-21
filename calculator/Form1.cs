using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public partial class Form1 : Form
    {
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
        {//add 0 to input if operand doesn't already begin with 0
            if (displayBox.Text != "0" && !displayBox.Text.EndsWith("-0") && !displayBox.Text.EndsWith("*0") && !displayBox.Text.EndsWith("+0") && !displayBox.Text.EndsWith("/0"))
            {
            displayBox.Text += "0";
            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {//remove default 0
            if (displayBox.Text == "0")
            {
                displayBox.Text = "";
            }
            //add 1 to input
            displayBox.Text += "1";
        }

        private void Button2_Click(object sender, EventArgs e)
        {//remove default 0
            if (displayBox.Text == "0")
            {
                displayBox.Text = "";
            }
            //add 2 to input
            displayBox.Text += "2";
        }

        private void Button3_Click(object sender, EventArgs e)
        {//remove default 0
            if (displayBox.Text == "0")
            {
                displayBox.Text = "";
            }
            //add 3 to input
            displayBox.Text += "3";
        }

        private void Button4_Click(object sender, EventArgs e)
        {//remove default 0
            if (displayBox.Text == "0")
            {
                displayBox.Text = "";
            }
            //add 4 to input
            displayBox.Text += "4";
        }

        private void Button5_Click(object sender, EventArgs e)
        {//remove default 0
            if (displayBox.Text == "0")
            {
                displayBox.Text = "";
            }
        //add 5 to input
            displayBox.Text += "5";
        }

        private void Button6_Click(object sender, EventArgs e)
        {//remove default 0
            if (displayBox.Text == "0")
            {
                displayBox.Text = "";
            }
        //add 6 to input
            displayBox.Text += "6";
        }

        private void Button7_Click(object sender, EventArgs e)
        {//remove default 0
            if (displayBox.Text == "0")
            {
                displayBox.Text = "";
            }
        //add 7 to input
            displayBox.Text += "7";
        }


        private void Button8_Click(object sender, EventArgs e)
        {//remove default 0
            if (displayBox.Text == "0")
            {
                displayBox.Text = "";
            }
        //add 8 to input
            displayBox.Text += "8";
        }

        private void Button9_Click(object sender, EventArgs e)
        {//remove default 0
            if (displayBox.Text == "0")
            {
                displayBox.Text = "";
            }
        //add 9 to input
            displayBox.Text += "9";
        }
        //clear button functionality
        private void Clear_Click(object sender, EventArgs e)
        {//rest display and result contents
            displayBox.Text = "";
            resultBox.Text = "0";
        }

        //backspace button
        private void Backspace_Click(object sender, EventArgs e)
        {//delete last character in input if input is not empty
            if ( displayBox.Text != "")
            {
                displayBox.Text = displayBox.Text.Remove(displayBox.Text.Length - 1, 1);

            }
        }
        //plus button functionality
        private void Plus_Click(object sender, EventArgs e)
        {
            // check if another operator is selected, if it is replace it
            if (displayBox.Text.EndsWith("-") || displayBox.Text.EndsWith("*") || displayBox.Text.EndsWith("/"))
            {
                displayBox.Text = displayBox.Text.Remove(displayBox.Text.Length - 1, 1) + "+";
            }
            // do not add doubles
            else if (displayBox.Text.EndsWith("+"))
            {   }
            // autocorrect trailing . to .0
            else if (displayBox.Text.EndsWith("."))
            {
                displayBox.Text += "0+";
            }
            // otherwise add +
            else
            {
                displayBox.Text += "+";
            }
        }
        //minus button functionality
        private void Minus_Click(object sender, EventArgs e)

        {
            // check if another operator is selected, if it is replace it
            if (displayBox.Text.EndsWith("+") || displayBox.Text.EndsWith("*") || displayBox.Text.EndsWith("/"))
            {
                displayBox.Text = displayBox.Text.Remove(displayBox.Text.Length - 1, 1) + "-";
            }
            // do not add doubles
            else if (displayBox.Text.EndsWith("-"))
            { }
            // autocorrect trailing . to .0
            else if (displayBox.Text.EndsWith("."))
            {
                displayBox.Text += "0-";
            }
            // otherwise add -
            else
            {
                displayBox.Text += "-";
            }

        }
        //multiply button functionality
        private void Multiply_Click(object sender, EventArgs e)
        {
            // check if another operator is selected, if it is replace it
            if (displayBox.Text.EndsWith("-") || displayBox.Text.EndsWith("+") || displayBox.Text.EndsWith("/"))
            {
                displayBox.Text = displayBox.Text.Remove(displayBox.Text.Length - 1, 1) + "*";
            }
            // do not add doubles
            else if (displayBox.Text.EndsWith("*"))
            {
            }
            // autocorrect trailing . to .0
            else if (displayBox.Text.EndsWith("."))
            {
                displayBox.Text += "0/";
            }
            // otherwise add *
            else
            {
                displayBox.Text += "*";
            }
        }
        //divide button functionality
        private void Divide_Click(object sender, EventArgs e)
        {
            // check if another operator is selected, if it is replace it
            if (displayBox.Text.EndsWith("-") || displayBox.Text.EndsWith("*") || displayBox.Text.EndsWith("+"))
            {
                displayBox.Text = displayBox.Text.Remove(displayBox.Text.Length - 1, 1) + "/";
            }
            // do not add doubles
            else if (displayBox.Text.EndsWith("/"))
            {
            }
            // change trailing . to .0
            else if (displayBox.Text.EndsWith("."))
            {
                displayBox.Text += "0/";
            }
            // otherwise add /
            else
            {
                displayBox.Text += "/";
            }
        }
        private void Dot_Click(object sender, EventArgs e)
        {
            // split input into operands by operator symbols
            string[] stringArray = displayBox.Text.Split(new char[] {'+', '-', '*', '/'});
            string[] symbolArray = { "+", "-", "*", "/", "." };

            bool[] boolArray = new bool[symbolArray.Length];
            for (int i = 0; i < boolArray.Length; i++)
            {
                boolArray[i] = !displayBox.Text.EndsWith(symbolArray[i]);
            }

            if (displayBox.Text == "")
            {
                displayBox.Text += "0.";
            }
            // check if operator symbol or . is last in input, if not continue

            else if (boolArray.All(x => x == true))
            {
                if (!stringArray[stringArray.Length-1].Contains('.'))
                {
                    displayBox.Text += ".";
                }

            }

        }
        // final calculation when equals button is pressed
        private void Equals_Click(object sender, EventArgs e)
        {
            if (displayBox.Text.EndsWith("."))
            {
                displayBox.Text += "0";
            }

            if (!displayBox.Text.EndsWith("-") && !displayBox.Text.EndsWith("*") && !displayBox.Text.EndsWith("+") && !displayBox.Text.EndsWith("/"))
            {
                string input = displayBox.Text;
                // convert input string to computable object
                DataTable inputCalculate = new DataTable();
                // calculate result
                object result = inputCalculate.Compute(input, "");
                // print result to resultbox
                resultBox.Text = result.ToString();
            }
            // missing operand error
            else
            {
                string message = "Please insert a second operand.";
                string title = "Calculation error";
                MessageBox.Show(message, title);
            }
        }


    }
}
