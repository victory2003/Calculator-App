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
        Double resultValue = 0;
        String operationPerformed = "";
        bool isOperationPerformed = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button_click(object sender, EventArgs e)
        {
            if ((EnterText.Text == "0") || (isOperationPerformed))
                EnterText.Clear();

            isOperationPerformed = false;

            Button button = (Button)sender;
            if(button.Text == ".")
            {
                if(!EnterText.Text.Contains("."))
                    EnterText.Text = EnterText.Text + button.Text;
            }
            else
            {
                EnterText.Text = EnterText.Text + button.Text;
            }

        }

        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if(resultValue != 0)
            {
                btnTotal.PerformClick();
                operationPerformed = button.Text;
                DisplayText.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            }
            else
            {
                operationPerformed = button.Text;
                resultValue = Double.Parse(EnterText.Text);
                DisplayText.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            EnterText.Text = "0";
            resultValue= 0;
        }

        private void btnTotal_Click(object sender, EventArgs e)
        {
            switch (operationPerformed)
            {
                case "+":
                    EnterText.Text = (resultValue + Double.Parse(EnterText.Text)).ToString();
                    break;
                case "-":
                    EnterText.Text = (resultValue - Double.Parse(EnterText.Text)).ToString();
                    break;
                case "*":
                    EnterText.Text = (resultValue * Double.Parse(EnterText.Text)).ToString();
                    break;
                case "/":
                    EnterText.Text = (resultValue / Double.Parse(EnterText.Text)).ToString();
                    break;
                default:
                    break;
            }
            resultValue = Double.Parse(EnterText.Text);
            DisplayText.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    }

