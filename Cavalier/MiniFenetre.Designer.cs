namespace Cavalier
{
    partial class MiniFenetre
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MiniFenetre));
            this.Personnalise_Button = new System.Windows.Forms.Button();
            this.Aleatoire_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Personnalise_Button
            // 
            this.Personnalise_Button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Personnalise_Button.BackgroundImage")));
            this.Personnalise_Button.Font = new System.Drawing.Font("Showcard Gothic", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Personnalise_Button.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Personnalise_Button.Location = new System.Drawing.Point(65, 101);
            this.Personnalise_Button.Name = "Personnalise_Button";
            this.Personnalise_Button.Size = new System.Drawing.Size(125, 42);
            this.Personnalise_Button.TabIndex = 1;
            this.Personnalise_Button.Text = "Personnalisé";
            this.Personnalise_Button.UseVisualStyleBackColor = true;
            // 
            // Aleatoire_Button
            // 
            this.Aleatoire_Button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Aleatoire_Button.BackgroundImage")));
            this.Aleatoire_Button.Font = new System.Drawing.Font("Showcard Gothic", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Aleatoire_Button.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Aleatoire_Button.Location = new System.Drawing.Point(65, 53);
            this.Aleatoire_Button.Name = "Aleatoire_Button";
            this.Aleatoire_Button.Size = new System.Drawing.Size(125, 42);
            this.Aleatoire_Button.TabIndex = 2;
            this.Aleatoire_Button.Text = "Aléatoire";
            this.Aleatoire_Button.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(49, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Choisissez un mode";
            // 
            // MiniFenetre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(251, 164);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Aleatoire_Button);
            this.Controls.Add(this.Personnalise_Button);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MiniFenetre";
            this.Text = "Choix";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MiniFenetre_FormClosing);
            this.Load += new System.EventHandler(this.MiniFenetre_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Personnalise_Button;
        private System.Windows.Forms.Button Aleatoire_Button;
        private System.Windows.Forms.Label label1;
    }
}