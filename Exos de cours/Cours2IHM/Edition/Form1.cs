using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Edition
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Tester le résultat
            {
                string file = openFileDialog1.FileName;
                try
                {
                   textBox1.Text  = File.ReadAllText(file);
                   
                }
                catch (IOException)
                {
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog1.ShowDialog();

            if (result == DialogResult.OK) // Tester le résultat
            {
                string file = saveFileDialog1.FileName;
                try
                {
                    File.WriteAllText(file, textBox1.Text);

                }
                catch (IOException)
                {
                }
            }

        }
    }
}
