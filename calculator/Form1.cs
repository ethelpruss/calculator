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
            displayBox.AutoEllipsis = true;
            resultBox.AutoEllipsis = true;
        }

        private void displayBox_TextChanged(object sender, EventArgs e)
        {
        }

        // keydown -> button
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
           switch (e.KeyCode)
            {
                case Keys.Back:
                    backspaceButton.PerformClick();
                    break;
                case Keys.Enter:
                    equalsButton.PerformClick();
                    break;
                case Keys.Delete:
                    cButton.PerformClick();
                    break;
                default:
                    return;
            }
            e.Handled = true;
        }

        // keypress -> button
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)'0':
                    zeroButton.PerformClick();
                    break;
                case (char)'1':
                    oneButton.PerformClick();
                    break;
                case (char)'2':
                    twoButton.PerformClick();
                    break;
                case (char)'3':
                    threeButton.PerformClick();
                    break;
                case (char)'4':
                    fourButton.PerformClick();
                    break;
                case (char)'5':
                    fiveButton.PerformClick();
                    break;
                case (char)'6':
                    sixButton.PerformClick();
                    break;
                case (char)'7':
                    sevenButton.PerformClick();
                    break;
                case (char)'8':
                    eightButton.PerformClick();
                    break;
                case (char)'9':
                    nineButton.PerformClick();
                    break;
                case (char)'.':
                case (char)',':
                    dotButton.PerformClick();
                    break;
                case (char)'+':
                    plusButton.PerformClick();
                    break;
                case (char)'-':
                    minusButton.PerformClick();
                    break;
                case (char)'*':
                case (char)'x':
                    multiplyButton.PerformClick();
                    break;
                case (char)'/':
                    divideButton.PerformClick();
                    break;
                case (char)'=':
                    equalsButton.PerformClick();
                    break;
                default:
                    return;
            }
            e.Handled = true;
        }

        // 1 - 9 buttons
        private void Number_Button_Click(object sender, EventArgs e)
        {
            //remove default 0
            if (displayBox.Text == "0")
            {
                displayBox.Text = "";
            }
            //add button number to input
            displayBox.Text += (sender as Button).Text;
            equalsButton.Focus();
        }

        // 0 button
        private void Button0_Click(object sender, EventArgs e)
        {//add 0 to input if operand doesn't already begin with 0
            if (displayBox.Text != "0" && !displayBox.Text.EndsWith("-0") && !displayBox.Text.EndsWith("*0") 
                && !displayBox.Text.EndsWith("+0") && !displayBox.Text.EndsWith("/0"))
            {
            displayBox.Text += "0";
            }
            equalsButton.Focus();
        }

        // + - / * buttons
        private void Operator_Button_Click(object sender, EventArgs e)
        {
            // if input is empty change to 0
            if (displayBox.Text == "")
            {
                displayBox.Text += "0";
            }
            // check if another operator is selected, if it is replace it
            if (displayBox.Text.EndsWith("-") || displayBox.Text.EndsWith("*") || displayBox.Text.EndsWith("/") 
                || displayBox.Text.EndsWith("+"))
            {
                displayBox.Text = displayBox.Text.Remove(displayBox.Text.Length - 1, 1) + (sender as Button).Text;
            }

            // autocorrect trailing . to .0
            else if (displayBox.Text.EndsWith("."))
            {
                displayBox.Text += "0" + (sender as Button).Text;
            }
            // otherwise add operator
            else
            {
                displayBox.Text += (sender as Button).Text; ;
            }
            equalsButton.Focus();
        }

        // clear button
        private void Clear_Click(object sender, EventArgs e)
        {//rest display and result contents
            displayBox.Text = "";
            resultBox.Text = "0";
            equalsButton.Focus();
        }

        // backspace button
        private void Backspace_Click(object sender, EventArgs e)
        {//delete last character in input if input is not empty
            if ( displayBox.Text != "")
            {
                displayBox.Text = displayBox.Text.Remove(displayBox.Text.Length - 1, 1);

            }
            equalsButton.Focus();
        }

        // dot button
        private void Dot_Click(object sender, EventArgs e)
        {
            // split input into operands by operator symbols
            string[] stringArray = displayBox.Text.Split(new char[] {'+', '-', '*', '/'});
            string[] symbolArray = { "+", "-", "*", "/", "." };

            // check if operator symbol or . is last in input, if not continue
            bool[] boolArray = new bool[symbolArray.Length];
            for (int i = 0; i < boolArray.Length; i++)
            {
                boolArray[i] = !displayBox.Text.EndsWith(symbolArray[i]);
            }

            // if input is empty change . to 0.
            if (displayBox.Text == "")
            {
                displayBox.Text += "0.";
            }
            
            // if current operand does not contain . add .
            else if (boolArray.All(x => x == true))
            {
                if (!stringArray[stringArray.Length-1].Contains('.'))
                {
                    displayBox.Text += ".";
                }

            }
            equalsButton.Focus();
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
