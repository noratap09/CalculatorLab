using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPE200Lab1
{
    public partial class Form1 : Form
    {
        string operate = "",num1="",num2="";
        double temp;
        bool cK_show = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            operate = "";
            num1 = "";
            num2 = "";
            lblDisplay.Text = 0 + "";
            cK_show = false;

            btn0.Enabled = true;
            btn1.Enabled = true;
            btn2.Enabled = true;
            btn3.Enabled = true;
            btn4.Enabled = true;
            btn5.Enabled = true;
            btn6.Enabled = true;
            btn7.Enabled = true;
            btn8.Enabled = true;
            btn9.Enabled = true;
            btnBack.Enabled = true;
            btnClear.Enabled = true;
            btnDivide.Enabled = true;
            btnDot.Enabled = true;
            btnEqual.Enabled = true;
            btnMinus.Enabled = true;
            btnMultiply.Enabled = true;
            btnPercent.Enabled = true;
            btnPlus.Enabled = true;
            btnSign.Enabled = true;
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if(float.Parse(lblDisplay.Text)>0)
            {
                lblDisplay.Text = "-" + lblDisplay.Text;
            }
            else if(float.Parse(lblDisplay.Text) < 0)
            {
                lblDisplay.Text = lblDisplay.Text.Substring(1, lblDisplay.Text.Length - 1);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (cK_show == false)
            {
                if (lblDisplay.Text.Length == 1)
                {
                    lblDisplay.Text = "0";
                }
                else if (lblDisplay.Text.Length > 1)
                {
                    lblDisplay.Text = lblDisplay.Text.Substring(0, lblDisplay.Text.Length - 1);
                }
            }
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (lblDisplay.Text.Length < 8)
            {
                if (lblDisplay.Text == "0" || cK_show == true)
                {
                    lblDisplay.Text = btn.Text;
                }
                else
                {
                    lblDisplay.Text += btn.Text;
                }
                cK_show = false;
            }
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text.IndexOf(".") <= 0)
            {
                lblDisplay.Text += ".";
            }
        }

        private void btnOpe_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            fun_get_num();

            if(operate!="" && num1 != "" && num2 != "" && cK_show == false)
            {
                fun_operate(double.Parse(num1), double.Parse(num2));
                temp = double.Parse(num2);
                num2 = "";
                cK_show = true;
            }
            if (operate != btn.Text) { num2 = ""; }
            operate = btn.Text;

            if (cK_show == false) { lblDisplay.Text = "0"; }
            //MessageBox.Show(num1 + operate + num2);
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            fun_get_num();
            if (num2 != "")
            {
                fun_operate(double.Parse(num1),double.Parse(num2));
                //MessageBox.Show(num1 + operate + num2);
                cK_show = true;
            }
            else if(num2 =="")
            {
                fun_operate(double.Parse(num1),temp);
                //MessageBox.Show(num1 + operate + temp);
            }
            
        }

        private void fun_operate(double n1, double n2)
        {
            if (operate == "+") { num1 = String.Format("{0:0.#}",(n1 + n2)); }
            else if (operate == "-") { num1 = String.Format("{0:0.#}", (n1 - n2)); }
            else if (operate == "X") { num1 = String.Format("{0:0.#}", (n1 * n2)); }
            else if (operate == "÷") { num1 = String.Format("{0:0.#}", (n1 / n2)); }
            if (num1.Length > 8) { num1 = "MAX"; }
            lblDisplay.Text = num1;
   
            if (num1 == "NaN" || num1 == "∞" || num1 == "MAX")
            {
                num1 = "0";
                btn0.Enabled = false;
                btn1.Enabled = false;
                btn2.Enabled = false;
                btn3.Enabled = false;
                btn4.Enabled = false;
                btn5.Enabled = false;
                btn6.Enabled = false;
                btn7.Enabled = false;
                btn8.Enabled = false;
                btn9.Enabled = false;
                btnBack.Enabled = false;
                btnClear.Enabled = true;
                btnDivide.Enabled = false;
                btnDot.Enabled = false;
                btnEqual.Enabled = false;
                btnMinus.Enabled = false;
                btnMultiply.Enabled = false;
                btnPercent.Enabled = false;
                btnPlus.Enabled = false;
                btnSign.Enabled = false;
            }
        }

        private void fun_get_num()
        {
            if (num1 == "")
            {
                num1 = lblDisplay.Text;
            }
            else if (num2 == "")
            {
                num2 = lblDisplay.Text;
            }
        }
    }
}