using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppCalc
{
    public partial class FormCalc : Form
    {
        private string strnb1, strnb2;
        private char sign;
        public FormCalc()
        {
            InitializeComponent();
            this.sign = '&';
        }

        private void buttonplus_Click(object sender, EventArgs e)
        {
            this.sign = '+';
        }

        private void buttonmoins_Click(object sender, EventArgs e)
        {
            this.sign = '-';
        }

        private void buttonfois_Click(object sender, EventArgs e)
        {
            this.sign = '*';
        }

        private void buttondiv_Click(object sender, EventArgs e)
        {
            this.sign = '/';
        }

        private void buttonegal_Click(object sender, EventArgs e)
        {
            double nb1, nb2;
            bool resultat1, resultat2;

            resultat1 = Double.TryParse(this.strnb1, out nb1);
            resultat2 = Double.TryParse(this.strnb2, out nb2);

            if ((resultat1 == false) || (resultat2 == false))
            {
                MessageBox.Show("Probleme !!!");
                return;
            }

            double res;
            
            if (this.sign == '+')
            {
                res = nb1 + nb2;
            }
            else if (this.sign == '-')
            {
                res = nb1 - nb2;
            }
            else if (this.sign == '*')
            {
                res = nb1 * nb2;
            }
            else if (this.sign == '/')
            {
                res = nb1 / nb2;
                if (nb2 == 0)
                    throw new OverflowException();
            }
            else if (this.sign == 'e')
            {
                res = Math.Pow(nb1, nb2);
            }
            else
            {
                MessageBox.Show("Opération inconnue", "Warning !",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string strres = res.ToString();

            textBoxResultat.Text = strres;
        }

        private void buttonCE_Click(object sender, EventArgs e)
        {
            this.sign = '&';
            this.strnb1 = this.strnb2 = "";
            textBoxResultat.Text = "";
        }

        private void buttonPow_Click(object sender, EventArgs e)
        {
            this.sign = 'e';
        }

        private void buttonSin_Click(object sender, EventArgs e)
        {
            double nb = Convert.ToDouble(textBoxResultat.Text);

            nb = Math.Sin(nb);

            textBoxResultat.Text = nb.ToString();
        }



        private void buttonChiffre_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
                       

            if (this.sign == '&')
            {
                strnb1 += b.Text;
                textBoxResultat.Text = strnb1;
            }
            else
            {
                strnb2 += b.Text;
                textBoxResultat.Text = strnb2;
            }
        }

    }
}
