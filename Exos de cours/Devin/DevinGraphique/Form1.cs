using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevinGraphique
{
    public partial class Form1 : Form
    {
        private int cible;
        private int cpt;
        private const int MAX = 6;
        private Boolean gagne;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cible = (new System.Random()).Next(1, 100);
            cpt = MAX;
            gagne = false;
            label2.Text = MAX.ToString();
            //button2.Enabled = false;
            button2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals(""))
            {
                int c;
                if (Int32.TryParse(textBox1.Text, out c) == false)
                {
                    label1.Text = "Lis les règles !!!";
              
                }
                else
                {
                    cpt--;
                    if (c > cible)
                    {
                        label1.ForeColor = Color.Yellow;
                        label1.Text = "Trop Grand !!";
                    }
                    else if (c < cible)
                    {
                        label1.ForeColor = Color.Yellow;
                        label1.Text = "Trop Petit !!";
                    }
                    else
                    {
                        label1.ForeColor = Color.Green;
                        label1.Text = "Bravo !! C'est gagné !!";
                        gagne = true;
                    }
                    label2.Text = ((Int32)cpt).ToString();
                    if (cpt == 0 && !gagne)
                    {
                        label1.ForeColor = Color.Red;
                        label1.Text = "Dommage !! C'est perdu !!";
                        button2.Visible = true;
                    }
                    //else label2.Text = cpt.ToString();
                    
                }

            }
            textBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cible = (new System.Random()).Next(1, 100);
            cpt = MAX;
            gagne = false;
            label2.Text = MAX.ToString();
            label1.Text = "";
            textBox1.Text = "";
        }
    }
}
