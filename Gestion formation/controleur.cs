using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_formation
{
    public static class controleur
    {
        static modele vmodele;

        public static void init(){
            vmodele = new modele();
        }

        internal static modele Vmodele
        {
            get { return controleur.vmodele; }
            set { controleur.vmodele = value; }
        }

        public static void crud_personne(Char c, String cle)
        {
            int index = 0;
            formCRUD formCRUD = new formCRUD();
            if (c== 'c')
            {
                formCRUD.TextBox1.Text = "";
                formCRUD.TextBox2.Text = "";
                formCRUD.TextBox3.Text = "";
            }
            if (c=='u' || c=='d')
            {
                string sortExpression = "IdPersonne";
                vmodele.Dv_personne.Sort = sortExpression;
                index = vmodele.Dv_personne.Find(cle);
                formCRUD.TextBox1.Text = vmodele.Dv_personne[index][1].ToString();
                formCRUD.TextBox2.Text = vmodele.Dv_personne[index][2].ToString();
                formCRUD.TextBox3.Text = vmodele.Dv_personne[index][3].ToString();
            }
            formCRUD.ShowDialog();
            if (formCRUD.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                if (c=='c')
                {
                    DataRowView newRow = vmodele.Dv_personne.AddNew();
                    newRow["IdPersonne"] = 15;
                    newRow["nom"] = formCRUD.TextBox1.Text;
                    newRow["prenom"] = formCRUD.TextBox2.Text;
                    newRow["IdFormation"] = formCRUD.TextBox3.Text;
                    newRow.EndEdit();
                }
                if (c=='u')
                {
                    vmodele.Dv_personne[index]["nom"] = formCRUD.TextBox1.Text;
                    vmodele.Dv_personne[index]["prenom"] = formCRUD.TextBox2.Text;
                    vmodele.Dv_personne[index]["IdFormation"] = formCRUD.TextBox3.Text;
                }
                if (c == 'd')
                {
                    vmodele.Dv_personne.Table.Rows[index].Delete();
                }
                MessageBox.Show("OK : données enregistrées");
                formCRUD.Dispose();
            }
            else
            {
                MessageBox.Show("Annulation : aucune donnée enregistrée");
                formCRUD.Dispose();
            }
        }
    }
}
