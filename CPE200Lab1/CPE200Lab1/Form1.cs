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
        bool ck_dot = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = 0+"";
            ck_dot = false;
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            char[] sigh = { btnPlus.Text.ToCharArray()[0], btnMinus.Text.ToCharArray()[0], btnDivide.Text.ToCharArray()[0], btnMultiply.Text.ToCharArray()[0], btnPercent.Text.ToCharArray()[0], btnEqual.Text.ToCharArray()[0] };
            int index = lblDisplay.Text.LastIndexOfAny(sigh);
            if (index>=1)
            {
                if (lblDisplay.Text.LastIndexOf('n') <= 0)
                {
                    lblDisplay.Text = lblDisplay.Text.Insert(index+1, "n");
                }
                else if (lblDisplay.Text.LastIndexOf('n') >= 1)
                {
                    lblDisplay.Text = lblDisplay.Text.Substring(0,index+1) + lblDisplay.Text.Substring(index+2, lblDisplay.Text.Length - index - 2);
                }
            }
            else if(index<=-1)
            {
                if (lblDisplay.Text.IndexOf('n') == -1)
                {
                    lblDisplay.Text = "n" + lblDisplay.Text;
                }
                else if (lblDisplay.Text.IndexOf('n') >= 0)
                {
                    lblDisplay.Text = lblDisplay.Text.Substring(1, lblDisplay.Text.Length - 1);
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text.Length>0 && lblDisplay.Text != "0")
            {
                char[] sigh = { btnPlus.Text.ToCharArray()[0], btnMinus.Text.ToCharArray()[0], btnDivide.Text.ToCharArray()[0], btnMultiply.Text.ToCharArray()[0], btnPercent.Text.ToCharArray()[0], btnEqual.Text.ToCharArray()[0]};
                if (lblDisplay.Text.Substring(lblDisplay.Text.Length - 1,1).LastIndexOfAny(sigh)>=0)
                {
                    ck_dot = true;
                }
                else if(lblDisplay.Text.Substring(lblDisplay.Text.Length - 1,1) == ".")
                {
                    ck_dot = false;
                }
                lblDisplay.Text =  lblDisplay.Text.Substring(0, lblDisplay.Text.Length-1);
                if (lblDisplay.Text.Length==0)
                {
                    lblDisplay.Text = 0 + "";
                }
            }

        }
       
        private void btnX_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text.Length < 8)
            {
                Button btn = (Button)sender;
                char[] sigh = { btnPlus.Text.ToCharArray()[0], btnMinus.Text.ToCharArray()[0], btnDivide.Text.ToCharArray()[0], btnMultiply.Text.ToCharArray()[0], btnPercent.Text.ToCharArray()[0], btnEqual.Text.ToCharArray()[0] };
                if (lblDisplay.Text == "MAX" || lblDisplay.Text == "∞" || lblDisplay.Text == "NaN" || lblDisplay.Text == "")
                {
                    lblDisplay.Text = "0";
                }

                if (lblDisplay.Text.LastIndexOfAny(sigh) == -1)
                {
                    String temp;
                    temp = lblDisplay.Text.Replace("n", "");
                    if (temp.Length == 1 && temp == "0")
                    {
                        lblDisplay.Text = btn.Text;
                    }
                    else if (temp.Length >= 1 && temp != "0")
                    {
                        lblDisplay.Text += btn.Text;
                    }
                }
                else if (lblDisplay.Text.LastIndexOfAny(sigh) >= 0)
                {
                    String temp;
                    temp = lblDisplay.Text.Substring(lblDisplay.Text.LastIndexOfAny(sigh) + 1, lblDisplay.Text.Length - lblDisplay.Text.LastIndexOfAny(sigh) - 1);
                    if (temp.Length <= 1 && (temp == "0" || temp == ""))
                    {
                        lblDisplay.Text = lblDisplay.Text.Substring(0, lblDisplay.Text.LastIndexOfAny(sigh) + 1) + btn.Text;
                    }
                    else if (temp.Length >= 1 && temp != "0")
                    {
                        lblDisplay.Text += btn.Text;
                    }
                }
            }
        }

        private void btnOpe_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text.Length < 9)
            {
                if (lblDisplay.Text == "MAX" || lblDisplay.Text == "∞" || lblDisplay.Text == "NaN" || lblDisplay.Text == "")
                {
                    lblDisplay.Text = "0";
                }
                ck_dot = false;
                Button btn = (Button)sender;
                string operat = lblDisplay.Text.Substring(lblDisplay.Text.Length - 1, 1);
                char[] sigh = { btnPlus.Text.ToCharArray()[0], btnMinus.Text.ToCharArray()[0], btnDivide.Text.ToCharArray()[0], btnMultiply.Text.ToCharArray()[0], btnPercent.Text.ToCharArray()[0], btnEqual.Text.ToCharArray()[0] };
                if (lblDisplay.Text.LastIndexOfAny(sigh) >= 1 && btn.Text.LastIndexOfAny(sigh) >= 0)
                {
                    string str_num1 = lblDisplay.Text.Substring(0, lblDisplay.Text.LastIndexOfAny(sigh));
                    string str_num2 = lblDisplay.Text.Substring(lblDisplay.Text.LastIndexOfAny(sigh) + 1, lblDisplay.Text.Length - lblDisplay.Text.LastIndexOfAny(sigh) - 1);
                    str_num1 = str_num1.Replace("n", "-");
                    str_num2 = str_num2.Replace("n", "-");
                    if (str_num2 == "") { str_num2 += "0"; }
                    float num1 = float.Parse(str_num1);
                    float num2 = float.Parse(str_num2);
                    float result = 0;
                    string operat_2 = lblDisplay.Text.Substring(lblDisplay.Text.LastIndexOfAny(sigh), 1);
                    if (operat_2 == btnPlus.Text) { result = num1 + num2; }
                    else if (operat_2 == btnMinus.Text) { result = num1 - num2; }
                    else if (operat_2 == btnDivide.Text) { result = num1 / num2; }
                    else if (operat_2 == btnMultiply.Text) { result = num1 * num2; }
                    else if (operat_2 == btnPercent.Text) { result = num1 % num2; }
                    //MessageBox.Show(num1 +" "+ operat_2 +" "+ num2+" = "+result);
                    if (String.Format("{0:0.#}", result).Length <= 8)
                    {
                        String temp = String.Format("{0:0.#}", result);
                        temp += btn.Text;
                        lblDisplay.Text = temp.Replace("=", "");
                    }
                    else if (String.Format("{0:0.#}", result).Length > 8)
                    {
                        lblDisplay.Text = "MAX";
                    }
                }
                else if (operat == btnPlus.Text || operat == btnMinus.Text || operat == btnDivide.Text || operat == btnMultiply.Text || operat == btnPercent.Text)
                {
                    lblDisplay.Text = lblDisplay.Text.Substring(0, lblDisplay.Text.Length - 1) + btn.Text;
                }
                else
                {
                    if (btn.Text != btnEqual.Text)
                    {
                        lblDisplay.Text += btn.Text;
                    }
                }
            }
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            char[] sigh = { btnPlus.Text.ToCharArray()[0], btnMinus.Text.ToCharArray()[0], btnDivide.Text.ToCharArray()[0], btnMultiply.Text.ToCharArray()[0], btnPercent.Text.ToCharArray()[0], btnEqual.Text.ToCharArray()[0],'.' };
            if (ck_dot==false && lblDisplay.Text.Substring(lblDisplay.Text.Length-1,1).IndexOfAny(sigh)!=0)
            {
                lblDisplay.Text += ".";
                ck_dot = true;
            }
        }
    }
}
