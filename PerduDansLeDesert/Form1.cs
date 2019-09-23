using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PerduDansLeDesert
{
    public partial class Form1 : Form
    {
        private delegate String Direction();
        private Direction ToutDroit;
        private Direction RevenirEnArriere;
        //private PictureBox[,] picb;
        //private int xx = 509;
        //private int yy = 163;
        public Form1()
        {
            InitializeComponent();
            Image image = new Bitmap(@"images/desert-1270345_960_720.jpg");
            this.BackgroundImage = image;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Tableau de picturbox
            /*PictureBox p = null;
            picb = new PictureBox[6, 5];
            for (int i=1; i<6;i++)
            {
                for (int j = 1; j < 5; j++)
                {

                    p = new PictureBox();
                    if (p is PictureBox)
                    { 
                        p.Location = new Point(x * i, y * j);
                        p.Margin = new Padding(0);
                        p.Size = new Size(120, 70);
                        p.SizeMode= PictureBoxSizeMode.Zoom;
                        p.BackColor = Color.Transparent;
                        p.Image = Image.FromFile(@"images/desert-1270345_960_720.jpg");
                        
                        this.Controls.Add(p);
                       
                        picb[i, j] = p;
                    } 
                }
               
            }

            p.Image = Image.FromFile(@"images/giphy.gif");
            p.BackColor = Color.Transparent;
            this.Controls.Add(p);
            picb[4, 2] = p;
          

            this.Controls.Add(p);*/
            //x(86-640)
            //y(12-82)
            Random rnd = new Random();
            int xx = rnd.Next(86, 640);
            int yy = rnd.Next(12, 82);

            pictureBox1.Location = new Point(xx, yy);
            textBox1.ReadOnly=true;
            updateButtonToutDroit();
            updateButtonRevenirEnArriere();
            textBox1.Text = "Quelle direction vous choisissez ?\r\n";

        }

        private void updateButtonToutDroit()//Pour gerer l'exception sur le button5
        {
            if (ToutDroit == null) { button5.Enabled = false; }
            else button5.Enabled = true;
        }
        private void updateButtonRevenirEnArriere()//Pour gerer l'exception sur le button6
        {
            if (RevenirEnArriere == null) { button6.Enabled = false; }
            else button6.Enabled = true;
        }

        private String Nord()
        {
            pictureBox1.Image = Image.FromFile(@"images/sad-151795_960_720.png");
            this.pictureBox1.Top = this.pictureBox1.Top - 10;
            return "\nVers le Nord...\r\n";

        }

        private String Ouest()
        {
            pictureBox1.Image = Image.FromFile(@"images/sad-151795_960_720.png");
            this.pictureBox1.Left = this.pictureBox1.Left - 10;
            return "Vers l'Ouest...\r\n";

        }
        private String Sud()
        {
            pictureBox1.Image = Image.FromFile(@"images/sad-151795_960_720.png");
            this.pictureBox1.Top = this.pictureBox1.Top + 10;
            return "Vers le Sud...\r\n";

        }
        private String Est()
        {
            pictureBox1.Image = Image.FromFile(@"images/sad-151795_960_720.png");
            this.pictureBox1.Left = this.pictureBox1.Left + 10;
            return "Vers l'Est...\r\n";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += Nord();
            Nord();
            ToutDroit = new Direction(Nord);
            updateButtonToutDroit();
            RevenirEnArriere += new Direction(Sud);
            updateButtonRevenirEnArriere();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += Ouest();
            Ouest();
            ToutDroit = new Direction(Ouest);
            updateButtonToutDroit();
            RevenirEnArriere += new Direction(Est);
            updateButtonRevenirEnArriere();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text += Sud();
            Sud();
            ToutDroit = new Direction(Sud);
            updateButtonToutDroit();
            RevenirEnArriere += new Direction(Nord);
            updateButtonRevenirEnArriere();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += Est();
            Est();
            ToutDroit = new Direction(Est);
            updateButtonToutDroit();
            RevenirEnArriere += new Direction(Ouest);
            updateButtonRevenirEnArriere();
        }

       

        private void button5_Click(object sender, EventArgs e)//Tout droit
        {

            textBox1.Text += ToutDroit();
            ToutDroit();
            updateButtonToutDroit();
            Delegate[] DelegTab = RevenirEnArriere.GetInvocationList();
            RevenirEnArriere += (Direction)DelegTab[DelegTab.Length - 1];
            updateButtonRevenirEnArriere();

        }

        private void button6_Click(object sender, EventArgs e)//En arrière
        {
            Delegate[] TabRevenir = RevenirEnArriere.GetInvocationList();
            Direction revenir = (Direction)TabRevenir[TabRevenir.Length - 1];
            textBox1.Text += "Déjà perdu ?Tu es nul!\r\n";
            textBox1.Text += revenir();
            
            for (int i = TabRevenir.Length - 2; i >= 0; i--)
             {
                revenir = (Direction)TabRevenir[i];
                revenir.Invoke();
                textBox1.Text += revenir();
                //System.Threading.Thread.Sleep(500);
                //this.Invalidate();
            }
            revenir();
            pictureBox1.Size = new Size(66, 193);
            pictureBox1.Image = Image.FromFile(@"images/happy-151793_960_720.png");
            RevenirEnArriere = null;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Text = "Quelle direction vous choisissez ?\r\n";
        }

        /***************************************/

        private void pictureBox1_Click_2(object sender, EventArgs e)
        {
            //pictureBox1.Location = new Point(xx, yy);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}