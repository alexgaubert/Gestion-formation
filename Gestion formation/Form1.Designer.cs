﻿namespace Gestion_formation
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.lienBDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionDesDonnéesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionDesPersonnesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionDesFormationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lienBDToolStripMenuItem,
            this.gestionDesDonnéesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(939, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // lienBDToolStripMenuItem
            // 
            this.lienBDToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.lienBDToolStripMenuItem.Name = "lienBDToolStripMenuItem";
            this.lienBDToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.lienBDToolStripMenuItem.Text = "Lien BD";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.importToolStripMenuItem.Text = "import";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exportToolStripMenuItem.Text = "export";
            // 
            // gestionDesDonnéesToolStripMenuItem
            // 
            this.gestionDesDonnéesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionDesPersonnesToolStripMenuItem,
            this.gestionDesFormationsToolStripMenuItem});
            this.gestionDesDonnéesToolStripMenuItem.Enabled = false;
            this.gestionDesDonnéesToolStripMenuItem.Name = "gestionDesDonnéesToolStripMenuItem";
            this.gestionDesDonnéesToolStripMenuItem.Size = new System.Drawing.Size(128, 20);
            this.gestionDesDonnéesToolStripMenuItem.Text = "Gestion des données";
            // 
            // gestionDesPersonnesToolStripMenuItem
            // 
            this.gestionDesPersonnesToolStripMenuItem.Name = "gestionDesPersonnesToolStripMenuItem";
            this.gestionDesPersonnesToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.gestionDesPersonnesToolStripMenuItem.Text = "gestion des personnes";
            this.gestionDesPersonnesToolStripMenuItem.Click += new System.EventHandler(this.gestionDesPersonnesToolStripMenuItem_Click);
            // 
            // gestionDesFormationsToolStripMenuItem
            // 
            this.gestionDesFormationsToolStripMenuItem.Name = "gestionDesFormationsToolStripMenuItem";
            this.gestionDesFormationsToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.gestionDesFormationsToolStripMenuItem.Text = "gestion des formations";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 552);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem lienBDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionDesDonnéesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionDesPersonnesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionDesFormationsToolStripMenuItem;
    }
}

