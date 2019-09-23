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

namespace Cavalier
{
    public partial class Jeu_Cavalier : Form
    {
        
        private Button[,] Echiquier;
        MiniFenetre mf;
        PictureBox pictureBox1;
        Boolean Jouer_Recommencer;
        Boolean ButtonClicked;
        Boolean IsStopped;

        private int compteur; 
        /***********variables pour l'algo d'euler**************/
        static int[,] echec = new int[12, 12];
        static int[] depi = new int[] { 2, 1, -1, -2, -2, -1, 1, 2 };
        static int[] depj = new int[] { 1, 2, 2, 1, -1, -2, -2, -1 };
        /******************************************************/

        public Jeu_Cavalier()
        {
            InitializeComponent();
            MaximizeBox = false;//desactiver plein ecran
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;

        }
        public int GetCompteur()
        {
            return this.compteur;
        }
       
        private void Jeu_Cavalier_Load(object sender, EventArgs e)
        {
            ButtonClicked = false;
            IsStopped = false;
            DessinerEchiquier();
            richTextBox1.ReadOnly = true;
            richTextBox1.BackColor = Color.PeachPuff;
            Richtext();
        }

        public void Richtext()
        {
            string str = "Simulation";
            string str2 = "Jouer";
            richTextBox1.Font = new Font("Showcard Gothic", 12);
            richTextBox1.Text = "Cliquez sur Simulation pour lancer le jeu automatiquement, " +
                "ou bien cliquez sur Jouer et essayer de gagnier! la regle est simple, le cavalier doit passer par toutes les cases une fois!";

            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;

            richTextBox1.Find(str);
            richTextBox1.SelectionColor = Color.Blue;
            richTextBox1.Find(str2);
            richTextBox1.SelectionColor = Color.Blue;
        }
        public void DessinerEchiquier()
        {
            Jouer_Recommencer = false;
            Echiquier = new Button[12, 12];
            compteur = 0;

            //assioation des boutons au clicks
            Simulation_Button.Click += new EventHandler(Simulation_event);
            Jouer_Button.Click += new EventHandler(Jouer_event);
            Reinitialiser_Button.Click += new EventHandler(Effacer_event);
            Arreter_Button.Click += new EventHandler(Arreter_event);
            Score_Button.Click += new EventHandler(Score_event);
            Quitter_Button.Click += new EventHandler(Quitter_event);


            pictureBox1 = new PictureBox();
            pictureBox1.Image = Image.FromFile(@"Image/Chess-Knight.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.Hide();
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Size = new Size(60, 60);



            Reinitialiser_Button.Enabled = false;
            Arreter_Button.Enabled = false;

            this.Controls.Add(pictureBox1);
            int ButtonSize = 60;
            int i, j;
            for (i = 2; i < 10; i++)
            {
                for (j = 2; j < 10; j++)
                {
                    Button b = new Button();
                    b.Location = new Point((i - 2) * ButtonSize, (j - 2) * ButtonSize);
                    b.Size = new Size(ButtonSize, ButtonSize);
                    b.UseVisualStyleBackColor = true;
                    b.Click += new EventHandler(Jouer);
                    b.Text = "";
                    b.Font = new Font("Lucida Console", 18F, FontStyle.Bold);

                    this.Controls.Add(b);

                    Echiquier[i, j] = b;

                    if (i % 2 == 0)
                    {
                        if (j % 2 == 0)
                            b.BackColor = Color.SaddleBrown;
                        else
                            b.BackColor = Color.NavajoWhite;
                    }
                    if (i % 2 != 0)
                    {
                        if (j % 2 != 0)
                            b.BackColor = Color.SaddleBrown;
                        else
                            b.BackColor = Color.NavajoWhite;
                    }

                }
            }

            DesactiverEchiquier();
        }

        public void InitialiserEchiquier()
        {
            int i, j;
            for (i = 2; i < 10; i++)
            {
                for (j = 2; j < 10; j++)
                {
                    if (i % 2 == 0)
                    {
                        if (j % 2 == 0)
                            Echiquier[i, j].BackColor = Color.SaddleBrown;
                        else
                            Echiquier[i, j].BackColor = Color.NavajoWhite;
                    }
                    if (i % 2 != 0)
                    {
                        if (j % 2 != 0)
                            Echiquier[i, j].BackColor = Color.SaddleBrown;
                        else
                            Echiquier[i, j].BackColor = Color.NavajoWhite;
                    }
                    Echiquier[i, j].Text = "";
                    Echiquier[i, j].FlatStyle = FlatStyle.Standard;
                    Echiquier[i, j].FlatAppearance.BorderSize = 3;
                    Echiquier[i, j].FlatAppearance.BorderColor = Color.Black;
                }
            }

        }
        public void ActiverEchiquier()
        {
            for (int i = 2; i < 10; i++)
            {
                for (int j = 2; j < 10; j++)
                    Echiquier[i, j].Enabled = true;
            }
        }

       
        public void Richemsg()
        {
            string str = "Simulation";
            string str2 = "Jouer";
            string str3 = "Reinitialiser";
            richTextBox1.Font = new Font("Showcard Gothic", 12);
            richTextBox1.Text = "Cliquez sur Reinitialiser pour pourvoir lancer une Simulation ou bien pour Jouer !";

            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;

            richTextBox1.Find(str);
            richTextBox1.SelectionColor = Color.Blue;
            richTextBox1.Find(str2);
            richTextBox1.SelectionColor = Color.Blue;
            richTextBox1.Find(str3);
            richTextBox1.SelectionColor = Color.Blue;

        }
        public async void Simulation(int ii, int jj, int vitesse)
        {
                DesactiverEchiquier();
                InitialiserEchiquier();

                /*--------------------------------------------------------------------*/
                /*            Définitions et déclarations                             */
                /*--------------------------------------------------------------------*/

                int nb_fuite, min_fuite, lmin_fuite = 0;
                int i, j, k, l;


                /*--------------------------------------------------------------------*/
                /*                          Initialisation                            */
                /*--------------------------------------------------------------------*/
                for (i = 0; i < 12; i++)
                    for (j = 0; j < 12; j++)
                        echec[i, j] = ((i < 2 | i > 9 | j < 2 | j > 9) ? -1 : 0);


                /*--------------------------------------------------------------------*/
                /*                Parcours du cavalier sur l'échiquier                */
                /*--------------------------------------------------------------------*/

                i = ii + 1; j = jj + 1;
                echec[i, j] = 1;
                Echiquier[i, j].Text = "1";
                Echiquier[i, j].BackColor = Color.Green;
                

                pictureBox1.Location = Echiquier[i, j].Location;
           
                for (k = 2; k <= 64; k++)
                {
                    for (l = 0, min_fuite = 11; l < 8; l++)
                    {
                        ii = i + depi[l]; jj = j + depj[l];

                        nb_fuite = ((echec[ii, jj] != 0) ? 10 : fuite(ii, jj));

                        if (nb_fuite < min_fuite)
                        {
                            min_fuite = nb_fuite; lmin_fuite = l;
                        }
                    }
                    if (min_fuite == 9 & k != 64)
                    {
                        MessageBox.Show("Impasse !");

                        break;
                    }
                    i += depi[lmin_fuite]; j += depj[lmin_fuite];
                    echec[i, j] = k;
                    await Task.Delay(vitesse);

                    //Addapter la couleur du cavalier
                    if (Echiquier[i, j].BackColor == Color.NavajoWhite)
                    {
                        pictureBox1.BackColor = Color.NavajoWhite;
                    }
                    else
                    {
                        pictureBox1.BackColor = Color.SaddleBrown;
                    }


                    Echiquier[i, j].Text = k.ToString();
                    Echiquier[i, j].FlatStyle = FlatStyle.Flat;
                    Echiquier[i, j].FlatAppearance.BorderColor = Color.Blue;
                    Echiquier[i, j].FlatAppearance.BorderSize = 5;
                    pictureBox1.Location = Echiquier[i, j].Location;
                    pictureBox1.Show();

                   
                    if (ButtonClicked == true)
                    {
                        InitialiserEchiquier();
                        compteur = 0;
                        DesactiverEchiquier();
                        Simulation_Button.Enabled = true;
                        Jouer_Button.Enabled = true;
                        pictureBox1.Hide();
                            break;
                    }
                    while (IsStopped == true)
                    {
                        await Task.Delay(1);
                    }
                }
                

           
        }
        

        private int fuite(int i, int j)
        {
            int n, l;

            for (l = 0, n = 8; l < 8; l++)
                if (echec[i + depi[l], j + depj[l]] != 0) n--;

            return (n == 0) ? 9 : n;
        }

        public void DesactiverEchiquier()
        {
            for (int i = 2; i < 10; i++)
            {
                for (int j = 2; j < 10; j++)
                    Echiquier[i, j].Enabled = false;
            }
        }

        /*public void DesactiverSimulation()
        {
            Simulation_Button.Enabled = false;
            Arreter_Button.Enabled = true;
        }*/
        
        

        private void Effacer_event(object sender, EventArgs e)
        {
            try
            {
                Richtext();
                InitialiserEchiquier();
                compteur = 0;
                pictureBox1.Hide();
                DesactiverEchiquier();
                
               
                Simulation_Button.Enabled = true;
                Jouer_Button.Enabled = true;
                Arreter_Button.Enabled = false;

                this.mf.FermerM();
                Richtext();
                ButtonClicked = true;
            }
            catch
            {
                Richtext();
            }
        }

        
        private void Simulation_event(object sender, EventArgs e)
        {
            ButtonClicked = false;
            Jouer_Button.Enabled = false;
            Reinitialiser_Button.Enabled = true;
            Arreter_Button.Enabled = true;
            Simulation_Button.Enabled = false;
            mf = new MiniFenetre(this);
            mf.Show();
        }

        
        private void Jouer_event(object sender, EventArgs e)
        {
            if (Jouer_Recommencer == false) {
                string str = "Jouer";
                string str2 = "Recommencer";
                Jouer_Recommencer = true;
                Jouer_Button.Text = "Recommencer";
                Simulation_Button.Enabled = false;
                Reinitialiser_Button.Enabled = false;
                ActiverEchiquier();
                richTextBox1.SelectionColor = Color.Black;
                richTextBox1.Text = "Cliquez sur une case pour Jouer ! ou cliquez sur Recommencer pour revenir en arrière";
                richTextBox1.SelectionAlignment = HorizontalAlignment.Center;

                richTextBox1.Find(str);
                richTextBox1.SelectionColor = Color.Blue;
                richTextBox1.Find(str2);
                richTextBox1.SelectionColor = Color.Blue;

            }
            else
            {
                Jouer_Recommencer = false;
                Jouer_Button.Text = "Jouer";
                InitialiserEchiquier();
                compteur = 0;
                pictureBox1.Hide();
                DesactiverEchiquier();
                Simulation_Button.Enabled = true;
                Reinitialiser_Button.Enabled = true;
                //richTextBox1.Text = "";
                Richtext();

            }
        }
        public void ScoreButtonDesactiver()
        {
            Score_Button.Enabled = false;
        }
        public void ScoreButtonActiver()
        {
            Score_Button.Enabled = true;
        }
        private void Arreter_event(object sender, EventArgs e)
        {
            if (IsStopped == false)
            {
                IsStopped = true;
                Arreter_Button.Text = "Continuer";
                Reinitialiser_Button.Enabled = false;
            }
            else
            {
                IsStopped = false;
                Arreter_Button.Text = "Arrêter";
                Reinitialiser_Button.Enabled = true;
            }
            
        }
        private void Score_event(object sender, EventArgs e)
        {
            Score s = new Score(this);
            s.Show();
        }

        private void Quitter_event(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void Jouer(object sender, EventArgs e)
        {
            int i, j, l;
            int fuite = 8;
            
            for (i = 2; i < 10; i++)
            {
                for (j = 2; j < 10; j++)
                {
                    if (i % 2 == 0)
                    {
                        if (j % 2 == 0)
                            Echiquier[i, j].BackColor = Color.SaddleBrown;
                        else
                            Echiquier[i, j].BackColor = Color.NavajoWhite;
                    }
                    if (i % 2 != 0)
                    {
                        if (j % 2 != 0)
                            Echiquier[i, j].BackColor = Color.SaddleBrown;
                        else
                            Echiquier[i, j].BackColor = Color.NavajoWhite;
                    }
                    Echiquier[i, j].FlatStyle = FlatStyle.Standard;
                    Echiquier[i, j].FlatAppearance.BorderSize = 3;
                    Echiquier[i, j].FlatAppearance.BorderColor = Color.Black;
                }
            }

            DesactiverEchiquier();
            pictureBox1.Location = ((Button)sender).Location;
            compteur++;
            ((Button)sender).Text = compteur.ToString();

            for (i = 2; i < 10; i++)
            {
                for (j = 2; j < 10; j++)
                {
                    if ((Button)sender == Echiquier[i, j])
                    {
                        this.pictureBox1.Location = Echiquier[i, j].Location;
                        pictureBox1.Show();

                        for (l = 0; l < 8; l++)
                        {
                            if (2 <= (i + depi[l]) && (i + depi[l]) < 10 && 2 <= (j + depj[l]) && (j + depj[l]) < 10)
                            {
                                if (Echiquier[i + depi[l], j + depj[l]].Text.Equals(""))
                                    Echiquier[i + depi[l], j + depj[l]].Enabled = true;

                                if (!Echiquier[i + depi[l], j + depj[l]].Enabled) fuite--;

                                Echiquier[i + depi[l], j + depj[l]].FlatStyle = FlatStyle.Flat;
                                Echiquier[i + depi[l], j + depj[l]].FlatAppearance.BorderSize = 5;
                                Echiquier[i + depi[l], j + depj[l]].FlatAppearance.BorderColor = Color.ForestGreen;
                              if(Echiquier[i + depi[l], j + depj[l]].Text.Equals("") == false)
                                {
                                    Echiquier[i + depi[l], j + depj[l]].FlatAppearance.BorderSize = 0;
                                }
                              if(Echiquier[i + depi[l], j + depj[l]].BackColor == Color.NavajoWhite)
                                {
                                    pictureBox1.BackColor = Color.SaddleBrown;
                                }
                              if(Echiquier[i + depi[l], j + depj[l]].BackColor == Color.SaddleBrown)
                                {
                                    pictureBox1.BackColor = Color.NavajoWhite;
                                }
                            }
                            else fuite--;
                            
                        }

                    }
                }
            }
            if (fuite == 0 && compteur != 64)
            {
               
                MessageBox.Show("Vous avez perdu ! Pour voir votre score cliquez sur Score!", "Coincé (-_-)");
                Score_Button.Enabled = true;
                
                string str = "Recommencer";
                string str2 = "Score";
                richTextBox1.SelectionColor = Color.Black;
                richTextBox1.Text = "Cliquez sur Score pour voir votre score ! ou cliquez sur Recommencer pour revenir en arrière";
                richTextBox1.SelectionAlignment = HorizontalAlignment.Center;

                richTextBox1.Find(str);
                richTextBox1.SelectionColor = Color.Blue;
                richTextBox1.Find(str2);
                richTextBox1.SelectionColor = Color.Blue;
            }
            if (compteur == 64)
            {
                
                MessageBox.Show("Parfaite! vous avez gagné", "Victoire (^_^)");
            }
        }

        private void Jeu_Cavalier_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Voulez-vous vraiment quitter ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        
    }
}