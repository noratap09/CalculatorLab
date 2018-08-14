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
        string firstOperand;
        string secondOperand;
        string Operand;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = 0+"";
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if(Int32.Parse(lblDisplay.Text)>0)
            {
                lblDisplay.Text = "-" + lblDisplay.Text;
            }
            else if(Int32.Parse(lblDisplay.Text) < 0)
            {
                lblDisplay.Text = lblDisplay.Text.Substring(1,lblDisplay.Text.Length-1);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text.Length>0 && lblDisplay.Text != "0")
            {
               lblDisplay.Text =  lblDisplay.Text.Substring(0, lblDisplay.Text.Length-1);
                if(lblDisplay.Text.Length==0)
                {
                    lblDisplay.Text = 0 + "";
                }
            }
        }
       
        private void btnX_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (lblDisplay.Text == "0")
            {
                lblDisplay.Text = btn.Text + "";
            }
            else
            {
                lblDisplay.Text += btn.Text + "";
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (Operand == "")
            {
                Operand = "+";
            }
            else if(Operand == "+")
            {
                firstOperand = lblDisplay.Text.Substring(0, lblDisplay.Text.IndexOf("+"));
                secondOperand = lblDisplay.Text.Substring(lblDisplay.Text.IndexOf("+"),lblDisplay.Text.Length- lblDisplay.Text.IndexOf("+"));
                lblDisplay.Text = Int32.Parse(firstOperand) + Int32.Parse(secondOperand)+"";
            }
        }
    }
}
