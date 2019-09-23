using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Morpion
{
    public partial class Form1 : Form
    {
        private Button[,] grille;
        private String joueur;
        int cpt;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            grille = new Button[3, 3];
            grille[0, 0] = button1;
            grille[0, 1] = button2;
            grille[0, 2] = button3;
            grille[1, 0] = button4;
            grille[1, 1] = button5;
            grille[1, 2] = button6;
            grille[2, 0] = button7;
            grille[2, 1] = button8;
            grille[2, 2] = button9;

            joueur = "X";
            cpt = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button b = null;
            if (sender is Button)
            {
                b = sender as Button;
            }

            b.Text = joueur;
            b.Enabled = false;
            cpt++;

            if (analyseGrille() == true) // Ya un gagnant
            {
                this.Text = "Le joueur " + joueur + " a gagné !";
                raz();
            }
            else
            {
                if (cpt == 9)
                {
                    this.Text = "Match nul";
                    raz();
                }
            }
 
            if (joueur.Equals("X")) joueur = "O";
            else joueur = "X";
        }

        private void coordBouton(Button b, out int x, out int y)
        {
            x = -1; y = -1;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    if (grille[i, j] == b)
                    {
                        x = i;
                        y = j;
                    }
                }
        }

        private Boolean analyseGrille()
        {
            String chaine = "";
            // Ligne 0
            for (int col = 0; col < 3; col++) chaine = chaine + grille[0, col].Text;
            if (chaine.Equals("XXX") || chaine.Equals("OOO")) return true;
            // Ligne 1
            chaine = "";
            for (int col = 0; col < 3; col++) chaine = chaine + grille[1, col].Text;
            if (chaine.Equals("XXX") || chaine.Equals("OOO")) return true;
            // Ligne 2
            chaine = "";
            for (int col = 0; col < 3; col++) chaine = chaine + grille[2, col].Text;
            if (chaine.Equals("XXX") || chaine.Equals("OOO")) return true;
            // Colonne 0
            chaine = "";
            for (int lig = 0; lig < 3; lig++) chaine = chaine + grille[lig, 0].Text;
            if (chaine.Equals("XXX") || chaine.Equals("OOO")) return true;
            // Colonne 1
            chaine = "";
            for (int lig = 0; lig < 3; lig++) chaine = chaine + grille[lig, 1].Text;
            if (chaine.Equals("XXX") || chaine.Equals("OOO")) return true;
            // Colonne 2
            chaine = "";
            for (int lig = 0; lig < 3; lig++) chaine = chaine + grille[lig, 2].Text;
            if (chaine.Equals("XXX") || chaine.Equals("OOO")) return true;
            // Diagonale 1
            chaine = "";
            for (int lig = 0; lig < 3; lig++) chaine = chaine + grille[lig, lig].Text;
            if (chaine.Equals("XXX") || chaine.Equals("OOO")) return true;
            // Diagonale 2
            chaine = "";
            for (int lig = 0; lig < 3; lig++) chaine = chaine + grille[2 - lig, lig].Text;
            if (chaine.Equals("XXX") || chaine.Equals("OOO")) return true;

            return false;

        }
        void raz ()
        {
            cpt = 0;
            joueur = "X";
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    grille[i, j].Text = "";
                    grille[i, j].Enabled = true;
                }
        }
    }
}
