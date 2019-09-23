using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cavalier
{
    public partial class PersonnaliseFenetre : Form
    {
        Jeu_Cavalier jeuCavalier;
        public PersonnaliseFenetre(Jeu_Cavalier jc)
        {
            jeuCavalier = jc;
            InitializeComponent();
            MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void PersonnaliseFenetre_Load(object sender, EventArgs e)
        {
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            label5.BackColor = Color.Transparent;
            label5.Text = "500 ms";
            Valider_Button.Click += new EventHandler(Valider_envent);
            Annuler_Button.Click += new EventHandler(Annuler_envent);
        }

        private void Valider_envent(object sender, EventArgs e)
        {
            int x, y,  vitesse;
            if (textBox1.Text.Equals("") || textBox2.Text.Equals(""))
            {
                MessageBox.Show("Vous avez oublié de remplir un ou plusieurs champs (-_-)");

            }
            else
            {
                y = Int32.Parse(textBox1.Text);
                x = Int32.Parse(textBox2.Text);
                vitesse = trackBar1.Value;
                if (x > 8 || x < 0 || y > 8 || y < 0)
                {
                    MessageBox.Show("Veuillez entrer des coordonnées comprises entre 1 et 8 !");
                }

                else
                {
                    jeuCavalier.Simulation(x, y, vitesse);
                    this.Close();
                }
            }
        }

        public void FermerP()
        {
            this.Close();
        }
        private void Annuler_envent(object sender, EventArgs e)
        {
            //this.jeuCavalier.ActiverButtonsIfmenuClosed();
            FermerP();
        }
       

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label5.Text = trackBar1.Value.ToString()+" ms";
        }
    }
}
