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
    public partial class Score : Form
    {
        Jeu_Cavalier jeucavlier;
        public Score(Jeu_Cavalier  jc)
        {
            jeucavlier = jc;
            InitializeComponent();
            MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void Score_Load(object sender, EventArgs e)
        {
            label1.BackColor = Color.Transparent;
            
            if (jeucavlier.GetCompteur() == 0)
            {
                label1.Text = "Il faut jouer d'abord !";
                this.jeucavlier.ScoreButtonDesactiver();
            }

            else
            {
                this.jeucavlier.ScoreButtonActiver();
                label1.Text = "Votre score est " + jeucavlier.GetCompteur() + " !!!";
            }
        }
       
    }
}
