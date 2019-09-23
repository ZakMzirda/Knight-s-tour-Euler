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
    public partial class MiniFenetre : Form
    {
        Jeu_Cavalier jeuCavalier;
        public MiniFenetre(Jeu_Cavalier jc)
        {
            jeuCavalier = jc;
            InitializeComponent();
            MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void MiniFenetre_Load(object sender, EventArgs e)
        {
            label1.BackColor = Color.Transparent;
            Aleatoire_Button.Click += new EventHandler(Aleatoire_envent);
            Personnalise_Button.Click += new EventHandler(Personnalise_envent);
            
        }
        private void Aleatoire_envent(object sender, EventArgs e)
        {
            int ii, jj;
            Random random = new Random();
            ii = random.Next(1, 8);
            jj = random.Next(1, 8);
            jeuCavalier.Simulation(ii, jj, 300);
            //this.jeuCavalier.DesactiverSimulation();
            //this.jeuCavalier.ActiverButtonsIfmenuClosed();
            this.Close();
        }
        public void FermerM()
        {
            this.Close();
        }
        private void Personnalise_envent(object sender, EventArgs e)
        {
            //this.jeuCavalier.DesactiverSimulation();
            //this.jeuCavalier.ActiverButtonsIfmenuClosed();
            PersonnaliseFenetre pf = new PersonnaliseFenetre(jeuCavalier);
            pf.Show();
            FermerM();
        }

        private void MiniFenetre_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.jeuCavalier.ActiverButtonsIfmenuClosed();
            // this.jeuCavalier.ReActiverButtonsIfmenuClosed();
            this.jeuCavalier.Richemsg();
        }
    }
}
