using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bienvenue
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals(""))
            label1.Text="Bonjour "+textBox1.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.Text = textBox1.Text;
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.ForestGreen;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form regles = new Form();
            regles.Show();

            Form2 mafenetrefushia = new Form2();
            mafenetrefushia.ShowDialog();
        }
    }
}
