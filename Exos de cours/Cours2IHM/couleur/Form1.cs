using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace couleur
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Afficher la boite de dialogue.
            DialogResult result = colorDialog1.ShowDialog();
            // Tester si l’utilisateur a cliqué sur OK.
            if (result == DialogResult.OK)
            {
                // Background du formulaire à la couleur sélectionnée.
                this.BackColor = colorDialog1.Color;
            }
        }
    }
}
