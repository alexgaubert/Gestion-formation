using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_formation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void gestionDesPersonnesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPersonne FP = new FormPersonne();
            FP.MdiParent = this;
            FP.Show();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            controleur.Vmodele.sedeconnecter();
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controleur.Vmodele.import();
        }
    }
}
