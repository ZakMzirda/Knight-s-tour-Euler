using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Feux
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"images/noir200x200.png");
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            this.Text = (trackBar1.Value).ToString();
            if (trackBar1.Value >=1 && trackBar1.Value<5) pictureBox1.Image = Image.FromFile(@"images/vert200x200.png");
            if (trackBar1.Value >= 5 && trackBar1.Value < 7) pictureBox1.Image = Image.FromFile(@"images/orange200x200.png");
            if (trackBar1.Value >= 7 && trackBar1.Value <= 10) pictureBox1.Image = Image.FromFile(@"images/rouge200x200.png");
        }
    }
}
